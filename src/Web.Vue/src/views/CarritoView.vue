<template>
  <div>
    <div class="container bloqueContenido">
      <div class="container carrito">
        <h2>EL CARRITO ESTA EN PROCESO</h2>
        <p>Mientras te dejo un messi chiquito</p>
        <img src="img/mesichiquito.jpeg" alt="" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "CarritoView",
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

.carrito {
  margin: auto 0;
  justify-content: center;
  flex-direction: column;
  align-items: center;
}

.carrito img {
  width: 30%;
}
</style>
