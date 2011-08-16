// Register the namespace for the control.
Type.registerNamespace('EvolutionNet.ProgressBar');

var t = new Array();
var count = 0;

//Define the custom control class which receives a reference to the
//DOM elenet it is associated with.
EvolutionNet.ProgressBar = function(element) {

    //Initialize the base class, passing a reference to the DOM element.
    EvolutionNet.ProgressBar.initializeBase(this, [element]);

    // Private class properties
    this.timer = null;
    //this.cancelationPending = false;

    this.id = null;
    this.autoProg = null;
    this.percentualFormat = null;
    this.showPercentualText = null;
    this.progress = null;
    this.progressBarDivID = null;
    this.percentDivID = null;
}

// Create the prototype for the control.
EvolutionNet.ProgressBar.prototype = {

    //Initialize the custom control class.
    initialize: function() {

        //Initialize the base class, passing a reference to the DOM element.
        EvolutionNet.ProgressBar.callBaseMethod(this, 'initialize');

        //Create the event delegates and associate them with their handlers.  
        //this.onloadHandler = Function.createDelegate(this, this.onLoad);

        //Attach the event handlers to the DOM element associated with the control.
        /*
        $addHandlers
        (
        this.get_element(),
        { 'load': this.onLoad },
        this
        );
        */

        if (this.autoProg) {
            //this.cancelationPending = false;
            this.setAutoProgress();
        }
        /*
        else {
        //this.cancelationPending = true;
        this.stopAutoProgress();
        }
        */
        //Default image to play.
        //    this.get_element().src = this._playImageUrl;

    },

    //Clean-up the custom control class.
    dispose: function() {

        //Clear the behavior event handlers associated with DOM element.
        $clearHandlers(this.get_element());
        //Call the base class dispose() method.
        EvolutionNet.ProgressBar.callBaseMethod(this, 'dispose');
    },

    /* Event Delegates*/

    /*
    onLoad: function(e) {
    alert('OnLoad');
    if (this.autoProg) {
    this.cancelationPending = false;
    this.setAutoProgress();
    }
    else {
    this.cancelationPending = true;
    this.stopAutoProgress();
    }
    //Change the image based upon whether the play or pause
    //is currently being displayed.
    //if (this.get_element() && (this.get_element().src.indexOf(this._playImageUrl) == -1)) {
    //this.get_element().src = this._playImageUrl;
    //}
    //else {
    //this.get_element().src = this._pauseImageUrl;
    //}
    },
    */
    /*Properties*/

    get_id: function() {
        return this.id;
    },
    set_id: function(value) {
        if (this.id !== value) {
            this.id = value;
            this.raisePropertyChanged('id');
        }
    },

    get_autoProg: function() {
        return this.autoProg;
    },
    set_autoProg: function(value) {
        if (this.autoProg !== value) {
            this.autoProg = value;
            this.raisePropertyChanged('autoProg');
        }
    },

    get_percentualFormat: function() {
        return this.percentualFormat;
    },
    set_percentualFormat: function(value) {
        if (this.percentualFormat !== value) {
            this.percentualFormat = value;
            this.raisePropertyChanged('percentualFormat');
        }
    },

    //Property get/set for the pause image.
    get_showPercentualText: function() {
        return this.showPercentualText;
    },
    set_showPercentualText: function(value) {
        if (this.showPercentualText !== value) {
            this.showPercentualText = value;
            this.raisePropertyChanged('showPercentualText');
        }
    },

    //Property get/set for the pause image.
    get_progressBarDivID: function() {
        return this.progressBarDivID;
    },
    set_progressBarDivID: function(value) {
        if (this.progressBarDivID !== value) {
            this.progressBarDivID = value;
            this.raisePropertyChanged('progressBarDivID');
        }
    },

    //Property get/set for the pause image.
    get_percentDivID: function() {
        return this.percentDivID;
    },
    set_percentDivID: function(value) {
        if (this.percentDivID !== value) {
            this.percentDivID = value;
            this.raisePropertyChanged('percentDivID');
        }
    },

    get_progress: function() {
        return this.progress;
    },
    set_progress: function(value) {
        if (this.progress !== value) {
            this.progress = value;
            this.raisePropertyChanged('progress');
        }
    },

    changeProgress: function(value) {
        if (value < 0 || value > 100)
            throw ('Value should be between 0 and 100');

        this.set_progress(value);

        var progDiv = document.getElementById(this.get_progressBarDivID());
        if (progDiv != null)
            progDiv.style.width = value.toString() + '%';

        var percDiv = document.getElementById(this.get_percentDivID());
        //alert('Progress: ' + value + ' | ProgID: ' + this.get_progressBarDivID() + ' | Div: ' + progDiv + '\r\nPercID: ' + this.get_percentDivID() + ' | Div: ' + percDiv + ' | Format: ' + this.get_percentualFormat());
        if (percDiv != null && this.get_percentualFormat() != null)
            percDiv.innerHTML = this.get_percentualFormat().replace('{0}', value);
    },

    stepProgress: function(step) {
        this.changeProgress(this.get_progress() + step);
    },

    setAutoProgress: function(step, time) {
        /*
        var i;
        for (i = 0; i < t.length; i++) {
        if (t[i] != null && t[i].id == this.get_id())
        break;
        }
        if (t[i] != null) {
        t[i].cancelationPending = false;
        }
        */
        var i;
        for (i = 0; i < t.length; i++) {
            if (t[i] != null && t[i].id == this.get_id())
                break;
        }
        if ((t[i] == null || (t[i] != null && !t[i].cancelationPending)) && this.timer == null) {
            alert('Starting');
            startAutoProgress(this, step, time);
        }
    },

    stopAutoProgress: function(c) {
        /*
        var i;
        for (i = 0; i < t.length; i++) {
        if (t[i] != null && t[i].id == this.get_id())
        break;
        }
        if (t[i] != null) {
        t[i].cancelationPending = true;
        //alert('Canceling ' + t[i].timer);
        }
        */
        //clearTimeout(this.timer);
        alert('c: ' + c + ' | count: ' + count);
        if (c == null || c == count) {
            var i;
            for (i = 0; i < t.length; i++) {
                if (t[i] != null && t[i].id == this.get_id())
                    break;
            }
            t[i] = { 'id': this.get_id(), 'cancelationPending': true };
            alert('Canceling ' + this.timer);
            //this.cancelationPending = true;

            if (c == count)
                count++;
        }
    }

}

function startAutoProgress(progressBar, step, time) {
    //if (time == null)
        //alert('ProgressBar: ' + progressBar + ' | Step: ' + step + ' | Time: ' + time + ' | timer: ' + progressBar.timer);
    //progressBar.set_percentualFormat("");
    if (step == null)
        step = 1;
    if (time == null)
        time = 10;
        //time = 3000;
    if (progressBar.get_progress() == 100)
        progressBar.changeProgress(0);
    progressBar.stepProgress(step);

    var i;
    for (i = 0; i < t.length; i++) {
        if (t[i] != null && t[i].id == progressBar.get_id())
            break;
    }
    if (t[i] == null) {
        //if (progressBar.timer == null)
        //alert('Runned');
        progressBar.timer = setTimeout(function() { startAutoProgress(progressBar, step, time); }, time);
    }
    else if (!t[i].cancelationPending) {
    //else if (!progressBar.cancelationPending)
        //if (progressBar.timer != null)
        alert('Cancelation pending');
        t[i] = null;
        //progressBar.timer = setTimeout(function() { startAutoProgress(progressBar, step, time); }, time);
    }
    else {
        //t[i].cancelationPending = false;
        //progressBar.cancelationPending = false;
        //progressBar.changeProgress(0);
        t[i] = null;
        clearTimeout(progressBar.timer);
        progressBar.timer = null;
        alert('Canceled');
    }
        
/*
    var i;
    for (i = 0; i < t.length; i++) {
        if (t[i] != null && t[i].id == progressBar.get_id())
            break;
    }
    if (t[i] == null) {
        alert('Creating t');
        t[i] = { 'id': progressBar.get_id(), 'cancelationPending': false, 'timer': setTimeout(function() { startAutoProgress(progressBar, step, time); }, time) };
    }
    else {
        if (!t[i].cancelationPending) {
            //alert('Not Canceling ' + t[i].timer);
            if (t[i].timer != null)
                t[i].timer = setTimeout(function() { startAutoProgress(progressBar, step, time); }, time);
        }
        else {
            progressBar.changeProgress(0);
            clearTimeout(t[i].timer);
            t[i].id = null;
            t[i].timer = null;
            t[i].cancelationPending = false;
            //t[i] = null;
            t[i + 1] = { 'id': progressBar.get_id(), 'cancelationPending': false, 'timer': null };
            alert('Canceled '); // + t[i].timer);
        }
    }
*/
}

/*
function clearAutoProgress(progressBar) {
    progressBar.set_autoProg(false);
    if (progressBar.timer != null) {
        clearTimeout(progressBar.timer);
        progressBar.timer = null;
    }
}
*/

// Optional descriptor for JSON serialization.
/*
CustomControls.MediaPlayerButton.descriptor = 
{
    properties: 
    [
        {name: 'playImageUrl', type: String},
        {name: 'pauseImageUrl', type: String} 
    ]
}
*/

//Register the MediaPlayerButton class with the client AJAX library and specify
//its base class as Sys.UI.Control.
EvolutionNet.ProgressBar.registerClass('EvolutionNet.ProgressBar', Sys.UI.Control);

//Notify the Sys.Application class this script has been loaded.
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
