function tandaPemisahTitik(b) {
    var _minus = false;
    if (b < 0) _minus = true;
    b = b.toString();
    b = b.replace(".", "");
    b = b.replace("-", "");
    c = "";
    panjang = b.length;
    j = 0;
    for (i = panjang; i > 0; i--) {
        j = j + 1;
        if (((j % 3) == 1) && (j != 1)) {
            c = b.substr(i - 1, 1) + "." + c;
        } else {
            c = b.substr(i - 1, 1) + c;
        }
    }
    if (_minus) c = "-" + c;
    return c;
}

function numbersonly(ini, e) {
    //keyCode => from numpad 1 until numpad 9
    if (e.keyCode >= 96 && e.keyCode <= 105) {
        e.keyCode = e.keyCode - 48;
    }

    //keyCode => from 1 until 9
    if (e.keyCode >= 49 && e.keyCode <= 57) {
        let b = ini.value.replace(/[^\d]/g, "");
        b = (b == "0") ? String.fromCharCode(e.keyCode) : b + String.fromCharCode(e.keyCode);
        ini.value = tandaPemisahTitik(b);
    }
    //keyCode => 0
    else if (e.keyCode == 48) {
        let b = ini.value.replace(/[^\d]/g, "") + String.fromCharCode(e.keyCode);
        if (parseFloat(b) != 0) {
            ini.value = tandaPemisahTitik(b);
        }
        else {
            ini.value = "0";
        }
    }
    //keyCode => backspace || delete
    else if (e.keyCode == 8 || e.keycode == 46) {
        let b = ini.value.replace(/[^\d]/g, "");
        b = b.substr(0, b.length - 1);
        if (tandaPemisahTitik(b) != "") {
            ini.value = tandaPemisahTitik(b);
        }
        else {
            ini.value = "0";
        }
    }
    //keyCode => tab
    else if (e.keyCode == 9) {
        return true;
    }

    return false;
}

function NumberAllowDecimal(ini, e) {
    //keyCode => from numpad 1 until numpad 9
    if (e.keyCode >= 96 && e.keyCode <= 105) {
        e.keyCode = e.keyCode - 48;
    }

    //keyCode => from 1 until 9
    if (e.keyCode >= 49 && e.keyCode <= 57) {
        let valueWoThousandSeparator = ini.value.replace(/[^\d,]/g, "") + String.fromCharCode(e.keyCode);
        let values = valueWoThousandSeparator.split(',');
        if (values.length > 1) {
            ini.value = tandaPemisahTitik(values[0]) + ',' + values[1];
        }
        else {
            ini.value = ini.value == "0" ? String.fromCharCode(e.keyCode) : tandaPemisahTitik(values[0]);
        }
    }
    //keyCode => 0
    else if (e.keyCode == 48) {
        let valueWoThousandSeparator = ini.value.replace(/[^\d,]/g, "") + String.fromCharCode(e.keyCode);
        let values = valueWoThousandSeparator.split(',');
        if (values.length > 1) {
            ini.value = tandaPemisahTitik(values[0]) + ',' + values[1];
        }
        else if (parseFloat(values[0]) != 0) {
            ini.value = tandaPemisahTitik(values[0]);
        }
        else {
            ini.value = "0";
        }
    }
    //keyCode => backspace || delete
    else if (e.keyCode == 8 || e.keycode == 46) {
        let valueWoThousandSeparator = ini.value.replace(/[^\d,]/g, "");
        valueWoThousandSeparator = valueWoThousandSeparator.substr(0, valueWoThousandSeparator.length - 1);
        let values = valueWoThousandSeparator.split(',');
        if (values.length > 1) {
            ini.value = tandaPemisahTitik(values[0]) + ',' + values[1];
        }
        else if (tandaPemisahTitik(values[0]) != "") {
            ini.value = tandaPemisahTitik(values[0]);
        }
        else {
            ini.value = "0";
        }
    }
    //keyCode => tab
    else if (e.keyCode == 9) {
        return true;
    }
    //keyCode => comma
    else if (e.keyCode == 188) {
        let valueWoThousandSeparator = ini.value.replace(/[^\d,]/g, "");
        let values = valueWoThousandSeparator.split(',');
        if (values.length == 1) {
            ini.value = tandaPemisahTitik(values[0]) + ',';
        }
    }

    return false;
}

function generateUUID() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}