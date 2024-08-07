

<script>
  import axios  from 'axios'
  import Swal from 'sweetalert2'

export default {
  name: 'HelloWorld',
  data() {
    return {
      users: []
    }
  },
  methods:
    {
      delUser(id)
      {
        axios
        .delete(`/api/Users/${id}`)
         // console.log(id);
         location.reload();  
      },


      // ajouter user
      addUser()
      {
        const { value: formValues } = Swal.fire({
  title: "add user",
  html: `
    <input id="swal-input1" class="swal2-input" >
    <input id="swal-input2" class="swal2-input" >
  `,
  focusConfirm: false,
  preConfirm: () => {
    const u = {"nom":document.getElementById("swal-input1").value,"prenom":document.getElementById("swal-input2").value}
    axios.post(`/api/Users`,u);
    location.reload(); 
  }
});
if (formValues) {
  Swal.fire(JSON.stringify(formValues));
}
      },

      //update user
      updateUser(user)
      {
        
        const { value: formValues } = Swal.fire({
  title: "update user",
  html: `
    <input id="swal-input1" class="swal2-input" value=${user.nom}>
    <input id="swal-input2" class="swal2-input" value=${user.prenom}>
  `,
  focusConfirm: false,
  preConfirm: () => {
    const u = {"id":user.id,"nom":document.getElementById("swal-input1").value,"prenom":document.getElementById("swal-input2").value}
    axios.put(`/api/Users?id=${u.id}`,u);
    location.reload(); 
  }
});
if (formValues) {
  Swal.fire(JSON.stringify(formValues));
}

          //console.log(id);
      }
      
    },

  
  created()
    {

      axios
      .get('/api/Users')
      .then((response) => {
        this.users = response.data
      })
    },
  }
</script>

<template>
  <div class="mx-auto p-2" style="width: 800px;">
    <h1>CRUD user</h1>
<table   class="table table-striped">
 
    <tr>   
    <th>first name</th>
    <th>last name</th>
    <th></th>
    <th></th>
  </tr>
  
    
      <tr v-for="user in users" :key="user.id">
        
        <td>
          {{ user.nom }}  
        </td>
        <td>
          {{ user.prenom }}
        </td>
        <td>
          <button class="btn btn-primary" @click="updateUser(user)">modifier</button>
        </td>
        <td>
          <button class="btn btn-danger"  @click="delUser(user.id)">suprimer</button>
        </td>
      </tr> 
  </table>
  <button type="button" class="btn btn-success" @click="addUser()">add user</button>
  </div>
</template>

<style>
div{
  margin-top: 100px;
}
h1{
  margin-bottom: 50px;
}
</style>