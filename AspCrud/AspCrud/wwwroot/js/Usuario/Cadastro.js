let button = document.getElementById('btn');
let cdusu = document.getElementById('cdusu');
let nmusu = document.getElementById('nmusu');
let cncct = document.getElementById('cncct');

button.addEventListener('click', () => {
    let usuario = {
        nmusu: nmusu.value,
        cdusu: cdusu.value,
        cncct: cncct.value
    };
    fetch('/Usuario/InserirNovo', {
        method: 'POST',
        body: JSON.stringify(usuario),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(chamaIndex())
        .catch(console.log('erro'));
});
function chamaIndex() {
    alert('Usuairo Inserido com sucesso');
    window.location.href = "/Usuario/Index";
}