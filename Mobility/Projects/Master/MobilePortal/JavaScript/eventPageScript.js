var app = angular.module("eventApp", []);

app.controller("eventAppController", function ($scope) {

//FIXME
//Hack to avoid the HTML input date type to select todays date dynamically
var dtToday = new Date();
var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if(month < 10)
        month = '0' + month.toString();
    if(day < 10)
        day = '0' + day.toString();
var minDate = year + '-' + month + '-' + day;
$scope.MinDate = minDate;

$scope.Event = {
    Name:"",
    Date:"",
    Address:"",
    StartTime:"",
    Contact:"",
    PhoneNo:"",
    Description:""
}

/*TODO: add validation to make sure the submit button is enabled only when all fields are added*/ 
$scope.ValidateEventModel = function(){

}

$scope.SaveEvent = function(){

}

$scope.ResetEventPage = function(){

}
});