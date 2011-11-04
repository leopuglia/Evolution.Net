// Register the namespace for the control.
Type.registerNamespace('EvolutionNet.ProgressBar');

var tProg = new Array();
var count = 0;

//Define the custom control class which receives a reference to the
//DOM elenet it is associated with.
EvolutionNet.ProgressBar = function(element) {

    //Initialize the base class, passing a reference to the DOM element.
    EvolutionNet.ProgressBar.initializeBase(this, [element]);

    // Private class properties
    this.id = null;
    this.startOnInit = null;
    this.percentualFormat = null;
    this.showPercentualText = null;
    this.progressValue = null;
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
        $addHandlers (
        this.get_element(),
        { 'load': this.onLoad },
        this
        );
        */

        if (this.get_startOnInit()) {
            this.startAutoProgress();
        }

        //Default image to play.
        //this.get_element().src = this._playImageUrl;

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
    //Change the image based upon whether the play or pause
    //is currently being displayed.
    if (this.get_element() && (this.get_element().src.indexOf(this._playImageUrl) == -1)) {
    this.get_element().src = this._playImageUrl;
    }
    else {
    this.get_element().src = this._pauseImageUrl;
    }
    },
    */

    /* Properties */

    get_id: function() {
        return this.id;
    },
    set_id: function(value) {
        if (this.id !== value) {
            this.id = value;
            this.raisePropertyChanged('id');
        }
    },

    get_startOnInit: function() {
        return this.startOnInit;
    },
    set_startOnInit: function(value) {
        if (this.startOnInit !== value) {
            this.startOnInit = value;
            this.raisePropertyChanged('startOnInit');
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

    get_showPercentualText: function() {
        return this.showPercentualText;
    },
    set_showPercentualText: function(value) {
        if (this.showPercentualText !== value) {
            this.showPercentualText = value;
            this.raisePropertyChanged('showPercentualText');
        }
    },

    get_progressValue: function() {
        return this.progressValue;
    },
    set_progressValue: function(value) {
        if (this.progressValue !== value) {
            this.progressValue = value;
            this.raisePropertyChanged('progressValue');
        }
    },

    get_progressBarDivID: function() {
        return this.progressBarDivID;
    },
    set_progressBarDivID: function(value) {
        if (this.progressBarDivID !== value) {
            this.progressBarDivID = value;
            this.raisePropertyChanged('progressBarDivID');
        }
    },

    get_percentDivID: function() {
        return this.percentDivID;
    },
    set_percentDivID: function(value) {
        if (this.percentDivID !== value) {
            this.percentDivID = value;
            this.raisePropertyChanged('percentDivID');
        }
    },

    /* Methods */

    setProgress: function(value) {
        if (value < 0 || value > 100)
            throw ('Value should be between 0 and 100');

        this.set_progressValue(value);

        var progDiv = document.getElementById(this.get_progressBarDivID());
        if (progDiv != null)
            progDiv.style.width = value.toString() + '%';

        var percDiv = document.getElementById(this.get_percentDivID());
        //alert('Progress: ' + value + ' | ProgID: ' + this.get_progressBarDivID() + ' | Div: ' + progDiv + '\r\nPercID: ' + this.get_percentDivID() + ' | Div: ' + percDiv + ' | Format: ' + this.get_percentualFormat());
        if (this.get_showPercentualText()) {
            if (percDiv != null && this.get_percentualFormat() != null)
                percDiv.innerHTML = this.get_percentualFormat().replace('{0}', value);
        }
        else if (percDiv != null)
            percDiv.innerHTML = "";
    },

    stepProgress: function(step) {
        this.setProgress(this.get_progressValue() + step);
    },

    startAutoProgress: function(step, time) {
        stopAutoProgressBar(this.get_id());
        startAutoProgressBar(this, step, time);
    },

    stopAutoProgress: function() {
        //this.set_showPercentualText(true);
        stopAutoProgressBar(this.get_id());
    }

}

function startAutoProgressBar(progressBar, step, time) {
    //if (time == null)
        //alert('ProgressBar: ' + progressBar + ' | Step: ' + step + ' | Time: ' + time + ' | timer: ' + progressBar.timer);
    
    if (step == null)
        step = 1;
    if (time == null) {
        time = 10;
        //time = 3000;
    }
        
    if (progressBar.get_progressValue() == 100)
        progressBar.setProgress(0);
    
    progressBar.stepProgress(step);

    var i = ArrayIDHelper.indexOfByID(progressBar.get_id(), tProg);
    if (i == -1) {
        //alert('Creating timer of progressBar');
        tProg.push({ 'id': progressBar.get_id(), 'timer': setTimeout(function() { startAutoProgressBar(progressBar, step, time); }, time) });
    }
    else
        tProg[i].timer = setTimeout(function() { startAutoProgressBar(progressBar, step, time); }, time);
}

function stopAutoProgressBar(id) {
    var i = ArrayIDHelper.indexOfByID(id, tProg);
    if (tProg[i] != null && tProg[i].timer != null) {
        clearTimeout(tProg[i].timer);
        tProg[i].timer = null;
    }
}


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
