import Vue from 'vue'
import Vuetify from 'vuetify/lib'
import "vuetify/dist/vuetify.min.css";

Vue.use(Vuetify)

import pt from 'vuetify/es5/locale/pt'

export default new Vuetify({
    theme: {
        dark: false
    },
    lang: {
        locales: { pt },
        current: 'pt',
    },
    icons: {
        iconfont: 'fa4',
    }
})