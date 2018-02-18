var Modal = ReactBootstrap.Modal;
var Button = ReactBootstrap.Button;
var FormGroup = ReactBootstrap.FormGroup;

var TrainerCorrectAnswer = React.createClass({
    getInitialState: function () {
        return this.props.answer;
    },
    render: function () {
        console.log("Answer state");
        console.log(this.state);
        return (
            <div>
                {this.state.answer}
            </div>
            );
    }
});
//////////////////////////////////////////////////////////////
var TrainerCar = React.createClass({
    getInitialState: function () {
        console.log("props of trainer car");
        console.log(this.props);
        return this.props.car;
    },
    render: function () {
        console.log("rendering car");
        console.log(this.state);
        var answers = this.state.correctResponses.map((a) =>
            <TrainerCorrectAnswer answer={a}/>
        );
        return (
            <div className="form-horizontal form-group col-md-12 well">
                <div className="col-md-8">
                    {answers}
                </div>
                <div className="col-md-4">
                    <div className="col-md-12">
                        <label><input type="checkbox" checked={this.state.hasWheels} />&nbsp;Колесики</label>
                    </div>
                    <div className="col-md-12">
                        <label><input type="radio" value="normal" />&nbsp;Без подчеркивания</label>
                        <label><input type="radio" value="blackSingle" />&nbsp;<span className="black-underline">Одинарное черное</span></label>
                        <label><input type="radio" value="blackDouble" />&nbsp;<span className="black-double-underline">Двойное черное</span></label>
                        <label><input type="radio" value="redSingle" />&nbsp;<span className="red-underline">Одинарное красное</span></label>
                        <label><input type="radio" value="redDouble" />&nbsp;<span className="red-double-underline">Двойное красное</span></label>
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
    render: function () {
        console.log("rendering trainer");
        console.log(this.state.trainer);
        var cars = null;
        this.state.trainer.cars;
        if (this.state.trainer.cars!=null)
            cars = this.state.trainer.cars.map((c) =>
                <TrainerCar car = {c} />
            );
        return (
            <div>
                <Button>Сохранить</Button>
                <textarea name="editor" cols="100" rows="6" defaultValue={"apta"}></textarea>
                {cars}
                <Button>Добавить вагончик</Button>
            </div>
            );
    }
});
