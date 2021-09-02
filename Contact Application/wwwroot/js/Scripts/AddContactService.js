app.service('AddContactService', function ($http) {

    this.postMethod = function (user) {

       
        return $http.post('/api/AddContact', { data: user }).
            then(function succesCallback(response) {
                return response.data;
            }
            ), function errorCallback(response) {
                alert("Error in ticket upload, try later");
                return "Nije proslo";
            };
    }

});