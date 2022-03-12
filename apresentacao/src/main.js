import Vue from 'vue'
import App from './App.vue'
import router from './router'
import DataTable from "@andresouzaabreu/vue-data-table";

import "bootstrap/dist/css/bootstrap.min.css";
import "@andresouzaabreu/vue-data-table/dist/DataTable.css";

Vue.component("data-table", DataTable);

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
