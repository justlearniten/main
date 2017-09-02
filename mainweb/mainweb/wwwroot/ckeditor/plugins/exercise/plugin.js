CKEDITOR.plugins.add('exercise', {
    icons: 'exercise',
    init: function (editor) {
        // Plugin logic goes here...
        editor.addCommand('exercise', new CKEDITOR.dialogCommand('exerciseDialog'));

        editor.ui.addButton('Exercise', {
            label: 'Упражнение',
            command: 'exercise',
            toolbar: 'styles'
        });

        CKEDITOR.dialog.add('exerciseDialog', this.path + 'dialogs/exercise.js');
    }
});


