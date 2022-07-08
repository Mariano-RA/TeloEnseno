<template>
  <div>
    <div class="container bloqueContenido">
      <div class="container" id="bloqueMisCursos">
        <div class="container" id="crearCurso">
          <router-link to="/crearcurso">Crear un nuevo curso</router-link>
        </div>

        <div class="container bloqueCursosPadre">
          <h2>Mis Cursos</h2>
          <div class="container bloqueCursosHijo">
            <div v-for="curso in listadoCursos" v-bind:key="curso.idPersona">
              <cardCurso
                src-img="img/curso 2.png"
                v-bind:idCurso="curso.idCurso"
              ></cardCurso>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import cardCurso from "@/components/cardCurso.vue";
import axios from "axios";

export default {
  name: "MisCursosView",
  props: ["idPersona"],
  components: {
    cardCurso,
  },
  data() {
    return {
      listadoCursos: [],
    };
  },
  mounted() {
    let vm = this;
    axios
      .get("./personacurso", {})
      .then(function (response) {
        for(let curso in response.data){
          if(response.data[curso].idPersona == vm.idPersona){
            vm.listadoCursos.push(response.data[curso].curso)
          }          
        }
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

.bloqueContenido {
  flex-direction: column;
  min-height: calc(100vh - 120px - 80.59px);
}

#bloqueMisCursos {
  flex-direction: column;
  align-items: center;
}

#crearCurso {
  margin-top: 30px;
}

#crearCurso a {
  text-decoration: none;
  font-size: 20px;
  font-weight: 500;
  color: #0b0b3b;
}

#crearCurso p {
  text-decoration: none;
  font-size: 20px;
  font-weight: 500;
  color: #0b0b3b;
  margin: 0px 20px;
}

#crearCurso a:hover {
  color: #0b0b3b63;
}

.bloqueCursosPadre h2 {
  font-size: 50px;
}
.bloqueCursosPadre {
  flex-direction: column;
  margin: 50px 0px;
}

.bloqueCursosPadre h2 {
  text-align: center;
  margin-bottom: 20px;
  color: #0b0b3b;
}

.bloqueCursosHijo {
  justify-content: space-around;
  flex-wrap: wrap;
}
</style>
