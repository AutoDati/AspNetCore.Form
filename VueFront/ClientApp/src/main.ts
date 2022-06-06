import { createApp } from "vue";
import App from "./App.vue";
import { createPinia } from "pinia";
import { plugin, defaultConfig } from "@formkit/vue";
import "@formkit/themes/genesis";
const pinia = createPinia();

createApp(App).use(pinia).use(plugin, defaultConfig).mount("#app");
