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
        .catch(error => alert ('Платформы не найдены', error));
}


async function addItem() {
    const path = document.getElementById('path').value.trim();

    try {
        const response = await fetch(uri, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ path: path })
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText);
        }

        const data = await response.json();
        alert(data.message); 
    } catch (error) {
        alert("Ошибка: " + error.message);
    }
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