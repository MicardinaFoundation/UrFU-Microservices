import { defineConfig } from "umi";

export default defineConfig({
  esbuildMinifyIIFE: true,
  routes: [
    {
      path: '/',
      wrappers: ['@/components/ProtectedRouteSect'],
      routes: [
        { path: "/", component: "@/pages/index" },
        { path: "/studentsList", component: "@/pages/studentsList" },
        //{ path: "/join", component: "@/pages/join" },

      ]
    },
    { path: "/join", component: "Login/LoginPage", layout: false },
    { path: "/*", component: "404" }


  ],
  access: {},
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
