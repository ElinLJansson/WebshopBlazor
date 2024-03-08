window.deleteAlert = (node) => {
    node.classList.add("class-fade-animation")
    setTimeout(() => {
        node.remove();
    }, 500); 
}

window.appendAlert = (message, type) => {
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder');

    const wrapper = document.createElement('div');
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible show" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close" id="closebutton"></button>',
        '</div>'
    ].join('');

    alertPlaceholder.insertBefore(wrapper, alertPlaceholder.firstChild);
    const nodes = alertPlaceholder.childNodes;
    const node = nodes[nodes.length - 1];

    const closeButtons = document.getElementsByClassName('btn-close');
    const closeButton = closeButtons[closeButtons.length - 1];

    closeButton.addEventListener("click", () => {
        window.deleteAlert(node);
        clearTimeout(timeout);
    });

    const timeout = setTimeout(() => {
        window.deleteAlert(node);
    }, 5000);

};




