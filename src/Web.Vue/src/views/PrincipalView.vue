<template>
  <div>
    <div class="container bloqueContenido">
      <div class="contaier bloqueCursosPadre">
        <h2>Cursos Populares</h2>
        <div class="bloqueHijos">
          <div
            v-for="curso in listadoCursos.slice(0, 8)"
            v-bind:key="curso.idCurso"
          >
            <cardCurso
              v-bind:idCurso="curso.idCurso"
              id="card"
            ></cardCurso>
          </div>
        </div>
      </div>

      <div class="container bloqueSpeach">
        <h2>Habilitando la transformación</h2>
        <div class="container bloqueSpeachContenido">
          <div>
            <p>
              Tu experiencia de aprendizaje en TeLoEnseño se basa en ciencia
              cognitiva de vanguardia. Con más de dos docenas de funciones de
              aprendizaje distintas para ayudarte a lograr tus objetivos,
              nuestro enfoque sigue tres principios clave:
            </p>
            <h3>Experimenta</h3>
            <p>
              Aprende nuevos conocimientos y habilidades en una variedad de
              formas, desde videos de expertos y textos y gráficos dinámicos
              hasta visualizaciones de datos y elementos interactivos.
            </p>
            <h3>Practica</h3>
            <p>
              Una parte fundamental del aprendizaje es la capacidad de demostrar
              tu conocimiento. Los cursos y programas de TeLoEnseño brindan un
              espacio para practicar con cuestionarios, evaluaciones de
              respuesta abierta, entornos virtuales y más.
            </p>
            <h3>Actualizar</h3>
            <p>
              Aprender en TeLoEnseño transforma tu forma de pensar y lo que
              puedes hacer, y se traduce directamente en el mundo real: aplica
              inmediatamente tus nuevas capacidades en el contexto de tu
              trabajo.
            </p>
          </div>
          <div>
            <img src="img/koosh-brain.png" alt="Imagen de cerebro" />
          </div>
        </div>
      </div>

      <div class="container bloqueSegundoSpeach">
        <div class="container">
          <div>
            <h2>Como funciona?</h2>
            <p>
              En nuestros cursos online en vivo vas a tener interacción real e
              instantánea con tu profesor, tutor y compañeros, para resolver
              todas tus dudas y avanzar en tus proyectos prácticos.
            </p>
            <ul>
              <li>Interacción en vivo</li>
              <li>Corrección de proyectos prácticos</li>
              <li>Networking con tus compañeros</li>
            </ul>
          </div>
          <div>
            <h2>Tutor dedicado</h2>
            <p id="segundoParrafo">
              En cada curso se te va a asignar un tutor que va a estar a
              disposición siempre que lo necesites, para resolver tus dudas y
              recibir feedback sobre tus proyectos.
            </p>
            <ul>
              <li>Atención en menos de 24 h</li>
              <li>Feedback constante</li>
              <li>Acompañamiento en el proyecto final</li>
            </ul>
          </div>
        </div>
        <router-link to="/cursos" class="botonColor">Ver Cursos</router-link>
      </div>
    </div>
  </div>
</template>

<script>
import cardCurso from "@/components/cardCurso.vue";
import axios from "axios";

export default {
  name: "PrincipalView",
  components: {
    cardCurso,
  },
  data() {
    return {
      listadoCursos: null || [],
    };
  },
  created() {
    let cursos = this;
    axios
      .get("./curso/", {})
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

/*--------------------------------------------------------------------*/

.bloqueContenido {
  flex-direction: column;
  min-height: calc(100vh - 120px - 80.59px);
}

/*--------------------------------------------------------------------*/

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

.bloqueHijos {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

.card {
  max-width: 400px;
}

/*--------------------------------------------------------------------*/

.bloqueSpeach {
  flex-direction: column;
  justify-content: space-between;
  margin: 20px 200px;
}

.bloqueSpeach h2 {
  font-size: 50px;
}

.bloqueSpeachContenido {
  margin: 20px 0px;
}

.bloqueSpeachContenido div {
  width: 50%;
}

.bloqueSpeachContenido div h3 {
  font-size: 30px;
  margin: 30px 0px 10px 0px;
}

.bloqueSpeachContenido div p {
  font-size: 20px;
  text-align: justify;
  color: grey;
}

/*--------------------------------------------------------------------*/

.bloqueSegundoSpeach {
  flex-direction: column;
  margin: 30px 50px;
}

.bloqueSegundoSpeach div {
  justify-content: space-evenly;
  flex-wrap: wrap;
  margin-bottom: 20px;
}

.bloqueSegundoSpeach div div {
  width: 45%;
}

.bloqueSegundoSpeach a {
  align-self: center;
}

.bloqueSegundoSpeach div h2 {
  font-size: 30px;
  margin: 30px 0px 10px 0px;
}

.bloqueSegundoSpeach div p {
  font-size: 20px;
  text-align: justify;
  color: rgb(88, 88, 88);
  margin-bottom: 20px;
}

.bloqueSegundoSpeach div li {
  font-size: 18px;
  font-weight: bold;
  list-style: none;
  margin-top: 10px;
  padding-bottom: 10px;
  border-bottom: 1px solid black;
}

.bloqueSegundoSpeach a {
  padding: 10px 20px;
  border-radius: 5px;
  text-decoration: none;
}

#segundoParrafo {
  margin-bottom: 43px;
}
</style>
