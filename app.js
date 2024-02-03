console.log('javascript loaded');

const timeInput = document.querySelector('input[type="time"]');
const form = document.querySelector('form');
const dialog = document.querySelector('#dialog')
const helpDialog = document.querySelector('#help');

window.addEventListener('load', () => {
    const now = new Date();
    now.setMinutes(now.getMinutes() - now.getTimezoneOffset());
    timeInput.value = now.toISOString().slice(11, 16);
})

timeInput.addEventListener('keydown', (event) => {
    if (event.key === 'Enter') {
        console.log('submit: enter');
    }
})

document.addEventListener('keydown', (event) => {
    // event.preventDefault();

    if (event.ctrlKey && event.key === 'k') {
        event.preventDefault();
        console.log('crtl + k');

        if (dialog.open) {
            dialog.close();
        } else {
            dialog.showModal();
        }
    } else if (event.ctrlKey && event.key.toLowerCase() === 'h') {
        event.preventDefault();
        console.log('crtl + h');

        if (helpDialog.open) {
            helpDialog.close();
        } else {
            helpDialog.showModal();
        }
    }

    // console.log(event.key);
})