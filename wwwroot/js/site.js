//listener on customerId dropdown creates an instance of active customer class based on dropdown value
$(document).ready(function () {
    console.log('ready')
    $("#CustomerId").on("change", function (e) {
        console.log('CustomerId clicked')
        $.ajax({
            url: `/Customers/Activate/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        }).done(() => {
            location.reload();
            console.log('hi')
        });
    });

//listener on Add to Cart button that posts the product selected to the customer's order
    $("#AddToCart").on("click", function(e) {
        console.log('AddtoCart clicked')
        $.ajax({
            url: `/Products/AddToCart/${$(this).val()}`,
            method: "POST",
            contentType: 'application/json; charset=utf-8'
        }).done(() => {
            console.log('product added to cart');
            location.reload();
        });
    });
    //listener on product type dropdown that injects corresponding subcategories into product type subcategory dropdown
    $("#Product_ProductTypeId").on("change", function (e) {
        $.ajax({
            url: `/Products/GetSubCategories/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done((subTypes) => {
            $("#Product_ProductTypeSubCategoryId").html("");
            $("#Product_ProductTypeSubCategoryId").append("<option value=null> Choose a Sub Category </option>");
            subTypes.forEach((option) => {
                console.log("these are the options", option);
                $("#Product_ProductTypeSubCategoryId").append(`<option value="${option.productTypeSubCategoryId}">${option.name}</option>`)
            });
        });
    });
});
