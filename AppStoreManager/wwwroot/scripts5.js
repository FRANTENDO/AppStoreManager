document.addEventListener('DOMContentLoaded', async function () {
    let users = JSON.parse(localStorage.getItem('users')) || [];
    //var response = await fetch("/api/StoreUser");
    //users = await response.json();
    //console.log(users);

    fetch("/api/StoreUser").then(response => response.json()).then(json => Test(json));

    const registerForm = document.getElementById('register-form');
    const registerResponse = document.getElementById('register-response');

    if (registerForm) {
        registerForm.addEventListener('submit', function (event) {
            event.preventDefault();

            const fullname = document.getElementById('fullname').value;
            const email = document.getElementById('email').value;
            const username = document.getElementById('new-username').value;
            const password = document.getElementById('new-password').value;

            // Verifica se l'username è già in uso
            const existingUser = users.find(user => user.username === username);

            if (existingUser) {
                // Se l'username è già in uso, mostra messaggio di errore
                registerResponse.innerHTML = `
                    <div class="alert alert-danger" role="alert">
                        Username già in uso. Scegli un altro username.
                    </div>`;
            } else {
                // Se l'username non è già in uso, aggiungi l'utente agli utenti registrati
               // users.push({ fullname: fullname, email: email, username: username, password: password });

                // Salva gli utenti registrati in localStorage
                const response = await fetch("/api/StoreUserController", {
                    method: "POST",
                    body: JSON.stringify({ username: users }),
                    headers: myHeaders,

                // Mostra messaggio di successo e reindirizza alla pagina di accesso
                registerResponse.innerHTML = `
                    <div class="alert alert-success" role="alert">
                        Registrazione completata con successo. Verrai reindirizzato alla pagina di accesso.
                    </div>`;

                // Reindirizza alla pagina di accesso dopo 2 secondi
                setTimeout(function () {
                    window.location.href = 'index.html';
                }, 2000);
            }
        });
    }
});

function Test(json) {
    console.log(json);
}