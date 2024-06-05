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
        <button
          type="button"
          class="btn btn-secondary me-2"
          @click="handlerCancel"
        >
          Cancel
        </button>
        <button type="submit" class="btn btn-primary" @click="handlerSave">
          {{ isEdition ? "Update" : "Create" }}
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { useFetchData } from "@/composables/useFetchData";
import { useFormatDate } from "@/composables/useFormatDate";

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
      permissionsType: [],
    };
  },
  computed: {
    isEdition() {
      return (
        this !== undefined &&
        this.id !== undefined &&
        this.id !== null &&
        this.id !== 0
      );
    },
  },
  props: {
    id: {
      type: [Number, String],
      default: null,
      required: false,
    },
  },
  methods: {
    handlerCancel() {
      this.$emit("close-form");
      this.resetForm();
    },
    async handlerSave() {
      if (this.isEdition === true) {
        const { fetchData } = useFetchData(
          `Permission/${this.id}`,
          "PUT",
          this.permissions
        );

        await fetchData();
      } else {
        const { fetchData } = useFetchData(
          `Permission`,
          "POST",
          this.permissions
        );

        await fetchData();
      }

      this.$emit("close-form");
      this.resetForm();
    },
    async fetchPermissionsType() {
      const { data, fetchData } = useFetchData("PermissionType");

      await fetchData();
      if (data.value) {
        this.permissionsType = data.value;
      }
    },
    async fetchPermissionById() {
      if (this.isEdition === true) {
        const { data, fetchData } = useFetchData(`Permission/${this.id}`);
        await fetchData();
        if (data.value) {
          this.permissions = data.value;
          const { formatIsoDate } = useFormatDate();
          this.formattedDate = formatIsoDate(this.formattedDate);
        }
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
    this.resetForm();
    this.fetchPermissionsType();
    this.fetchPermissionById();
  },
};
</script>
