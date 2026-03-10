const uri = 'api/tvshows';
let tVSeries = [];
let sortDirection = true;

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const addTitleTextbox = document.getElementById('add-title');
    const addTotalSeasonsTextbox = document.getElementById('add-totalSeasons');
    const addPlatformTextbox = document.getElementById('add-platform');
    const addTVRatingSelection = document.getElementById('add-tVRating');
    const addHaveStartedWatchingBool = document.getElementById('add-haveStartedWatching');

    const item = {
        title: addTitleTextbox.value.trim(),
        totalSeasons: parseInt(addTotalSeasonsTextbox.value.trim()),
        platform: addPlatformTextbox.value.trim(),
        tVRating: addTVRatingSelection.value,
        haveStartedWatching: addHaveStartedWatchingBool.checked
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addTitleTextbox.value = '';
            addTotalSeasonsTextbox.value = '';
            addPlatformTextbox.value = '';
            addTVRatingSelection.value = "";
            addHaveStartedWatchingBool.checked = false;
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = tVSeries.find(item => item.id === id);

    document.getElementById('edit-title').value = item.title;
    document.getElementById('edit-totalSeasons').value = item.totalSeasons;
    document.getElementById('edit-platform').value = item.platform;
    document.getElementById('edit-tVRating').value = item.tvRating;
    document.getElementById('edit-haveStartedWatching').checked = item.haveStartedWatching;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        title: document.getElementById('edit-title').value.trim(),
        totalSeasons: parseInt(document.getElementById('edit-totalSeasons').value.trim()),
        platform: document.getElementById('edit-platform').value.trim(),
        tVRating: document.getElementById('edit-tVRating').value,
        haveStartedWatching: document.getElementById('edit-haveStartedWatching').checked

    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'TV Show' : 'TV Series';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('TVSeries');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.title);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(item.totalSeasons);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(item.platform);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(item.tvRating);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        let textNode5 = document.createTextNode(item.haveStartedWatching);
        td5.appendChild(textNode5);

        let td6 = tr.insertCell(5);
        td6.appendChild(editButton);

        let td7 = tr.insertCell(6);
        td7.appendChild(deleteButton);
    });

    tVSeries = data;
}

function sortData(columnName) {
    tVSeries.sort((a, b) => {
        if (sortDirection) {
            return a[columnName] - b[columnName];
        } else {
            return b[columnName] - a[columnName];
        }
    });

    sortDirection = !sortDirection;

    _displayItems(tVSeries);
}