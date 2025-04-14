const uri = 'api/Platforms';
let plarforms = [];

function findPlatforms() {
    const location = document.getElementById('searchBox').value.trim();
    if (!location) return;

    fetch(`${uri}/find?location=${encodeURIComponent(location)}`)
        .then(response => response.json())
        .then(data => {
            const table = document.getElementById('table');
            if (data.length != 0) {
                table.style.visibility = 'visible';
                _displayItems(data);
            }
            else {
                alert("Ничего не найдено");
            }
        })
        .catch(error => console.error('Платформы не найдены', error));
}


function addItem() {
    const path = document.getElementById('path').value.trim();
    
    fetch(uri, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ path: path })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Ошибка на сервере');
            }
            return response.json();
        })
        .then(data => {
            setTimeout(() => {
                alert('Данные загружены');
            }, 0);
        })
        .catch(error => console.error('Не получилось загрузить данные.', error));
}



function _displayItems(data) {
    const tBody = document.getElementById('tab');
    tBody.innerHTML = '';

    data.forEach(name => {
        let tr = tBody.insertRow();
        let td = tr.insertCell(0);
        let textNode = document.createTextNode(name);
        td.appendChild(textNode);
    });
}