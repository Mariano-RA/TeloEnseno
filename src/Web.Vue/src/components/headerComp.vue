<template>
  <div>
    <header class="container">
      <nav class="container primerHeader">
        <div>
          <router-link to="/"
            ><img src="img/logo.png" alt="logo"
          /></router-link>
        </div>
        
        <div class="container menuBuscador">
          <input v-model="cursoABuscar" placeholder="Busca tu curso aca.." id="lbl_buscar" 
          @keyup.enter="buscarCurso" />
          <button id="btn_buscar" @click.prevent="buscarCurso">Buscar</button>          
        </div>


        <div class="container menuBotones">
          <div v-show="parametros.ocultar">
            <a href="#login">INGRESAR</a>
          </div>
          <div v-show="parametros.ocultar">
            <a href="#registro">REGISTRARME</a>
          </div>
          <div v-show="!parametros.ocultar" id="bienvenidaNombre">
            Bienvenido, {{ parametros.nombrePersona }}
          </div>
          <router-link to="/carrito">CARRITO</router-link>
        </div>
      </nav>
      <div class="segundoHeader">
        <nav>
          <ul class="container">
            <li><router-link to="/cursos">CURSOS</router-link></li>
            <li><a href="https://www.lingscars.com/">FORO</a></li>
            <li><router-link to="/quienessomos">QUIENES SOMOS</router-link></li>
            <li><router-link to="/contacto">CONTACTO</router-link></li>
            <li>
              <router-link :to="{name: 'miscursos',query: { id: this.$store.getters.usuario },}">MIS CURSOS</router-link>
            </li>
          </ul>
        </nav>
      </div>
    </header>

    <div id="login" class="modal">
      <div class="contenidoModal">
        <form action="" method="get" class="container">
          <a href="#" id="cerrarLogin" class="botonColor" ref="botonCerrar"
            >Cerrar</a
          >
          <div class="container">
            <label for="lbl_usuario">Ingresa tu usuario</label>
            <input
              type="text"
              placeholder="Usuario"
              id="lbl_usuario"
              v-model="usuario.nombre"
            />
            <label for="lbl_contrasena">Ingresa tu contraseña</label>
            <input
              type="password"
              placeholder="Contraseña"
              name="contraseña"
              id="lbl_contrasena"
              v-model="usuario.password"
            />
          </div>
          <button
            type="submit"
            class="botonColor"
            @click.prevent="loguearUsuario"
          >
            Ingresar
          </button>
        </form>
        <p>No tenes una cuenta? <a href="#registro">Registrate</a></p>
      </div>
    </div>

    <div id="registro" class="modal">
      <div class="contenidoModal">
        <form action="" method="POST" class="container">
          <a href="#" id="cerrarLogin" class="botonColor">Cerrar</a>
          <div class="container">
            <label for="nombre">Ingresa tu nombre</label>
            <input
              type="text"
              placeholder="Nombre"
              id="lbl_nombre"
              v-model="modelo.nombre"
            />
            <label for="apellido">Ingresa tu apellido</label>
            <input
              type="text"
              placeholder="Apellido"
              id="lbl_apellido"
              v-model="modelo.apellido"
            />
            <label for="dni">Ingresa tu DNI</label>
            <input
              type="text"
              placeholder="D.N.I"
              id="lbl_dni"
              v-model="modelo.dni"
            />
            <label for="email">Ingresa tu mail</label>
            <input
              type="email"
              placeholder="Mail"
              id="lbl_mail"
              v-model="modelo.correo"
            />
            <label for="contraseña">Ingresa tu contraseña</label>
            <input
              type="password"
              placeholder="Contraseña"
              name="contraseña"
              id="lbl_contrasena"
              v-model="modelo.password"
            />
          </div>
          <button class="botonColor" @click.prevent="cargarDatos">
            Registrarme
          </button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      modelo: {
        nombre: null,
        apellido: null,
        dni: null,
        correo: null,
        password: null,
      },
      datosLog: null,
      usuario: {
        nombre: null,
        password: null,
      },
      parametros: {
        ocultar: true,
        nombrePersona: null,
      },
      cursoABuscar: null,
    };
  },
  methods: {
    cargarDatos: function () {
      let modelo = this.modelo;
      axios
        .post("./persona", {
          nombre: modelo.nombre,
          apellido: modelo.apellido,
          dni: modelo.dni,
          mail: modelo.correo,
          password: modelo.password,
        })
        .then(function (modelo) {
          console.log(modelo);
        });
      for (let dato in modelo) {
        modelo[dato] = null;
      }
      this.$refs.botonCerrar.click();
    },
    loguearUsuario: function () {
      let vm = this;
      axios
        .get("./persona", {})
        .then(function (response) {
          vm.datosLog = response.data;
          for (let persona in vm.datosLog) {
            if (
              vm.datosLog[persona].mail == vm.usuario.nombre &&
              vm.datosLog[persona].password == vm.usuario.password
            ) {
              vm.parametros.ocultar = false;
              vm.$refs.botonCerrar.click();
              vm.parametros.nombrePersona = vm.datosLog[persona].nombre;
              vm.$store.dispatch(
                "iniciarSesion",
                vm.datosLog[persona].idPersona
              );
            }
          }
        })
        .catch(function (response) {
          console.log(response);
        });
    },   
    buscarCurso: function(){
      this.$router.push({name: 'cursobuscado',query: { cursoABuscar: this.cursoABuscar }, })
      this.$router.go();
    } 
  },
};
</script>

<style>
.container {
  display: flex;
}

header {
  flex-direction: column;
}

.primerHeader {
  justify-content: space-between;
  background-color: #38383b;
}

.primerHeader div a img {
  width: 50%;
  margin-left: 50px;
}

.menuBuscador {
  width: 72%;
}

.menuBuscador input#lbl_buscar {
  margin: 20px 0px;
  padding: 0px 100px 0px 10px;
  border-radius: 7px;
}

#btn_buscar {
  margin: 20px 5px;
  padding: 10px 20px;
  border-radius: 7px;
  border: none;
  background-color: #b1b1ba;
  text-decoration: none;
}

#btn_buscar:hover {
  background-color: #e4e4f0;
  cursor: pointer;
}
.menuBotones {
  margin-right: 20px;
}

.menuBotones a {
  margin: 20px 0px;
  text-decoration: none;
  padding: 10px 20px;
  display: block;
  color: #b1b1ba;
}

.menuBotones a:hover {
  color: #e4e4f0;
}

#bienvenidaNombre {
  text-transform: uppercase;
  margin: 20px 0px;
  padding: 10px 0px;
  width: 200px;
  color: #b1b1ba;
}

.segundoHeader {
  background-color: #797980;
  padding: 10px 0px;
}

.segundoHeader nav ul {
  justify-content: space-evenly;
  list-style: none;
}

.segundoHeader li a {
  color: #cbcbd6;
  padding: 10px 20px;
  text-decoration: none;
}

.segundoHeader li a:hover {
  color: #f4f4ff;
}

.modal {
  background-color: rgba(0, 0, 0, 0.8);
  position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  opacity: 0;
  pointer-events: none;
  transition: all 1s;
}

.contenidoModal {
  background-color: #ffffff;
  width: 300px;
  padding: 10px 20px;
  margin: 10% auto;
  position: relative;
}

.contenidoModal form {
  flex-direction: column;
}

.contenidoModal form a#cerrarLogin {
  align-self: flex-end;
  border-radius: 5px;
  padding: 5px;
  text-decoration: none;
}

.contenidoModal form div {
  width: 100%;
  flex-direction: column;
}

.contenidoModal form div input {
  display: block;
  margin: 10px 0px;
  padding: 10px 0px 10px 10px;
}

.contenidoModal form button {
  margin: 10px 0px;
  padding: 10px 0px;
  border-radius: 5px;
}

.modal:target {
  opacity: 1;
  pointer-events: auto;
}
</style>
