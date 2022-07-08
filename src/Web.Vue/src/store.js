import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    logged_in: false,
    usuario: "",
  },
  mutations: {
    iniciarSesion(state, usuario) {
      state.logged_in = true;
      state.usuario = usuario;
    },
    cerrarSesion(state) {
      state.logged_in = false;
      state.usuario = "";
    },
    falseLoggedIn(state) {
      state.logged_in = false;
    }
  },
  actions: {
    iniciarSesion({ commit }, usuario) {
      commit("iniciarSesion", usuario);
    },
    cerrarSesion({ commit }) {
      commit("iniciarSesion");
    },
    falseLoggedIn({ commit }) {
      commit("falseLoggedIn");
    }
  },
  getters: {
    logged_in(state) {
      return state.logged_in;
    },
    usuario(state) {
      return state.usuario;
    },
  },
});
