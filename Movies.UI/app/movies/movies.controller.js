(function () {
    'use strict';

    angular.module('app').controller('MoviesController', MoviesController);

    MoviesController.$inject = ['$log', 'MoviesService'];

    function MoviesController($log, MoviesService)
    {

        //$log.info('Loading movies controller');

        var self = this;
        self.movies = [];
        self.getMovies = getMovies;

        _activate();

        function _activate()
        {
            getMovies();
        }

        function getMovies()
        {
            MoviesService.getMovies().then(function(movies)
            {
                if (movies.length)
                {
                    self.movies = movies;
                }

            }, function (error) {
                $log.error("MovieService -> getMovies" + error);
            });
        }
    }

})();