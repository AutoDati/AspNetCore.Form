# AspNetCore.Form

Provides and endpoint for form schema's to be consume by front ends

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

``` csharp
// startup.cs
...
service.AddFormEndpoint(assembly list)

...
app.useRouting(); //should be called only once and before useFormEndpoint()
app.useFormEndpoint();
```

## References from other projects

https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatypeattribute?view=net-6.0

https://github.com/rbasniak/rbk-api-modules/blob/master/rbkApiModules.UIAnnotations/Models/FormDefinition.cs
https://github.com/rbasniak/rbk-api-modules/blob/f379ef8f77c4a77a0137bf92376d4c8293df21ed/rbkApiModules.UIAnnotations.Common/DialogDataAttribute.cs
https://github.com/rbasniak/rbk-api-modules/blob/cb367ba31f67dc4848aa6735597183c344dd79c6/rbkApiModules.UIAnnotations/Services/DialogDataBuilderService.cs#L15