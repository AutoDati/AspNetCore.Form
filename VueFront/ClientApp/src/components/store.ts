import { defineStore } from "pinia";
import { useFetch } from "@vueuse/core";

export const useFormStore = defineStore("counter", {
  state: () => {
    return {
      forms: {} as any,
      count: 0,
    };
  },
  // could also be defined as
  // state: () => ({ count: 0 })
  actions: {
    increment() {
      this.count++;
    },
    fetchForms() {
      const { data } = useFetch("form").json();
      this.forms = data;
    },
  },
  getters: {
    getContact: (state) => {
      return state.forms.contact;
    },
    getCustomer: (state) => state.forms.customer,
    getForm: (state) => (formName: string) => {
      var controls = state.forms[formName][0].controls;
      var schema = [] as any[];
      controls.map((control: any) => {
        schema.push({
          $cmp: "FormKit",
          props: {
            ...control,
            validation: control.required ? "required" : "",
            validationVisibility: "dirty",
          },
        });
      });

      return schema;
    },
  },
});
