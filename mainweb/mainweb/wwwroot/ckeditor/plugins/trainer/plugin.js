function getTrainer(trainerId) {
    if (!trainerId) return "";
        var xhr = new XMLHttpRequest();

        var request = new XMLHttpRequest();
        request.open('GET', '/trainers/code/' + trainerId, false);  // `false` makes the request synchronous
        request.send(null);

        if (request.status === 200) {
            console.log(request.responseText);
            return (request.responseText);
        }
        return "";
}

CKEDITOR.plugins.add('trainer', {
    requires: 'trainer',

    icons: 'trainer',

    init: function (editor) {
        editor.widgets.add('trainer', {
            //button: 'Вставить тренажер',
            defaults: {
                trainerId: 0
            },
            template:
            '<div class="trainer" >  ' +
            '' +
            '</div>',
            allowedContent: 'div(!trainer){trainerId}; div(!simplebox-content); h2(!simplebox-title)',

            requiredContent: 'div(trainer)',

            dialog: 'trainer',

            upcast: function (element) {
                console.log("upcast");
                console.log(element);
                return element.name == 'div' && element.hasClass('trainer');
            },


            data: function () {
                if (this.data.trainerId)
                    this.element.setAttribute("trainerId9", this.data.trainerId);
                var el = this.element;
                if (el && this.data.trainerId) {
                    var $el = jQuery(el.$);
                    var trainerCode = getTrainer(this.data.trainerId);
                    $el.html(trainerCode);

                }
            },

            init: function () {
                console.log(this.element);
                var trainerId = this.element.getAttribute('trainerId9');
                if (trainerId)
                    this.setData('trainerId', trainerId);
            }

        });

        CKEDITOR.dialog.add('trainer', this.path + 'dialogs/trainer.js');
        editor.ui.addButton('trainer', {
            label: 'Вставить тренажер',
            command: 'trainer',
            toolbar: 'styles'
        });

    }
});