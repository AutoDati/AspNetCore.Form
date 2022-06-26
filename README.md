# AspNetCore.Form

Provides and endpoint for form schema's to be consume by front ends

See the 📕 [Full Documentation](https://emersonbottero.github.io/AspNetCore.Form/)

## Form schemas

Produces form schema's to be consumed by different front end form builders like:

- Form.io (the core and frameworks version are open source)

  - [Formio core](https://github.com/formio/formio.js)
  - [Vue](https://github.com/formio/vue)
  - [React](https://github.com/formio/react)
  - [Anular](https://github.com/formio/angular)

- Other libraries
  - [Vue FormKit](https://formkit.com/advanced/schema#formkit-inputs)
  - [React JsonSchema Forms](https://react-jsonschema-form.readthedocs.io/en/latest/usage/objects/)
  - [Angular](https://angular.io/guide/dynamic-form#create-a-form-object-model)

## Getting started

```csharp
// startup.cs

...
service.AddFormEndpoint(typeof(class))

...
app.useRouting(); //should be called only once and before useFormEndpoint()
app.useFormEndpoint();
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

## References

https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatypeattribute?view=net-6.0
