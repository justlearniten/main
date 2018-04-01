var Modal = ReactBootstrap.Modal;
var Button = ReactBootstrap.Button;
var FormGroup = ReactBootstrap.FormGroup;
var FormControl = ReactBootstrap.FormControl;
var Checkbox = ReactBootstrap.Checkbox;
var Radio = ReactBootstrap.Radio;
var Form = ReactBootstrap.Form;

var lastId = 2000000000;
function makeid() {
    return ++lastId;
    //var text = "a";
    //var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    //for (var i = 0; i < 5; i++)
    //    text += possible.charAt(Math.floor(Math.random() * possible.length));

    //return text;
}
var TrainerCorrectAnswer = React.createClass({
    getInitialState: function () {
        return null;
    },
    render: function () {
        return (
            <Form inline>
                <FormControl className={"no-max-width"}
                    type="text"
                    id={this.props.correctAnswer.trainerCorrectResponseId.toString()}
                    value={this.props.correctAnswer.answer}
                    placeholder="Введите ответ"
                    onChange={this.props.onAnswerEdit}
                />
                <Button bsStyle="danger" onClick={e => this.props.deleteAnswer(this.props.correctAnswer.trainerCorrectResponseId)}>Удалить</Button>
            </Form>
            );
    }
});
//////////////////////////////////////////////////////////////
var TrainerCar = React.createClass({
    onAddAnswer(e) {
        this.props.addCorrectResponse(this.props.car.trainerCarId);
    },
    render: function () {
        var answers = this.props.car.correctResponses.map((a) =>
            <TrainerCorrectAnswer
                deleteAnswer={this.props.deleteAnswer}
                correctAnswer={a}
                onAnswerEdit={this.props.onAnswerEdit}
                key={a.trainerCorrectResponseId} />
        );
        var radio_name = "carstyle_" + this.props.car.trainerCarId;
        return (
            <div className="form-horizontal form-group col-md-12 well">
                <div className="col-md-8">
                    {answers}
                    <hr/>
                    <Button onClick={this.onAddAnswer}>Добавить ответ</Button>
                </div>
                <div className="col-md-4">
                    <div className="col-md-12">
                        <Checkbox id={this.props.car.trainerCarId.toString()}
                            checked={this.props.hasWheels} onChange={this.props.onChangeWheels} >
                       &nbsp;Колесики
                        </Checkbox>
                    </div>
                    <div className="col-md-12">
                        {this.props.car.style == 0 &&
                            <Radio name={radio_name} checked onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString()+"_"+"0"}>&nbsp;Без подчеркивания</Radio>
                        }
                        {this.props.car.style != 0 &&
                            <Radio name={radio_name} onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"0"}>&nbsp;Без подчеркивания</Radio>
                        }
                        {this.props.car.style == 1 &&
                            <Radio name={radio_name} checked onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"1"}>Одинарное черное</Radio>
                        }
                        {this.props.car.style != 1 &&
                            <Radio name={radio_name} onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"1"}>Одинарное черное</Radio>
                        }
                        {this.props.car.style == 3 &&
                            <Radio name={radio_name} checked onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"3"}>Двойное черное</Radio>
                        }
                        {this.props.car.style != 3 &&
                            <Radio name={radio_name} onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"3"}>Двойное черное</Radio>
                        }
                        {this.props.car.style == 2 &&
                            <Radio className={"red-underline"} name={radio_name} checked onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"2"}>Одинарное красное</Radio>
                        }
                        {this.props.car.style != 2 &&
                            <Radio className={"red-underline"} name={radio_name} onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"2"}>Одинарное красное</Radio>
                        }
                        {this.props.car.style == 4 &&
                            <Radio name={radio_name} checked onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"4"}>Двойное красное</Radio>
                        }
                        {this.props.car.style != 4 &&
                            <Radio name={radio_name} onChange={this.props.onStyleChange} value={this.props.car.trainerCarId.toString() + "_" +"4"}>Двойное красное</Radio>
                        }
                    </div>
                </div>
                
            </div>
        );
    }
});

/////////////////////////////////////////////////////////////////////////////////
var Trainer = React.createClass({

    getInitialState: function () {
        return {
            trainer: this.props.trainer
        };
      
    },
    componentDidMount: function () {
        /* let configuration = {
             toolbar: "Basic"
         };*/
        CKEDITOR.replace("editor");//, configuration);
        CKEDITOR.instances.editor.on('change', function () {
            let data = CKEDITOR.instances.editor.getData();
            this.setState({ original: data });
        }.bind(this));



    },
    onAnswerEdit(e) {

        var trainerCorrectResponseId = e.target.id;
        var value = e.target.value;
        var state = Object.assign({}, this.state);
        for (var i = 0; i < state.trainer.cars.length; i++)
        {
            var car = state.trainer.cars[i];
            for (var j = 0; j < car.correctResponses.length; j++) {
                var correctResponse = car.correctResponses[j];
                if (correctResponse.trainerCorrectResponseId == trainerCorrectResponseId) {
                    correctResponse.answer = value;
                    this.setState(state);
                    return;
                }
            }

        }

    },
    onChangeWheels(e) {
        var trainerCarId = parseInt(e.target.id);
        var newVal = e.target.checked;
        var state = Object.assign({}, this.state);
        for (var i = 0; i < state.trainer.cars.length; i++) {
            var car = state.trainer.cars[i];
            if (car.trainerCarId == trainerCarId) {
                car.hasWheels = newVal;
                this.setState(state);
                return;
            }
        }
        
    },
    onStyleChange(e) {
        var parts = e.target.value.split("_");
        var trainerCarId = parseInt(parts[0]);
        var style = parseInt(parts[1]);

        var state = Object.assign({}, this.state);
        for (var i = 0; i < state.trainer.cars.length; i++) {
            var car = state.trainer.cars[i];
            if (car.trainerCarId == trainerCarId) {
                car.style = style;
                this.setState(state);
                return;
            }
        }
    },
    addCorrectResponse(trainerCarId) {
        var state = Object.assign({}, this.state);
        for (var i = 0; i < state.trainer.cars.length; i++) {
            var car = state.trainer.cars[i];
            if (car.trainerCarId == trainerCarId) {
                car.correctResponses.push({
                    trainerCorrectResponseId: makeid(),
                    answer: ""
                });
                this.setState(state);
                return;
            }
        }
    },
    deleteAnswer(trainerCorrectResponseId) {
        var state = Object.assign({}, this.state);
        for (var i = 0; i < state.trainer.cars.length; i++) {
            var car = state.trainer.cars[i];
            for (var j = 0; j < car.correctResponses.length;j++) {
                var correectResponse = car.correctResponses[j];
                if (correectResponse.trainerCorrectResponseId == trainerCorrectResponseId) {
                    car.correctResponses.splice(j,1);
                    this.setState(state);
                    return;
                }
            }
        }
    },
    addTrain() {
        var state = Object.assign({}, this.state);

        var car = {
            trainerCarId: makeid(),
            style: 0,
            hasWheels: false,
            correctResponses: [
                {
                    trainerCorrectResponseId: makeid(),
                    answer: ""
                }
            ]
        };
        state.trainer.cars.push(car);
        this.setState(state);
    },
    render: function () {
        var cars = null;
        if (this.state.trainer.cars!=null)
            cars = this.state.trainer.cars.map((c) =>
                <TrainerCar car={c}
                    onAnswerEdit={this.onAnswerEdit}
                    onChangeWheels={this.onChangeWheels}
                    key={c.trainerCarId}
                    onStyleChange={this.onStyleChange}
                    addCorrectResponse={this.addCorrectResponse}
                    deleteAnswer={this.deleteAnswer}
                />
            );
        return (
            <div>
                <Button>Сохранить</Button>
                <textarea name="editor" cols="100" rows="6" defaultValue={"apta"}></textarea>
                {cars}
                <Button onClick={this.addTrain} > Добавить вагончик</Button>
            </div>
            );
    }
});
