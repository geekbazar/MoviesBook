(function () {
    'use strict';

    angular.module('app').controller('MoviesController', MoviesController);

    MoviesController.$inject = ['$log', 'MoviesService'];

    function MoviesController($log, MoviesService)
    {

        //$log.info('Loading movies controller');

        var self = this;
        self.movies = [];
        self.pages = [];
        self.navigate = _navigate;
        self.goToMovie = _goToMovie;
        _activate();

        function _activate()
        {
            //declarations
            self.sortBy = 'title';
            self.reverse = true;
            self.offset = 0;
            self.pageSize = 2;
            self.activePage = 1;
            _getMovies();
        }

        function _getMovies()
        {
            MoviesService.getMovies().then(function(movies)
            {
                self.movies = movies;
                //preparing pagination
                var numberOfPages = Math.ceil(self.movies.length / self.pageSize);
                for (var index = 1; index <= numberOfPages; index++) {
                    self.pages.push(index);
                }
            }, function (error) {
                $log.error("MovieService -> getMovies" + error);
            });
        }

        function _navigate(page)
        {
            self.activePage = page;

            self.offset = (self.activePage - 1) * self.pageSize;
        }

        function _goToMovie(movie)
        {

        }
    }

})();