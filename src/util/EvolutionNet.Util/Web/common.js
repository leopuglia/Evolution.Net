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
