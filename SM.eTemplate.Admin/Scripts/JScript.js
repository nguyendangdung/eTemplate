//function ValidateKeypress(numcheck, e) {
//    var keynum, keychar, numcheck;
//    if (window.event) {
//        keynum = e.keyCode;
//    }
//    else if (e.which) {
//        keynum = e.which;
//    }
//    if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
//    keychar = String.fromCharCode(keynum);
//    var result = numcheck.test(keychar);
//    return result;
//}

//function ValidateKeypressIsNumber(evt) {
//    evt = (evt) ? evt : window.event;
//    var charCode = (evt.which) ? evt.which : evt.keyCode;
//    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
//        return false;
//    }
//    return true;
//}

function isDigit(evt, txt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    var c = String.fromCharCode(charCode);

    if (txt.indexOf(c) > 0 && charCode == 46) {
        return false;
    }
    else if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }

    return true;
}

function SelectAll(obj, chkID) {
    var frm = document.forms['aspnetForm'];
    for (var i = 0; i < document.forms[0].length; i++) {
        if (document.forms[0].elements[i].id.indexOf('' + chkID + '') != -1) {
            document.forms[0].elements[i].checked = obj.checked
        }
    }
}

function CheckOneRadioButton(id) {
    var rdBtn = document.getElementById(id);
    var List = document.getElementsByTagName("input");
    for (i = 0; i < List.length; i++) {
        if (List[i].type == "radio" && List[i].id != rdBtn.id) {
            List[i].checked = false;
        }
    }
}

function refreshParent() {
    try {
        window.opener.location.href = window.opener.location.href;

        if (window.opener.progressWindow) {
            window.opener.progressWindow.close()
        }
        window.close();
    } catch (ex) {
    }
}

function redirectParent(linkRedirect) {
    window.opener.location.href = linkRedirect;

    if (window.opener.progressWindow) {
        window.opener.progressWindow.close()
    }
    window.close();
}

function selectAllCheckbox(obj, chkName) {
    $('span[name = "' + chkName + '"]').children(':enabled').attr('checked', obj.checked);
}

function selectOneRadiobox(obj, rdoName) {
    $('span[name = "' + rdoName + '"]').children().attr('checked', false);
    obj.checked = true;
}

function confirmDeleteAll() {
    chkChecks = document.getElementsByTagName('input');
    count = 0;
    for (i = 0; i < chkChecks.length; i++) {
        objElement = chkChecks[i];
        if (objElement.type == 'checkbox' && objElement.checked == 'true') {
            count = 1;
            break;
        }
    }

    if (count == 0) {
        alert("Bạn chưa chọn bản ghi nào để xóa.");
        return false;
    }

    return confirm('Bạn có muốn xóa bản ghi đã chọn đã chọn?');
}
var targetWin;

function PopupCenter(pageURL, title, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);

    strFeatures = 'toolbar=no, location=no, directories=no, status=no, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left;
    targetWin = window.open(pageURL, title, strFeatures);
    targetWin.focus();

    return targetWin;
}

function GetRadioButtonValueByName(id) {
    var radio = document.getElementsByName(id);
    for (var j = 0; j < radio.length; j++) {
        if (radio[j].checked)
            alert(radio[j].value);
    }
}
// start decorate grid for status
function updateColor(strName, strStatus, strColor) {
    arrTask = document.getElementsByName(strName);
    for (i = 0; i < arrTask.length; i++) {
        spanTask = arrTask[i];
        strValue = spanTask.innerHTML.trim();
        if (strValue == strStatus.toString()) {
            trTask = spanTask.parentNode.parentNode;
            trTask.style.color = strColor.toString();
        }
    }
}
// end
// start check click inside popup
function isInsidePopup(element, strDivId, strImgId) {
    if (element == null || element == 'undefined') {
        return false;
    }

    strId = getElementId(element);
    if (strId == strDivId) {
        return true;
    }
    if (strId == strImgId) {
        return true;
    }

    return isInsidePopup(element.parentNode, strDivId, strImgId);
}

function getElementId(element) {
    try {
        return element.id;
    }
    catch (ex) { }

    return '';
}
// end
// start popup
function popupShowHide(divData, isSetPosition) {
    objDiv = document.getElementById(divData);
    if (objDiv.style.display == 'none' || objDiv.style.display == '') {
        objDiv.style.display = 'block';
        if (isSetPosition) {
            screenSize = popupGetScreenWidth(false);
            popupSize = objDiv.clientWidth;
            paddingSize = screenSize - popupSize;
            paddingSize = paddingSize / 2;
            objDiv.style.left = paddingSize + 'px';

            screenSize = popupGetScreenHeight(false);
            popupSize = objDiv.clientHeight;
            paddingSize = screenSize - popupSize;
            paddingSize = paddingSize / 2;
            objDiv.style.top = paddingSize + 'px';
        }
    }
    else {
        objDiv.style.display = 'none';
    }
}
function popupFitBlanketSize(divBlanket) {
    blanket = document.getElementById(divBlanket);
    blanket.style.height = popupGetScreenHeight(true) + 'px';
    blanket.style.width = popupGetScreenWidth(true) + 'px';
}
function popup(divData, divBlanket) {
    popupFitBlanketSize(divBlanket);
    popupShowHide(divBlanket, false);
    popupShowHide(divData, true);
}
function popupGetScreenHeight(isIncludeScroll) {
    height = 0;
    if (typeof window.innerHeight != 'undefined') {
        height = window.innerHeight;
    } else {
        height = document.documentElement.clientHeight;
    }

    if (isIncludeScroll) {
        if ((height <= document.body.parentNode.scrollHeight) || (height <= document.body.parentNode.clientHeight)) {
            if (document.body.parentNode.clientHeight > document.body.parentNode.scrollHeight) {
                height = document.body.parentNode.clientHeight;
            } else {
                height = document.body.parentNode.scrollHeight;
            }
        }
    }
    return height;
}
function popupGetScreenWidth(isIncludeScroll) {
    width = 0;
    // window
    if (typeof window.innerWidth != 'undefined') {
        width = window.innerWidth;
    } else {
        width = document.documentElement.clientWidth;
    }
    // parent
    if (width < document.body.parentNode.clientWidth) {
        width = document.body.parentNode.clientWidth;
    }
    // scroll
    if (isIncludeScroll) {
        if (width < document.body.parentNode.scrollWidth) {
            width = document.body.parentNode.scrollWidth;
        }
    }
    return width;
}
// end popup
function allowClick() {
    return true;
}
function notAllowClick() {
    return false;
}
// start fix OnItemsRequested event of RadCombobox
function RadHanleOnClientKeyPressing(comboBox, eventArgs) {
    intKeyCode = eventArgs.get_domEvent().keyCode;
    if (isPressNormalChar(intKeyCode)) {
        strChar = String.fromCharCode((96 <= intKeyCode && intKeyCode <= 105) ? intKeyCode - 48 : intKeyCode);
        strText = comboBox.get_text() + strChar;
        comboBox.requestItems(strText, false);
    }
}
function isPressNormalChar(keyCode) {
    switch (keyCode) {
        case 9:
        case 13:
        case 16:
        case 17:
        case 18:
        case 19:
        case 20:
        case 27:
        case 33:
        case 34:
        case 35:
        case 36:
        case 37:
        case 38:
        case 39:
        case 40:
        case 45:
        case 91:
        case 92:
        case 112:
        case 113:
        case 114:
        case 115:
        case 116:
        case 117:
        case 118:
        case 119:
        case 120:
        case 121:
        case 122:
        case 123:
        case 144:
        case 145:
            return false;
    }
    return true;
}
// end fix OnItemsRequested event of RadCombobox

// start show model dialog
function showPagePopup(url) {
    screenWidth = popupGetScreenWidth(false);
    screenHeight = popupGetScreenHeight(false);

    popupTop = 50;
    popupLeft = 50;

    popupWidth = screenWidth - 2 * popupLeft;
    popupHeight = screenHeight - 2 * popupTop;

    popupName = Math.random();
    popupName = popupName + "";
    popupName = popupName.substring(2);

    try {
        showOption = 'scrollbars=1,menubar=0,resizable=1,status=0,width=' + screenWidth + ',height=' + popupHeight + ',left=' + popupLeft + ',top=' + popupTop;
        popupForm = window.open(url, popupName, showOption);
        popupForm.focus();
    } catch (ex) {
    }
}
function showPageDialog(url) {
    screenWidth = popupGetScreenWidth(false);
    screenHeight = popupGetScreenHeight(false);

    popupTop = 50;
    popupLeft = 50;

    popupWidth = screenWidth - 2 * popupLeft;
    popupHeight = screenHeight - 2 * popupTop;

    popupName = Math.random();
    popupName = popupName + "";
    popupName = popupName.substring(2);

    try {
        window.ShowModalDialog(url, 1200, 1000, '', '');
    } catch (ex) {
    }
}
// end show model dialog

//Check maxlength for textarea
function checkMaxLength(textbox, event, long) {
    var maxlength = new Number(long); // Change number to your max length.
    if (!checkSpecialKeys(event)) {
        if (textbox.value.length > maxlength - 1) {
            event.preventDefault();
        }
    }
}

function checkSpecialKeys(e) {
    if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
        return false;
    else
        return true;
}