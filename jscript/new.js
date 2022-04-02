

function ValidatePG0() {
    var appType = $('#ApplicationTypeDropDownList option:selected').text();
    var passport = $('#AP_PassportTextBox');
    var trn = $('#AP_TRNTextBox');
    var idType = $('#AP_IDTypeDropDownList option:selected').text();
    var idNum = $('#AP_IDNumTextBox');
    var fName = $('#AP_FirstnameTextBox');
    var mName = $('#AP_MiddlenameTextBox');
    var alias = $('#AP_AliasTextBox');
    var lName = $('#AP_LastnameTextBox');

    var occupation = $('#AP_OccupationTextBox');
    var dob = $('#AP_DOBDateBox');
    var sex = $('#AP_SexDropDownList option:selected').text();
    var mStatus = $('#AP_MaritalStatusDropDownList option:selected').text();
    var pob = $('#AP_POBDropDownList option:selected').text();
    var nationality = $('#AP_NationalityDropDownList option:selected').text();

    if (passport.val() == '') {
        passport.attr('placeholder', 'Required').focus();
    }/* else if (trn.val() == '') {
        trn.attr('placeholder', 'Required').focus();
    } else if (isNaN(trn.val()) == true) {
        alert('TRN Number invalid')
    } else if (idNum.val() == '') {
        idNum.attr('placeholder', 'Required').focus();
    } else if (fName.val() == '') {
        fName.attr('placeholder', 'Required').focus();
    } else if (lName.val() == '') {
        lName.attr('placeholder', 'Required').focus();
    } else if (occupation.val() == '') {
        occupation.attr('placeholder', 'Required').focus();
    } else if (dob.val() == '') {
        alert('Please enter applicant\'s Date of Birth');
    } else if (pob == '') {
        alert('Please select applicant\'s Place of Birth');
    } */else if (nationality == '') {
        alert('Please select applicant\'s Nationality');
    }
    else {
        if (mStatus == 'Married' || mStatus == 'Common Law' || appType == 'Marriage') {
            $('#isMarried').val('true');
        }
        else {
            $('#isMarried').val('false');
        }
        if (appType == 'Dependent') {
            $('#isDependent').val('true');
        }
        else {
            $('#isDependent').val('false');
        }

        // console.log($('#isMarried').val(), $('#isDependent').val())

        /*****************************************************************/


        if ($('#isMarried').val() == 'false' && $('#isDependent').val() == 'false') {

            $('#AP_NextButton2').val('Save AP');

            $('#AP_NextButton2').on('click', function () {
                if (ValidatePG1() != true) {
                    e.preventDefault();
                    ValidatePG1();
                }
                else {
                     $('#SaveButton').click();
                }
            });

        }
        else if ($('#isMarried').val() == 'false' && $('#isDependent').val() == 'true') {
            $('#AP_NextButton2').val('Next DEP');
            $('#AP_NextButton2').on('click', function () {
                $('#pg1').css('display', 'none');
                $('#pg3').css('display', 'block');
            });


            /*$('AP_NextButton2').click(function () {
                ValidatePG1();
            });*/
        }

        else if ($('#isMarried').val() == 'true' && $('#isDependent').val() == 'true') {
            $('#AP_NextButton2').val('Next SPO');
            $('#AP_NextButton2').on('click', function () {

                $('#pg1').css('display', 'none');
                $('#pg2').css('display', 'block');
            });
        }

        else if ($('#isMarried').val() == 'true' && $('#isDependent').val() == 'false') {
            $('#AP_NextButton2').val('Next SPO');
            $('#AP_NextButton2').on('click', function () {
                $('#pg1').css('display', 'none');
                $('#pg2').css('display', 'block');
            });
        }

        $('#pg0').css('display', 'none');
        $('#pg1').css('display', 'block');
        window.scrollTo({ top: 0, behavior: 'auto' });

    }
}



function ValidatePG1() {
    var appType = $('#ApplicationTypeDropDownList option:selected').text();
    var mStatus = $('#AP_MaritalStatusDropDownList option:selected').text();

    var citizenship = $('#AP_C1DropDownList option:selected').text();
    var pResidency = $('#AP_PreviousResidenceDropDownList option:selected').text();
    var lResidency = $('#AP_LengthOfResidenceTextBox');
    var priLang = $('#AP_PrimaryLangDropDownList option:selected').text();
    var secLang = $('#AP_SecondaryLangDropDownList option:selected').text();

    var street = $('#AP_StreetAddressTextBox');
    var town = $('#AP_TownAddressTextBox');
    var city = $('#AP_CityAddressTextBox');
    var country = $('#AP_CountryAddressDropDownList option:selected').text();
    var house = $('#AP_HouseNumTextBox');
    var business = $('#AP_BusinessNumTextBox');
    var cell = $('#AP_CellNumTextBox');
    var email = $('#AP_EmailTextBox');

    if (citizenship == '') {
        alert('Please select a Citizenship');
    } /*else if (pResidency == '') {
        alert('Please select Country of Previous Residence');
    } else if (lResidency.val() == '') {
        lResidency.attr('placeholder', 'Required').focus();
    } else if (priLang == '') {
        alert('Please select applicant\'s Primary Language');
    } else if (secLang == '') {
        alert('Please select applicant\'s Secondary Language');
    } else if (street.val() == '') {
        street.attr('placeholder', 'Required').focus();
    } else if (town.val() == '') {
        town.attr('placeholder', 'Required').focus();
    } else if (city.val() == '') {
        city.attr('placeholder', 'Required').focus();
    } else if (country == '') {
        alert('Please select country address');
    } else if (house.val() == '') {
        house.attr('placeholder', 'Required').focus();
    } else if (business.val() == '') {
        business.attr('placeholder', 'Required').focus();
    } else if (cell.val() == '') {
        cell.attr('placeholder', 'Required').focus();
    } else if (email.val() == '') {
        email.attr('placeholder', 'Required').focus();
    }*/

    else if (ValidateEmail(email.val()) == false) {
        alert('Invalid email address')
    }
    else {
        // alert('test');

        if ($('#isMarried').val() == 'true') {
            $('#pg2').css('display', 'block');
        }

        if ($('#isDependent').val() == 'false') {
            $('#SP_NextButton').val('SaveEEE');

            $('#SP_NextButton').on('click', function () {
                if (ValidatePG2() != true) {
                    ValidatePG2();
                }
                else {
                    $('#SaveButton').click();
                }
            });

        }
        if ($('#isDependent').val() == 'true' && $('#isMarried').val() != 'true') {

            $('#pg3').css('display', 'block');
        }

        $('#pg1').css('display', 'none');
        /*else {
            $('#pg3').css('display', 'block');
        }*/
        window.scrollTo({ top: 0, behavior: 'auto' });
        return true;
    }
}

//SPOUSE
function ValidatePG2() {

    var mStatus = $('#AP_MaritalStatusDropDownList option:selected').text();

    var fName = $('#SP_FirstnameTextBox');
    var mName = $('#SP_MiddlenameTextBox');
    var maidName = $('#SP_MaidennameTextBox');
    var lName = $('#SP_LastnameTextBox');

    var sex = $('#SP_SexDropDownList option:selected').text();
    var dom = $('#SP_DOBDateBox');
    var dob = $('#SP_DOBDateBox');
    var pob = $('#SP_POBDropDownList option:selected').text();
    var nationality = $('#SP_NationalityDropDownList option:selected').text();
    var occupation = $('#SP_OccupationTextBox');

    var street = $('#SP_StreetAddressTextBox');
    var town = $('#SP_TownAddressTextBox');
    var city = $('#SP_CityAddressTextBox');
    var country = $('#SP_CountryAddressDropDownList option:selected').text();
    var house = $('#SP_HouseNumTextBox');
    var business = $('#SP_BusinessNumTextBox');
    var cell = $('#SP_CellNumTextBox');
    var email = $('#SP_EmailTextBox');

    if (fName.val() == '') {
        fName.attr('placeholder', 'Required').focus();
    }/* else if (sex == 'Female' && maidName.val() == '') {
        maidName.attr('placeholder', 'Required').focus();
    } else if (lName.val() == '') {
        lName.attr('placeholder', 'Required').focus();
    } else if (dom.val() == '' && mStatus == 'Married') {
        alert('Please enter Date of Marriage');
    } else if (dob.val() == '') {
        alert('Please enter spouse\'s Date of Birth');
    } else if (pob == '') {
        alert('Please select spouse\'s Place of Birth');
    } else if (nationality == '') {
        alert('Please select spouse\'s Nationality');
    } else if (occupation.val() == '') {
        occupation.attr('placeholder', 'Required').focus();
    } else if (street.val() == '') {
        street.attr('placeholder', 'Required').focus();
    } else if (town.val() == '') {
        town.attr('placeholder', 'Required').focus();
    } else if (city.val() == '') {
        city.attr('placeholder', 'Required').focus();
    } else if (country == '') {
        alert('Please select country address');
    }*/ /*else if (house.val() == '') {
        house.attr('placeholder', 'Required').focus();
    } else if (business.val() == '') {
        business.attr('placeholder', 'Required').focus();
    } else if (cell.val() == '') {
        cell.attr('placeholder', 'Required').focus();
    } else if (email.val() == '') {
        email.attr('placeholder', 'Required').focus();
    } */ else if (email.val() != '' && ValidateEmail(email.val()) == false) {
        alert('Invalid email address')
    } else {
        if ($('#isDependent').val() == 'true') {
            $('#SP_NextButton').val('Next DPP');

            $('#pg2').css('display', 'none');
            $('#pg3').css('display', 'block');
        }
        else {
            $('#SP_NextButton').val('SaveEEE');

            $('#SP_NextButton').on('click', function () {
                $('#SaveButton').click();
            });
        }

        return true;
        /* $('#pg2').css('display', 'none');
         $('#pg3').css('display', 'block');
         window.scrollTo({ top: 0, behavior: 'auto' });*/
    }
}


//DEPENDENTS
function ValidatePG3() {
    var appType = $('#ApplicationTypeDropDownList option:selected').text();

    var fName = $('#DP_FirstnameTextBox');
    var mName = $('#DP_MiddlenameTextBox');
    var alias = $('#DP_AliasTextBox');
    var lName = $('#DP_LastnameTextBox');

    var sex = $('#DP_SexDropDownList option:selected').text();
    var dob = $('#DP_DOBDateBox');
    var pob = $('#DP_POBDropDownList option:selected').text();
    var rel = $('#DP_RelationshipDropDownList option:selected').text();

    var street = $('#DP_StreetAddressTextBox');
    var town = $('#DP_TownAddressTextBox');
    var city = $('#DP_CityAddressTextBox');
    var country = $('#DP_CountryAddressDropDownList option:selected').text();
    var house = $('#DP_HouseNumTextBox');
    var business = $('#DP_BusinessNumTextBox');
    var cell = $('#DP_CellNumTextBox');
    var email = $('#DP_EmailTextBox');

    if (appType == 'Dependent') {

        if (fName.val() == '') {
            fName.attr('placeholder', 'Required').focus();
        } else if (lName.val() == '') {
            lName.attr('placeholder', 'Required').focus();
        } else if (dob.val() == '') {
            alert('Please enter dependent\'s Date of Birth');
        } else if (pob == '') {
            alert('Please select dependent\'s Place of Birth');
        } else if (rel == '') {
            alert('Please select dependent\'s relationship to applicant');
        } else if (street.val() == '') {
            street.attr('placeholder', 'Required').focus();
        } else if (town.val() == '') {
            town.attr('placeholder', 'Required').focus();
        } else if (city.val() == '') {
            city.attr('placeholder', 'Required').focus();
        } else if (country == '') {
            alert('Please select country address');
        } /*else if (house.val() == '') {
            house.attr('placeholder', 'Required').focus();
        } else if (business.val() == '') {
            business.attr('placeholder', 'Required').focus();
        } else if (cell.val() == '') {
            cell.attr('placeholder', 'Required').focus();
        } else if (email.val() == '') {
            email.attr('placeholder', 'Required').focus();
        }*/ else if (email.val() != '' && ValidateEmail(email.val()) == false) {
            alert('Invalid email address')
        } else {
            /*$('#pg3').css('display', 'none');
            $('#pg4').css('display', 'block');*/
            $('#SaveButton').click();

        }
    } /*else {
        /*$('#pg3').css('display', 'none');
        $('#pg4').css('display', 'block');
        $('#DP_SaveButton').click(function () {
            $('#SaveButton').click();
        });
    }*/
}











function GoBack1() {
    $('#pg0').css('display', 'block');
    $('#pg1').css('display', 'none');
    window.scrollTo({ top: 0, behavior: 'auto' });
}

function GoBack2() {
    $('#pg2').css('display', 'none');
    $('#pg1').css('display', 'block');
    window.scrollTo({ top: 0, behavior: 'auto' });
}

function GoBack3() {
    $('#pg3').css('display', 'none');
    $('#pg1').css('display', 'block');
    window.scrollTo({ top: 0, behavior: 'auto' });
}




function ValidateEmail(emailAddress) {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (emailAddress.match(mailformat)) {
        return true;
    } else {
        return false;
    }
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
