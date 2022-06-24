## Getting Started

- Install the package

```bash
dotnet add package AspNetCore.Form --version 1.0.0
```

- Add assembly entries to the service

```csharp
// startup.cs
...
service.AddFormEndpoint(assembly list)
...
```

- Use the service

```csharp
// startup.cs
...
app.useRouting(); //should be called only once and before
...
app.useFormEndpoint();
...
```

- Add attributes to any class or property to generate an schemas
