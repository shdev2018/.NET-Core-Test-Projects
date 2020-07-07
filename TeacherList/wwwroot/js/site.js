// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$('.alert-autoclose').fadeTo(2000, 500).slideUp(500, function () {
    $('alert-autoclose').fadeTo(500);
});