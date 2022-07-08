<template>
  <div>
    <div id="titulo">
      {{ tituloCurso }}
      <h5>Listado de alumnos</h5>
    </div>
    <div class="grilla">
      <div class="encabezados">
        <div class="caja"><h3>Nombre</h3></div>
        <div class="caja"><h3>Apellido</h3></div>
        <div class="caja"><h3>Mail</h3></div>
        <div class="caja"><h3>DNI</h3></div>
      </div>

      <div v-for="persona in personas" :key="persona.idPersona" class="datos">
        <div class="caja">{{ persona.nombre }}</div>
        <div class="caja">{{ persona.apellido }}</div>
        <div class="caja">{{ persona.mail }}</div>
        <div class="caja">{{ persona.dni }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ListadoAlumnosView",
  props: ["idCurso"],
  data() {
    return {
      personas: [],
      cursos: null,
      tituloCurso: "",
    };
  },
  created() {
    var vm = this;
    axios
      .get("./PersonaCurso/", {})
      .then(function (response) {
        response.data.forEach((element) => {
          if (element.idCurso == vm.idCurso) {
            vm.personas.push(element.persona);
            vm.tituloCurso = element.curso.titulo;
          }
        });
      })
      .catch(function (response) {
        console.log(response);
      });
  },
};
</script>

<style>
.grilla {
  display: grid;
  grid-template-columns: (5, 200px);
  width: 80%;
  margin: 30px auto;
}

.encabezados {
  display: flex;
  grid-row: 1/5;
  justify-content: space-around;
}

.datos {
  display: flex;
  justify-content: space-between;
}

.caja {
  border: 1px solid black;
  width: 25%;
  text-align: center;
  padding: 20px 10px;
}

#titulo {
  font-size: 50px;
  text-align: center;
  margin: 20px 0px;
  color: #0b0b3b;
  font-weight: bold;
}

h5 {
  color: #0b0b3b;
  margin: 20px 0px;
}
</style>
