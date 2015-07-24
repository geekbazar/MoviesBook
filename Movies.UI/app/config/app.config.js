(function () {
    'use strict';

    angular.module('app').config(function ($stateProvider, $urlRouterProvider, paginationTemplateProvider) {

        $urlRouterProvider.otherwise('/');

        $stateProvider
        .state('home', {
            url: '/',
            templateUrl: 'app/movies/movies.template.html',
            controller: 'MoviesController as MoviesCtrl'
        });

        paginationTemplateProvider.setPath('app/common/directives/pagination/dirPagination.tpl.html');
    });
})();

