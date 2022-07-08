<template>
  <div>
    <div class="container bloqueContenido">
      <div class="container" id="infoCurso">
        <div id="primerBloque">
          <div>
            <h3>Carrera online en vivo de</h3>
            <h2>{{ infoCurso.titulo }}</h2>
            <div>
              <h3>Descripcion del curso</h3>
              <p>
                {{ infoCurso.descripcion }}
              </p>
              <p id="creador">
                Creador: <span>{{ nombreCompleto }}</span>
              </p>
              <p>Ultima actualizacion: 31/05/2022</p>
              <p>Idioma: Español</p>
              <p>Subtitulos: Ingles y Español</p>
            </div>
          </div>
          <div id="costoCurso" class="container">
            <img :src=imagen alt="logo del curso" />
            <p>Precio: $ {{ infoCurso.precio }}</p>
            <button class="botonColor">Añadir al carrito</button>
            <button class="botonComprar" v-on:click="cargarAlumno">
              Inscribirme
            </button>
          </div>
        </div>

        <div id="contenido">
          <h3>Contenido del curso</h3>
          <div>
            {{ infoCurso.contenido }}
          </div>
        </div>

        <div id="listaAlumnos">
          <router-link :to="{ name: 'listadoalumnos', query: { id: idCurso } }"
            >Listado de Alumnos</router-link
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "InformacionCursoView",
  props: ["idCurso"],
  data() {
    return {
      infoCurso: {},
      infoProfesor: {},
      imagen: null,
    };
  },
  created() {
    var vm = this;
    axios
      .get("./curso/" + vm.idCurso, {})
      .then(function (response) {
        vm.infoCurso = response.data;
        axios
          .get("./persona/" + vm.infoCurso.idProfesor, {})
          .then(function (response) {
            vm.infoProfesor = response.data;
          })
          .catch(function (response) {
            console.log(response);
          });
      })
      .catch(function (response) {
        console.log(response);
      });
    let numero = Math.floor(Math.random() * (5 - 1) + 1);
    this.imagen = "img/" + numero + ".png";
    console.log(this.imagen)
  },
  computed: {
    nombreCompleto: function () {
      return this.infoProfesor.nombre + " " + this.infoProfesor.apellido;
    },
  },
  methods: {
    cargarAlumno: function () {
      if (this.infoCurso.idProfesor == this.$store.getters.usuario) {
        alert("No podes anotarte a tus cursos!");
      } else {
        axios
          .post(
            "./PersonaCurso?idCurso=" +
              this.infoCurso.idCurso +
              "&idPersona=" +
              this.$store.getters.usuario,
            {}
          )
          .then(function (response) {
            alert("Felicitaciones! Te has anotado a " + this.infoCurso.titulo);
            console.log(response);
          })
          .catch(function (response) {
            console.log(response);
          });
      }
    },
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

#infoCurso {
  margin: 5% 10%;
  flex-direction: column;
}

#primerBloque {
  display: flex;
  justify-content: space-between;
  margin-bottom: 20px;
}

#primerBloque div div {
  margin: 2% 0;
  width: 80%;
}

#primerBloque div h2 {
  font-size: 50px;
  margin: 20px 0px;
}

#primerBloque div div p {
  margin: 5px 0px;
}

#primerBloque div div p {
  margin: 5px 0px;
  font-size: 14px;
}

#creador span {
  text-decoration: underline;
}

#infoCurso h3,
h2,
h4 {
  color: #0b0b3b;
}

#infoCurso p,
ul li {
  color: rgb(88, 88, 88);
}

#costoCurso {
  flex-direction: column;
  width: 20%;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  border-radius: 5px;
  align-self: baseline;
}

#costoCurso p {
  margin: 20px 0px;
  padding: 0px 10px;
}

#costoCurso button {
  padding: 5px 0px;
  border-radius: 5px;
  margin: 5px 10px;
}

.botonComprar {
  background-color: #181879;
  color: #b1b1ba;
  border: none;
  font-size: 14px;
  font-weight: 500;
}

.botonComprar:hover {
  background-color: #18187994;
  color: #e8e8f3;
}

#contenido {
  margin-right: 25%;
}

#contenido div ul {
  padding: 0px 20px;
  margin: 20px 0px;
}

#contenido div ul li {
  margin-bottom: 10px;
}

#contenido div p {
  text-align: justify;
  padding: 10px 0px;
}

#listaAlumnos {
  margin-top: 20px;
}
</style>
