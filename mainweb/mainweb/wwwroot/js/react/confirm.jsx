var Modal = ReactBootstrap.Modal;
var Button = ReactBootstrap.Button;

var Confirm = React.createClass({
    getInitialState: function () {
        return { show: true };
    },
    onOK: function () {
        this.setState({ show: false });
        if (this.state.onOK)
            this.state.onOK();
    },
    onCancel: function () {
        this.setState({ show: false });
    },
    onKeyPress: function (event) {
        if (event.key === "Enter") {
            this.onOK();
        }
    },
    render: function () {
        return (
            <Modal show={this.state.show} onHide={this.onCancel} onKeyPress={this.onKeyPress}>
                <Modal.Header closeButton style={{ textAlign: 'center' }}>
                    <b >{this.state.title}</b>
                </Modal.Header>
                {this.state.message &&
                    <Modal.Body>
                        {this.state.message}
                    </Modal.Body>
                }
                <Modal.Footer>
                    <Button onClick={this.onOK} bsStyle={'primary'} >{this.state.OKLabel}</Button>
                    <Button onClick={this.onCancel}>{this.state.CancelLabel}</Button>
                </Modal.Footer>
            </Modal>
        );
    }
});

function showConfirm(onOK, title, message, OKLabel, CancelLabel) {
    var a = ReactDOM.render(
        <Confirm title={title} message={message} />,
        document.getElementById("confirmDiv")
    );
    var newState = {
        show: true,
        title: title,
        message: message,
        onOK: onOK,
        OKLabel: OKLabel ? OKLabel : "OK",
        CancelLabel: CancelLabel ? CancelLabel:"Cancel"
    };
    a.setState(newState);
}
//////////////////////////////////////////////////////////////////////////////////////
var OkDialog = React.createClass({
    getInitialState: function () {
        return { show: true };
    },
    onOK: function () {
        this.setState({ show: false });
    },
    render: function () {
        return (
            <Modal show={this.state.show} onKeyPress={this.onKeyPress}>
                <Modal.Header style={{ textAlign: 'center' }}>
                    <b >{this.state.title}</b>
                </Modal.Header>
                {this.state.message &&
                    <Modal.Body>
                        {this.state.message}
                    </Modal.Body>
                }
                <Modal.Footer style={{ textAlign: 'center' }}>
                    <Button onClick={this.onOK} bsStyle={'primary'} >{this.state.OKLabel}</Button>
                </Modal.Footer>
            </Modal>
        );
    }
});
function showOk(title, message, OKLabel) {
    var a = ReactDOM.render(
        <OkDialog title={title} message={message} />,
        document.getElementById("okDiv")
    );
    var newState = {
        show: true,
        title: title,
        message: message,
        OKLabel: OKLabel ? OKLabel : "OK"
    };
    a.setState(newState);
}