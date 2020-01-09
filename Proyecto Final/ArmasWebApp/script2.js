document.getElementById("getArmaByCalibre").addEventListener("click",
async function(){
    try{
        const request3 = await fetch('http://localhost:49749/api/Armas');
        const data3 = await request3.json();
       
     document.getElementById("ArmasContainer2").innerHTML = `<ul> ${data3.map(e => `<li>${e.calibre} | <button onclick="GetByCalibre(${e.calibre})">Mostrar Armas</button>   </li>`).join('')} </ul>`
    }catch(error){

    }
});

async function GetByCalibre(num){
    try{
    var url =  `http://localhost:49749/api/Armas/calibre/${num}`;
    const request2 = await fetch(url);
    const data2 = await request2.json(); 
     document.getElementById('ArmaByCalibreContainer').innerHTML = `<ul>${data2.map(e => `<li>${e.name} | ${e.category} | ${e.type} | ${e.producer} </li>`).join('')}</ul>`
    }catch(error){

    }
}