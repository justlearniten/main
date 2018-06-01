var Modal = ReactBootstrap.Modal;
var Button = ReactBootstrap.Button;
var FormGroup = ReactBootstrap.FormGroup;
var ExcerciseItem = React.createClass({
    //addAnswer: function (e) {
    //    this.setState({ correctResponses: this.state.correctResponses.concat([{ answer: "hehehe" }]) });
    //},
    onEditQuestion: function (e) {
        this.props.onEditQuestion(this.props.item.excerciseItemId, e.target.value);
    },
    onEditAnswer: function (correctResponseId, newValue) {
        this.props.onEditAnswer(this.props.item.excerciseItemId, correctResponseId, newValue);
    },
    onAddAnswer: function () {
        this.props.onAddAnswer(this.props.item.excerciseItemId);
    },
    onDeleteAnswer: function (correctResponseId) {
        if (!window.confirm("Точно удалить?")) return;
        this.props.onDeleteAnswer(this.props.item.excerciseItemId, correctResponseId);
    },
    onDeleteItem: function () {
        if (!window.confirm("Точно удалить?")) return;
        this.props.onDeleteItem(this.props.item.excerciseItemId);
    },
    render: function () {
        var answers = this.props.item.correctResponses.map((r) =>
            <div className="col-md-12" key={r.correctResponseId}>
                <input className="form-control col-md-7 col-md-offset-2 width58" 
                type="text"
                placeholder="Введите вариант"
                defaultValue={r.answer}
                name={"ans-" + r.correctResponseId}
                onChange={(e) => { this.onEditAnswer(r.correctResponseId, e.target.value) } }
                />
                <input type="button" value="Удалить" className="btn btn-danger col-md-2 col-md-offset-1"
                    onClick={(e) => { this.onDeleteAnswer(r.correctResponseId) }} />
            </div>
            );
        return (
            <div className="form-horizontal form-group col-md-12 well">
                <label className="col-md-2 control-label">Вопрос</label>
                <div className="col-md-10">
                    <input className = "form-control"
                        type="text"
                        placeholder="Введите вопрос"
                        defaultValue={this.props.item.question}
                        onChange={this.onEditQuestion}
                    />
                </div>
                <div className="col-md-12">
                    <label className="control-label col-md-4" style={{ textAlign: "center" }}>Варианты ответов</label>
                </div>
                <div className="col-md-12">
                    {answers}
                </div>
                <input type="button" value="Удалить вопрос" className="btn btn-danger "
                    onClick={this.onDeleteItem} />
                <input type="button"
                    value="Добавить ответ"
                    className="btn btn-default col-md-offset-1"
                    onClick={this.onAddAnswer}
                />
            </div>
        );
    }
});

var ExcerciseItemsList = React.createClass({
    getInitialState: function () {
        return { items: this.props.items };
    },
    onAddItem: function (e) {
        e.preventDefault();
        this.props.onAddItem();
    },
    render: function () {
        var items = this.props.items.map((i) =>
            <ExcerciseItem item={i} key={i.excerciseItemId}
                onEditQuestion={this.props.onEditQuestion}
                onAddAnswer={this.props.onAddAnswer}
                onEditAnswer={this.props.onEditAnswer}
                onDeleteAnswer={this.props.onDeleteAnswer}
                onDeleteItem={this.props.onDeleteItem}
            />
        );
        return (
            <div>
                {items}
                <input type="submit" className="btn btn-default col-md-3"
                    onClick={this.onAddItem}
                    value="Добавить вопрос" />
            </div>     
       );
    }
});
var Excercise = React.createClass({
    getInitialState: function () {
        return this.props.excercise;
    },
    onSave: function (e) {
        e.preventDefault();
        var excerciseName = this.state.excerciseName.trim();

        var xhr = new XMLHttpRequest();

        xhr.open('post', this.state.excerciseId, true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            var newState = JSON.parse(xhr.response);

            this.setState(newState);
        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка  при сохранении!");
        }
        xhr.send(JSON.stringify(this.state));
        
    },
    onAddItem: function () {
        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/AddExcerciseItem', true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            var newItem = JSON.parse(xhr.response);

            this.setState({ excerciseItems: this.state.excerciseItems.concat([newItem]) });
        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка  при создании вопроса!");
        }
        xhr.send(JSON.stringify(this.state.excerciseId));
    },
    onEditQuestion: function (itemId, newQuestion) {

        var newItems = this.state.excerciseItems.slice(0);
        for (var i = 0; i < newItems.length; i++) {
            if (newItems[i].excerciseItemId == itemId) {
                newItems[i].question = newQuestion;
                break;
            }
        }
        this.setState({ excerciseItems: newItems });
    },
    onEditAnswer: function (excerciseItemId, correctResponseId, newValue) {
        var newItems = this.state.excerciseItems.slice(0);
        for (var i = 0; i < newItems.length; i++) {
            if (newItems[i].excerciseItemId == excerciseItemId) {
                for (var j = 0; j < newItems[i].correctResponses.length; j++) {
                    if (newItems[i].correctResponses[j].correctResponseId == correctResponseId) {
                        newItems[i].correctResponses[j].answer = newValue;
                        break;
                    }
                }
                break;
            }
        }
        this.setState({ excerciseItems: newItems });
    },
    onAddAnswer: function (excerciseItemId) {
        var data = { excerciseItemId: excerciseItemId, excerciseId: this.state.excerciseId };

        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/AddAnswer', true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            var newAnswer = JSON.parse(xhr.response);

            var newExcerciseItems = JSON.parse(JSON.stringify(this.state.excerciseItems));
            for (var i = 0; i < newExcerciseItems.length; i++) {
                if (newExcerciseItems[i].excerciseItemId == excerciseItemId)
                    newExcerciseItems[i].correctResponses.push(newAnswer);
            }
            this.setState({ excerciseItems: newExcerciseItems });
        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка  при создании вопроса!");
        }
        xhr.send(JSON.stringify(data));
    },
    onDeleteAnswer: function (excerciseItemId, correctResponseId) {
        var data = { excerciseItemId: excerciseItemId, correctResponseId: correctResponseId, excerciseId: this.state.excerciseId };

        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/DeleteAnswer', true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            var newItems = JSON.parse(xhr.response);

            
            this.setState({ excerciseItems: newItems });
        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка  при удалении ответа!");
        }
        xhr.send(JSON.stringify(data));
    },
    onDeleteItem: function (excerciseItemId) {
        var data = { excerciseItemId: excerciseItemId, excerciseId: this.state.excerciseId };

        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/DeleteItem', true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            
            var newItems = [];
            for (var i = 0; i < this.state.excerciseItems.length; i++)
                if (this.state.excerciseItems[i].excerciseItemId != excerciseItemId)
                    newItems.push(this.state.excerciseItems[i]);
            this.setState({ excerciseItems: newItems });
        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка  при удалении вопроса!");
        }
        xhr.send(JSON.stringify(data));
    },
    onNameChange: function (e) {
        this.setState({ excerciseName: e.target.value });
    },
    render: function () {
        return (
            <div className="form-horizontal">
                 <input type="hidden" value={this.state.excerciseId} />
                <div className="form-group">
                    <label className="col-md-2 control-label">Название</label>
                    <div className="col-md-10">
                        <input className="col-md-8 form-control width58" 
                            value={this.state.excerciseName}
                            onChange={this.onNameChange} />
                        <input type="submit" value="Сохранить" className="btn btn-default col-md-2 col-md-offset-1"
                            onClick={this.onSave} />
                    </div>
                </div>
                <ExcerciseItemsList
                    items={this.state.excerciseItems}
                    excerciseId={this.state.excerciseId}
                    onAddItem={this.onAddItem}
                    onEditQuestion={this.onEditQuestion}
                    onAddAnswer={this.onAddAnswer}
                    onEditAnswer={this.onEditAnswer}
                    onDeleteAnswer={this.onDeleteAnswer}
                    onDeleteItem={this.onDeleteItem}
                />
                <input type="submit" value="Сохранить" className="btn btn-default col-md-3 col-md-offset-1"
                    onClick={this.onSave} />
             </div>
            );
    }
});
///////////////////////////////////////////////////////////////////////////
var ExcerciseDlg = React.createClass({
    getInitialState: function () {
        return {
            currentItem: 0,
            show: true,
            validationState:null
        };
    },
    onEditAnswer: function (e) {
        var newItems = this.state.excercise.excerciseItems.slice(0);
        newItems[this.state.currentItem].answer = e.target.value;
        this.setState({
            excercise:
            {
                excerciseId: this.state.excercise.excerciseId,
                excerciseName: this.state.excercise.excerciseName,
                excerciseItems: newItems
            }
        });
        this.checkAnswer();
       
    },
    checkAnswer: function (index) {
        var idx = index !== undefined ?index: this.state.currentItem;
        var answer = this.state.excercise.excerciseItems[idx].answer.trim();

        if (!answer) {
            this.setState({ validationState: null });
            return;
        }
        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/CheckAnswer', true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();

            var res = JSON.parse(xhr.response);
            var status = null;
            if (res.correct)
                status = "success";
            else
                status = "error";
            this.setState({ validationState: status });

        }.bind(this);

        xhr.onerror = function () {
            this.setState({ validationState: null });
        }.bind(this);

        xhr.send(JSON.stringify(this.state.excercise.excerciseItems[idx]));
   
    },
    onForward: function (e) {
        var index = this.state.currentItem + 1;
        if (index >= this.state.excercise.excerciseItems.length)
            index = this.state.excercise.excerciseItems.length-1;
        this.setState({ currentItem: index });
        this.checkAnswer(index);
    },
    onBack: function (e) {
        var index = this.state.currentItem - 1;
        if (index < 0)
            index = 0;

        this.setState({ currentItem: index });
        this.checkAnswer(index);
    },
    close: function () {
        this.setState({ show: false });
    },
    onHide: function () {
        showConfirm(
            () => { this.setState({ show: false }); },
            "Закончить упражнение без оценки?",
            null,
            "Да", "Нет");
    },
    check: function () {
        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/Check', false);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            var res = JSON.parse(xhr.response);

            this.setState({ show: false });
            var msg = "Вы набрали " + res.points + " баллов из " + res.maxPoints + " возможных";
            showOk("Упраженение проверено", msg);

        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка при проверке упражнения");
        }
        var timeLocal =  new Date();
        var offsetMinutes = timeLocal.getTimezoneOffset();
        timeLocal = new Date(timeLocal.getTime() - offsetMinutes * 60 * 1000);
        this.state.excercise.currentTime = timeLocal;
        xhr.send(JSON.stringify(this.state.excercise));
    },
    onCheck: function () {
        showConfirm(
            this.check,
            "Проверить упражнение?",
            "Если вы уже выполняли это упражнение, проверка сбросит предыдущий результат.",
            "Да", "Нет");
    },
    render: function () {
        var a = (
            <Modal bsSize="large" backdrop="static"
                show={this.state.show} onHide={this.onHide} >
                <Modal.Header closeButton >
                    <Modal.Title><b>{this.state.excercise && this.state.excercise.excerciseName}</b></Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <div className="form-horizontal">
                        <div className="form-group">
                            <label className="col-md-2 control-label">Вопрос: </label>
                            <div className="col-md-8" style={{ paddingTop: "7px" }}>
                                {this.state.excercise && this.state.excercise.excerciseItems[this.state.currentItem].question}
                            </div>
                        </div>
                        <FormGroup validationState={this.state.validationState} >
                        <div className=" form-group">
                            <label className="col-md-2 control-label">Ответ: </label>
                            <input className="form-control col-md-8" style={{ maxWidth: "600px" }}
                                value={this.state.excercise ? this.state.excercise.excerciseItems[this.state.currentItem].answer : ""}
                                onChange={this.onEditAnswer}
                               
                            />
                        </div>
                        </FormGroup>
                    </div>
                </Modal.Body>

                <Modal.Footer >
                    <div>
                        <div className="col-md-4" style={{ textAlign: "left" }}>
                            <Button onClick={this.onBack}><i className="fa fa-chevron-left" aria-hidden="true"></i></Button>
                            <label className="control-label"
                                style={{ paddingLeft: "10px", paddingRight: "10px" }}>
                                &nbsp; {this.state.currentItem + 1} / {this.state.excercise ? this.state.excercise.excerciseItems.length : 1}&nbsp;
                            </label>
                            <Button onClick={this.onForward}><i className="fa fa-chevron-right" aria-hidden="true"></i></Button>
                        </div>
                        <div className="col-md-4 col-md-offset-4">
                            <Button bsStyle="primary" onClick={this.onCheck}>Сдать на проверку</Button>
                        </div>
                    </div>
                </Modal.Footer>
            </Modal>
        );
        return a;
    }
});

function getExcercise(excerciseId) {
    

    var xhr = new XMLHttpRequest();
    var res = null;
    xhr.open('get', '/Excercises/Details/' + excerciseId, false);
    xhr.setRequestHeader("Accept", 'application/json');
    xhr.onload = function () {
        if (xhr.status != 200)
            return null;
        res = JSON.parse(xhr.response);
    }.bind(this);
    xhr.onerror = function () {
        return null;
    }
    xhr.send();
    return res;
}

function showExcercise(excerciseId){


    //var excercise = getExcercise(excerciseId);
    
    var a = ReactDOM.render(
        <ExcerciseDlg excerciseId={excerciseId} show={true} />,
        document.getElementById('excerciseDiv')
    );
    a.setState({
        excercise: getExcercise(excerciseId),
        currentItem: 0,
        show: true
    });
}
///////////////////////////////////////////////////////////////////////////

//ReactDOM.render("ExcerciseItemsList",
//    <CommentBox />,
//    document.getElementById('excerciseDiv')
//);