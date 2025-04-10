const uri = 'api/Platforms';
let plarforms = [];

function findPlatforms() {
    const location = document.getElementById('searchBox').value.trim();
    if (!location) return;

    fetch(`${uri}/find?location=${encodeURIComponent(location)}`)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to find platforms.', error));
}

function addItem() {
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }})
        .then(response => response.json())
        .catch(error => console.error('Unable to add item.', error));
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