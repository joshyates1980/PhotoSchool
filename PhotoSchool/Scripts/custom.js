﻿$(document).ready(function () {
    //build dropdown
    $("<select />").appendTo("nav#main_menu div");

    // Create default option "Go to..."
    $("<option />", {
        "selected": "selected",
        "value": "",
        "text": "Please choose page"
    }).appendTo("nav#main_menu select");

    // Populate dropdowns with the first menu items
    $("nav#main_menu li a").each(function () {
        var el = $(this);
        $("<option />", {
            "value": el.attr("href"),
            "text": el.text()
        }).appendTo("nav#main_menu select");
    });

    //make responsive dropdown menu
    $("nav#main_menu select").change(function () {
        window.location = $(this).find("option:selected").val();
    });

    //Iframe transparent
    $("iframe").each(function () {
        var ifr_source = $(this).attr('src');
        var wmode = "wmode=transparent";
        if (ifr_source.indexOf('?') != -1) {
            var getQString = ifr_source.split('?');
            var oldString = getQString[1];
            var newString = getQString[0];
            $(this).attr('src', newString + '?' + wmode + '&' + oldString);
        }
        else $(this).attr('src', ifr_source + '?' + wmode);
    });
    //Tooltip
    $('.follow_us a').tooltip();
});