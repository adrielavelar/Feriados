<template>
  <main>
    <data-table v-bind="bindings" @actionTriggered="handleAction" />
  </main>
</template>

<style lang="css">
main {
  padding: 32px;
}
</style>

<script>
import api from "../../lib/feriados";

export default {
    data(){
        return {
            list:[]
        }
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
          }
        ],
      };
    },
  },

  methods: {
    handleAction(actionName, data) {
      console.log(actionName, data);
      window.alert("check out the console to see the logs");
    },

    get() {
      var array = api.get();

      const promise = new Promise((resolve) => {
        resolve(array);
      });

      promise
        .then((values) => {
          this.list= values;
        })
        .catch((error) => alert("Erro: " + error.response.data));
    },
  },

  mounted() {
    this.get();
  },
};
</script>