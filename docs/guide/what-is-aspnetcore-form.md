## AspNetCore.Form

This tool is meant to provide input schemas to be use in html forms or with form generators in any front end form generators!

### Some Generators Examples

- Form.io (the core and frameworks version are open source)

  - [Formio core](https://github.com/formio/formio.js)
  - [Vue](https://github.com/formio/vue)
  - [React](https://github.com/formio/react)
  - [Anular](https://github.com/formio/angular)

- Other libraries
  - [Vue FormKit](https://formkit.com/advanced/schema#formkit-inputs)
  - [React JsonSchema Forms](https://react-jsonschema-form.readthedocs.io/en/latest/usage/objects/)
  - [Angular](https://angular.io/guide/dynamic-form#create-a-form-object-model)

## Goals

- Don't repeat the definition for forms and validations (the properties and types are already declared in controllers and/or endpoints)
- Instantaneous feedback on validations (there is no need to call and wait for the validations from the backend to return to update the forms)
- Keep validation only on backends (requests made from cli or other means still are validation)
