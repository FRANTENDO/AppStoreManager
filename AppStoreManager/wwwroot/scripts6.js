document.addEventListener('DOMContentLoaded', function () {
    const recoverForm = document.getElementById('recover-form');
    const recoverResponse = document.getElementById('recover-response');

    if (recoverForm) {
        recoverForm.addEventListener('submit', function (event) {
            event.preventDefault();

            const email = document.getElementById('recover-email').value;

            // Invia richiesta di recupero password al backend
            fetch('/recover-password', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email: email }),
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        recoverResponse.innerHTML = `
                        <div class="alert alert-success" role="alert">
                            Se un account con questa email esiste, riceverai un'email con le istruzioni per recuperare la password.
                        </div>`;
                    } else {
                        recoverResponse.innerHTML = `
                        <div class="alert alert-danger" role="alert">
                            Errore nel recupero della password. Riprova più tardi.
                        </div>`;
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    recoverResponse.innerHTML = `
                    <div class="alert alert-danger" role="alert">
                        Errore nel recupero della password. Riprova più tardi.
                    </div>`;
                });
        });
    }
});