app.service('httpRequestServices', function ($http) {

    //get all contacts
    this.getAllContacts = function () {
        return $http({
            method: 'GET',
            url: '/Home/GetAllContacts'          
        });
    }

    //get tags
    this.getTags = function () {

        return $http({
            method: 'GET',
            url: "/Home/TagOptions"
        });
              
    }

    //getFilteredData
    this.getFilteredData = function (filterValue, selectedCriteria) {
        return $http({
            method: 'GET',
            url: "/Home/" + selectedCriteria + "/" + filterValue
        });
    }

    //get single contact data
    this.getSingleContact = function (id) {
        return $http.get("EditContact/GetContact", { params: { id: id } });
           
    }

    //post new contact
    this.addContact = function (user) {
        user.TagID = parseInt(user.TagID);
        console.log(user);
        return $http.post('/api/AddContact', {user: user });
    }

    //put new info
    this.editContact = function (user, id) {
        
        return $http({
            method: "put",
            url: "EditContact/EditContact/" + id,
            data: user
        });
    }
    //delete contact
    this.deleteMethod = function (userID) {

        return $http.delete('api/delete', { params: { userID: userID } });
           
    };

});