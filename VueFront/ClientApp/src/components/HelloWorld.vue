<script setup lang="ts">
import { ref } from "vue";

import { useFetch } from "@vueuse/core";

const { isFetching, error, data } = useFetch("form");

defineProps<{ msg: string }>();

const count = ref(0);
</script>

<template>
  <h1>{{ msg }}</h1>

  <h3>{{ isFetching }}</h3>

  <h3>{{ error }}</h3>

  <p>{{ data }}</p>
</template>

<style scoped>
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
