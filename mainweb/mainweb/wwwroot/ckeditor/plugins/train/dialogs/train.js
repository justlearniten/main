// Whole-positive-integer validator.
//from table plugin code
function validatorNum(msg) {
    return function () {
        var value = this.getValue(),
            pass = !!(CKEDITOR.dialog.validate.integer()(value) && value > 0);

        if (!pass) {
            alert(msg); // jshint ignore:line
            this.select();
        }

        return pass;
    };
}

CKEDITOR.dialog.add('trainDialog', function (editor) {
    return {
        title: 'Паровозик',
        minWidth: 200,
        minHeight: 120,

        contents: [
            {
                id: 'main',
                elements: [
                    {
                        type: 'text',
                        id: 'cars',
                        label: 'Вагончиков',
                        'default': 3,
                        validate: validatorNum("Число вагончиков должно быть числом")
                    },
                    {
                        type: 'checkbox',
                        id: 'tail',
                        label:'Добавить хвост'
                    }
                ]
            }
        ],
        //////////////////////////////////////////////////////////////////////////
        //OK handler
        onOk: function () {
            var dialog = this;
            var train = editor.document.createElement('table');
            train.setAttribute('class', 'train cke_show_border');
            train.setAttribute('align', 'center');
            var row = editor.document.createElement('tr');
            var row2 = editor.document.createElement('tr');
            var n = parseInt(dialog.getValueOf('main', 'cars'));
            var bTail = dialog.getValueOf('main', 'tail');
            var numCols = 0;
            for (var i = 0; i < n; i++) {
                //car 
                var car = editor.document.createElement('td');
                car.setAttribute('class', 'train-car');
                //car.setText(' ');
                row.append(car);

                var txtTd;
                //second row
                var txtTd = editor.document.createElement('td');
                txtTd.setAttribute('class', 'second-row');
                row2.append(txtTd);
                numCols++;
                if (bTail || i < n - 1) {
                    var link = editor.document.createElement('td');
                    link.setAttribute('class', 'train-arrow');
                    var img = editor.document.createElement('img');
                    img.setAttribute('src', '/images/arrow-right.png');
                    link.append(img);
                    row.append(link);
                    //second row
                    txtTd = editor.document.createElement('td');
                    txtTd.setAttribute('class', 'second-row');
                    row2.append(txtTd);
                    numCols++;
                }
            }
            
            if (bTail) {
                var wheelsTd = editor.document.createElement('td');
                var wheelsImg = editor.document.createElement('img');
                wheelsImg.setAttribute('src', '/images/wheels.png');
                wheelsTd.append(wheelsImg);
                row.append(wheelsTd);
                var wheelsText = editor.document.createElement('td');
                //wheelsText.setText(' ');
                wheelsText.setAttribute('class', 'second-row');
                row2.append(wheelsText);
                numCols++;
            }
            var titleRow = editor.document.createElement('tr');
            var titleTd = editor.document.createElement('td');
            titleTd.setAttribute('colspan', numCols.toString());
            titleTd.setAttribute('class', 'train-title');
            titleRow.append(titleTd);

            train.append(titleRow);
            train.append(row);
            train.append(row2);

            editor.insertElement(train);
        }
    };
});