"use strict";

function deleteItem(item) {
    let row = $(item).parent().parent();
    row.fadeOut(function () {
        row.remove();
        fixShowLinks();
    })
}

function moveItemUp(item) {
    let row = $(item).parent().parent();

    row.fadeOut(function () {
        row.insertBefore(row.prev());
        row.fadeIn();
        fixShowLinks();
    })
}

function moveItemDown(item) {
    let row = $(item).parent().parent();

    row.fadeOut(function () {
        row.insertAfter(row.next());
        row.fadeIn();
        fixShowLinks();
    })
}

function addCountry() {
    let country = $('#textCountryName').val();
    let capital = $('#textCapitalName').val();

    $('#textCountryName').val('');
    $('#textCapitalName').val('');

    let row = addCountryToTable(country, capital);
    row.hide();
    row.fadeIn();

    fixShowLinks();
}

function addCountryToTable(country, capital) {
    let row = $('<tr>')
        .append($('<td>').text(country))
        .append($('<td>').text(capital))
        .append($('<td>')
            .append($('<a href="#" onclick="moveItemUp(this)">[Up]</a>'))
            .append(' ')
            .append($('<a href="#" onclick="moveItemDown(this)">[Down]</a>'))
            .append(' ')
            .append($('<a href="#" onclick="deleteItem(this)">[Delete]</a>'))
        );

    $('#tableCountries').append(row);
    fixShowLinks();
    return row;
}

function fixShowLinks() {
    $('#tableCountries a').show();

    let tableRows = $('#tableCountries tr');

    $(tableRows[1]).find('a:contains("Up")').hide();
    $(tableRows[tableRows.length - 1]).find('a:contains("Down")').hide();
}

$(function () {
    addCountryToTable('Bulgaria', 'Sofia');
    addCountryToTable('Germany', 'Berlin');
    addCountryToTable('Great Britain', 'London');
    addCountryToTable('Spain', 'Madrid');
    fixShowLinks();
});