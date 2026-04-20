using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:5249", "http://127.0.0.1:5249")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();
app.UseCors("FrontendDev");

var categories = new List<Dictionary<string, object?>>
{
    new() { ["id"] = 1, ["name"] = "General" },
    new() { ["id"] = 2, ["name"] = "C#" },
    new() { ["id"] = 3, ["name"] = "API" }
};
var articles = new List<Dictionary<string, object?>>
{
    new()
    {
        ["id"] = 1,
        ["title"] = "Welcome",
        ["content"] = "<p>This is the first demo article.</p>",
        ["categoryId"] = 1,
        ["thumb"] = "/article_thumb/screenshot1.png",
        ["visibility"] = "public",
        ["authorUsername"] = "system",
        ["createdAt"] = DateTime.UtcNow.AddMinutes(-30)
    }
};

var nextArticleId = 2;

app.MapGet("/health", () => Results.Ok(new { message = "C# API demo is running." }));

var api = app.MapGroup("/api");

api.MapGet("/categories", () =>
{
    return Results.Ok(new { categories });
});

api.MapGet("/articles", () =>
{
    var ordered = articles
        .OrderByDescending(a => a.TryGetValue("createdAt", out var createdAtObj) && createdAtObj is DateTime createdAt
            ? createdAt
            : DateTime.MinValue);

    return Results.Ok(new { articles = ordered });
});

api.MapPost("/articles", (JsonElement req) =>
{
    var title = req.TryGetProperty("title", out var titleProp) ? titleProp.GetString()?.Trim() : null;
    var content = req.TryGetProperty("content", out var contentProp) ? contentProp.GetString()?.Trim() : null;

    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
    {
        return Results.BadRequest(new { error = "title and content are required" });
    }

    var categoryId = req.TryGetProperty("categoryId", out var categoryIdProp) && categoryIdProp.TryGetInt32(out var parsedCategoryId)
        ? parsedCategoryId
        : 1;
    var thumb = req.TryGetProperty("thumb", out var thumbProp) ? thumbProp.GetString()?.Trim() : null;
    var visibility = req.TryGetProperty("visibility", out var visibilityProp) ? visibilityProp.GetString()?.Trim().ToLowerInvariant() : null;

    var article = new Dictionary<string, object?>
    {
        ["id"] = nextArticleId++,
        ["title"] = title,
        ["content"] = content,
        ["categoryId"] = categoryId <= 0 ? 1 : categoryId,
        ["thumb"] = string.IsNullOrWhiteSpace(thumb) ? "/article_thumb/screenshot1.png" : thumb,
        ["visibility"] = string.IsNullOrWhiteSpace(visibility) ? "public" : visibility,
        ["authorUsername"] = "demo",
        ["createdAt"] = DateTime.UtcNow
    };

    articles.Add(article);
    return Results.Ok(new { article });
});

api.MapPatch("/articles/{id:int}", (int id, JsonElement req) =>
{
    var index = articles.FindIndex(a =>
        a.TryGetValue("id", out var articleIdObj) &&
        articleIdObj is int articleId &&
        articleId == id
    );
    if (index < 0)
    {
        return Results.NotFound(new { error = "article not found" });
    }

    var current = articles[index];
    var newVisibility = req.TryGetProperty("visibility", out var visibilityProp)
        ? visibilityProp.GetString()?.Trim().ToLowerInvariant()
        : null;

    current["visibility"] = string.IsNullOrWhiteSpace(newVisibility)
        ? current["visibility"]
        : newVisibility;

    return Results.Ok(new { article = current });
});

api.MapDelete("/articles/{id:int}", (int id) =>
{
    var removed = articles.RemoveAll(a =>
    {
        return a.TryGetValue("id", out var articleIdObj) &&
               articleIdObj is int articleId &&
               articleId == id;
    });
    if (removed == 0)
    {
        return Results.NotFound(new { error = "article not found" });
    }

    return Results.Ok(new { ok = true, id });
});

app.Run();
