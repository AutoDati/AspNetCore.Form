import serverOption from './serverOption'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  server : serverOption,
  plugins: [vue()]
})
