<template>
  <footer class="container">
    <img src="img/logo.png" alt="Icono de TeLoEnseño" />
    <div class="container" id="listaFooter">
      <router-link to="/cursos">Cursos</router-link>
      <a href="">Blog</a>
      <a href="">Politicas de Privacidad</a>
      <a href="">Condiciones</a>
    </div>
    <p>Copyright © 2022. All rights reserved</p>
  </footer>
</template>

<script>
export default {};
</script>

<style>
.container {
  display: flex;
}

footer {
  background-color: #38383b;
  justify-content: space-between;
  padding: 0px 50px;
  align-items: center;
}

footer img {
  padding: 10px 0px;
  width: 100px;
}

footer div a,
p {
  color: #b1b1ba;
}

footer div {
  justify-content: space-between;
  width: 30%;
}
</style>
