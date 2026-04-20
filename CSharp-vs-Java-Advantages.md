
## 1. Delegates

### Simplified Code
```csharp
// C# Delegate: Direct method passing (clean & short)
delegate void Greet(string name);
static void SayHi(string n) => Console.WriteLine($"Hi {n}!");

void Main() {
  Greet greet = SayHi;
  greet("Alice"); // Output: Hi Alice!
}
```

```java
// Java: Must use interface + anonymous class (verbose)
interface Greet { void sayHi(String name); }

public static void main(String[] args) {
  Greet g = new Greet() {
    public void sayHi(String n) {
      System.out.println("Hi " + n + "!");
    }
  };
  g.sayHi("Alice"); // Output: Hi Alice!
}
```

---

## 2. True Generics
### Simplified Code
```csharp
// C# True Generics: Full type safety, no casting
List<int> nums = new List<int>();
nums.Add(10);
int val = nums[0]; // No cast, compile-time type check
// nums.Add("text"); // COMPILE ERROR (safe)
```

```java
// Java Erased Generics: Requires casting, unsafe at runtime
List<Integer> nums = new ArrayList<>();
nums.add(10);
int val = (Integer) nums.get(0); // Mandatory casting

List raw = nums;
raw.add("text"); // COMPILES OK, crashes at runtime (unsafe)
```

---

## 3. LINQ Integration
### Simplified Code
```csharp
// C# LINQ: One-line data processing (readable)
var nums = new List<int> {1,2,3,4,5,6};
var res = nums.Where(n=>n%2==0).Select(n=>n*2).OrderDescending();
// Result: 12, 8, 4
```

```java
// Java: Manual loop + logic (long & messy)
List<Integer> nums = Arrays.asList(1,2,3,4,5,6);
List<Integer> res = new ArrayList<>();

for(int n : nums) {
  if(n%2==0) res.add(n*2);
}
Collections.sort(res, Collections.reverseOrder());
// Result: 12, 8, 4
