app.controller("uploadController", ['$scope', 'fileUpload', function ($scope, fileUpload) {
    $scope.uploadFile = function () {
        var file = $scope.myFile;
        fileUpload.uploadFileToUrl(file, '/Transaction');
    };
}]);