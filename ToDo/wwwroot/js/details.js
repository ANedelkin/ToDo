function removeParticipant(button) {
    button.closest('.participant-item').remove();
    if (!document.querySelector('.participant-list').children.length) document.querySelector('#none-text').style.display = 'block';
}

function addParticipant() {
    const userName = document.getElementById('newUserName').value;
    const error = document.getElementById('error');

    fetch(`/users?userName=${userName}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (response.status != 200) {
            error.textContent = 'User not found!';
            error.style.display = 'inline';
        }
        else {
            response.json().then(data => {
                if (data) {
                    if ([...document.querySelectorAll('.participant-item')].some(pi => pi.children[1].getAttribute('data-user-id') == data.model.id)) {
                        error.textContent = 'User already added!';
                        error.style.display = 'inline';
                        return;
                    }
                    document.querySelector('#none-text').style.display = 'none';
                    const participantList = document.querySelector('.participant-list');
                    const newParticipant = document.createElement('div');
                    newParticipant.classList.add('participant-item', 'd-flex', 'justify-content-between', 'align-items-center', 'p-2', 'mb-2', 'bg-light', 'border', 'rounded');
                    newParticipant.innerHTML = `<span>${data.model.username}</span>
                                            <button type="button" class="leave-btn" data-user-id="${data.model.id}" onclick="removeParticipant(this)">Remove</button>`;
                    participantList.appendChild(newParticipant);
                    document.getElementById('newUserName').value = '';
                    error.style.display = 'none';
                } else {
                    error.textContent = 'User not found!';
                    error.style.display = 'inline';
                }
            })
        }
    })
}