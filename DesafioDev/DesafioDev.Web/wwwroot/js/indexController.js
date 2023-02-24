app.controller("indexController", function ($scope, $http) {
    $http.get("/Transaction").then(function (response) {
        var data = response.data;
        $scope.transactionsList = data.transactions;
        $scope.totalAmount = data.totalAmount;

        $scope.getTypeText = function (type) {
            switch (type) {
                case 1:
                    return "Débito";
                case 2:
                    return "Boleto";
                case 3:
                    return "Financiamento";
                case 4:
                    return "Crédito";
                case 5:
                    return "Recebimento Empréstimo";
                case 6:
                    return "Vendas";
                case 7:
                    return "Recebimento TED";
                case 8:
                    return "Recebimento DOC";
                case 9:
                    return "Aluguel";
                default:
                    return "";
            }
        };

        $scope.formatDateTime = function (dateString) {
            var year = dateString.substr(0, 4);
            var month = dateString.substr(4, 2);
            var day = dateString.substr(6, 2);
            return `${day}/${month}/${year}`;
        };

        $scope.formatHours = function (hourString) {
            var hour = hourString.substr(0, 2);
            var minute = hourString.substr(2, 2);
            var second = hourString.substr(4, 2);
            return `${hour}:${minute}:${second}`;
        };

        $scope.maskCpf = function (cpf) {
            const cpfPattern = /^(\d{3})(\d{3})(\d{3})(\d{2})$/;
            return cpf.replace(cpfPattern, "$1.$2.$3-$4");
        }
    });
});