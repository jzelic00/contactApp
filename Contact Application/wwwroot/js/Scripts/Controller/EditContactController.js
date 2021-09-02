app.controller('EditContactController', function ($scope, $routeParams, httpRequestServices) {

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

    var id = $routeParams.id;

    //getting single contact info
    var getSingleContactPromise = httpRequestServices.getSingleContact(id);

    getSingleContactPromise.then(function (response) {
        
        $scope.user = response.data;
        //potrebno zbog toga sto nece populate napravit u selecetu ako je inteegr
        $scope.user.tagID = $scope.user.tagID.toString();
    }, function errorCallback(error) {
        alert("Greška u dohvaćanju kontakta" + error.statusText);
    });
    

    
    $scope.savedata = function (user) {
       
        var editContactPromise = httpRequestServices.editContact(user,id);
       
        editContactPromise.
            then(function succesCallback(response) {
                console.log(response);
            }
            , function errorCallback(error) {
                alert("Greška u dodavanju kontakta" + error.statusText);
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