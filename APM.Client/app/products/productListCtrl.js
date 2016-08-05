(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("productListCtrl",
                       ["productResource",          
                            productListCtrl]);

    function productListCtrl(productResource) {
        var vm = this;

        vm.searchCriteria = "GDN";
        vm.sortProperty = "Price";
        vm.sortDirection = "desc";

        productResource.query({
            $filter: "contains(ProductCode, '" + vm.searchCriteria + "')" +
                " or contains(ProductName, '" + vm.searchCriteria + "')",
            $orderby: vm.sortProperty + " " + vm.sortDirection
        },
            function (data) {
                vm.products = data;
        })
    }
}());
