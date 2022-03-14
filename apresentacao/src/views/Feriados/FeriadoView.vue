<template>
  <main>
    <data-table v-bind="bindings" @actionTriggered="handleAction" />
  </main>
</template>

<script>
import api from "../../lib/feriados";

export default {
  data() {
    return {
      list: [],
    };
  },
  computed: {
    bindings() {
      return {
        data: this.list,
        lang: "pt-br",
        tableClass: "table table-striped table-hover table-bordered",
        actions: ["edit", "delete"],
        actionMode: "single",
        columns: [
          { key: "id" },
          {
            key: "date",
            title: "Data",
          },
          {
            key: "title",
            title: "Título",
          },
          {
            key: "description",
            title: "Descrição",
          },
          {
            key: "legislation",
            title: "Lei",
          },
          {
            key: "type",
            title: "Tipo",
          },
          {
            key: "startTime",
            title: "Início",
          },
          {
            key: "endTime",
            title: "Fim",
          },
        ],
      };
    },
  },

  methods: {
    handleAction(actionName, data) {
      if (actionName === "edit") {
        this.$router.push({ name: "feriadosUpdate", params: { data } });
      } else {
        api.delete(data.id);
        var index = this.list.findIndex((x) => x.id == data.id);
        this.list.splice(index, 1);
      }
    },

    get() {
      var array = api.get();

      const promise = new Promise((resolve) => {
        resolve(array);
      });

      promise
        .then((values) => {
          this.list = values;
        })
        .catch((error) => alert("Erro: " + error.response.data));
    },
  },

  mounted() {
    this.get();
  },
};
</script>

<style lang="css">
main {
  padding: 32px;
}
</style>