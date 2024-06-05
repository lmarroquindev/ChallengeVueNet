<template>
  <img alt="Vue logo" src="./assets/logo.png" />
  <ListaPermisos></ListaPermisos>
  <FormularioPermiso></FormularioPermiso>
</template>

<script>
import ListaPermisos from "./components/Permission/ListaPermisos.vue";
import FormularioPermiso from "./components/Permission/FormularioPermiso.vue";

export default {
  name: "App",
  components: {
    ListaPermisos,
    FormularioPermiso,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
