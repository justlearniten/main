var Popover = ReactBootstrap.Popover;
var OverlayTrigger = ReactBootstrap.OverlayTrigger;
var Button = ReactBootstrap.Button;
var TranslationDlg = React.createClass({
    render: function () {
        return (
            this.props.show && (
                <Popover id="Translation"
                    title={this.props.word}
                    placement="bottom"
                    positionTop={32} 
                >
                    {this.props.translation}
                </Popover>
            ));
    }
});

function showTranslation(selectedText) {
    hideTranslation();
 
    var show = selectedText.trim() !== "";
    if (show) {
        word = selectedText.toUpperCase();

        var xhr = new XMLHttpRequest();
        var res = null;
        xhr.open('get', '/Dictionary/Translate?word=' + word, false);
       
        xhr.onload = function () {
            if (xhr.status != 200)
                return null;

            translation = xhr.response;
            const popoverBottom = (
                <Popover id="popover-positioned-bottom" title={word}>
                    {translation}
                </Popover>
            );

            if (translation) {
                var anchor = document.getElementById('anchor');
 
                var t = ReactDOM.render(
                    <OverlayTrigger trigger="click" placement="bottom" overlay={popoverBottom}>
                      <span>&#8203;</span>
                    </OverlayTrigger>,
                    anchor
                );

                t.setState({ show: true });
            }
        }.bind(this);
        xhr.onerror = function () {
             return null;
        }
        xhr.send();
        return res;
    }
}

function hideTranslation() {
    var anchor = document.getElementById('anchor');
    ReactDOM.unmountComponentAtNode(anchor);
}
