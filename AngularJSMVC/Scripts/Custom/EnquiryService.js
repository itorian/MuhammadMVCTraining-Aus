

// Angular service to handle all remote server interactions
var myEnquiry = angular.module("EnquiryList", []);

myEnquiry.service("Repo", ["$http", function ($http) {

    // Add new Enquiry
    this.addEnquiry = function (usr) {
        var enquiryObj = { "Id": usr.Id, "Name": usr.Name, "Email": usr.Email, "Contact": usr.Contact, "Details": usr.Details }
        var config = { method: "POST", url: "/Enquiry/CreateEnquiry", data: enquiryObj };
        return $http(config);
    };

    // Get All Enquiries
    this.GetEnquiries = function () {
        return $http.get("/Enquiry/GetEnquiries");
    };

    // Get Single Enquiry
    this.GetEnquiry = function (id) {
        var config = { method: "GET", url: "/Enquiry/GetEnquiry", data: Id };
        $http(config)
            .success(function (data, status, header, config) {
                alert(data);
            }).error(function (data, status, header, config) {
                alert("Error: Something went wrong");
            });
    };

    // Edit Enquiry
    this.editEnquiry = function (usr) {
        var enquiryObj = { "Id": usr.Id, "Name": usr.Name, "Email": usr.Email, "Contact": usr.Contact, "Details": usr.Details };
        var config = { method: "POST", url: "/Enquiry/UpdateEnquiry", data: enquiryObj };
        return $http(config);
    };

    // Delete Enquiry
    this.deleteEnquiry = function (id) {
        var enquiryObj = { "Id": id };
        var config = { method: "POST", url: "/Enquiry/DeleteEnquiry", data: enquiryObj };
        return $http(config);
    };

}]);
