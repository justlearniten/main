﻿
var exerciseList = undefined;
function load() {
    var xhr = new XMLHttpRequest();

    xhr.open('get', "/excercises/list", false);
    xhr.setRequestHeader("Content-Type", 'application/json');
    xhr.onload = function () {
        if (xhr.status != 200)
            return xhr.onerror();
        exerciseList = JSON.parse(xhr.response);
    }.bind(this);
    xhr.onerror = function () {
        alert("Ошибка  загрузки упражнений!");
    }
    xhr.send(JSON.stringify(this.state));
}
load();
CKEDITOR.dialog.add('exerciseDialog', function (editor) {
    return {
        title: 'Вставить упражнение',
        minWidth: 250,
        minHeight: 100,

        contents: [
            {
                id: 'main',
                elements: [
                    {
                        type: 'select',
                        id: 'exercises',
                        label: 'Выберите упражнение',
                        items: exerciseList
                    }
                ]
            }
        ],

        //////////////////////////////////////////////////////////////////////////
        onLoad: function () {
            var sel = this.getContentElement("main", "exercises");
            sel.setValue(exerciseList[0][1]);
        },
        //////////////////////////////////////////////////////////////////////////
        //OK handler
        onOk: function () {
            var dialog = this;
            
            var exerciseId = dialog.getValueOf('main', 'exercises');
            var exerciseTitle = undefined;
            for (var i = 0; i < exerciseList.length; i++)
                if (exerciseId === exerciseList[i][1])
                    exerciseTitle = exerciseList[i][0];
            var exerciseLink = "<a href='javascript:showExcercise(" + exerciseId + ")'>" + exerciseTitle + "</a>";

            var a = CKEDITOR.dom.element.createFromHtml(exerciseLink);
            editor.insertElement(a);
        }
    };
});