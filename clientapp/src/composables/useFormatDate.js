export function useFormatDate() {
  function formatIsoDate(fechaIso, invert = false) {
    if (!fechaIso) return "";

    const fecha = new Date(fechaIso);
    const dia = fecha.getDate().toString().padStart(2, "0");
    const mes = (fecha.getMonth() + 1).toString().padStart(2, "0");
    const año = fecha.getFullYear();
    // const horas = fecha.getHours().toString().padStart(2, "0");
    // const minutos = fecha.getMinutes().toString().padStart(2, "0");
    // const segundos = fecha.getSeconds().toString().padStart(2, "0");
    if (invert === true) {
      return `${año}-${mes}-${dia}`;
    } else {
      return `${dia}/${mes}/${año}`;
    }
  }

  return { formatIsoDate };
}
