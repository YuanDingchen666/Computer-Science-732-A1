# C# API Console Demo

**COMPSCI 732 — Frontend Frameworks ( Assignment 1)**  
**University of Auckland · 2026**

A full-stack demo project showing how a frontend framework (Blazor WebAssembly) can interact with a lightweight backend (ASP.NET Core Minimal API) through clean REST endpoints.

**Keywords:** `Blazor WASM` `Minimal API` `C#` `.NET 10` `REST` `CORS`

---

## 📋 Assignment Context

This project is designed as a practical demonstration of:

- frontend application structure
- API integration workflow
- request/response handling
- routing entry and component organization
- framework usage in a real mini full-stack setup

It is intentionally simplified for presentation and teaching, while still covering real API operations (`GET / POST / PATCH / DELETE`).

---

## 🧩 Project Summary

### What this app does

The app provides an API console UI where users can:

1. fetch categories and articles
2. create a new article
3. update article visibility
4. delete an article by ID

### Why this project is useful for demo

- clear separation between frontend and backend
- concise codebase with minimal setup
- complete CRUD-like interaction loop
- easy to explain in a 4-5 minute presentation

---

## 🛠️ Tech Stack

| Layer | Technology | Version | Purpose |
|---|---|---|---|
| Frontend | Blazor WebAssembly | .NET 10 | SPA UI and API interaction |
| Backend | ASP.NET Core Minimal API | .NET 10 | REST endpoints |
| Language | C# | 13 (via .NET 10) | Full-stack implementation |
| Transport | HTTP + JSON | - | API communication |
| Data | In-memory collections | - | Demo data storage (no DB) |

---

## 📁 Project Structure

```text
732 Assignment 1/
├── backend/
│   ├── Program.cs                 # Minimal API endpoints, CORS, in-memory data
│   └── C#.csproj                  # ASP.NET Core Web SDK project file
├── frontend/
│   ├── Pages/
│   │   └── Home.razor             # API console page (GET/POST/PATCH/DELETE)
│   ├── Layout/
│   │   ├── MainLayout.razor       # Main layout wrapper
│   │   └── NavMenu.razor          # Navigation menu
│   ├── Program.cs                 # Blazor WASM startup config
│   ├── _Imports.razor             # Razor shared imports
│   ├── frontend.csproj
│   └── Properties/
│       └── launchSettings.json    # Frontend local dev port config
├── CSharp-vs-Java-Advantages.md   # Additional course notes
└── README.md
```

---

## ✅ Prerequisites

Install:

- .NET 10 SDK

Check:

```bash
dotnet --version
```

If your machine has multiple SDK versions, ensure .NET 10 is available.

---

## 🚀 Quick Start (Run the App)

This project runs with **two servers**:

- Backend API: `http://localhost:5000`
- Frontend UI: `http://localhost:5249`

Open **two terminals** from the project root.

### Terminal 1 — Start backend

```bash
cd backend
dotnet run --urls http://localhost:5000
```

Expected output includes:

```text
Now listening on: http://localhost:5000
```

### Terminal 2 — Start frontend

```bash
cd frontend
dotnet run --launch-profile http
```

Expected output includes:

```text
Now listening on: http://localhost:5249
```

### Open in browser

- Frontend: `http://localhost:5249`
- Backend health check: `http://localhost:5000/health`

In `Home.razor`, keep API Base URL as:

```text
http://localhost:5000/api
```

---

## 🌐 Frontend Pages

| Page | Route | Description |
|---|---|---|
| Home | `/` | API console UI for testing backend endpoints |

> Current project scope uses a single focused page for faster demonstration.

---

## 📡 API Endpoints

API Base URL: `http://localhost:5000/api`  
Service Health URL: `http://localhost:5000/health` (outside `/api`)

| Method | Endpoint | Description |
|---|---|---|
| GET | `/health` | Service health check (outside `/api`) |
| GET | `/api/categories` | List categories |
| GET | `/api/articles` | List articles (newest first) |
| POST | `/api/articles` | Create article |
| PATCH | `/api/articles/{id}` | Update article visibility |
| DELETE | `/api/articles/{id}` | Delete article |

### 1) Health Check

**Request**

```http
GET /health
```

**Response**

```json
{
  "message": "C# API demo is running."
}
```

### 2) Get Categories

**Request**

```http
GET /api/categories
```

**Sample Response**

```json
{
  "categories": [
    { "id": 1, "name": "General" },
    { "id": 2, "name": "C#" },
    { "id": 3, "name": "API" }
  ]
}
```

### 3) Get Articles

**Request**

```http
GET /api/articles
```

### 4) Create Article

**Request**

```http
POST /api/articles
Content-Type: application/json
```

```json
{
  "title": "Demo Article",
  "content": "<p>Created from Blazor demo.</p>",
  "categoryId": 1,
  "thumb": "/article_thumb/screenshot1.png",
  "visibility": "public"
}
```

### 5) Update Visibility

**Request**

```http
PATCH /api/articles/1
Content-Type: application/json
```

```json
{
  "visibility": "private"
}
```

### 6) Delete Article

**Request**

```http
DELETE /api/articles/1
```

---

## 🧪 Recommended Demo Script (Presentation Flow)

Use this sequence during your midterm demonstration:

1. Open frontend `http://localhost:5249`
2. Confirm API Base URL is `http://localhost:5000/api`
3. Click `GET /categories`
4. Click `GET /articles`
5. Enter title/content and click `POST /articles`
6. Set a valid ID and click `PATCH /articles/:id`
7. Click `DELETE /articles/:id`
8. Highlight response panel showing success/error handling

This provides a complete story: **read -> create -> update -> delete**.

---

## ✅ Marking Criteria Mapping (COMPSCI 732)

This section maps the current implementation to common assignment expectations.

| Assignment Focus | Evidence in This Project |
|---|---|
| Application structure | Clear separation into `backend/` and `frontend/`, with focused entry files (`backend/Program.cs`, `frontend/Pages/Home.razor`) |
| Tool support and setup | Uses standard .NET CLI flow (`dotnet run`, `dotnet build`), plus launch profile for frontend port management |
| State management | Frontend component state in `Home.razor` (`ApiBaseUrl`, `Title`, `Content`, `TargetId`, `Busy`, `ResponseText`) |
| Routing | Frontend route declared with `@page "/"`; backend routes grouped under `/api` with `MapGroup("/api")` |
| API integration | Unified request pipeline in frontend (`RunApiAsync`, `SendAsync`) connected to backend REST endpoints |
| Error handling | Backend returns `400` and `404`; frontend surfaces response failures in the response panel |
| Framework demonstration | Shows practical Blazor WASM usage and contrasts well with React-style API-console patterns in presentation |

---

## 🧠 Code Highlights

### Backend (`backend/Program.cs`)

- CORS policy allows frontend origin (`5249`)
- route group `/api` keeps endpoints organized
- data stored in memory via `List<Dictionary<string, object?>>`
- explicit status handling for `400` and `404`

### Frontend (`frontend/Pages/Home.razor`)

- minimal UI focused on API testing
- unified request wrapper `RunApiAsync(...)`
- shared HTTP sender `SendAsync(...)`
- readable output with `PrettyJson(...)`
- loading state via `Busy` to prevent repeated clicks

---

## ⚠️ Limitations

This is a teaching/demo project, so:

- no persistent database
- no authentication/authorization
- limited input validation
- no production logging/monitoring pipeline

After backend restart, all runtime-created articles are reset.

---

## 🔧 Troubleshooting

| Problem | Solution |
|---|---|
| Frontend cannot reach API | Ensure backend is running on `http://localhost:5000` |
| CORS error in browser console | Ensure backend CORS includes `http://localhost:5249` |
| `PATCH`/`DELETE` returns 404 | Run `GET /api/articles` and use an existing `id` |
| Port 5000 already in use | Stop process on 5000, then restart backend |
| Port 5249 already in use | Stop process on 5249, then restart frontend |
| Data disappeared after restart | Expected: backend uses in-memory data |

---

## 🔄 Reset Steps

If you want to reset to initial demo state:

1. Stop backend and frontend (`Ctrl + C`)
2. Restart backend first
3. Restart frontend

Because data is in memory, restarting backend automatically restores seed state in code.

---

## 📚 Suggested Future Improvements

- add SQLite/PostgreSQL persistence
- add DTO/model classes and validation layer
- add auth and role-based access control
- add automated tests (unit + integration)
- add CI workflow

---

## 📄 License / Academic Use

This project is prepared for educational use in COMPSCI 732 (University of Auckland).  
Please follow your course's academic integrity rules when reusing or modifying this repository.


