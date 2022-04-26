app.controller('EditContactController', function ($scope,UIService, $routeParams, httpRequestServices) {

    $scope.contact = {};
    $scope.TagOptions = {};

    $scope.contact.Number = [{ PhoneNumber: "" }];
    $scope.contact.Mail = [{ MailAddress: "" }];

    $scope.addNewMail = function () {
        $scope.contact.Mail = UIService.AddMail($scope.contact.Mail);
    }

    $scope.addNewNumber = function () {
        $scope.contact.Number = UIService.AddPhoneNumber($scope.contact.Number);
    }

    var id = $routeParams.id;

    //getting single contact info
    var getSingleContactPromise = httpRequestServices.getSingleContact(id);

    getSingleContactPromise.then(function (response) {
        
        $scope.contact = response.data;
        //potrebno zbog toga sto nece populate napravit u selecetu ako je inteegr
        $scope.contact.TagID = $scope.contact.TagID.toString();
    }, function errorCallback(error) {
        alert("Greška u dohvaćanju kontakta" + error.statusText);
    });
      
    $scope.savedata = function (contact) {
       
        var editContactPromise = httpRequestServices.editContact(contact,id);
       
        editContactPromise.
            then(function succesCallback(response) {
                alert("Podaci kontakta uspješno promijenjeni");               
            }
            , function errorCallback(error) {
                alert("Greška u promjeni informacija kontakta" + error.statusText);
            });      
    };
    
    //get contacts tags
    var getTagsPromise = httpRequestServices.getTags();

    getTagsPromise.
        then(function succesCallback(response) {
            $scope.TagOptions = response.data;
        }
            , function errorCallback(error) {
                alert("Greška u dohvaćanju tagova" + error.statusText);
            });
    
});