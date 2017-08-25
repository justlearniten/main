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
                <input className="form-control col-md-12 col-md-offset-2"
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
            <div className="form-horizontal form-group col-ms-12 well">
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
                <input type="submit" className="btn btn-default"
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
            console.log(newState);
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
            console.log(newItem);
            this.setState({ excerciseItems: this.state.excerciseItems.concat([newItem]) });
        }.bind(this);
        xhr.onerror = function () {
            alert("Ошибка  при создании вопроса!");
        }
        xhr.send(JSON.stringify(this.state.excerciseId));
    },
    onEditQuestion: function (itemId, newQuestion) {
        console.log(newQuestion);
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
            console.log(newAnswer);
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
        console.log(data);
        var xhr = new XMLHttpRequest();

        xhr.open('post', '/Excercises/DeleteAnswer', true);
        xhr.setRequestHeader("Content-Type", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return xhr.onerror();
            var newItems = JSON.parse(xhr.response);
            console.log(newItems);
            
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
                        <input className="form-control col-md-8" 
                            value={this.state.excerciseName}
                            onChange={this.onNameChange} />
                        <input type="submit" value="Save" className="btn btn-default col-md-1 col-md-offset-1"
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
             </div>
            );
    }
});


//ReactDOM.render("ExcerciseItemsList",
//    <CommentBox />,
//    document.getElementById('excerciseDiv')
//);