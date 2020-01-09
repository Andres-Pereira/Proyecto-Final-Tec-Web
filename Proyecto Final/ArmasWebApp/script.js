document.getElementById("getArmaBtn").addEventListener("click",
async function(){
    try{
        const request = await fetch('http://localhost:49749/api/Dealers');
        const request2 = await fetch('http://localhost:49749/api/Armas');
        const data = await request.json();
        const data2 = await request2.json();
        document.getElementById("ArmaContainer").innerHTML = `<ul class="kkk"> ${data.map(e => `<li><br/> <img src="${e.url}" height="150"/><br/> ID Vendedor:${e.id} <br/>Nombre: ${e.name} <br/> Nacionalidad: ${e.pais} <br/> <button class="getArmaBt" onclick="GetByDealer(${e.id})">Su catalogo aqui</button><br/>   </li>`).join('')} </ul>`
    }catch(error){

    }
});



document.getElementById("newArmaForm").addEventListener("submit", PostArma);

function PostArma(event){
    event.preventDefault(); 
    const formElements = event.target.elements;
    console.log('formElements',formElements.newName.value);
    var url = 'http://localhost:49749/api/Armas';
    var data = {
        DealerId:formElements.newDealer.value,
        name: formElements.newName.value,
        category: formElements.newcategory.value,
        type: formElements.newtype.value,
        producer: formElements.newProducer.value,
        Calibre: formElements.newCalibre.value
    };

    fetch(url, {
    method: 'POST', 
    body: JSON.stringify(data), 
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => console.error('Error:', error))
    .then((response) => {
        console.log('Success:', response)
    });
}

document.getElementById("deleteArmaForm").addEventListener("submit",DeleteArma);

function DeleteArma(event){
    event.preventDefault(); 
    const formElements = event.target.elements;
    console.log('formElements',formElements.ArmaToDelete.value);
    const nameDelete = formElements.ArmaToDelete.value;
    var url =  `http://localhost:49749/api/Armas/${nameDelete}`;
    fetch(url, {
    method: 'DELETE',
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => console.error('Error:', error))
    .then((response) => {
        console.log('Success:', response)
    });
}

document.getElementById("searchArmaForm").addEventListener("submit",SearchArma);

function SearchArma(event){
    event.preventDefault(); 
    const formElements = event.target.elements;
    console.log('formElements',formElements.ArmaToSearch.value);
    const Armaid = formElements.ArmaToSearch.value;
    var url =  `http://localhost:49749/api/Armas/${Armaid}`;
    fetch(url, {
        method: 'GET',
        headers:{
            'Content-Type': 'application/json'
        }
        }).then((res) => {
            return res.json()})
        .catch(error => console.error('Error:', error))
        .then((response) => {
            console.log('Success:', response)
            document.getElementById('ArmaContainer2').innerHTML = `<div>${response.name} | ${response.category} | ${response.type} | ${response.producer} | ${response.Calibre} </div>`
        });
    
}

document.getElementById("updateArmaForm").addEventListener("submit",PutArma);
function PutArma(event){
    event.preventDefault();  
    const formElements = event.target.elements;
    console.log('formElements',formElements.Upid.value);
    var url = `http://localhost:49749/api/Armas/${formElements.Upid.value}`;
    var data = {
        id: formElements.Upid.value,
        name: formElements.updateName.value,
        category: formElements.updatecategory.value,
        type: formElements.updatetype.value,
        producer: formElements.updateProducer.value,
        Calibre: formElements.updateCalibre.value
    };

    fetch(url, {
    method: 'PUT', 
    body: JSON.stringify(data), 
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => console.error('Error:', error))
    .then((response) => {
        console.log('Success:', response)
    });
}






async function GetByDealer(num){
    try{
    var url =  `http://localhost:49749/api/Armas/dealer/${num}`;
    const request2 = await fetch(url);
    const data2 = await request2.json(); 
     document.getElementById('ArmaByDealerContainer').innerHTML = `<ul>${data2.map(e => `<li>${e.name} | ${e.category} | ${e.type} | ${e.producer} | ${e.id} </li>`).join('')}</ul>`
    }catch(error){

    }
}
    

