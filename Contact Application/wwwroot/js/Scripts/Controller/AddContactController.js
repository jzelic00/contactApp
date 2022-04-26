app.controller('AddContactController', function ($scope,UIService,httpRequestServices) {

    $scope.contact = {};
    $scope.TagOptions = {};

    $scope.contact.Number = [{ PhoneNumber: "" }];
    $scope.contact.Mail = [{ MailAddress: "" }];
    
    $scope.addNewMail = function () {
       $scope.contact.Mail= UIService.AddMail($scope.contact.Mail);
    }

    $scope.addNewNumber = function () {
        $scope.contact.Number = UIService.AddPhoneNumber($scope.contact.Number);
    }

    //get contacts tags
    var getTagsPromise = httpRequestServices.getTags();

    getTagsPromise.
        then(function succesCallback(response) {
            $scope.TagOptions = response.data;
           
        }, function errorCallback(error) {
            alert("Greška u dohvaćanju tagova" + error.statusText);
        });

    $scope.savedata = function (contact) {
        contact.TagID = parseInt(contact.TagID);
        var addContactPromise = httpRequestServices.addContact(contact);
        
        addContactPromise.
            then(function succesCallback(response) {               
                alert("Kontakt uspješno dodan");
            }
            ,function errorCallback(error) {
                alert("Greška u dodavanju kontakta" + error.statusText);               
                });
       
        $scope.contact = {};
        $scope.contact.Number = [{ PhoneNumber: "" }];
        $scope.contact.Mail = [{ MailAddress: "" }];
    }
   
});