<template>
  <v-app>
    <v-main>
      <PowerBiReport/>
    </v-main>
  </v-app>
</template>

<script>
import PowerBiReport from './components/PowerBiReport';

export default {
  name: 'App',

  components: {
    PowerBiReport,
  },

  data: () => ({
    //
  }),
};
</script>
