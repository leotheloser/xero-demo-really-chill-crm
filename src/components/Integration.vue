<template>
  <div>
    <h1>Xero Integration Settings</h1>
    <div v-if="connected">
      <b-row align-h="center">
        <span>Your are connected to <b>{{ organisationName }}</b> Xero Organisation</span>
      </b-row>
      <b-row align-h="center">
        <a :href="disconnectUrl">
          <img src="../assets/disconnect-blue.png">
        </a>
      </b-row>
    </div>
    <div v-else>
      <b-row align-h="center">
        <span>Click below to connect your Xero organisation: </span>
      </b-row>
      <b-row align-h="center">
        <a :href="authUrl">
          <img src="../assets/connect-blue.png">
        </a>
      </b-row>
    </div>

  </div>
</template>

<script>
import XeroApiService from '@/api-service/XeroApiService';

export default {
  name: 'Integration',
  data() {
    return {
      connected: false,
      organisationName: '',
      oauthStatus: '',
      authUrl: 'https://localhost:5001/api/auth',
      disconnectUrl: 'https://localhost:5001/api/auth/disconnect',
    };
  },
  created() {
    XeroApiService.checkConnection().then((response) => {
      this.organisationName = response.data.name;
      this.connected = true;
      // eslint-disable-next-line
      console.log(this.organisationName);
    }).catch((error) => {
      this.connected = false;
      // eslint-disable-next-line
      console.log(error.response.data);
    });
  },
};
</script>
