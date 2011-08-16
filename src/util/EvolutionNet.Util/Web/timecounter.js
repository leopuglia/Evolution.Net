// Register the namespace for the control.
Type.registerNamespace('EvolutionNet.TimeCounter');

var t = Array();
var initialTime = new Date();

//Define the custom control class which receives a reference to the
//DOM elenet it is associated with.
EvolutionNet.TimeCounter = function(element) {

    //Initialize the base class, passing a reference to the DOM element.
    EvolutionNet.TimeCounter.initializeBase(this, [element]);

    // Private class properties
    //this.timer = null;
    //this.cancelationPending = false;

    this.id = null;
    this.interval = null;
    this.timeStringFormat = null;
    this.isPostBack = null;
    //this.initialTime = new Date().toString();
}

// Create the prototype for the control.
EvolutionNet.TimeCounter.prototype = {

    //Initialize the custom control class.
    initialize: function() {

        //Initialize the base class, passing a reference to the DOM element.
        EvolutionNet.TimeCounter.callBaseMethod(this, 'initialize');

        //this.initialTime = new Date();
        // Aqui está o pulo do gato, descobrir se é postback ou não
        // Mesmo assim é interessante mander o timer em uma variável global
        if (!this.get_isPostBack())
            this.startCount();
        //else
            //alert("isPostBack");
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

    get_isPostBack: function() {
        return this.isPostBack;
    },
    set_isPostBack: function(value) {
        if (this.isPostBack !== value) {
            this.isPostBack = value;
            this.raisePropertyChanged('isPostBack');
        }
    },

    startCount: function() {
        startTimeCounter(this.get_id(), this.get_timeStringFormat(), this.get_interval());
        //label.innerHTML = timeFormat(this.get_timeStringFormat());
        //timer = setTimeout(function() { this.startCount(); }, this.get_interval());
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

    //var item = ArrayIDHelper.findByID(id, t);
    var i = ArrayIDHelper.indexOfByID(id, t);
    //if (item == null) {
    if (i == -1) {
        //alert('Creating item');
        t.push({ 'id': id, 'timer': setTimeout(function() { startTimeCounter(id, format, interval, startTime); }, interval) });
    }
    else
        //item.timer = setTimeout(function() { startTimeCounter(id, format, interval); }, interval);
        t[i].timer = setTimeout(function() { startTimeCounter(id, format, interval, startTime); }, interval);
}

function stopTimeCounter(id) {
    //var control = $find(id);
    //var item = ArrayIDHelper.findByID(id, t);
    var i = ArrayIDHelper.indexOfByID(id, t);
    //if (item != null && item.timer != null) {
    if (t[i] != null && t[i].timer != null) {
        //clearTimeout(item.timer);
        //alert('Canceled ' + item.timer);
        //item.timer = null;
        clearTimeout(t[i].timer);
        //alert('Canceled ' + t[i].timer);
        t[i].timer = null;
    }
    //else
        //alert('Nothing to cancel');
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

//Register the MediaPlayerButton class with the client AJAX library and specify
//its base class as Sys.UI.Control.
EvolutionNet.TimeCounter.registerClass('EvolutionNet.TimeCounter', Sys.UI.Control);

//Notify the Sys.Application class this script has been loaded.
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
