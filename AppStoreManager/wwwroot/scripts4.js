document.addEventListener('DOMContentLoaded', function () {
    let users = [
        { username: 'user1', password: 'password1' },
        { username: 'user2', password: 'password2' }
        // Aggiungi altri utenti registrati se necessario
    ];

    const loginForm = document.getElementById('login-form');
    const loginResponse = document.getElementById('login-response');

    if (loginForm) {
        loginForm.addEventListener('submit', function (event) {
            event.preventDefault();

            const username = document.getElementById('username').value;
            const password = document.getElementById('password').value;

            // Verifica se le credenziali sono corrette
            const user = users.find(user => user.username === username && user.password === password);

            if (user) {
                // Credenziali corrette, reindirizza alla pagina principale
                window.location.href = 'index6.html';
            } else {
                // Credenziali errate, mostra messaggio di errore
                loginResponse.innerHTML = `
                    <div class="alert alert-danger" role="alert">
                        Credenziali non valide. Controlla di aver inserito username e password corretti.
                    </div>`;
            }
        });
    }
});