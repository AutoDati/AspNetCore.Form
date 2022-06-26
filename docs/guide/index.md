## Getting Started

- Install the package

```bash
dotnet add package AspNetCore.Form --version <last version>
```

- Add assembly entries to the service

```csharp
// startup.cs
...
service.AddFormEndpoint(typeof(class in assembly), typeof(class in another assembly))
...
```

- Use the service

```csharp
// startup.cs
...
app.useRouting(); //should be called only once and before

...
app.useFormEndpoint(); //should be called only once
...
```

- Add attributes to any class or property to generate an schemas

```csharp
[FormGroup]
public class CreateUser {
    ...
}

public class CreateOrder {

    [FormInput(...)]
    [Range(18,50)]
    public int Age;
    ...
}
```

- call the endpoint `form` to get the metadata.
