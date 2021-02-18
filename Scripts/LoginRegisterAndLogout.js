$(window).on('load', function () {
    $("#divRegistration").hide();
    $("#divLogin").hide();
    $("#btnLogOut").hide();
});


$(document).ready(function () {
    var token = null;
    var headers = {};
    var endpoint = "https://localhost:44310/api/users/";

    $("#btnRegister").on("click", function () {
        $("#divRegistration").show();
        $("#divLogin").hide();
        $("#LoginOrRegisterDiv").hide();
    });

    $("#btnLogin").on("click", function () {
        $("#divRegistration").hide();
        $("#divLogin").show();
        $("#LoginOrRegisterDiv").hide();
    });

    $("#cancelReg").on("click", function () {
        $("#LoginOrRegisterDiv").show();
        $("#divRegistration").hide();
        $("#divLogin").hide();
    });

    $("#cancelLog").on("click", function () {
        $("#LoginOrRegisterDiv").show();
        $("#divRegistration").hide();
        $("#divLogin").hide();
    });

    //LOGIN
    $("#loginForm").submit(function (e) {
        e.preventDefault();

        var loginEmail = $("#loginEmail").val();
        var loginPassword = $("#loginPassword").val();

        var sendData = {
            "grant_type": "password",
            "username": loginEmail,
            "password": loginPassword
        };

        $.ajax({
            type: "POST",
            url: "https://localhost:44310/Token",
            data: sendData
        }).done(function (data, status) {
            token = data.access_token;

            $("#divLogin").hide();
            $("#LoginOrRegisterDiv").hide();
            $("#LoginMessage").empty();
            $("#LoginMessage").append("Logged in user: " + loginEmail);
            $("#btnLogOut").show();

            $("#loginEmail").val('');
            $("#loginPassword").val('');
            $("#btnLoginOrRegister").hide();

        }).fail(function (data, status) {
            alert("Error while trying to login! " + data);
        });
    });

    //REGISTER
    $("#registerForm").submit(function (e) {
        e.preventDefault();

        var registerEmail = $("#registerEmail").val();
        var registerPassword = $("#registerPassword").val();
        var confirmPassword = $("#confirmPassword").val();

        var sendData = {
            "Email": registerEmail,
            "Password": registerPassword,
            "ConfirmPassword": confirmPassword
        };

        $.ajax({
            type: "POST",
            url: "https://localhost:44310/api/Account/Register",
            data: sendData
        }).done(function (data) {
            $("#message").css("color", "green");
            $("#message").append("Successful registration! You can now login.");
            $("#divLogin").show();
            $("#divRegistration").hide();
            $("#loginEmail").val(registerEmail);
            $("#loginPassword").val(registerPassword);

            $("#registerEmail").val('');
            $("#registerPassword").val('');
            $("#registerConfirmPassword").val('');
        }).fail(function (data) {
            alert("Error while trying to register! " + data);
        });
    });

    //LOG OUT
    $("#btnLogOut").on("click", function () {
        token = null;
        headers = {};

        $("#divLogin").hide();
        $("#divRegistration").hide();
        $("#LoginOrRegisterDiv").show();
        $("#LoginMessage").empty();
        $("#message").empty();
        $("#btnLogOut").hide();
        $("#btnLoginOrRegister").show();
    });

});