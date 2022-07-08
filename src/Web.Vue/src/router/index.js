import Vue from "vue";
import VueRouter from "vue-router";
import PrincipalView from "../views/PrincipalView.vue";
import QuienesSomos from "../views/QuienesSomosView.vue";
import CarritoView from "../views/CarritoView.vue";
import ContactoView from "../views/ContactoView.vue";
import InformacionCurso from "../views/InformacionCursoView.vue";
import MisCursos from "../views/MisCursosView.vue";
import CrearCurso from "../views/CrearCursoView.vue";
import Cursos from "../views/CursosView.vue";
import ListadoAlumnos from "../views/ListadoAlumnosView.vue";
import CursoBuscado from "../views/CursoBuscadoView.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "principal",
    component: PrincipalView,
  },
  {
    path: "/quienessomos",
    name: "quienessomos",
    component: QuienesSomos,
  },
  {
    path: "/carrito",
    name: "carrito",
    component: CarritoView,
  },
  {
    path: "/contacto",
    name: "contacto",
    component: ContactoView,
  },
  {
    path: "/informacioncurso",
    name: "informacioncurso",
    props: (route) => ({ idCurso: route.query.id }),
    component: InformacionCurso,
  },
  {
    path: "/miscursos",
    name: "miscursos",
    props: (route) => ({ idPersona: route.query.id }),
    component: MisCursos,
  },
  {
    path: "/crearcurso",
    name: "crearcurso",
    component: CrearCurso,
  },
  {
    path: "/cursos",
    name: "cursos",
    component: Cursos,
  },
  {
    path: "/listadoalumnos",
    name: "listadoalumnos",
    props: (route) => ({ idCurso: route.query.id }),
    component: ListadoAlumnos,
  },
  {
    path: "/cursobuscado",
    name: "cursobuscado",
    props: (route) => ({ cursoABuscar: route.query }),
    component: CursoBuscado,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
