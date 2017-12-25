CKEDITOR.plugins.add('overhang', {
    icons: 'overhang',
    init: function (editor) {
        // Plugin logic goes here...
        editor.addCommand('overhang', { exec: insertOverhang });

        editor.ui.addButton('Overhang', {
            label: 'НАДпись',
            command: 'overhang',
            toolbar: 'styles'
        });
    }
});


function insertOverhang(editor) {
   
    var s = editor.document.createElement("span");
    s.setAttribute('class', 'overhang cke_show_border');
    
    var row1 = editor.document.createElement('span');
    row1.setAttribute('class', 'upper cke_show_border');
    row1.setText("надпись");
    s.append(row1);

    var selection = editor.getSelection();
    if (selection)
        selection = selection.getSelectedText();
    if (!selection)
        selection = "слово";

    var row2 = editor.document.createElement('span');
    row2.setAttribute('class', 'lower');
    row2.setText(selection);
    s.append(row2);
    
    editor.insertElement(s);
}
