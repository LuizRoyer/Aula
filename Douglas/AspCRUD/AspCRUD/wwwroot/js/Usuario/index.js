let linhas = document.getElementById('linhas');
carregaUsuarios();

function carregaUsuarios() {
    linhas.innerHTML = '';
    let xml = new XMLHttpRequest();
    xml.open('GET', '/Usuario/BuscarUsuarios', true);
    xml.onreadystatechange = () => {
        if (xml.readyState === 4 && xml.status === 200) {
            let data = JSON.parse(xml.responseText);
            data.forEach(usuario => {
                linhas.innerHTML += `
                                    <tr>
                                        <td>${usuario.cdusu}</td>
                                        <td>${usuario.nmusu}</td>
                                        <td>${usuario.cnemp}</td>   
                                        <td>${usuario.essitusu}</td>
                                        <td><button class='btn btn-danger' onClick='Editar("${usuario.cdusu.trim()}",${usuario.cnemp},"${usuario.nmusu.trim()}","${usuario.essitusu.trim()}")'>Editar</button></td>
                                        <td><button class='btn btn-warning' onClick='Excluir(${usuario.cdusu},${usuario.cnemp})'>Excluir</button></td>
                                    </tr>
                                   `
            });
        }
    };
    xml.send();
}

function Excluir(cdusu, cnemp) {
    if (confirm('Você tem certeza que deseja Remover?')) {
        let xml = new XMLHttpRequest();
        xml.open('DELETE', `/Usuario/ExcluirUsuario?cdusu=${cdusu}&cnemp=${cnemp}`);
        xml.onreadystatechange = () => {
            if (xml.readyState === 4 && xml.status === 200) {
                carregaUsuarios();
                alert('Excluído com Sucesso!');
            };
        };
        xml.send();
    }
}

function Editar(cdusu, cnemp, nmusu, essitusu) {
    window.location.href = `/Usuario/Cadastro?cdusu=${cdusu}&cnemp=${cnemp}&nmusu=${nmusu}&essitusu=${essitusu}`;
}