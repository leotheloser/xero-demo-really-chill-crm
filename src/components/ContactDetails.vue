<template>
  <div>
    <b-card bg-variant="light">
      <b-form-group
      label-cols-lg="3"
      label="Contact Details"
      label-size="lg"
      label-class="font-weight-bold pt-0"
      class="mb-0">

        <b-form-group
        label-cols="4"
        label-cols-lg="2"
        label-size="Default"
        label="First Name"
        label-for="input_firstname">
          <b-form-input
          id="input_firstname"
          size="sm"
          type="text"
          v-if="editing"
          v-model="form.firstName"
          required
          :placeholder="contact.firstName"/>
          <div class="text-left" v-else>
            <span >{{ contact.firstName }}</span>
          </div>
        </b-form-group>

        <b-form-group
        label-cols="4"
        label-cols-lg="2"
        label-size="Default"
        label="Last Name"
        label-for="input_lastname">
          <b-form-input
          id="input_lastname"
          size="sm"
          type="text"
          v-if="editing"
          v-model="form.lastName"
          required
          :placeholder="contact.lastName"/>
          <div class="text-left" v-else>
            <span >{{ contact.lastName }}</span>
          </div>
        </b-form-group>

        <b-form-group
        label-cols="4"
        label-cols-lg="2"
        label-size="Default"
        label="Email Address"
        label-for="input_sm">
          <b-form-input
          id="input_sm"
          size="sm"
          type="text"
          v-if="editing"
          v-model="form.email"
          required
          :placeholder="contact.email"/>
          <div class="text-left" v-else>
            <span >{{ contact.email }}</span>
          </div>
        </b-form-group>

        <b-form-group
        label-cols="4"
        label-cols-lg="2"
        label-size="Default"
        label="Skype Username"
        label-for="input_skypeusername">
          <b-form-input
          id="input_skypeusername"
          size="sm"
          type="text"
          v-if="editing"
          v-model="form.skypeUserName"
          required
          :placeholder="contact.skypeUserName"/>
          <div class="text-left" v-else>
            <span >{{ contact.skypeUserName }}</span>
          </div>
        </b-form-group>

        <div id="control-btns">
          <b-button
          id="save-btn"
          variant="success"
          v-if="editing"
          v-on:click="saveContact">Save</b-button>
          <b-button
          id="edit-btn"
          variant="success"
          v-else v-on:click="editing = true">Edit</b-button>
          <b-button
          id="delete-btn"
          variant="warning"
          v-on:click="deleteContact">Delete</b-button>
          <b-button
          id="cancel-btn"
          variant="danger"
          v-if="editing"
          href="/Contacts">Cancel</b-button>
        </div>
      </b-form-group>
    </b-card>
  </div>
</template>

<script>
import ContactService from '@/api-service/ContactApiService';

export default {
  name: 'ContactDetails',
  el: '#control-btns',
  data() {
    return {
      editing: false,
      contact: {
        id: '',
        firstName: '',
        lastName: '',
        email: '',
        skypeUserName: '',
        isSyncedWithXero: null,
        xeroContactId: '',
      },
      form: {
        id: '',
        firstName: '',
        lastName: '',
        email: '',
        skypeUserName: '',
        isSyncedWithXero: null,
        xeroContactId: '',
      },
    };
  },
  created() {
    ContactService.get(this.$route.params.id).then((response) => {
      this.contact = response.data;
      this.form = this.contact;
    }).catch((error) => {
      // eslint-disable-next-line
      console.log(error.response.data);
    });
  },
  methods: {
    saveContact(event) {
      if (event) {
        ContactService.update(this.contact.id, this.form).then(() => {
          this.editing = false;
        }).catch((error) => {
          // eslint-disable-next-line
          console.log(error.response.data);
        });
      }
    },
    deleteContact(event) {
      if (event) {
        // eslint-disable-next-line
        console.log(this.contact.id);
        ContactService.delete(this.contact.id).then((response) => {
          this.editing = false;
          // eslint-disable-next-line
          console.log(response.data);
          this.$router.push('/Contacts');
        }).catch((error) => {
          // eslint-disable-next-line
          console.log(error.response.data);
        });
        // eslint-disable-next-line
        console.log('deleted');
      }
    },
  },
};

</script>
