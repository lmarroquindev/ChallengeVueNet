<template>
  <div class="container mt-5">
    <h2 class="text-center mb-4">Permission List</h2>
    <div class="row">
      <div class="col-auto text-align-left pb-2">
        <button class="btn btn-primary" @click="openNew()">Add New</button>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-12">
        <table class="table table-bordered table-hover table-striped">
          <thead class="thead-dark">
            <tr>
              <th>ID</th>
              <th>First name</th>
              <th>Last name</th>
              <th>Permisson Type</th>
              <th>Permisson Date</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="permiso in permisos" :key="permiso.id">
              <td>{{ permiso.id }}</td>
              <td>{{ permiso.firstNameEmployee }}</td>
              <td>{{ permiso.lastNameEmployee }}</td>
              <td>{{ permiso.permissionType.description }}</td>
              <td>{{ formatIsoDate(permiso.permissionDate) }}</td>
              <td>
                <div class="d-flex justify-content-end">
                  <button
                    class="btn btn-secondary"
                    @click="openEdit(permiso.id)"
                  >
                    Edit
                  </button>
                  <button
                    class="btn btn-danger"
                    @click="eliminarPermiso(permiso.id)"
                  >
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>
<style>
@import "bootstrap/dist/css/bootstrap.min.css";
</style>

<script>
import { useFormatDate } from "@/composables/useFormatDate";
import { useFetchData } from "@/composables/useFetchData";

export default {
  name: "ListaPermisos",
  data() {
    return {
      permisos: [],
      error: null,
    };
  },
  methods: {
    openNew() {
      this.$emit("new-permission", null);
    },
    openEdit(id) {
      this.$emit("edit-permission", id);
    },
    async eliminarPermiso(id) {
      const { fetchData } = useFetchData(`Permission/${id}`, "DELETE");
      await fetchData();

      await this.fetchPermisos();
    },
    async fetchPermisos() {
      const { data, fetchData } = useFetchData("Permission");

      await fetchData();

      if (data.value) {
        this.permisos = data.value;
      }
    },
  },
  setup() {
    const { formatIsoDate } = useFormatDate();
    return {
      formatIsoDate,
    };
  },
  mounted() {
    this.fetchPermisos();
  },
};
</script>
