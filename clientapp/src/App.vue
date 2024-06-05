<template>
  <img alt="Vue logo" src="./assets/logo.png" />
  <ListaPermisos
    v-if="showList"
    @edit-permission="editPermission"
    @new-permission="newPermission"
  />
  <FormularioPermiso v-else :key="id" :id="id" @close-form="cerrarFormulario" />
</template>

<script>
import ListaPermisos from "./components/Permission/ListaPermisos.vue";
import FormularioPermiso from "./components/Permission/FormularioPermiso.vue";

export default {
  name: "App",
  data() {
    return {
      showList: true,
      id: null,
    };
  },
  methods: {
    newPermission() {
      this.showList = false;
      this.id = null;
    },
    editPermission(id) {
      console.log(id);
      this.showList = false;
      this.id = id;
    },
    cerrarFormulario() {
      this.showList = true;
      this.id = null;
    },
  },
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
