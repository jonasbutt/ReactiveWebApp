(function () {
    var app = angular.module('App', []);

    var messagingHub = $.connection.messagingHub;

    app.controller('AppController', ['$scope', function ($scope) {

        $scope.messages = [];

        messagingHub.client.sendMessage = function (message) {
            $scope.messages.push({ text: message.Text });
            $scope.$apply();
        }

        $scope.sendMessage = function () {
            var message = $scope.messageText;
            $scope.messages.push({ text: message });
            $scope.messageText = "";
            messagingHub.server.sendMessage({ Text : message });
        };

    }]);

    $.connection.hub.disconnected(function () {
        setTimeout(function () {
            $.connection.hub.start();
        }, 5000);
    });

    $.connection.hub.start();
    
})();