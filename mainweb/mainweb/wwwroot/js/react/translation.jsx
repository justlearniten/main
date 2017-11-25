var Popover = ReactBootstrap.Popover;
var TranslationDlg = React.createClass({
    render: function () {
        return (
            this.props.show && (
                <Popover id="Translation"
                    title={this.props.word}
                    placement="bottom"
                    positionLeft={this.props.left}
                    positionTop ={this.props.top}
                >
                    {this.props.translation}
                </Popover>
            ));
    }
});

function showTranslation(selectedText, selectionCoords) {
     
   
    var show = selectedText !== "";
    if (show) {
        word = selectedText.toUpperCase();

        var xhr = new XMLHttpRequest();
        var res = null;
        xhr.open('get', '/Dictionary/Translate?word=' + word, false);
        //xhr.setRequestHeader("Accept", 'application/json');
        xhr.onload = function () {
            if (xhr.status != 200)
                return null;
            translation = xhr.response;
            if (translation) {
                var anchor = document.getElementById('popupDiv');
                ReactDOM.render(
                    <TranslationDlg
                        show={show}
                        word={word}
                        left={selectionCoords.x}
                        top={selectionCoords.y}
                        translation={translation}
                    />,
                    anchor
                );
            }
            else
                hideTranslation();
        }.bind(this);
        xhr.onerror = function () {
            hideTranslation();
            return null;
        }
        xhr.send();
        return res;
    }
    else {
        hideTranslation();
    }
}

function hideTranslation() {
    var anchor = document.getElementById('popupDiv');
    ReactDOM.render(
        <TranslationDlg
            show={false}
        />,
        anchor
    );
}