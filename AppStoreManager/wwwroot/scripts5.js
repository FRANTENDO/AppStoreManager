document.addEventListener('DOMContentLoaded', function () {
    const registerForm = document.getElementById('register-form');
    const registerResponse = document.getElementById('register-response');

    if (registerForm) {
        registerForm.addEventListener('submit', function (event) {
            event.preventDefault();

            const fullname = document.getElementById('fullname').value;
            const email = document.getElementById('email').value;
            const username = document.getElementById('new-username').value;
            const password = document.getElementById('new-password').value;

            const userData = {
                FullName: fullname,
                Mail: email,
                NickName: username,
                Pass: password
            };

            fetch('https://localhost:7207/api/StoreUser/CheckUsername', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ username: username })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.isUsernameTaken) {
                        registerResponse.innerHTML = `
                        <div class="alert alert-danger" role="alert">
                            Username già in uso. Scegli un altro username.
                        </div>`;
                    } else {
                        fetch('https://localhost:7207/api/StoreUser/Register', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(userData)
                        })
                            .then(response => {
                                if (!response.ok) {
                                    throw new Error('Errore durante la registrazione');
                                }
                                return response.json();
                            })
                            .then(data => {
                                registerResponse.innerHTML = `
                            <div class="alert alert-success" role="alert">
                                Registrazione completata con successo. Verrai reindirizzato alla pagina di accesso.
                            </div>`;
                                setTimeout(function () {
                                    window.location.href = 'index.html'; // Reindirizzamento dopo 2 secondi
                                }, 2000);
                            })
                            .catch(error => {
                                console.error('Errore durante la registrazione:', error);
                                registerResponse.innerHTML = `
                            <div class="alert alert-danger" role="alert">
                                Si è verificato un errore durante la registrazione. Riprova più tardi.
                            </div>`;
                            });
                    }
                })
                .catch(error => {
                    console.error('Errore durante la verifica dell\'username:', error);
                    registerResponse.innerHTML = `
                    <div class="alert alert-danger" role="alert">
                        Si è verificato un errore durante la verifica dell'username. Riprova più tardi.
                    </div>`;
                });
        });
    }
});
