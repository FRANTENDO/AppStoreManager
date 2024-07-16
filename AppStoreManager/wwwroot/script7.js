const imageName = 'SubwaySurfersIcon.jpg'; // Nome dell'immagine che vuoi caricare
const imageUrl = `/api/images/${SubwaySurfersIcon}`;

fetch(imageUrl)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.blob();
    })
    .then(blob => {
        const url = URL.createObjectURL(blob);
        const img = document.createElement('img');
        img.src = url;
        document.body.appendChild(img); // Aggiungi l'immagine al DOM
    })
    .catch(error => {
        console.error('There has been a problem with your fetch operation:', error);
    });
