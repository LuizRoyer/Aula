let linhas = document.getElementById('linhas');
carregarEstacionamento();

function carregarEstacionamento() {
    linhas.innerHTML = '';
    let xml = new XMLHttpRequest();
    xml.open('GET', '/Estacionamento/ListarVeiculos', true);
    xml.onreadystatechange = () => {
        if (xml.readyState === 4 && xml.status === 200) {
            let data = JSON.parse(xml.responseText);
            console.log(data);
            data.forEach(estacionamento => {
                linhas.innerHTML += `
                                    <tr>
                                        <td>${estacionamento.registro}</td>
                                        <td>${estacionamento.modeloVeiculo}</td>
                                        <td>${estacionamento.placaVeiculo}</td>   
                                        <td>${estacionamento.dataEntrada}</td>
                                        <td>${estacionamento.dataSaida}</td>
                                        <td>${estacionamento.observacao}</td>`
                linhas.innerHTML.replace('</tr>',' ');
                if (estacionamento.dataSaida === "0001-01-01T00:00:00")
                    linhas.innerHTML += ` <td><button class='btn btn-warning' onClick='SaidaVeiculo("${estacionamento.registro}","${estacionamento.dataEntrada}")'>Saida</button></td>`;
                else
                    linhas.innerHTML += ` <td><button class='btn btn-danger'> OK </button></td>`;
                linhas.innerHTML += `</tr>`;
                                
            });
        }
    };
    xml.send();
}


function SaidaVeiculo(registro, dataEntrada) {

    //if (data === '01/01/0001 00:00:00') {
    //    alert('Data Invalida');
    //}
  
        let xml = new XMLHttpRequest();
    xml.open('Post', `/Estacionamento/SaidaVeiculo?registro=${registro}&dataEntrada=${dataEntrada}`);
        xml.onreadystatechange = () => {
            if (xml.readyState === 4 && xml.status === 200) {
                let valor = JSON.parse(xml.responseText);
                              
                alert(`Valor a pagar RS = ${ valor } `);
                carregarEstacionamento();
            };
        };
        xml.send();
    
}

