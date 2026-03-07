const uri = '/api/songs';
let songs = [];
//let sortDirection = true;

console.log('JS File is connected');

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}


function addItem() {
    const addTitleTextbox = document.getElementById('add-title');
    const addArtistTextbox = document.getElementById('add-artist');
    const addAlbumTextbox = document.getElementById('add-album');
    const addReleaseYearTextbox = document.getElementById('add-releaseYear');
    const addGenreTextbox = document.getElementById('add-genre');
    const addIsExplicitCheckbox = document.getElementById('add-isExplicit');

    const item = {
        title: addTitleTextbox.value.trim(),
        artist: addArtistTextbox.value.trim(),
        album: addAlbumTextbox.value.trim(),
        releaseYear: addReleaseYearTextbox.value.trim(),
        genre: addGenreTextbox.value.trim(),
        isExplicit: addIsExplicitCheckbox.checked
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
            addArtistTextbox.value = '';
            addAlbumTextbox.value = '';
            addReleaseYearTextbox.value = '';
            addGenreTextbox.value = '';
            addIsExplicitCheckbox.checked = false;
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
    const item = songs.find(item => item.id === id);

    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-title').value = item.title;
    document.getElementById('edit-artist').value = item.artist;
    document.getElementById('edit-album').value = item.album;
    document.getElementById('edit-releaseYear').value = item.releaseYear;
    document.getElementById('edit-genre').value = item.genre;
    document.getElementById('edit-isExplicit').checked = item.isExplicit;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        title: document.getElementById('edit-title').value.trim(),
        artist: document.getElementById('edit-artist').value.trim(),
        album: document.getElementById('edit-album').value.trim(),
        releaseYear: parseInt(document.getElementById('edit-releaseYear').value.trim(), 10),
        genre: document.getElementById('edit-genre').value.trim(),
        isExplicit: document.getElementById('edit-isExplicit').checked
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
    const title = (itemCount === 1) ? 'Song' : 'Songs';

    document.getElementById('counter').innerText = `${itemCount} ${title}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('songs');
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
        let textNode2 = document.createTextNode(item.artist);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(item.album);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(item.releaseYear);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        let textNode5 = document.createTextNode(item.genre);
        td5.appendChild(textNode5);

        let td6 = tr.insertCell(5);
        let textNode6 = document.createTextNode(item.isExplicit);
        td6.appendChild(textNode6);

        let td7 = tr.insertCell(6);
        td7.appendChild(editButton);

        let td8 = tr.insertCell(7);
        td8.appendChild(deleteButton);
    });

    songs = data;
}

// function sortData(columnName) {
//     songs.sort((a, b) => {
//         if (sortDirection) {
//             return a[columnName] - b[columnName];
//         } else {
//             return b[columnName] - a[columnName];
//         }
//     });

//     sortDirection = !sortDirection;

//     _displayItems(songs);
// }