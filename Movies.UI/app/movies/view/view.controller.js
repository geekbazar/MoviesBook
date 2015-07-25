(function () {
    'use strict';

    angular.module('app').controller('ViewController', ViewController);

    ViewController.$inject = ['$log', '$stateParams', 'MoviesService','$state'];

    function ViewController($log, $stateParams, MoviesService, $state)
    {
        var self = this;
        self.editMovie = _editMovie;
        self.goToMovies = _goToMovies;
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
                             self.movie = movie;
                         },
                         //failure callback
                         function (error) {
                             $log.error('ViewController -->',error);
                         }
                         );
        }

        function _editMovie()
        {
            $state.go('edit', { id: $stateParams.id });
        }

        function _goToMovies()
        {
            $state.go('movies');
        }

    }

})();