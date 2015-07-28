(function () {
    'use strict';

    angular.module('app').controller('EditController', EditController);

    EditController.$inject = ['$log', 'MoviesService', '$stateParams', '$state', '$filter'];

    function EditController($log, MoviesService, $stateParams, $state, $filter)
    {
        var self = this;
        self.movie = null;
        self.goToMovies = _goToMovies;
        self.updateMovie = _updateMovie;
        _activate();

        function _activate()
        {
            _getMovie($stateParams.id);
        }

        function _getMovie(id)
        {
            MoviesService.getMovie(id)
                        .then(
                        //success callback
                        function (movie) {
                            movie.releaseDate = $filter('date')(movie.releaseDate, "MM/dd/yyyy");
                            self.movie = movie;
                        },
                        //failure callback
                        function (error) {
                            $log.error('EditController -->', error);
                        }
                        );
        }

        function _updateMovie()
        {
            var movie = self.movie;
            MoviesService.updateMovie(movie)
                          .then(
                          //success callback
                          function (movieStatus) {
                              if(movieStatus == 200)
                              {
                                  alert('Movie is updated');
                                  $state.go('movies');
                              }
                          },
                          //failure callback
                          function (error) {
                            $log.error('EditController -->', error);
                          }
                          );
        }

        function _goToMovies() {
            $state.go('movies');
        }

    }
})();