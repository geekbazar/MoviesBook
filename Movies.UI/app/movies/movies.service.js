(function () {
    'use strict';

    angular.module('app').factory('MoviesService', MoviesService);

    MoviesService.$inject = ['$log','$q'];

    function MoviesService($log, $q) {

        var service = {
            getMovies: getMovies
        }

        function getMovies() {

            var requestDefer = $q.defer();

            requestDefer.resolve(
                [
  {
      "title": "Bahubali",
      "genre": "Fiction",
      "releasedate": "12/12/2015"
  },
  {
      "title": "Charulatha",
      "genre": "Horror",
      "releasedate": "09/01/2013"
  },
  {
      "title": "Arundhathi",
      "genre": "Horror",
      "releasedate": "05/06/2014"
  },
  {
      "title": "Ganga",
      "genre": "Horror",
      "releasedate": "09/07/2013"
  },
  {
      "title": "Matrix",
      "genre": "Action",
      "releasedate": "08/03/2012"
  },
  {
      "title": "Fast and Furious",
      "genre": "Action",
      "releasedate": "09/03/2012"
  },
  {
      "title": "Avengers",
      "genre": "Scifi",
      "releasedate": "05/07/1992"
  },
  {
      "title": "Terminator",
      "genre": "Action",
      "releasedate": "07/05/2018"
  },
  {
      "title": "Inside Out",
      "genre": "Animation",
      "releasedate": "02/05/2017"
  }
                ]
            );

            return requestDefer.promise;
        }
        
        return service;
    }
})();