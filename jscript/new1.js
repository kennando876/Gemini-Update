function GoBack(page) {
    var previousPage = 'pg' + parseInt(page - 1);
    var page = 'pg' + page;

    document.getElementById(page).style.display = 'none';
    document.getElementById(previousPage).style.display = 'block';
}

function GoForward(page) {
    var nextPage = 'pg' + parseInt(page + 1);
    var page = 'pg' + page;

    document.getElementById(page).style.display = 'none';
    document.getElementById(nextPage).style.display = 'block';
}

function AutofillAdress(target) {
    var appStreet = document.getElementById('AP_StreetAddressTextBox').value;
    var appTown = document.getElementById('AP_TownAddressTextBox').value;
    var appCity = document.getElementById('AP_CityAddressTextBox').value;
    var appCountryDDL = document.getElementById('AP_CountryAddressDropDownList');
    var appCountry = appCountryDDL.options[appCountryDDL.selectedIndex].text;
    var appBusinessNum = document.getElementById('AP_BusinessNumTextBox').value;
    var appHouseNum = document.getElementById('AP_HouseNumTextBox').value;

    var tStreet = target + 'StreetAddressTextBox';
    var tTown = target + 'TownAddressTextBox';
    var tCity = target + 'CityAddressTextBox';
    var tCountryDDLID = target + 'CountryAddressDropDownList';
    var tBnum = target + 'BusinessNumTextBox';
    var tHnum = target + 'HouseNumTextBox';

    document.getElementById(tStreet).value = appStreet;
    document.getElementById(tTown).value = appTown;
    document.getElementById(tCity).value = appCity;
    tCountryDDL = document.getElementById(tCountryDDLID);
    tCountryDDL.options[tCountryDDL.selectedIndex].text = appCountry;
    document.getElementById(tHnum).value = appHouseNum;
    document.getElementById(tBnum).value = appBusinessNum;
}



