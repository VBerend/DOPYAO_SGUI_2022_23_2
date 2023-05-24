let animals = [];
let shelters = [];
let adopters = [];

getDataAnimal();

async function getDataAnimal() {
    await fetch('http://localhost:38088/Animal')
        .then(x => x.json())
        .then(y => {
            animals = y;
            console.log(animals);
            displayAnimals();
        });
}
//async function getDataAdopter() {
//    await fetch('http://localhost:38088/Adopter')
//        .then(x => x.json())
//        .then(y => {
//            adopters = y;
//            console.log(adopters);
//            displayAdopters();
//        });
//}
//async function getDataShelter() {
//    await fetch('http://localhost:38088/Shelter')
//        .then(x => x.json())
//        .then(y => {
//            shelters = y;
//            console.log(shelters);
//            displayShelters();
//        });
//}

function displayAnimals() {
    document.getElementById('resultareaanimal').innerHTML = "";
    animals.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + "</td><td>" + t.gender + "</td><td>" + "</td><td>" + t.specie + "</td><td>" + "</td><td>" + t.bodysize + "</td><td>" + "</td><td>" + t.age + "</td><td>" + "</td><td>" + t.shelterId + "</td><td>" + "</td><td>" + t.adopterId + "</td><td>"+`<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

//function displayAdopters() {
//    document.getElementById('resultarea').innerHTML = "";
//    adopters.forEach(t => {
//        document.getElementById('resultarea').innerHTML +=
//            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` +
//            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
//            + "</td></tr>";
//    });
//}

//function displayShelters() {
//    document.getElementById('resultarea').innerHTML = "";
//    shelters.forEach(t => {
//        document.getElementById('resultarea').innerHTML +=
//            "<tr><td>" + t.id + "</td><td>" + t.shelterName + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` +
//            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
//            + "</td></tr>";
//    });
//}