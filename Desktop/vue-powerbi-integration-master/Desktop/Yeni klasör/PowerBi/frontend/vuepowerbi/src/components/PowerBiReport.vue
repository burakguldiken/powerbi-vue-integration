<template>
  <v-container fill-height fluid grid-list-xl>
      <v-layout justify-center wrap>
        <v-row justify="center">
          <v-col cols="12" sm="12" md="12" lg="4">
            <v-flex sm12 md12>
              <v-card elevation="4" light tag="section">
                <v-card-title>
                  <v-layout align-center justify-space-between>
                    <v-flex>
                      <v-img class="ml-3" contain height="48px" position="center left" src="@/assets/powerbi.webp"></v-img>
                    </v-flex>
                  </v-layout>
                </v-card-title>
                <v-divider></v-divider>
                <v-card-text>
                  <p>Please Enter Report Info</p>
                  <v-form>
                    <v-row>
                      <v-col cols="6">
                        <v-text-field
                          outline
                          label="Power Bi Username"
                          type="text"
                          v-model="username">
                        </v-text-field>
                      </v-col>
                      <v-col cols="6">
                        <v-text-field
                          outline
                          hide-details
                          label="Power Bi Password"
                          type="password"
                          v-model="password">
                        </v-text-field>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="12">
                        <v-text-field
                          outline
                          hide-details
                          label="Report ID"
                          type="text"
                          v-model="reportId">
                        </v-text-field>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col>
                        <v-text-field
                        outline
                        hide-details
                        label="Workspace ID"
                        type="text"
                        v-model="workspaceId">
                      </v-text-field>
                      </v-col>
                    </v-row>
                  </v-form>
                </v-card-text>
                <v-divider></v-divider>
                <v-card-actions :class="{ 'pa-3': $vuetify.breakpoint.smAndUp }">
                  <v-spacer></v-spacer>
                  <v-btn @click="viewReport" color="info" small>
                    Görüntüle
                  </v-btn>
                </v-card-actions>
              </v-card>
        </v-flex>
        <v-flex sm12 md6 offset-md3>
        </v-flex>
          </v-col>
          <v-col cols="12" sm="12" md="12" lg="8">
            <div id="container" style="width:80%;height:80%;"></div>
          </v-col>
        </v-row>
      </v-layout>
  </v-container>
</template>

<script>

import { GET_REPORT } from "@/store/actions.type";
import * as pbi from 'powerbi-client';

export default {
  name: 'PowerBiReport',
  data () {
    return {
      password: null,
      username: null,
      reportId:null,
      workspaceId:null,
      reportInfo:{}
    }
  },
  
  methods: {
    viewReport () {
      var request = {
        Username: this.username,
        Password: this.password,
        ReportId: this.reportId,
        WorkspaceId: this.workspaceId
      }
      this.$store
        .dispatch(GET_REPORT, request)
        .then((response) => {
          this.reportInfo = response.data.Data;

          var permissions = pbi.models.Permissions.All
      
          var config = {
                type: 'report',
                tokenType:  pbi.models.TokenType.Embed,
                accessToken: this.reportInfo.AccessToken,
                embedUrl: this.reportInfo.EmbedUrl,
                id: this.reportInfo.ReportId,
                permissions: permissions,
                settings: {
                    filterPaneEnabled: false,
                    navContentPaneEnabled: true
                }
            };
      
          let powerbi = new pbi.service.Service(pbi.factories.hpmFactory, pbi.factories.wpmpFactory, pbi.factories.routerFactory);
      
          var embedContainer = document.getElementById('container');
      
          // Embed the report and display it within the div container.
          console.log(pbi);
          var report = powerbi.embed(embedContainer, config);
      
          // Report.off removes a given event handler if it exists.
          report.off("loaded");
      
          // Report.on will add an event handler which prints to Log window.
          report.on("loaded", function () {
            console.log("Loaded");
          });
      
          // Report.off removes a given event handler if it exists.
          report.off("rendered");
      
          // Report.on will add an event handler which prints to Log window.
          report.on("rendered", function () {
            console.log("Rendered");
          });
      
          report.on("error", function (event) {
            console.log(event.detail);
      
            report.off("error");
          });
      
          report.off("saved");
          report.on("saved", function (event) {
            if (event.detail.saveAs) {
              console.log('In order to interact with the new report, create a new token and load the new report');
            }
          });
            })
            .catch((err) => {
              this.$swal("Hata!", err, "error");
          });
        },
  }
}

</script>

<style>
.v-btn,.v-card {
  border-radius: 4px
}
.v-card__title {
  text-transform: uppercase
}
</style>