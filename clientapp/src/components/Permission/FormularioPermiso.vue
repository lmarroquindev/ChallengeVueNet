<template>
  <div class="container mt-3">
    <h2>{{ isEdition ? "Update Permission" : "New Permission" }}</h2>
    <form @submit.prevent="submitForm">
      <div class="row">
        <div class="col-md-6">
          <div class="mb-3">
            <label for="firstNameEmployee" class="form-label"
              >First Name Employee</label
            >
            <input
              type="text"
              class="form-control"
              id="firstNameEmployee"
              v-model="permissions.firstNameEmployee"
              required
            />
          </div>
          <div class="mb-3">
            <label for="permissionTypeIds" class="form-label"
              >Permission Type</label
            >
            <select
              class="form-select"
              id="permissionTypeId"
              v-model="permissions.permissionTypeId"
              required
            >
              <option value="" disabled>Select</option>
              <option
                v-for="tipo in permissionsType"
                :key="tipo.id"
                :value="tipo.id"
              >
                {{ tipo.description }}
              </option>
            </select>
          </div>
        </div>
        <div class="col-md-6">
          <div class="mb-3">
            <label for="lastNameEmployee" class="form-label"
              >Last Name Employee</label
            >
            <input
              type="text"
              class="form-control"
              id="lastNameEmployee"
              v-model="permissions.lastNameEmployee"
              required
            />
          </div>
          <div class="mb-3">
            <label for="permissionDate" class="form-label"
              >Permission Date</label
            >
            <input
              type="date"
              class="form-control"
              id="permissionDate"
              v-model="permissions.permissionDate"
              required
            />
          </div>
        </div>
      </div>
      <div class="d-flex justify-content-end">
        <button type="button" class="btn btn-secondary me-2" @click="resetForm">
          Cancel
        </button>
        <button type="submit" class="btn btn-primary">
          {{ isEdition ? "Update" : "Create" }}
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { useFetchData } from "@/composables/useFetchData";

export default {
  name: "FormularioPermiso",
  data() {
    return {
      permissions: {
        id: 0,
        firstNameEmployee: "",
        lastNameEmployee: "",
        permissionTypeId: null,
        permissionDate: "",
      },
      isEdition: false,
      permissionsType: [],
    };
  },
  methods: {
    submitForm() {
      // Aquí iría la lógica para enviar el formulario al backend
      // Si esEdicion es true, se actualiza el permiso
      // Si esEdicion es false, se crea un nuevo permiso
    },
    async fetchPermissionsType() {
      // Obtiene la función fetchData del composable
      const { data, fetchData } = useFetchData("PermissionType");

      // Ejecuta fetchData y actualiza permissionsType con los datos obtenidos
      await fetchData();
      if (data.value) {
        this.permissionsType = data.value;
      }
    },
    resetForm() {
      this.permissions = {
        id: 0,
        firstNameEmployee: "",
        lastNameEmployee: "",
        permissionTypeId: null,
        permissionDate: "",
      };
    },
  },
  mounted() {
    this.fetchPermissionsType();
  },
};
</script>
