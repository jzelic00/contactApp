app.controller('HomeController', function ($scope,$routeParams,httpRequestServices) {
  
    $scope.Selectors = ["Name", "Lastname", "Tag"];
    $scope.selectedCriteria = ""; 
    $scope.filterValue = "";
    $scope.contacts = [];

    
    //using route params for searching and filtering data
    if ($routeParams.filterValue && $routeParams.selectedCriteria)
    {
        var getFilteredDataPromise = httpRequestServices.getFilteredData($routeParams.filterValue, $routeParams.selectedCriteria);

        getFilteredDataPromise.then(function (response) {
            $scope.contacts = response.data;
        },
            function (error) {
                alert("Pogreška kod dohvaćanja filter vrijednosti " + error.statusText)
            });
    }

    //if user press showAll button
    if ($scope.contacts.length === 0) {
       
        var getAllContactsPromise = httpRequestServices.getAllContacts();

        getAllContactsPromise.then(function (response) {           
            $scope.contacts = response.data;          
            },
            function (error) {
                alert("Pogreška kod dohvaćanja svih kontakata "+ error.statusText)
            });                 
     }

    //deleting choosen contact
    $scope.DeleteContact = function (contact) {

        var deleteUserPromise = httpRequestServices.deleteMethod(contact.ContactID);

        deleteUserPromise.then(function (response) {
            alert("Kontakt uspješno obrisan");          
        },
            function (error) {
                alert("Pogreška prilikom brisanja korisnika: "+ error.statusText );
            });

        var index = $scope.contacts.indexOf(contact);
        $scope.contacts.splice(index, 1);
    }
});