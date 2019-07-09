<template>
  <div>
    <br>
    <div>
      <b-button variant="dark" :to="{name: 'NewContact'}">Create a Contact</b-button>
    </div>
    <br>
    <b-row>
      <b-col md="12">
        <div id="contacts-table" class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="contact in contacts"
                :key="contact.id">
                <td>{{ contact.firstName }}</td>
                <td>{{ contact.lastName }}</td>
                <td>{{ contact.email }}</td>
                <td>
                  <b-button variant="dark" :href="'/Contact/' + contact.id">Details</b-button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import ContactService from '@/api-service/ContactApiService';

export default {
  name: 'Contacts',
  data() {
    return {
      contacts: [],
    };
  },
  created() {
    ContactService.getAll().then((response) => {
      this.contacts = response.data;
    }).catch((error) => {
      // eslint-disable-next-line
      console.log(error.response.data);
    });
  },
};

</script>
