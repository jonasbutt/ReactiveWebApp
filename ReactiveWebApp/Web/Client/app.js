(function () {
    var app = angular.module('App', []);

    var messageHub = $.connection.messageHub;

    app.controller('AppController', ['$scope', function ($scope) {

        $scope.messages = [];

        messageHub.client.sendMessage = function (message) {
            $scope.messages.push({ text: message });
            $scope.$apply();
        }

        $scope.sendMessage = function () {
            var message = $scope.messageText;
            $scope.messages.push({ text: message });
            $scope.messageText = "";
            messageHub.server.sendMessage(message);
        };

    }]);

    $.connection.hub.disconnected(function () {
        setTimeout(function () {
            $.connection.hub.start();
        }, 5000);
    });

    $.connection.hub.start();
    
})();