function isSpclChar() {
    
    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";
    for (var i = 0; i < document.qfrm.q.value.length; i++) {
        if (iChars.indexOf(document.qfrm.q.value.charAt(i)) != -1) {
            return false;
        }
    }
    return true;
}
function isValidText() {

    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?1234567890";
    for (var i = 0; i < document.qfrm.q.value.length; i++) {
        if (iChars.indexOf(document.qfrm.q.value.charAt(i)) != -1) {
            return false;
        }
    }
    return true;
}
function isValidText(x) {
    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";
    for (var i = 0; i < document.qfrm.q.value.length; i++) {
        if (iChars.indexOf(document.qfrm.q.value.charAt(i)) != -1) {
           x.value='';
           
        }
    }
}
function checkNum(x) {
    var s_len = x.value.length;
    var s_charcode = 0;
    for (var s_i = 0; s_i < s_len; s_i++) {
        s_charcode = x.value.charCodeAt(s_i);
        if (!((s_charcode >= 48 && s_charcode <= 57))) {
            x.value = '';
            x.focus();
            return false;
        }
    }
    return true;
}
function ValidIntegerText(e) {
    var keyEntry;
    if (window.event)
    { keyEntry = e.keyCode; }
    else if (e.which)
    { keyEntry = e.which; }
    if (keyEntry == 8 || keyEntry == 9 || keyEntry== 27 || keyEntry== 13 ||
                    (keyEntry >= 35 && keyEntry <= 39)) {
        // let it happen, don't do anything
        return true;
    }
    if (((keyEntry < 48) || (keyEntry > 57))) {
        return false;
    }
}

function validatesaletax() {
    var val = document.getElementById('txtSaleTax').value;
    var objRegExp = /^\s*-?(\d+(\.\d{1,2})?|\.\d{1,2})\s*$/;
    if (!objRegExp.test(val)) {
        alert('invalid sale tax');
        return false;
    }
    else {
        return true;
    }

}
function isUrl(s) {
    if (s.value != "") {
        var url = s.value;
        if (url.indexOf("http", 0) == -1) {
            url = "http://" + url;
        }
        var RegExp = /^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$/;
        if (RegExp.test(url)) {
            return true;
        } else {
        document.getElementById("lblInvalidUrl").innerHTML = "Invalid Url";
            return false;
        }
    }
    else {
        document.getElementById("lblInvalidUrl").innerHTML = "";
        return true;
    }
}

function Validateform() {

    var isValid = true;
    isValid = isUrl(document.getElementById('txtURL'));
    if (!isValid) {
        document.getElementById('txtURL').focus();
        return isValid;
    }
    isValid = validatesaletax();
    if (!isValid) {
        return isValid;
    }
    return isValid;
    
}
function validateTrayPrice(txtHalfTrayPrice,txtFullTrayPrice)
{
    if(document.getElementById("txtDish").value=='')
    {
         document.getElementById("lblDish").style.display="inline-block";
         return false;
    }
    else
    {
         document.getElementById("lblDish").style.display="none";
    }
    var price = document.getElementById(txtHalfTrayPrice).value;
    var regExp = /^\s*((\d+(\.\d\d)?)|(\.\d\d))\s*$/;

    if(!regExp.test(price))
    {
       document.getElementById("lblHalfTrayPrice").style.display="inline-block";
       return false;
    }
    else
    {
         document.getElementById("lblHalfTrayPrice").style.display="none";
    }
    price = document.getElementById(txtFullTrayPrice).value;
    if(!regExp.test(price))
    {
       document.getElementById("lblFullTrayPrice").style.display="inline-block";
       return false;
    }
    else
    {
         document.getElementById("lblFullTrayPrice").style.display="none";
    }
    return true;
}
