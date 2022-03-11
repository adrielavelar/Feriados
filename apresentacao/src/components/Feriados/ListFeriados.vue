<template>
  <v-responsive>
    <v-row justify="center">
      <v-dialog v-model="dialog" max-width="290">
        <v-card>
          <v-card-title class="text-h5"> Atenção! </v-card-title>

          <v-card-text>
            Deseja excluir o feriado {{ this.name }}?
          </v-card-text>

          <v-card-actions>
            <v-spacer></v-spacer>

            <v-btn color="red darken-1" text @click="dialog = false">
              Não
            </v-btn>

            <v-btn color="green darken-1" text @click="dialog = false">
              Sim
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
    <v-progress-linear
      v-if="inProgress"
      color="#4BB1EA"
      absolute
      indeterminate
    />
    <v-lazy
      v-model="isActive"
      :options="{
        threshold: 0.5,
      }"
      min-height="200"
      transition="fade-transition"
    >
      <v-card tile>
        <v-card-title>
          <v-spacer></v-spacer>
          <v-text-field
            color="#4BB1EA"
            v-model="search"
            append-icon="mdi-magnify"
            label="Pesquisar"
            single-line
            hide-details
          ></v-text-field>
        </v-card-title>

        <v-data-table
          v-model="selected"
          :headers="headers"
          :items="feriados"
          :search="search"
          :single-select="singleSelect"
          item-key="name"
          class="elevation-1"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon class="mr-2" @click="deleteItem(item)"> fa-trash </v-icon>
          </template>

          <template slot="footer">
            <v-btn
              style="position: absolute; left: 10px; bottom: 10px"
              color="#4BB1EA"
              v-if="!selected.length"
              @click="newFeriado()"
            >
              Novo Feriado
              <v-icon right> fa-plus </v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-card>
    </v-lazy>
  </v-responsive>
</template>

<script>
import api from '../../lib/feriados'

export default {
  methods: {
    viewItem(item) {
      console.log(item);
    },
    deleteItem(item) {
      this.delete(item, true);
    },
    delete(item) {
        this.inProgress = true;
        this.snackbar = true;

        api.delete(item.id)

        var index = this.feriados.findIndex((x) => x.id == item.id);
        this.feriados.splice(index, 1);

        this.snackbar = true;
        this.inProgress = false;
    },
    newFeriado() {
      this.$router.push({ name: "FeriadoCreate" });
    },
    getAll() {
      this.inProgress = true;
      var array = api.get();

      const promise = new Promise((resolve) => {
        setTimeout(() => {
          resolve(array);
        });
      });

      promise
        .then((values) => {
          this.feriados = values;
          console.log(values);
          this.inProgress = false;
        })
        .catch((error) => alert("Erro: " + error.response.data));
    },
  },
  mounted() {
    this.getAll();
  },
  data() {
    return {
      inProgress: false,
      dialog: false,
      name: "",
      crumbs: [
        {
          text: "Feriados",
          disabled: true,
          href: "/feriados/list",
        },
      ],
      isActive: true,
      search: "",
      singleSelect: true,
      selected: [],
      headers: [
        {
          text: "Data",
          align: "start",
          sortable: true,
          value: "date",
        },
        { text: "Título", value: "title" },
        { text: "Descrição", value: "description" },
        { text: "Lei", value: "legislation" },
        { text: "Tipo", value: "type" },
        { text: "Início", value: "startTime" },
        { text: "Fim", value: "endTime" },
        { text: "Ações", value: "actions", sortable: false },
      ],
      feriados: [],
    };
  },
};
</script>