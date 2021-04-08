var LEFT_MENU_CLOSED_KEY = 'spcleftmenu'
function spcToggleNav(sender)
{
    var divContainer = $(sender).parent();
    $(divContainer).toggleClass('Open');

    if ($(divContainer).hasClass('Open'))
    {
        spcOpenMenu(divContainer);
        sessionStorage.setItem(LEFT_MENU_CLOSED_KEY, 'false');
    }
    else
    {
        spcCloseMenu(divContainer);
        sessionStorage.setItem(LEFT_MENU_CLOSED_KEY, 'true');
    }

}

function onStartLeftMenu(containerStr)
{
    var divContainer = $(containerStr);
    if (sessionStorage.getItem(LEFT_MENU_CLOSED_KEY) == null)
    {
        spcOpenMenu(divContainer);
        return;
    }

    if (sessionStorage.getItem(LEFT_MENU_CLOSED_KEY) == 'false')
    {
        spcOpenMenu(divContainer);
    }
    else
    {
        spcCloseMenu(divContainer);
    }
}

function spcOpenMenu(divContainer)
{

    var icon = $(divContainer).find('.fa-lg');
    $(icon).removeClass('fa-unlock');
    $(icon).addClass('fa-lock');

    $(divContainer).width("200px");
    $('.spcBody').css('margin-left', '200px');
    var spans = $(divContainer).find('span');
    for (i = 0; i < spans.length; i++)
    {
        $(spans[i]).show();
    }
}

function spcCloseMenu(divContainer)
{
    var icon = $(divContainer).find('.fa-lg');
    $(icon).addClass('fa-unlock');
    $(icon).removeClass('fa-lock');

    var spans = $(divContainer).find('span');
    for (i = 0; i < spans.length; i++)
    {
        $(spans[i]).hide();
    }
    $(divContainer).width("40px");
    $('.spcBody').css('margin-left', '50px');
    var submenuUl = $(divContainer).find('.sub-menu');
    for (i = 0; i < submenuUl.length; i++)
    {
        $(submenuUl[i]).collapse('hide');
    }
}
