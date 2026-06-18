import { defineConfig } from "umi";

export default defineConfig({
  esbuildMinifyIIFE: true,
  // layout: {
  //       title: 'Project: Nektarynki Tesco', 
  //         },
 routes: [
    {
      path: '/',
      wrappers: ['@/components/ProtectedRouteSect'],
      routes: [
        { path: "/calculateKU", component: "@/pages/index"},
        { path: "/kotelList", component: "@/pages/studentsList"},
        //{ path: "/join", component: "@/pages/join" },

      ]
    },
    { path: "/join", component: "Login/LoginPage", layout: false, title: 'Вход'},
    { path: "/home", component: "@/pages/HomePage/homePage", title: 'Главная страница'},
    { path: "/*", component: "404", title: '404 :с'}


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
