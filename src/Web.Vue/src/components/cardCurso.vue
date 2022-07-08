<template>
  <div class="card">
    <img :src="obtenerRandom" alt="imagen de prueba" />
    <div class="cardDatos">
      <h4>{{ curso.titulo }}</h4>
      <p>Precio: ${{ curso.precio }}</p>
      <p class="estrella">★★★★★</p>
      <router-link
        :to="{ name: 'informacioncurso', query: { id: curso.idCurso } }"
        ><button class="botonColor">Ver mas</button></router-link
      >
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  props: ["idCurso"],
  data() {
    return {
      curso: "",
      imagen: null,
    };
  },
  mounted() {
    var vm = this;
    axios
      .get("./curso/" + vm.idCurso, {})

      .then(function (response) {
        vm.curso = response.data;
      })
      .catch(function (response) {
        console.log(response);
      });
  },
  created() {
    let numero = Math.floor(Math.random() * (5 - 1) + 1);
    this.imagen = "img/" + numero + ".png";
  },
  computed: {
    obtenerRandom: function () {
      let numero = Math.floor(Math.random() * (5 - 1) + 1);
      return "img/" + numero + ".png";
    },
  },
};
</script>

<style>
.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  transition: 0.3s;
  border-radius: 5px;
  margin: 20px;
}

.card img {
  width: 100%;
  height: 230px;
  max-width: 400px;
  border-radius: 5px 5px 0 0;
}

.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
}

.cardDatos {
  padding: 10px 16px 5px 16px;
  color: #0b0b3b;
}

.cardDatos h4 {
  max-width: 100%;
  height: 50px;
}

.cardDatos button {
  width: 100%;
  padding: 5px;
  margin: 10px 0px;
  border-radius: 5px;
}

.botonColor {
  background-color: #b1b1ba81;
  color: #0b0b3b;
  border: none;
  font-size: 14px;
  font-weight: 500;
}

.botonColor:hover {
  background-color: #d8d8e481;
  color: #181879;
}

.estrella {
  color: #0b0b3b;
}
</style>
