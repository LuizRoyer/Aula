let linhas = document.getElementById('linhas');

carregaUsuarios();
function carregaUsuarios() {
    let xml = new XMLHttpRequest();
    xml.open('GET', '/Usuario/RetornaUsuarios', true);
    xml.onreadystatechange = () => {
        if (xml.readyState === 4 && xml.status === 200) {
            let data = JSON.parse(xml.responseText);
            data.forEach(usuario => {
                linhas.innerHTML += `
                                    <tr>
                                        <td>${usuario.nmusu}</td>
                                        <td>${usuario.cnemp}</td>
                                        <td>${usuario.essitusu}</td>
                                        <td><button class='btn btn-danger' onClick='Deletar(${usuario.cnemp})'>Remover</button></td>
                                    </tr>
                                    `;
            });
        }
    };
    xml.send();
}
function Deletar(cnemp) {
    alert(cnemp);
}