

function salvaScheda()
{
    ShowWaiting();
    executeSubmit();
}

function SubmitForm(sender)
{
    $(sender).prop('disabled', true);
    salvaScheda()
}

var TRSelezionata;
function evidenziaTR(sender)
{
    var tr = $(sender).closest('tr');
    TRSelezionata = $(tr).attr('id');
    $(tr).addClass('evidenzia');
}

function disevidenziaTR()
{
    var tr = '#' + TRSelezionata;
    $(tr).removeClass('evidenzia');
}
