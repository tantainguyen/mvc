//================================================//
//MODAL CONTENT
//================================================//
class Modal extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            showModal: true,
            title: props.title || 'Modal heading',
            content: props.content || 'Modal content'
        };
        this.close = this.close.bind(this);
        this.open = this.open.bind(this);
    }

    close() {
        this.setState({ showModal: false });
    }
    open() {
        this.setState({ showModal: true });
    }
    render() {
        return (
            <ReactBootstrap.Modal show={this.state.showModal} onHide={this.close}>
              <ReactBootstrap.Modal.Header closeButton>
                <ReactBootstrap.Modal.Title>{this.state.title}</ReactBootstrap.Modal.Title>
              </ReactBootstrap.Modal.Header>
              <ReactBootstrap.Modal.Body>
                <h4>{this.state.content}</h4>
              </ReactBootstrap.Modal.Body>
              <ReactBootstrap.Modal.Footer>
                <ReactBootstrap.Button onClick={this.close}>Close</ReactBootstrap.Button>
              </ReactBootstrap.Modal.Footer>
            </ReactBootstrap.Modal>
        )
    }
};
(function (v) {
    v.log('MODAL');
    v.modal = function (title, content, callback) {
        const temp = <Modal title={title} content={content} />;
        v.render(temp, 'modal-content');
    }
})(vst)

//================================================//
//END MODAL CONTENT
//================================================//
