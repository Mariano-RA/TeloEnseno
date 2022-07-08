<template>
  <div>
    <div class="container bloqueContenido">
      <form id="regForm" action="">
        <!-- One "tab" for each step in the form: -->
        <div class="tab" v-show="contador == 0">
          <label>¿Por qué no eliges un título temporal?</label>
          <p>
            No pasa nada si no se te ocurre un buen título en este momento.
            Puedes cambiarlo más tarde.
          </p>
          <input
            placeholder="Por ejemplo: Aprende Python desde cero."
            v-model="modelo.titulo"
          />
        </div>

        <div class="tab" v-show="contador == 1">
          <label
            >¿Qué categoría se corresponde mejor con la de los conocimientos que
            quieres compartir?</label
          >
          <p>
            Si no tienes claro cuál es la categoría correcta, puedes cambiarla
            más adelante.
          </p>
          <select
            name="slt_categoria"
            id="slt_categoria"
            v-model="modelo.categoria"
          >
            <option value="0">Elige una categoría</option>
            <option value="1">Desarrollo</option>
            <option value="2">Negocios</option>
            <option value="3">Finanzas</option>
            <option value="4">Diseño</option>
            <option value="5">Marketing</option>
          </select>
        </div>

        <div class="tab" v-show="contador == 2">
          <label for="lbl_duracion">¿Cuánto tiempo puede durar tu curso?</label>
          <p>No hay respuesta incorrecta a esta pregunta.</p>

          <input
            placeholder="Indica la cantidad de horas necesarias para completar tu curso"
            v-model="modelo.duracion"
          />
        </div>

        <div class="tab" v-show="contador == 3">
          <label for="lbl_descripcion">¿Sobre qué tratará el curso?</label>
          <p>Dejanos una breve descripcion del curso.</p>

          <textarea
            name="descripcionCurso"
            id="descripcionCurso"
            v-model="modelo.descripcion"
          ></textarea>
        </div>

        <div class="tab" v-show="contador == 4">
          <label for="lbl_contenido"
            >¿A que contenido accederan tus alumnos?</label
          >
          <p>Ingresa aca el contenido del curso.</p>
          <textarea
            name="contenidoCurso"
            id="contenidoCurso"
            v-model="modelo.contenido"
            rows="5"
          ></textarea>
        </div>

        <div class="tab" v-show="contador == 5">
          <label for="lbl_contenido">¿Cual es el precio de tu curso?</label>
          <p>Ingresa aca el precio del curso.</p>
          <input
            placeholder="Indica el precio en dolares de tu curso"
            v-model="modelo.precio"
          />
        </div>

        <div id="botones">
          <div>
            <button
              type="button"
              id="prevBtn"
              @click="nextPrev(false)"
              class="botonColor"
              v-if="contador != 0"
            >
              Anterior
            </button>
            <button
              type="button"
              id="nextBtn"
              @click="
                nextPrev(true);
                enviarDatos();
              "
              class="botonColor"
            >
              {{ mostrarBtnFinalizar }}
            </button>
          </div>
        </div>

        <!-- Circles which indicates the steps of the form: -->
        <div style="text-align: center; margin-top: 40px">
          <span class="step" v-bind:class="{ finish: contador == 0 }"></span>
          <span class="step" v-bind:class="{ finish: contador == 1 }"></span>
          <span class="step" v-bind:class="{ finish: contador == 2 }"></span>
          <span class="step" v-bind:class="{ finish: contador == 3 }"></span>
          <span class="step" v-bind:class="{ finish: contador == 4 }"></span>
          <span class="step" v-bind:class="{ finish: contador == 5 }"></span>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "CrearCursoView",
  data() {
    return {
      contador: 0,
      modelo: {
        titulo: null,
        categoria: null,
        duracion: null,
        descripcion: null,
        contenido: null,
        precio: null,
      },
    };
  },
  computed: {
    mostrarBtnFinalizar: function () {
      if (this.contador == 5) {
        return "Finalizar";
      }
      return "Siguiente";
    },
  },
  methods: {
    nextPrev: function (bandera) {
      if (bandera == false) {
        this.contador--;
      } else {
        this.contador++;
      }
    },
    enviarDatos: function () {
      let modelo = this.modelo;
      let creador = this.$store.getters.usuario
      if (this.contador == 6) {
        axios
          .post("./curso", {
            titulo: modelo.titulo,
            categoria: modelo.categoria,
            duracion: modelo.duracion,
            descripcion: modelo.descripcion,
            contenido: modelo.contenido,
            precio: modelo.precio,
            idProfesor: creador,
          })
          .then(function (modelo) {
            console.log(modelo);
            alert("Los datos del curso fueron enviados");
          });
        this.contador = 0;
        for (let dato in modelo) {
          modelo[dato] = null;
        }
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

#regForm {
  background-color: #ffffff;
  margin: 100px auto;
  padding: 40px;
  width: 70%;
  min-width: 300px;
  border-radius: 5px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}

/* Style the input fields */
#regForm div input {
  padding: 10px;
  margin-bottom: 10px;
  width: 100%;
  font-size: 17px;
  border: 1px solid #aaaaaa;
  border-radius: 5px;
}

/* Mark input boxes that gets an error on validation: */
input.invalid {
  background-color: #ffdddd;
}

/* Hide all steps by default: */

.tab label {
  font-size: 30px;
  color: #0b0b3b;
  font-weight: 500;
}

.tab p {
  font-size: 20px;
  margin: 15px 0px;
}

.tab select {
  width: 100%;
  padding: 10px 0px;
  margin-bottom: 20px;
}

/* Make circles that indicate the steps of the form: */
.step {
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbbbbb;
  border: none;
  border-radius: 50%;
  display: inline-block;
  opacity: 0.5;
}

/* Mark the active step: */
.step.active {
  opacity: 1;
}

/* Mark the steps that are finished and valid: */
.finish {
  background-color: #04aa6d;
}

.sinterminar {
  background-color: #bbbbbb;
}

#botones {
  overflow: auto;
}

#botones div {
  float: right;
}

#botones div button {
  padding: 10px 15px;
  border-radius: 5px;
}

#contenidoCurso {
  width: 100%;
  resize: vertical;
  padding: 10px;
}

#descripcionCurso {
  width: 100%;
  resize: none;
  padding: 10px;
}

.botonColor {
  background-color: #b1b1ba81;
  color: #0b0b3b;
  border: none;
  font-size: 14px;
  font-weight: 500;
  margin-left: 10px;
}

.botonColor:hover {
  background-color: #d8d8e481;
  color: #181879;
}
</style>
