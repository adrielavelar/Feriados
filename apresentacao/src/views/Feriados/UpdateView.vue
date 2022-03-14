<template>
  <main>
      <div class="form-group row">
        <label for="data">Data</label>
        <input
          v-model="form.date"
          type="text"
          class="form-control"
          id="inputData"
          aria-describedby="dataHelp"
          placeholder="Insira uma data"
        />
      </div>
      <div class="form-group row">
        <label for="titulo">Título</label>
        <input
          v-model="form.title"
          type="text"
          class="form-control"
          id="inputTitulo"
          aria-describedby="tituloHelp"
          placeholder="Insira um título"
        />
      </div>
      <div class="form-group row">
        <label for="descricao">Descrição</label>
        <input
          v-model="form.description"
          type="text"
          class="form-control"
          id="inputDescricao"
          aria-describedby="descricaoHelp"
          placeholder="Insira uma descrição"
        />
      </div>
      <div class="form-group row">
        <label for="lei">Lei</label>
        <input
          v-model="form.legislation"
          type="text"
          class="form-control"
          id="inputLei"
          aria-describedby="leiHelp"
          placeholder="Insira uma lei"
        />
      </div>
      <div class="form-group row">
        <label for="tipo">Tipo</label>
        <input
          v-model="form.type"
          type="text"
          class="form-control"
          id="inputTipo"
          aria-describedby="tipoHelp"
          placeholder="Insira um tipo"
        />
      </div>
      <div class="form-group row">
        <label for="inicio">Início</label>
        <input
          v-model="form.startTime"
          type="text"
          class="form-control"
          id="inputInicio"
          aria-describedby="inicioHelp"
          placeholder="Insira o início"
        />
      </div>
      <div class="form-group row">
        <label for="fim">Fim</label>
        <input
          v-model="form.endTime"
          type="text"
          class="form-control"
          id="inputFim"
          aria-describedby="fimHelp"
          placeholder="Insira o fim"
        />
      </div>
      <div class="form-group row">
        <button @click="submit" class="btn btn-primary">Atualizar</button>
      </div>
  </main>
</template>

<script>
import api from '../../lib/feriados'

export default {
  data() {
    return {
      form: {
        date: "",
        title: "",
        description: "",
        legislation: "",
        type: "",
        startTime: "",
        endTime: "",
      },
    };
  },
  created(){
      this.form =  this.$route.params.data
  },
  methods:{
      submit(){
        api.edit(this.form)
        setTimeout(() => {
          this.$router.push('/feriados')
        }, 3000);
      }
  }
};
</script>

<style lang="css">
main {
  padding: 32px;
}
</style>