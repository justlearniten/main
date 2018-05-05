// Write your Javascript code.
//Used for collapsable panel
$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
    }
});
//////////////////////////////////////////////////////////////////////////////////////
//selection for dictionary
//https://stackoverflow.com/questions/15076173/end-of-text-selection-event
var selectionEndTimeout = null;

// bind selection change event to my function
document.onselectionchange = userSelectionChanged;
function userSelectionChanged() {
    // wait 500 ms after the last selection change event
    if (selectionEndTimeout) {
        clearTimeout(selectionEndTimeout);
    }
    selectionEndTimeout = setTimeout(function () {
        $(window).trigger('selectionEnd');
    }, 500);
}
// helper functions
function getSelectionText() {
    var text = "";
    if (window.getSelection) {
        text = window.getSelection().toString();
    } else if (document.selection && document.selection.type != "Control") {
        text = document.selection.createRange().text;
    }
    return text;
}
$(window).bind('selectionEnd', function () {
    // reset selection timeout
    selectionEndTimeout = null;
    document.onselectionchange = undefined;
    // get user selection
    var selectedText = getSelectionText();
    repositionAnchor();
    showTranslation(selectedText);
    document.onselectionchange = userSelectionChanged;
});
function repositionAnchor() {
    if (window.getSelection) {
        sel = window.getSelection();
        if (sel.rangeCount) {
           range = sel.getRangeAt(0).cloneRange();
 
           var span = document.getElementById('anchor');
           if (span) {
               var spanParent = span.parentNode;
               spanParent.removeChild(span);
               spanParent.normalize();
               range.insertNode(span);
           }
        }
    }
}
//////////////////////////////////////////////////////////////////////////////////////
function onBodyLoad() {
    resizeMain();
}

function onBodyResize() {
    resizeMain();
}

function resizeMain() {
    var windowHeight = $(window).height();

    var fullHeight = windowHeight  - 50  - 30;
                                 //navbar  2*padding
        var el = $("#full_height");
    if (el) {
        el.height(fullHeight);
    }

}

function trainerChange(e) {
    var txt = e.value;
    while (e && e.getAttribute("class").indexOf("trainer-car") < 0)
        e = e.parentElement;
    var answers = e.getAttribute("answers");
    console.log(answers);
    if (answers) {
        txt = txt.trim().toLowerCase().replace(/\s\s+/g, ' ');//remove double spaces
        txt = txt + "%$";//see also controller
        var correct = answers.indexOf(txt) >= 0;

        var cl = e.getAttribute("class");
        cl = cl.replace("incorrect", "").replace("correct","");//remove corrct and incorrect classes
        cl = cl + " "+(correct? "correct" : "incorrect");
        e.setAttribute("class", cl);
    }
}