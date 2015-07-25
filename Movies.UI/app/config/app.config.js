(function () {
    'use strict';

    angular.module('app').config(function ($stateProvider, $urlRouterProvider, paginationTemplateProvider) {

        $urlRouterProvider.otherwise('/');

        $stateProvider
        .state('home', {
            url: '/',
            templateUrl: 'app/movies/movies.template.html',
            controller: 'MoviesController as MoviesCtrl'
        })
        .state('view', {
            url: 'movie/{id}',
            templateUrl: 'app/movies/view/view.template.html',
            controller: 'ViewController as ViewCtrl'
        });

        paginationTemplateProvider.setPath('app/common/directives/pagination/dirPagination.tpl.html');
    });
})();

