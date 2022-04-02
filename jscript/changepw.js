function ValidatePW() {
    if ($('#OldTextBox').val() == '') {
        $('#OldTextBox').attr('placeholder', 'Required').focus();
    } else if ($('#NewTextBox').val() == '') {
        $('#NewTextBox').attr('placeholder', 'Required').focus()
    }
}

$('#SaveButton').on('click', function () {
   
    if ($('#OldTextBox').val() == '') {
        $('#OldTextBox').attr('placeholder', 'Required').focus();
    } else if ($('#NewTextBox').val() == '') {
        $('#NewTextBox').attr('placeholder', 'Required').focus()
    } else if ($('#ComfirmTextBox').val() == '') {
        $('#ComfirmTextBox').attr('placeholder', 'Required').focus()
    } else if ($('#NewTextBox').val() !== $('#ComfirmTextBox').val()) {
        alert('New and confirmed passwords do not match')
    }
    else {
        console.log('heyo');
        $('#Save').click();
    }
});