"use strict";

var app = angular.module("eventApp", []);

app.controller("eventAppController", ['$scope', function ($scope) {

    //FIXME
    //Hack to avoid the HTML input date type to select todays date dynamically
    var dtToday = new Date();
    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    if (day < 10)
        day = '0' + day.toString();
    var minDate = year + '-' + month + '-' + day;
    $scope.MinDate = minDate;

    $scope.Event = {
        Name: "",
        Date: "",
        Address: "",
        StartTime: "",
        Contact: "",
        PhoneNo: "",
        Description: ""
    };

    $scope.ResetEventModel = function () {
        $scope.Event = {};
    };

    $scope.IsValidData = function () {
        //TODO: validation using regex for names and other field value
    };

    $scope.SaveEvent = function () {
        //TODO: Validate the scope model and call the service
        if ($scope.EventForm.$valid) {
            //TODO: Call service as all fields are filled
            alert('TODO: Call service and save data');
        } else {
            alert('Please enter all the details of the event before you submit');
        }
    };

    $scope.ResetEventPage = function () {

        //TODO:Only if the element has changed you should show the pop up
        if (confirm("Would you like to reset the form?")) {
            $('#EventInputForm input[type="text"]').val('');
            $('#EventInputForm input[type="date"]').val('');
            $('#EventInputForm input[type="time"]').val('');
            $('#EventInputForm #eventAddress').val('');
            $('#EventInputForm #eventDescription').val('');
            $scope.ResetEventModel();
        }
    };
}]);