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

            var translation = xhr.response;
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
            else
                translateOnline(selectedText);
        }.bind(this);
        xhr.onerror = function () {
             return null;
        }
        xhr.send();
        return res;
    }
}
function translateOnline(text) {
    var xhr = new XMLHttpRequest();
    var res = null;
    var url = "https://translate.yandex.net/api/v1.5/tr.json/translate?key=trnsl.1.1.20171209T230509Z.f8a31d60b222dae3.b0f6807ad4a1fbaacde09d3b56483994ca46cf57&lang=";
    var firstChar = text.toUpperCase().charAt(0);
    if (firstChar >= 'A' && firstChar <= 'Z')
        url += "en-ru";
    else
        url += "ru-en";
    url += "&text=" + text;

    xhr.open('get', url, false);
    xhr.onload = function () {
        if (xhr.status != 200)
            return null;

        var translation = JSON.parse(xhr.response).text;
        const popoverBottom = (
            <Popover id="popover-positioned-bottom" title={text}>
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

}
function hideTranslation() {
    var anchor = document.getElementById('anchor');
    ReactDOM.unmountComponentAtNode(anchor);
}
