let linhas = document.getElementById("linhas");


CarregaUsuarios();

function CarregaUsuarios() {
    let xml = new XMLHttpRequest();
    linhas.innerHTML = "";
    xml.open('GET', 'Usuario/ListaUsuario', true);
    xml.onreadystatechange = () => {
        if (xml.readyState === 4 && xml.status === 200) {
            let data = JSON.parse(xml.responseText);
            data.forEach(usuario => {
                linhas.innerHTML +=`<tr>
                                       <td> ${usuario.cnemp}</td>
                                        <td> ${usuario.cdusu}</td>
                                        <td> ${usuario.nmusu}</td>
                                        <td> ${usuario.essitusu}</td>
                                        <td> ${usuario.cncct}</td>
                                        <td> <button class ='btn btn-danger' onclick="Deletar(${usuario.cdusu})">Excluir</button>  </td>    
                                    </tr>`});
        }
    };
    xml.send();
}
function Deletar(cdusu) {
    let xml = new XMLHttpRequest();
    xml.open('DELETE', `Usuario/Delete?cnemp=1&cdusu=${cdusu}`);

    xml.send();

    xml.onreadystatechange = () => {
        if (xml.readyState == 4 && xml.status === 200)
            CarregaUsuarios();
    }
}


