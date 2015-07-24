(function () {
    'use strict';

    angular.module('app').factory('MoviesService', MoviesService);

    MoviesService.$inject = ['$log','$q', '$http'];

    function MoviesService($log, $q, $http) {

        var service = {
            getMovies: getMovies
        }

        function getMovies() {

            var requestDefer = $q.defer();

            $http.get('http://localhost:4747/api/movies')
                .then(
                //success response
                function (response) {
                requestDefer.resolve(response.data);
                },
                //failure response
                function (error) {
                    requestDefer.reject("Movies not found");
                }
                );
         
            return requestDefer.promise;
        }
        
        return service;
    }
})();