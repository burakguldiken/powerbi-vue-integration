import Vue from "vue";
import Vuex from "vuex";

import powerbi from "./powerbi.module.js";

Vue.use(Vuex);

export default new Vuex.Store({    
  modules: {
    powerbi
  }
});