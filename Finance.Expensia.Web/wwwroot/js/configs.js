//For disable alert from DataTable when error happens
$.fn.dataTable.ext.errMode = 'none';

window.onload = function () {
    //Remove loading icon
    var bodyElement = document.body;
    bodyElement.classList.add('loaded');

    //Remove label 'entries per page' from DataTable
    $('label[for="dt-length-0"]').hide();

    //Transform all select with class 'select2' with select2
    $(".select2").select2();

    //Set highlight menu
    var url = window.location;
    $('ul.nav-sidebar a').each(function () {
        var href = $(this).attr('href');
        if ((url.pathname).startsWith(href)) {
            $(this).addClass('active');
            return false; // Keluar dari loop setelah menemukan yang cocok
        }
    });
    $('ul.nav-treeview a').filter(function () {
        return this.href == url;
    }).parentsUntil(".nav-sidebar > .nav-treeview").addClass('menu-open').prev('a').addClass('active');

    //Set display name on left panel
    $("#displayName").html(localStorage.getItem("displayName"));

    //Set photo user from google on left panel
    $("#photoUser").attr("src", localStorage.getItem("photoUrl"));
};