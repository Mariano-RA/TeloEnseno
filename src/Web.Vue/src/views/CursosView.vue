<template>
  <div>
    <div class="contaier bloqueCursosPadre">
      <h2>Cursos</h2>
      <div class="container bloqueCursosHijo">
        <div v-for="curso in listadoCursos" v-bind:key="curso.idCurso">
          <cardCurso
            src-img="img/curso 2.png"
            v-bind:idCurso="curso.idCurso"
          ></cardCurso>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import cardCurso from "@/components/cardCurso.vue";
import axios from "axios";

export default {
  name: "CursosView",
  components: {
    cardCurso,
  },
  data() {
    return {
      listadoCursos: null,
    };
  },
  mounted() {
    let cursos = this;
    axios
      .get("./curso", {})
      .then(function (response) {
        cursos.listadoCursos = response.data;
      })
      .catch(function (response) {
        console.log(response);
      });
  },
};
</script>

<style>
.container {
  display: flex;
}

.bloqueCursosPadre {
  flex-direction: column;
  margin: 50px 0px;
  min-height: calc(100vh - 120px - 80.59px);
}

.bloqueCursosPadre h2 {
  text-align: center;
  margin-bottom: 20px;
  color: #0b0b3b;
  font-size: 50px;
}

.bloqueCursosHijo {
  flex-wrap: wrap;
  justify-content: center;
}
</style>
