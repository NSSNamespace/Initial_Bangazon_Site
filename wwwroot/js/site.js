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

    $("#AddToCart").on("click", function(e) {
        console.log('AddtoCart clicked')
        $.ajax({
            url: `/Products/AddToCart/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done((result) => {
            console.log('result of post', result);
            // location.reload(); 
        });
    });
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
