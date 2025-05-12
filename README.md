```markdown
# Startup Ideas Tracker (C# Console App)

## 📌 Overview
A simple yet powerful console application for tracking and managing startup ideas with:
- **CRUD operations** (Create, Read, Update, Delete)
- **Persistent JSON storage**
- **Search and filtering**
- **Clean tabular display**

## 🛠️ Features
| Feature | Description |
|---------|-------------|
| **Add Ideas** | Capture name, problem, solution, status |
| **View List** | Tabular display with truncation for long text |
| **Search** | Case-insensitive search across all fields |
| **Edit/Delete** | Modify existing entries |
| **Auto-Save** | Persists to `ideas.json` on exit |

## ⚙️ Technical Details
```plaintext
├── Models/
│   └── StartupIdea.cs      # Data structure
├── Services/
│   └── IdeaService.cs      # Business logic
├── Program.cs              # Main application
└── ideas.json              # Data storage (auto-created)
```

## 🚀 Getting Started
1. **Prerequisites**
   - [.NET 6+ SDK](https://dotnet.microsoft.com/download)

2. **Run the App**
   ```bash
   dotnet run
   ```

3. **Build for Release**
   ```bash
   dotnet publish -c Release
   ```

## 🎨 UI Features
```csharp
// Dynamic width separator
Console.WriteLine(new string('=', idea.Name.Length + 4)); 

// Formatted table output
Console.WriteLine($"{idea.Id,-5} {Truncate(name,20),-20} {status,-15}");
```

## 📦 Dependencies
- `System.Text.Json` - Built-in JSON serialization
- *(Optional)* `Spectre.Console` - For enhanced UI (future upgrade)

## 🔧 Customization
Edit `Program.cs` to:
- Change field widths (`-20` in format strings)
- Add new status types in `GetValidStatus()`
- Modify truncation length (`Truncate(idea.Name, 18)`)

## 📜 License
MIT - Free for personal and commercial use

```

