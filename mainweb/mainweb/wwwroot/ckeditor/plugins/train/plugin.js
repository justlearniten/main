CKEDITOR.plugins.add('train', {
    icons: 'train',
    init: function (editor) {
        // Plugin logic goes here...
        editor.addCommand('train', new CKEDITOR.dialogCommand('trainDialog'));

        editor.ui.addButton('Train', {
            label: 'Паровозик',
            command: 'train',
            toolbar: 'styles'
        });

        CKEDITOR.dialog.add('trainDialog', this.path + 'dialogs/train.js');
    }
});


