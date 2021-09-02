app.controller('AddContactController', function ($scope,$http,httpRequestServices) {

    $scope.user = {};
    $scope.TagOptions = {};

    $scope.user.Number = [""];
    $scope.user.Mail = [""];
    
    $scope.addNewMail = function () {
        if ($scope.user.Mail[$scope.user.Mail.length - 1] != 0)
            return $scope.user.Mail.push("");

        alert("Prethno polje mail nije ispunjeno");
    }

    $scope.addNewNumber = function () {
        if ($scope.user.Number[$scope.user.Number.length - 1] != "")
            return $scope.user.Number.push("");

        alert("Prethodno polje number nije ispunjeno");
    }

    //get contacts tags
    var getTagsPromise = httpRequestServices.getTags();

    getTagsPromise.
        then(function succesCallback(response) {
            $scope.TagOptions = response.data;
            console.log(response.data);
        }, function errorCallback(error) {
            alert("Greška u dohvaćanju tagova" + error.statusText);
        });

    $scope.savedata = function (user) {
        
        var addContactPromise = httpRequestServices.addContact(user);

        addContactPromise.
            then(function succesCallback(response) {
                console.log(response.data);
            }
            ,function errorCallback(error) {
                alert("Greška u dodavanju kontakta" + error.statusText);
                console.log(user);
            });
    }

    
    
});