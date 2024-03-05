window.deleteAlert = () => {
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder')
    alertPlaceholder.remove()
}

window.appendAlert = (message, type) => {
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder')
    
    const wrapper = document.createElement('div')
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close" id="closebutton"></button>',
        '</div>'
    ].join('')

    alertPlaceholder.append(wrapper)
    const closeButton = document.getElementById('closebutton')
    closeButton.addEventListener("click", window.deleteAlert)
}



