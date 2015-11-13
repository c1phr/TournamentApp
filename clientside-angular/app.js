angular.module("tournament", [])
  .controller("TournamentController", TournamentController);

  function TournamentController($http) {

      this.test = "Hello";

      var vm = this;

      vm.tournamentInformation = tournamentInformation;

      vm.tournamentInformation();

      function tournamentInformation () {
        $http.get('http://acmtournamentapi.azurewebsites.net/api/Match/dota').then(function(data) {
          console.log(data);
          vm.currentGameData = data.data;
        })
      }

  }
