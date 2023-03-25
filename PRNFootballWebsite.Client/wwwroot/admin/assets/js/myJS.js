$(document).ready(function () {
    var span = $(".UpdateAccountStatus");
    var JwtToken = $("#JwtToken:hidden").val();
    console.log(JwtToken);
    span.click(function () {
        var id = $(this).attr("id");
        $.ajax({
            url: "https://localhost:5000/api/Account/UpdateAccountStatus/" +id,
            type: "put",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + JwtToken);
            },
            success: (result) => {
                location.reload();
            },
            error: (error) => {
                console.log(error)
            },
        });
    });
});