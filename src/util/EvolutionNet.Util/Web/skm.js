function skm_CountTextBox(textboxId, outputId, formatString, treatCRasOneChar, maxChars, maxWords, defaultCssClass, warningCssClass, maxCssClass, warningPercentage)
{
    var textBox = document.getElementById(textboxId);
    var output = document.getElementById(outputId);
    
    var tbText = textBox.value;
    var totalWords = 0, wordsRemaining = 0;
    var totalChars = 0, charsRemaining = 0;

    // Count the total number of words...    
    var uniformSpaces = tbText.replace(/\s/g, ' ');
    var pieces = uniformSpaces.split(' ');

    for (var i = 0; i < pieces.length; i++)
        if (pieces[i].length > 0)
            totalWords++;

    // Count the total number of characters...
    if (treatCRasOneChar)
    {        
        var removedExtraChar = tbText.replace('\r\n', '\n');
        totalChars = removedExtraChar.length;
    }
    else   
        totalChars = tbText.length;

    // Compute chars/words remaining    
    if (maxChars > 0 && (maxChars - totalChars > 0))
        charsRemaining = maxChars - totalChars;
    if (maxWords > 0 && (maxWords - totalWords > 0))
        wordsRemaining = maxWords - totalWords;
    
    // Output the message, replacing the placeholders as needed
    output.innerHTML = formatString.replace('{0}', totalWords).replace('{1}', totalChars).replace('{2}', wordsRemaining).replace('{3}', charsRemaining).replace('{4}', maxWords).replace('{5}', maxChars);
    
    // Apply the appropriate CSS class, if needed
    if ((defaultCssClass != '' || warningCssClass != '' || maxCssClass != '') && (maxChars > 0 || maxWords > 0) && (warningPercentage > 0)) {
        // Only apply the CSS classes if they have a value to apply
        // and if at least one of the max variables is set
        if (((totalChars >= maxChars && maxChars > 0) || (totalWords >= maxWords && maxWords > 0)) && (maxCssClass != '')) {
            output.className = output.className.replace(defaultCssClass, '');
            output.className = output.className.replace(warningCssClass, '');

            if (output.className.search(maxCssClass) == -1) {
                output.className = output.className + ' ' + maxCssClass;
            }
        }
        else if (((totalChars >= warningPercentage / 100 * maxChars && maxChars > 0) || (totalWords >= warningPercentage / 100 * maxWords && maxWords > 0)) && (warningCssClass != '')) {
            output.className = output.className.replace(defaultCssClass, '');
            output.className = output.className.replace(maxCssClass, '');

            if (output.className.search(warningCssClass) == -1) {
                output.className = output.className + ' ' + warningCssClass;
            }
        }
        else {
            output.className = output.className.replace(warningCssClass, '');
            output.className = output.className.replace(maxCssClass, '');

            if (output.className.search(defaultCssClass) == -1) {
                output.className = output.className + ' ' + defaultCssClass;
            }
        }
    }
}


/* Based on script created by: John G. Wang | http://www.csua.berkeley.edu/~jgwang/ */
/* Script online at: http://javascript.internet.com/forms/check-cap-locks.html */
function skm_CheckCapsLock( e, warnId, dispTime ) {
	var myKeyCode = 0;
	var myShiftKey = e.shiftKey;
    
	if ( document.all ) {
    	// Internet Explorer 4+
		myKeyCode = e.keyCode;
	} else if ( document.getElementById ) {
    	// Mozilla / Opera / etc.
		myKeyCode = e.which;
	}
	
	if ((myKeyCode >= 65 && myKeyCode <= 90 ) || (myKeyCode >= 97 && myKeyCode <= 122)) {
		if ( 
    	    // Upper case letters are seen without depressing the Shift key, therefore Caps Lock is on
	        ( (myKeyCode >= 65 && myKeyCode <= 90 ) && !myShiftKey )

	        ||

    	    // Lower case letters are seen while depressing the Shift key, therefore Caps Lock is on
	        ( (myKeyCode >= 97 && myKeyCode <= 122 ) && myShiftKey )
    	   )
        {
		    skm_ShowCapsWarning(warnId, dispTime);
	    }
	    else {
	        skm_HideCapsWarning(warnId);
	    }
    }
}

function skm_GetWarningElement(warnId)
{
	if ( document.all ) {
    	// Internet Explorer 4+
		return document.all[warnId];
	} else if ( document.getElementById ) {
    	// Mozilla / Opera / etc.
		return document.getElementById(warnId);
	}
}

/* Clearing of timers logic / script based on work by Ben Kittrell
   http://garbageburrito.com/blog/entry/555/slideshow-clearing-all-javascript-timers */
var myTimers = new Array();

function skm_ShowCapsWarning(warnId, dispTime)
{
    var warnElem = skm_GetWarningElement(warnId);
    
    if (warnElem == null)
        return;
    else
    {
        warnElem.style.visibility = 'visible';
        warnElem.style.display = 'inline';
        
        if (dispTime > 0)
            myTimers.push(setTimeout('skm_HideCapsWarning("' + warnId + '");', dispTime));
    }
}

function skm_HideCapsWarning(warnId)
{
    var warnElem = skm_GetWarningElement(warnId);
    
    if (warnElem == null)
        return;
    else
    {
        warnElem.style.visibility = 'hidden';
        warnElem.style.display = 'none';
        
        // Clear all timers
        while (myTimers.length > 0)
            clearTimeout(myTimers.pop());
    }
}

function skm_Redirect(url, ctrl)
{
    var assocCtrl = document.getElementById(ctrl);
    var assocValue = '';
    
    if (assocCtrl)
        assocValue = assocCtrl.value;
    
    document.location.href = url.replace('{AssocCtrlValue}', escape(assocValue));
}

function skm_CheckForEnter(e, btnToClick)
{
	var myKeyCode = 0;
    
	if ( document.all ) {
    	// Internet Explorer 4+
		myKeyCode = e.keyCode;
	} else if ( document.getElementById ) {
    	// Mozilla / Opera / etc.
		myKeyCode = e.which;
	}
    
    if (myKeyCode == 13)
    {
        var btn = document.getElementById(btnToClick);
        if (btn)
        {
            btn.click();
            
            e.cancelBubble = true;
            if (e.stopPropagation)
                e.stopPropagation();
            
            return false;
        }
    }
    
    return true;
}