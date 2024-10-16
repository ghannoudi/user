<script>
  import axios from 'axios';

export default {
  name: 'HelloWorld',
  data() {
    return {
      users: [],
      showModal: false,
      modalMode: '',
      modalData: {
        id: null,
        nom: '',
        prenom: ''
      }
    }
  },
  methods: {
    delUser(id) {
      this.showModal = true;
      this.modalMode = 'delete';
      this.modalData.id = id;
    },

    confirmDelete() {
      axios.delete(`/api/Users/${this.modalData.id}`)
        .then(() => {
          this.fetchUsers();
          this.closeModal();
        });
    },

    addUser() {
      this.showModal = true;
      this.modalMode = 'add';
      this.modalData.nom = '';
      this.modalData.prenom = '';
    },

    updateUser(user) {
      this.showModal = true;
      this.modalMode = 'update';
      this.modalData.id = user.id;
      this.modalData.nom = user.nom;
      this.modalData.prenom = user.prenom;
    },

    confirmSave() {
      if (this.modalMode === 'add') {
        const user = { nom: this.modalData.nom, prenom: this.modalData.prenom };
        axios.post('/api/Users', user).then(() => {
          this.fetchUsers();
          this.closeModal();
        });
      } else if (this.modalMode === 'update') {
        const updatedUser = { id: this.modalData.id, nom: this.modalData.nom, prenom: this.modalData.prenom };
        axios.put(`/api/Users?id=${updatedUser.id}`, updatedUser).then(() => {
          this.fetchUsers();
          this.closeModal();
        });
      }
    },

    closeModal() {
      this.showModal = false;
    },

    fetchUsers() {
      axios.get('/api/Users')
        .then((response) => {
          this.users = response.data;
        });
    }
  },

  created() {
    this.fetchUsers();
  },
}
</script>

<template>
  <div class="mx-auto p-2" style="width: 800px;">
    <h1>CRUD User </h1>
    <table class="table table-striped">
      <tr>
        <th>First Name</th>
        <th>Last Name</th>
        <th></th>
        <th></th>
      </tr>
      <tr v-for="user in users" :key="user.id">
        <td>{{ user.nom }}</td>
        <td>{{ user.prenom }}</td>
        <td>
          <button class="btn btn-primary" @click="updateUser(user)">Modifier</button>
        </td>
        <td>
          <button class="btn btn-danger" @click="delUser(user.id)">Supprimer</button>
        </td>
      </tr>
    </table>
    <button type="button" class="btn btn-success" @click="addUser()">Add User</button>

    <!-- Modal -->
    <div v-if="showModal" class="modal-overlay">
      <div class="modal-container">
        <h3 v-if="modalMode === 'add'">Add User</h3>
        <h3 v-if="modalMode === 'update'">Update User</h3>
        <h3 v-if="modalMode === 'delete'">Delete User</h3>

        <div v-if="modalMode !== 'delete'">
          <input v-model="modalData.nom" placeholder="First Name" class="form-control" />
          <input v-model="modalData.prenom" placeholder="Last Name" class="form-control" />
        </div>

        <div v-if="modalMode === 'delete'">
          <p>Are you sure you want to delete this user?</p>
        </div>

        <button class="btn btn-primary" @click="confirmSave" v-if="modalMode !== 'delete'">Save</button>
        <button class="btn btn-danger" @click="confirmDelete" v-if="modalMode === 'delete'">Delete</button>
        <button class="btn btn-secondary" @click="closeModal">Cancel</button>
      </div>
    </div>
  </div>
</template>

<style>
div {
  margin-top: 100px;
}

h1 {
  margin-bottom: 50px;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal-container {
  background-color: white;
  padding: 20px;
  border-radius: 5px;
  text-align: center;
  width: 300px;
}

.form-control {
  width: 100%;
  margin-bottom: 15px;
  padding: 10px;
  box-sizing: border-box;
}
</style>
