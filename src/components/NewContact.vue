<template>
  <div>
    <b-form @submit="onSubmit">
      <b-form-group id="InputGroup1" label="First Name:" label-for="Input1">
        <b-form-input
          id="Input1"
          type="text"
          v-model="form.firstName"
          required
          placeholder="Enter first name" />
      </b-form-group>

      <b-form-group id="InputGroup2" label="Last Name:" label-for="Input2">
        <b-form-input
          id="Input2"
          type="text"
          v-model="form.lastName"
          required
          placeholder="Enter lastname" />
      </b-form-group>

      <b-form-group
        id="InputGroup3"
        label="Email address:"
        label-for="Input3"
      >
        <b-form-input
          id="Input3"
          type="email"
          v-model="form.email"
          required
          placeholder="Enter email"/>
      </b-form-group>

      <b-form-group id="InputGroup4" label="Skype Username:" label-for="Input4">
        <b-form-input
          id="Input4"
          type="text"
          v-model="form.skypeUserName"
          required
          placeholder="Enter Skype username" />
      </b-form-group>

      <b-button type="submit" variant="primary">Create</b-button>
      <b-button type="cancel" variant="danger" href="/Contacts">Cancel</b-button>
    </b-form>
  </div>
</template>

<script>
import ContactService from '@/api-service/ContactApiService';

export default {
  name: 'NewContact',
  data() {
    return {
      form: {
        firstName: '',
        lastName: '',
        email: '',
        skypeUserName: '',
      },
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      ContactService.create(this.form).then((response) => {
        // eslint-disable-next-line
        console.log(response.data);
        this.$router.push('Contacts');
      }).catch((error) => {
        // eslint-disable-next-line
        console.log(error.response.data);
      });
    },
  },
};
</script>

<style>
label {
  text-align: left;
}
</style>
