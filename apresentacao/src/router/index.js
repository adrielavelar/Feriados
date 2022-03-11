import Vue from 'vue'
import VueRouter from 'vue-router'

import Feriados from '../components/Feriados/ListFeriados.vue'

Vue.use(VueRouter)

const router = new VueRouter({
    mode: 'history',
    routes:[
        {
            path: '/',
            name: 'Feriados',
            component: Feriados,
            meta: {
                title: 'Feriados'
            }
        }
    ]
})

export default router