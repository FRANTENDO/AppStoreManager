document.addEventListener('DOMContentLoaded', function () {
    const registerForm = document.getElementById('register-form');
    const registerResponse = document.getElementById('register-response');

    fetch("/api/StoreUser").then(response => response.json()).then(json => Test(json));

    if (registerForm) {
        registerForm.addEventListener('submit', function (event) {
            event.preventDefault();

            const fullname = document.getElementById('fullname').value;
            const email = document.getElementById('email').value;
            const username = document.getElementById('username').value;
            const password = document.getElementById('password').value;

            const userData = {
                fullname: fullname,
                email: email,
                username: username,
                password: password
            };

            // Fetch per verificare se l'username è già in uso
            fetch('/api/StoreUser', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ username: username })
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Errore durante la verifica dell\'username');
                    }
                    return response.json();
                })
                .then(data => {
                    // Se l'username è già in uso, mostra messaggio di errore
                    if (data.isUsernameTaken) {
                        registerResponse.innerHTML = `
                        <div class="alert alert-danger" role="alert">
                            Username già in uso. Scegli un altro username.
                        </div>`;
                    } else {
                        // Se l'username non è già in uso, procedi con la registrazione
                        fetch('/api/StoreUser', {
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
                                // Operazioni dopo la registrazione riuscita
                                registerResponse.innerHTML = `
                            <div class="alert alert-success" role="alert">
                                Registrazione completata con successo. Verrai reindirizzato alla pagina di accesso.
                            </div>`;
                                setTimeout(function () {
                                    window.location.href = 'index.html'; // Reindirizzamento dopo 1 secondo
                                }, 1000);
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

function Test(json) {
    console.log(json);
}