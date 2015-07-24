(function () {
    'use strict';

    describe("Testing movies service", function () {
        var MoviesService,
            $rootScope;

        beforeEach(function () {
            module('app');
            inject(function ($injector) {
                MoviesService = $injector.get('MoviesService');
                $rootScope = $injector.get('$rootScope');
            })
        });

        it("MoviesService should be defined", function () {
            expect(MoviesService).toBeDefined();
        });

        it("Should return movies data", function (done) {
            var mockResponse;
            //arrange
            //act
            var getMoviesFake = MoviesService.getMovies();

            getMoviesFake.then(function (movies) {
                mockResponse = movies;
                //assert
                expect(mockResponse).toBeDefined();
                expect(mockResponse.length).toEqual(9);

                done();
            });
            //TIP: Promise then is only resolving after callign the digest of the root scope
            $rootScope.$digest();
        });



    });
})();