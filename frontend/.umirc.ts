import { defineConfig } from "umi";

export default defineConfig({
  esbuildMinifyIIFE: true,
  routes: [
    { path: "/", component: "index" },
    { path: "/studentsList", component: "studentsList" },
    { path: "/join", component: "join" },
  ],
  access:{},
  request: {},
  initialState: {},
  model: {},
  proxy: {
    '/api/': {
      target: 'http://localhost:10280',
      changeOrigin: true,
    },
  },
  npmClient: 'npm',
});
