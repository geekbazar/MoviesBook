(function () {
    'use strict';
    
    angular.module('app').directive('gbDatepicker', Datepicker);

    Datepicker.$inject = ['$log'];


    function Datepicker($log)
    {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function(scope, element, attrs,ngModel)
            {
                element.datepicker({
                    inline: true,
                    onSelect: function(dateText)
                    {
                        scope.$apply(function () {
                            ngModel.$setViewValue(dateText);
                        });
                    }
                });
            }
        }
    }

})();