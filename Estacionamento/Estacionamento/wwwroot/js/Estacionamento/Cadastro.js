let button = document.getElementById('salvar');
let placa = document.getElementById('placa');
let modelo = document.getElementById('modelo');
let obs = document.getElementById('obs');


button.addEventListener('click', () => {
    InserirCarro();
});


function InserirCarro() {
    fetch('/Estacionamento/InserirCarro', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            modeloVeiculo: modelo.value,
            placaVeiculo: placa.value,
            observacao: obs.value          
        })
    }).then((res) => console.log(res))
        .then((data) => console.log(data))
        .catch((err) => console.log(err))

    chamaIndex();

}

function chamaIndex() {
    window.location.href = `Index`;
}