let conteudo = document.getElementById("conteudo");
let button= document.getElementById('button');
loadUser();
function loadUser() {

    let xml = new XMLHttpRequest();
    xml.open('GET', 'https://randomuser.me/api/', true);
    xml.onreadystatechange = () => {
        if (xml.readyState === 4 && xml.status === 200) {
            let data = JSON.parse(xml.responseText);
            console.log(data);
            data.results.forEach(usuario => {
                conteudo.innerHTML = `<h2>Nome: ${usuario.name.first} 
          ${usuario.name.last}</h2>
          <br>
          <img src='${usuario.picture.large}' height='300px'></img>
          <h4>Contato:${usuario.phone} </h4>`;
            });

        }
    }
    xml.send();
}

button.addEventListener('click',()=>{
    loadUser();
});