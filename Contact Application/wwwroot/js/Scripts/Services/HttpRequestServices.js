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
    this.addContact = function (contact) {
        contact.TagID = parseInt(contact.TagID);
       
        return $http({
            method: "post",
            url: "/AddContactController/AddContact",
            dataType: 'json',
            data:contact
        });
    }

    //put new info
    this.editContact = function (contact, id) {
        
        return $http({
            method: "put",
            url: "EditContact/EditContact/" + id,           
            data: contact
        });
    }

    //delete contact
    this.deleteMethod = function (ContactID) {

        return $http.delete('Home/delete', { params: { ContactID: ContactID } });
           
    };

});