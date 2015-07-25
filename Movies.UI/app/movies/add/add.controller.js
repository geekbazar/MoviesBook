(function () {
    'use strict';

    angular.module('app').controller('AddController', AddController);

    AddController.$inject = ['$log', 'MoviesService','$state'];

    function AddController($log, MoviesService,$state) {
        var self = this;
        self.movie = null;
        self.addMovie = _addMovie;
        self.goToMovies = _goToMovies;

        function _addMovie() {
            var movie = self.movie;
            MoviesService.addMovie(movie)
                          .then(
                          //success callback
                          function (movieStatus) {
                              if (movieStatus == 200) {
                                  alert('Movie is added');
                                  $state.go('movies');
                              }
                          },
                          //failure callback
                          function (error) {
                              $log.error('AddController -->', error);
                          }
                          );
        }

        function _goToMovies() {
            $state.go('movies');
        }
    }
})();