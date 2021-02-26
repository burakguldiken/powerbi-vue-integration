import apiService from "@/common/api.service";

import {
  GET_REPORT,
} from "@/store/actions.type";

import { 
    SET_REPORT,
} from "@/store/mutations.type";

const state = {
    report: {},
};

const getters = {
    getReport:(state) => {
        return state.report;
    },
};

const actions = {
    [GET_REPORT](context,payload) {
      return new Promise((resolve, reject) => {
        apiService
          .post(`PowerBi/getreport`,payload)
          .then((response) => {
            context.commit(SET_REPORT, response);
            resolve(response);
          })
          .catch((err) => {
            reject(err);
          });
      });
    },
}

const mutations = {
    [SET_REPORT](state, payload) {
      state.data = payload.data.Data;
    },
  };
  
  export default {
    state,
    actions,
    mutations,
    getters,
  };