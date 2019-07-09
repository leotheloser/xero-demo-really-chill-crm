import Axios from 'axios';

const API_ENDPOINT = 'https://localhost:5001/api/auth/check';

export default {
  checkConnection() {
    return Axios.get(API_ENDPOINT);
  },
};
