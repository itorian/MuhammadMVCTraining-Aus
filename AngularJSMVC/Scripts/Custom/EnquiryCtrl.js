

// Controller is update with the custome Repo and window service dependancy
myEnquiry.controller("EnquiryCtrl", ["$scope", "$window", "Repo", function ($scope, $window, $Repo) {
    $scope.enquiries = [];
    $scope.c = { Id: "", Name: "", Email: "", Contact: "", Details: "" };

    $scope.IsInEditMode = false;

    clearFields = function () {
        $scope.c.Id = "";
        $scope.c.Name = "";
        $scope.c.Email = "";
        $scope.c.Contact = "";
        $scope.c.Details = "";
        $scope.IsInEditMode = false;
    };
    $scope.clearFields = clearFields;

    addEnquiry = function (enquiry) {
        $Repo.addEnquiry(enquiry)
            .success(function (data, status, header, config) {
                getEnquiries();
                clearFields();
                $scope.isEditMode = false;
                $("#name").focus();
            })
            .error(function (data, status, header, config) {
                alert("Error: Something went wrong");
            });
    };
    $scope.addEnquiry = addEnquiry;

    doEdit = function (enquiry) {
        var localCopy = angular.copy(enquiry);
        $scope.c.Id = localCopy.Id;
        $scope.c.Name = localCopy.Name;
        $scope.c.Email = localCopy.Email;
        $scope.c.Contact = localCopy.Contact;
        $scope.c.Details = localCopy.Details;
        $scope.IsInEditMode = true;
    }
    $scope.doEdit = doEdit;

    getEnquiries = function () {
        $Repo.GetEnquiries()
            .success(function (data, status, header, config) {
                $scope.enquiries = data;
            })
            .error(function (data, status, header, config) {
                alert("Error: Something went wrong");
            })
    };

    editEnquiry = function (xEnquiry) {
        $Repo.editEnquiry(xEnquiry).success(function (data, status, header, config) {
            getEnquiries();
            clearFields();
            $scope.isEditMode = false;
        })
        .error(function (data, status, header, config) {
            alert("Error: Something went wrong");
        });
    }
    $scope.editEnquiry = editEnquiry;

    deleteEnquiry = function (Id) {
        if ($window.confirm("Are you sure you want to delete the enquiry")) {
            $Repo.deleteEnquiry(Id).success(function (data, status, header, config) {
                getEnquiries();
                clearFields();
                $scope.isEditMode = false;
            }).error(function (data, status, header, config) {
                alert("Error: Something went wrong");
            });
        }
    }
    $scope.deleteEnquiry = deleteEnquiry;

    haveEnquiries = function () {
        return $scope.enquiries.length > 0 ? true : false;
    }
    $scope.haveEnquiries = haveEnquiries;

    clearFields();
    getEnquiries();
}]);
