let animals = [];
let shelters = [];
let adopters = [];

let animalIdForUpdate = -1;
let adopterIdForUpdate = -1;
let shelterIdForUpdate = -1;

getDataAnimal();
getDataAdopter();
getDataShelter();

async function getDataAnimal() {
    await fetch('http://localhost:38088/Animal')
        .then(x => x.json())
        .then(y => {
            animals = y;
            console.log(animals);
            displayAnimals();
        });
}
async function getDataAdopter() {
    await fetch('http://localhost:38088/Adopter')
        .then(x => x.json())
        .then(y => {
            adopters = y;
            console.log(adopters);
            displayAdopters();
        });
}
async function getDataShelter() {
    await fetch('http://localhost:38088/Shelter')
        .then(x => x.json())
        .then(y => {
            shelters = y;
            console.log(shelters);
            displayShelters();
        });
}


function createAdopter() {
    let name = document.getElementById('adopterName').value;
    let city = document.getElementById('city').value;
    let address = document.getElementById('address').value;
    let haskid = docunment.getElementById('haskid').value;
    fetch('http://localhost:38088/Adopter', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, city: city, address: address, haskid: haskid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataAdopter();
        })
        .catch((error) => { console.error('Error:', error); });

}

function createShelter() {
    let name = document.getElementById('Name').value;
    let address = document.getElementById('address').value;
    let city = document.getElementById('city').value;
    fetch('http://localhost:38088/Shelter', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                shelterName: name,
                address: address,
                city: city
            }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getDataShelter();
        })
        .catch((error) => { console.error('Error:', error); });

}

function removeShelter(id) {
    fetch('http://localhost:38088/Shelter/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataShelter();
        })
        .catch((error) => { console.error('Error:', error); })
}

function removeAdopter(id) {
    fetch('http://localhost:38088/Adopter/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataAdopter();
        })
        .catch((error) => { console.error('Error:', error); })
}

function removeAnimal(id) {
    fetch('http://localhost:38088/Animal/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataAnimal();
        })
        .catch((error) => { console.error('Error:', error); })
}


function displayAnimals() {
    document.getElementById('resultareaanimal').innerHTML = "";
    animals.forEach(a => {
        document.getElementById('resultareaanimal').innerHTML +=
            "<tr><td>" +
            a.id + "</td><td>" +
            a.name + "</td><td>" +
            a.gender + "</td><td>" +
            a.specie + "</td><td>" +
            a.bodysize + "</td><td>" +
            a.age + "</td><td>" +
            `<button type="button" onclick="showupdatedanimals(${a.id})">Update</button>` +
            "</td></tr>"
    })
}

function displayAdopters() {
    document.getElementById('resultareaadopter').innerHTML = "";
    adopters.forEach(t => {
        document.getElementById('resultareaadopter').innerHTML +=
            "<tr><td>" +
            t.id + "</td><td>" +
            t.name + "</td><td>" +
            t.address + "</td><td>" +
            t.city + "</td><td>" +
            t.haskid + "</td><td>" +
            `<button type="button" onclick="removeAdopter(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdatedadopters(${t.id})">Update</button>` +
            "</td></tr>"
    })
}

function displayShelters() {
    document.getElementById('resultareashelter').innerHTML = "";
    shelters.forEach(t => {
        document.getElementById('resultareashelter').innerHTML +=
            "<tr><td>" +
            t.id + "</td><td>" +
            t.shelterName + "</td><td>" +
            t.address + "</td><td>" +
            t.city + "</td><td>" +
            `<button type="button" onclick="removeShelter(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdatedshelter(${t.id})">Update</button>` +
            "</td></tr>"
    })
}

function showupdatedanimals(id) {
    document.getElementById('anim').value = animals.find(t => t['id'] == id)['name'];
    document.getElementById('animUpd').style.display = 'unset';
    animalIdForUpdate = id;
}

function showupdatedadopters(id) {
    document.getElementById('adop').value = adopters.find(t => t['id'] == id)['name'];
    document.getElementById('adopUpd').style.display = 'unset';
    adopterIdForUpdate = id;
}

function showupdatedshelter(id) {
    document.getElementById('shel').value = shelters.find(t => t['id'] == id)['name'];
    document.getElementById('shelUpd').style.display = 'unset';
    shelterIdForUpdate = id;
}

function animalUpdate() {
    document.getElementById('animUpd').style.display = 'none';
    let name = document.getElementById('anim').value;
    fetch('http://localhost:38088/Animal/newName', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name }),
    })
        .then(response => response)
        .then(data => {
            console.log('WellDone:', data);
            getDataAnimal();
        })
        .catch((error) => { console.error('Error:', error); });

}

function adopterUpdate() {
    document.getElementById('adopUpd').style.display = 'none';
    let name = document.getElementById('adop').value;
    fetch('http://localhost:38088/Adopter/ChangeAdopterAddress/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                address: address,
                city: city
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('WellDone:', data);
            getDataAdopter();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}

function shelterUpdate() {
    document.getElementById('shelUpd').style.display = 'none';
    let name = document.getElementById('shel').value;
    fetch('http://localhost:38088/Shelter/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                city: city,
                address: address
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('WellDone:', data);
            getDataShelter();
        })
        .catch((error) => { console.error('Error:', error); });

}