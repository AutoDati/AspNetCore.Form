<script setup lang="ts">
import { computed, ref, watch } from "vue";
import { useFormStore } from "./store.js";

defineProps<{ msg: string }>();

// const schema = computed(() =>{
//   data.value
// })

const schema = [
  {
    $formkit: "email",
    label: "Email address",
    validation: "required",
  },
];

const count = ref(0);

const formStore = useFormStore();

formStore.fetchForms();

const recommendation = ref("10");
</script>

<template>
  <h1>{{ msg }}</h1>

  <pre><code>{{formStore.getForm('contact') }}</code></pre>
  <div class="form">
    <h2>Contact</h2>
    <FormKitSchema :schema="formStore.getForm('contact')" />
  </div>

  <div class="form">
    <h2>Contact</h2>
    <FormKitSchema :schema="formStore.getForm('customer')" />
  </div>

  <div class="form">
    <FormKit type="group" v-model="formData">
      <FormKit
        name="hello_world"
        label="Hello World"
        placeholder="Enter something here..."
        validation="required"
        validation-behavior="live"
        help="Read the docs for more info on using FormKit"
      />
      <FormKit
        name="opinion"
        label="Opinion"
        help="How excited are you about FormKit?"
        type="radio"
        value="A lot"
        :options="['A little', 'A lot']"
      />
      <div class="side-by-side">
        <FormKit
          name="recommendation"
          label="Recommendation"
          v-model="recommendation"
          help="How likely are you to recommend FormKit to a friend?"
          type="range"
          min="0"
          max="10"
        />
        <pre class="range-output">{{ recommendation }} </pre>
      </div>
    </FormKit>
  </div>

  <h2>Modeled group values</h2>
  <!-- <pre class="form-data">{{ formData }}</pre> -->
</template>

<style scoped>
.form {
  width: 300px;
}

a {
  color: #42b983;
}

label {
  margin: 0 0.5em;
  font-weight: bold;
}

code {
  background-color: #eee;
  padding: 2px 4px;
  border-radius: 4px;
  color: #304455;
}
</style>
