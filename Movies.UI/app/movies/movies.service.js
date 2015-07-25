(function () {
    'use strict';

    angular.module('app').factory('MoviesService', MoviesService);

    MoviesService.$inject = ['$log','$q', '$http'];

    function MoviesService($log, $q, $http) {

        var service = {
            getMovies: getMovies,
            getMovie: getMovie,
            updateMovie: updateMovie,
            addMovie: addMovie
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

        function getMovie(id)
        {
            var requestDefer = $q.defer();

            $http.get('http://localhost:4747/api/movies/' + id)
                 .then(
                 //success callback
                 function (response) {
                     requestDefer.resolve(response.data);
                 },
                 //failure callback
                 function (error) {
                     requestDefer.reject("Movie with {0} not found", id);
                 }
                 );

            return requestDefer.promise;
        }

        function updateMovie(movie)
        {
            var requestDefer = $q.defer();

            $http.put('http://localhost:4747/api/movies/' + movie.movieId, movie)
                 .then(
                 //success callback
                 function (response) {
                     requestDefer.resolve(response.status);
                 },
                 //failure callback
                 function (error) {
                     requestDefer.reject("Movie with {0} is not updated", movie.movieId);
                 }
                 );

            return requestDefer.promise;
        }

        function addMovie(movie)
        {
            var requestDefer = $q.defer();

            $http.post('http://localhost:4747/api/movies/', movie)
                 .then(
                 //success callback
                 function (response) {
                     requestDefer.resolve(response.status);
                 },
                 //failure callback
                 function (error) {
                     requestDefer.reject("Movie is not added", error);
                 }
                 );

            return requestDefer.promise;
        }
        
        return service;
    }
})();