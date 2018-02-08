(function () {

    'use strict';
    angular
        .module('app')
        .controller('appController', appController);

    appController.$inject = ['$http', '$scope'];

    function appController($http, $scope) {

        $scope.setQtdeNumeros = setQtdeNumeros;
        $scope.sortear = sortear;
        $scope.getSurpresinha = getSurpresinha;
        $scope.gravarJogo = gravarJogo;
        $scope.apostas = [];
        $scope.verResultado = false;
        $scope.possuiErro = false;
        $scope.jogarNovamente = jogarNovamente;

        init();
        function init() {

            $scope.qtdeNumeros = 6;

            $scope.jogo = {
                nome: '',
                numeros: []
            };          

            setQtdeNumeros($scope.qtdeNumeros);
            $scope.eSurpresinha = false;
        }


        function gravarJogo()
        {
            $scope.apostas.push($scope.jogo);            
            init();
        }

        function sortear()
        {
            $http.post('/api/jogo/Sortear', $scope.apostas)
                .then(function successCallback(response) {
                    var dados = response.data;
                    if (dados.Sucesso)
                    {   
                        $scope.resultado = dados.Dados;
                        $scope.verResultado = true;
                    }
                    else
                    {
                        $scope.possuiErro = true;
                        $scope.mensagemErro = dados.Mensagem;
                    }
                });
        }

        function getSurpresinha() {

            if (!$scope.eSurpresinha)
                return;

            $http.get('/api/jogo/GetSurpresinha?qtdeNumeros=' + $scope.qtdeNumeros)
                .then(function successCallback(response) {
                    var dados = response.data;
                    for (var i = 0; i < dados.length; i++)
                    {
                        $scope.jogo.numeros[i] = dados[i];
                    }
           });
        }


        function setQtdeNumeros(numeros) {
            $scope.jogo.numeros = [];
            for (var i = 0; i < numeros; i++) {
                var item = '';
                $scope.jogo.numeros.push(item);
            }
        }

        function jogarNovamente() {
            init();
            $scope.verResultado = false;
            $scope.possuiErro = false;
            $scope.apostas = [];
        }

    }


})();