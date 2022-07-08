<template>
  <div>
    <div class="container bloqueContenido">
      <div><h2 id="tituloContacto">Contacta con nosotros</h2></div>
      <div id="contacto">
        <h3>¿Necesitas ayuda?</h3>
        <p>
          Si eres un estudiante que usa la plataforma de Coursera y deseas hacer
          alguna pregunta o necesitas ayuda técnica, visita nuestro Centro de
          Ayuda al Alumno para ver los tutoriales de la plataforma, hacer
          preguntas frecuentes o chatear con un miembro de nuestro equipo de
          Atención al cliente.
        </p>

        <p>
          También, puedes navegar por nuestros temas de ayuda más populares:
        </p>

        <ul>
          <li><a href="">Configuración de la cuenta</a></li>
          <li><a href="">Pagos y suscripciones</a></li>
          <li><a href="">Cómo inscribirse en un curso</a></li>
          <li><a href="">Software Recomendado y Dispositivos</a></li>
          <li><a href="">Descargando y Viendo Vídeos</a></li>
          <li><a href="">Calificaciones y Logros</a></li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ContactoView",
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

#tituloContacto {
  border-bottom: 1px solid #0b0b3b;
  margin: 50px 20% 0px 20%;
  padding: 0px 70px;
  text-align: center;
}

#contacto {
  margin: 20px 20%;
  text-align: justify;
}

#contacto h3 {
  margin-bottom: 20px;
}

#contacto ul {
  margin: 20px 5%;
}
</style>
