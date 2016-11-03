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
    $("#Product_ProductTypeId").on("change", function (e) {
        console.log('ProductTypeId clicked')
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
});