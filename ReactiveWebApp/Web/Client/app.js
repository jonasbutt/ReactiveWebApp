(function () {
    var app = angular.module('App', []);

    var messagingHub = $.connection.messagingHub;

    app.controller('AppController', ['$scope', function ($scope) {

        $scope.messages = [];

        messagingHub.client.sendMessage = function (message) {
            $scope.messages.push(message);
            $scope.$apply();
        }

        $scope.sendMessage = function () {
            var message = { Text: $scope.messageText };
            $scope.messageText = "";
            $scope.messages.push(message);
            messagingHub.server.sendMessage(message);
        };

        $scope.requestStatusUpdate = function () {
            messagingHub.server.requestStatusUpdate();
        };

    }]);

    $.connection.hub.disconnected(function () {
        setTimeout(function () {
            $.connection.hub.start();
        }, 5000);
    });

    $.connection.hub.start();
    
})();