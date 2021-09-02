app.config(['$routeProvider','$locationProvider',function ($routeProvider, $locationProvider) {

    $routeProvider
        .when("/showAll", {
            templateUrl: "Home/contactPartialView",
            controller:"HomeController"
        })
        .when("/AddContact", {
            templateUrl: "AddContact/AddContact",
            controller:'AddContactController'
        })
        .when("/contact/:id", {
            templateUrl: "EditContact/Index",
            controller: 'EditContactController'
        })
        .when("/search/:selectedCriteria/:filterValue", {
            templateUrl: "Home/contactPartialView",
            controller:"HomeController"
        })
        .otherwise({
            redirectTo: '/'
        });

}]);