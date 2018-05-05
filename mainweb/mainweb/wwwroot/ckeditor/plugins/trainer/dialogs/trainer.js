var trainersList = undefined;
function load() {
    var xhr = new XMLHttpRequest();

    xhr.open('get', "/trainers/list", false);
    xhr.setRequestHeader("Content-Type", 'application/json');
    xhr.onload = function () {
        if (xhr.status != 200)
            return xhr.onerror();
        trainersList = JSON.parse(xhr.response);
    }.bind(this);
    xhr.onerror = function () {
        alert("Ошибка  при загрузке тренажеров!");
    }
    xhr.send(JSON.stringify(this.state));
}
load();

CKEDITOR.dialog.add('trainer', function (editor) {
    return {
       title: 'Вставить тренажер',
       minWidth: 300,
       minHeight: 100,
       
       contents: [
       {
           id: 'main',
           elements: [
               {
                   type: 'select',
                   id: 'trainers',
                   label: 'Выберите тренажер',
                   items: trainersList,

                   setup: function (widget) {
                       this.setValue(widget.data.trainerId);
                   },

                   commit: function (widget) {
                       console.log("Hello");
                       widget.setData('trainerId', this.getValue());
                   
                   }
               }
           ]
       }
       ],
    };
});