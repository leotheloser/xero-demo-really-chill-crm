import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/components/Home';
import NotFound from '@/components/NotFound';
import Contacts from '@/components/Contacts';
import ContactDetails from '@/components/ContactDetails';
import NewContact from '@/components/NewContact';
import Integration from '@/components/Integration';


Vue.use(Router);

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
    },
    {
      path: '/Contacts',
      name: 'Contacts',
      component: Contacts,
    },
    {
      path: '/Contact/:id',
      name: 'ContactDetails',
      component: ContactDetails,
    },
    {
      path: '/NewContact',
      name: 'NewContact',
      component: NewContact,
    },
    {
      path: '/Integration',
      name: 'Integration',
      component: Integration,
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound,
    },
  ],
});
