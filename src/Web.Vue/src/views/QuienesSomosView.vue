<template>
  <div>
    <div class="container bloqueContenido">
      <div class="container bloqueSpeach">
        <div class="container bloqueSpeachContenido">
          <div class="quienesSomosParrafo">
            <h3>La tienda virtual de aprendizaje y enseñanza global líder</h3>
            <p>
              Al conectar estudiantes de todo el mundo con los mejores
              instructores, TeLoEnseño ayuda a las personas a alcanzar sus metas
              y perseguir sus sueños.
            </p>
            <h3>
              Somos un grupo de profesionales con la misión de democratizar la
              educación en Latinoamérica
            </h3>
            <p>
              Creamos experiencias de aprendizaje y desarrollo profesional
              increíbles para entusiastas digitales
            </p>
          </div>
          <div class="quienesSomosParrafo">
            <h3>ESTA ES NUESTRA HISTORIA</h3>
            <p>
              Somos la primera Digital School de Argentina. Fundada en 2022 en
              Cordoba, nacimos como una simple escuela de programación. Con los
              años fuimos creciendo y comenzamos a ofrecer otros cursos como los
              de Marketing, Diseño, E Commerce, Product Manager y con el
              transcurrir de los años, ¡muchísimos cursos más!
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "QuienesSomosView",
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

.quienesSomosParrafo {
  margin: 0px 50px;
}
</style>
