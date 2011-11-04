function timeDifferenceFormat(format, timeString) {
    var time = new Date(timeString);
    var now = new Date();

    var difference = Math.abs(now - time);

    //alert(now + ' | ' + timeString + ' | ' + difference);

    var milliseconds = difference % 1000;
    difference = Math.floor(difference / 1000);

    var seconds = difference % 60;
    difference = Math.floor(difference / 60);

    var minutes = difference % 60;
    difference = Math.floor(difference / 60);

    var hours = difference % 24;
    difference = Math.floor(difference / 24);

    return numberFormat(format, hours, minutes, seconds, milliseconds);
}

function numberFormat(format, args) {
    var strFormatted = "";
    for (var i = 1; i < arguments.length; i++)
        strFormatted += numberFormatHelp(arguments[i], format, i - 1);

    return strFormatted;

    function getString(value, size) {
        var str = value.toString();
        for (var i = str.length; i < size; i++) {
            str = '0' + str;
        }
        return str;
    }

    function numberFormatHelp(value, format, indexFormat) {
        var indexStart = format.indexOf('{' + indexFormat + ':');
        if (indexStart >= 0) {
            var indexEnd = format.indexOf('}', indexStart);
            var size = indexEnd - (indexStart + 3);
            //alert(indexStart + ' ' + indexEnd + ' ' + size);

            var indexNext = format.indexOf('{', indexEnd);
            if (indexNext == -1)
                indexNext = format.length;
            var separatorSize = indexNext - (indexEnd + 1);
            //alert(indexNext + ' ' + separatorSize);

            var separator = format.substr(indexEnd + 1, separatorSize);

            return getString(value, size) + separator;
        }

        return "";
    }
}

/* Criando uma classe de helper pra arrays cujos objetos possuem id */
ArrayIDHelper = function() {
}
// Métodos "estáticos"
ArrayIDHelper.indexOfByID = function(id, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].id == id)
            return i;
    }

    return -1;
}
ArrayIDHelper.indexOf = function(item, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == item)
            return i;
    }

    return -1;
}
ArrayIDHelper.containsByID = function(id, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].id == id)
            return true;
    }

    return false;
}
ArrayIDHelper.contains = function(item, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == item)
            return true;
    }

    return false;
}
ArrayIDHelper.findByID = function(id, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].id == id)
            return arr[i];
    }

    return null;
}
ArrayIDHelper.find = function(item, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == item)
            return arr[i];
    }

    return null;
}
/*
// Métodos de instância
ArrayHelper.prototype = {
    indexOf: function(id, arr) {
        for (var i = 0; i < arr.lenght; i++) {
            if (arr[i].id == id)
                return i;
        }

        return -1;
    }
}
*/
