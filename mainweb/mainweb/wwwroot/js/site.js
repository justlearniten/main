﻿// Write your Javascript code.
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
    // get user selection
    var selectedText = getSelectionText();
    repositionAnchor();
    showTranslation(selectedText);
});
function repositionAnchor() {
    if (window.getSelection) {
        sel = window.getSelection();
        if (sel.rangeCount) {
           range = sel.getRangeAt(0).cloneRange();
 
           var span = document.getElementById('anchor');
           var spanParent = span.parentNode;
           spanParent.removeChild(span);
           spanParent.normalize();
           range.insertNode(span);
        }
    }
}
//////////////////////////////////////////////////////////////////////////////////////
