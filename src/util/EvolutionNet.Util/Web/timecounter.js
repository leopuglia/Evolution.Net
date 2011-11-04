// Register the namespace for the control.
Type.registerNamespace('EvolutionNet.TimeCounter');

var tTime = Array();
var initialTime = new Date();

//Define the custom control class which receives a reference to the
//DOM elenet it is associated with.
EvolutionNet.TimeCounter = function(element) {

    //Initialize the base class, passing a reference to the DOM element.
    EvolutionNet.TimeCounter.initializeBase(this, [element]);

    // Private class properties
    this.id = null;
    this.interval = null;
    this.timeStringFormat = null;
    this.startCountOnInit = null;
}

// Create the prototype for the control.
EvolutionNet.TimeCounter.prototype = {

    //Initialize the custom control class.
    initialize: function() {

        //Initialize the base class, passing a reference to the DOM element.
        EvolutionNet.TimeCounter.callBaseMethod(this, 'initialize');

        if (this.get_startCountOnInit())
            this.startCount();
    },

    //Clean-up the custom control class.
    dispose: function() {

        //Clear the behavior event handlers associated with DOM element.
        $clearHandlers(this.get_element());
        //Call the base class dispose() method.
        EvolutionNet.TimeCounter.callBaseMethod(this, 'dispose');
    },

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

    get_interval: function() {
        return this.interval;
    },
    set_interval: function(value) {
        if (this.interval !== value) {
            this.interval = value;
            this.raisePropertyChanged('interval');
        }
    },

    get_timeStringFormat: function() {
        return this.timeStringFormat;
    },
    set_timeStringFormat: function(value) {
        if (this.timeStringFormat !== value) {
            this.timeStringFormat = value;
            this.raisePropertyChanged('timeStringFormat');
        }
    },

    get_startCountOnInit: function() {
        return this.startCountOnInit;
    },
    set_startCountOnInit: function(value) {
        if (this.startCountOnInit !== value) {
            this.startCountOnInit = value;
            this.raisePropertyChanged('startCountOnInit');
        }
    },

    startCount: function(startTime) {
        stopTimeCounter(this.get_id());
        startTimeCounter(this.get_id(), this.get_timeStringFormat(), this.get_interval(), startTime);
    },

    stopCount: function() {
        stopTimeCounter(this.get_id());
    }

}

function startTimeCounter(id, format, interval, startTime) {
    if (startTime == null)
        startTime = initialTime;
    
    var label = document.getElementById(id);
    label.innerHTML = timeDifferenceFormat(format, startTime);

    var i = ArrayIDHelper.indexOfByID(id, tTime);
    if (i == -1) {
        //alert('Creating timer');
        tTime.push({ 'id': id, 'timer': setTimeout(function() { startTimeCounter(id, format, interval, startTime); }, interval) });
    }
    else
        tTime[i].timer = setTimeout(function() { startTimeCounter(id, format, interval, startTime); }, interval);
}

function stopTimeCounter(id) {
    var i = ArrayIDHelper.indexOfByID(id, tTime);
    if (tTime[i] != null && tTime[i].timer != null) {
        clearTimeout(tTime[i].timer);
        tTime[i].timer = null;
    }
}

//Register the MediaPlayerButton class with the client AJAX library and specify
//its base class as Sys.UI.Control.
EvolutionNet.TimeCounter.registerClass('EvolutionNet.TimeCounter', Sys.UI.Control);

//Notify the Sys.Application class this script has been loaded.
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
