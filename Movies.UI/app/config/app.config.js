(function () {
    'use strict';

    angular.module('app').config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/movies');

        $stateProvider
        .state('movies', {
            url: '/movies',
            templateUrl: 'app/movies/movies.template.html',
            controller: 'MoviesController as MoviesCtrl'
        })
        .state('view', {
            url: '/movies/{id}/view',
            templateUrl: 'app/movies/view/view.template.html',
            controller: 'ViewController as ViewCtrl'
        })
        .state('add', {
            url: '/movies/add',
            templateUrl: 'app/movies/add/add.template.html',
            controller: 'AddController as AddCtrl'
        })
        .state('edit', {
            url: '/movies/{id}/edit',
            templateUrl: 'app/movies/edit/edit.template.html',
            controller: 'EditController as EditCtrl'
        });
    });
})();

