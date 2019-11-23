let nome = document.getElementById("usuario");
let enviar = document.getElementById("enviar");
let senha = document.getElementById("senha");

enviar.addEventListener('click', () => {
    if (ValidaCampos()) {
        let xml = new XMLHttpRequest();
        xml.open('POST', `/Exemplo/ValidarLogin?nome=${nome.value}&senha=${senha.value}`, true);
        xml.onreadystatechange = () => {
            if (xml.readyState == 4 && xml.status === 200) {
                let resultado = JSON.parse(xml.responseText);

                if (resultado)
                    alert("Bem vindo");
                else
                    alert("Voce nao está autorizado");

            }
        };
        xml.send();
    }
});

function ValidaCampos() {

    nome.classList.remove();
    senha.classList.remove();

    if (senha.value === "" && nome.value === "") {
        nome.classList.add('error');
        senha.classList.add('error');
        return false;
    }
    if (senha.value === "") {
        senha.classList.add('error');
        return false;
    }
    if (nome.value === "") {

        nome.classList.add('error');
        return false
    }

    return true;
}