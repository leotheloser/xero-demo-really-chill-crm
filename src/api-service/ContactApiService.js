import Axios from 'axios';

const API_ENDPOINT = 'https://localhost:5001/api/contact';

export default {
  getAll() {
    return Axios.get(API_ENDPOINT);
  },

  get(id) {
    return Axios.get(`${API_ENDPOINT}/${id}`);
  },

  create(data) {
    return Axios.post(API_ENDPOINT, data);
  },

  update(id, data) {
    return Axios.put(`${API_ENDPOINT}/${id}`, data);
  },

  delete(id) {
    return Axios.delete(`${API_ENDPOINT}/${id}`);
  },
};
