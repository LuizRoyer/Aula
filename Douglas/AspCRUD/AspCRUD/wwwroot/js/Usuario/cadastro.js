let button = document.getElementById('salvar');
let cdusu = document.getElementById('cdusu');
let nmusu = document.getElementById('nmusu');
let cncct = document.getElementById('cncct');

button.addEventListener('click', () => {
    let usuario = {
        cdusu: cdusu.value,
        nmusu: nmusu.value,
        cncct: cncct.value
    };
    inserirUsuario(usuario);
});

function inserirUsuario(usuario) {
    let xml = new XMLHttpRequest();
    xml.open('POST', '/Usuario/InserirUsuario?cdusu=' + usuario.cdusu + '&nmusu=' + usuario.nmusu + '&cncct=' + usuario.cncct, true);
    xml.onreadystatechange = () => {
        if (xml.readyState === 4 && xml.status === 200) {
            alert('Inserido com Sucesso!');
            chamaIndex();
        } else if (xml.status !== 200) {
            alert(xml.responseText);
        }
    };
    xml.send();
}

function chamaIndex() {
    window.location.href = `Usuario\Index`;
}

let url = windows.location.href;

let stringCdusu = url.split('cdusu')[1];
if (stringCdusu !== undefined)
    cdusu.value = stringCdusu.replace('=', '');

let stringCnemp = url.split('cnemp')[1];
if (stringCnemp !== undefined)
    cnemp.value = stringCnemp.replace('=', '');

let stringNmusu = url.split('nmusu')[1];
if (stringNmusu !== undefined)
    nmusu.value = stringNmusu.replace('=', '');

let stringEssitusu = url.split('essitusu')[1];
if (stringEssitusu !== undefined)
    essitusu.value = stringEssitusu.replace('=', '');