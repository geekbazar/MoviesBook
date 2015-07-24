(function () {
    'use strict';

    describe("Testing movies controller", function () {
        var MoviesController,
            MoviesService,
            $controller,
            scope,
            q,
            deferredMovies,
            movies,
            $rootScope;

        beforeEach(function () {
            module('app');
            inject(function ($injector) {
                $controller = $injector.get('$controller');
                MoviesService = $injector.get('MoviesService');
                $rootScope = $injector.get('$rootScope');
                scope = $rootScope.$new();
                q = $injector.get('$q');
                deferredMovies = q.defer();
            });

            //mock promises on service calls
            spyOn(MoviesService, "getMovies").and.returnValue(deferredMovies.promise);


            //create controller
            MoviesController = $controller("MoviesController",
                {
                    "$scope": scope
                });
        });

        it("MoviesService should be defined", function () {
            expect(MoviesService).toBeDefined();
        });

        it("MoviesController should be defined", function () {
            expect(MoviesController).toBeDefined();
        });

        describe("Verify functionality to get movies", function () {

            beforeEach(function () {
                movies = [
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
                ];

                deferredMovies.resolve(movies);
            });

            it("The getMovies function should return movies list", function () {
                //Arrange

                //Act
                //MoviesController.getMovies();
                scope.$digest();

                //Assert
                expect(MoviesController.movies).toBe(movies);

                
            });
        });

    });
})();