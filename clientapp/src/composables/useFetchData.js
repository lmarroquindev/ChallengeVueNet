import { ref, onMounted } from "vue";

export function useFetchData(url, httpMethod = "GET") {
  const data = ref(null);
  const error = ref(null);
  const loading = ref(false);
  const apiBaseUrl = process.env.VUE_APP_API_BASE_URL;
  const endpoint = `${apiBaseUrl}/api/${url}`;

  async function fetchData() {
    loading.value = true;
    try {
      const response = await fetch(endpoint, {
        method: httpMethod,
      });
      if (!response.ok) {
        throw new Error("Error al cargar los datos");
      }
      data.value = await response.json();
    } catch (e) {
      error.value = e;
    } finally {
      loading.value = false;
    }
  }

  onMounted(fetchData);

  return { data, error, loading, fetchData };
}
