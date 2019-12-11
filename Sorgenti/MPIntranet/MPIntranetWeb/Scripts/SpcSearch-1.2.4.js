function HideDiv(sender)
{
    var obj = $(sender).parent().parent().parent();
    CleanDiv(obj);
    obj.hide();
}

function CleanDiv(obj)
{
    obj.find('input:text').val('');
    obj.find('select').val(-1).trigger('change');
}
