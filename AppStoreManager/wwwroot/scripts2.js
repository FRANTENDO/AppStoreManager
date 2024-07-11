document.addEventListener('DOMContentLoaded', function () {
    const contactForm = document.getElementById('contact-form');
    const formResponse = document.getElementById('form-response');

    contactForm.addEventListener('submit', function (event) {
        event.preventDefault();
        formResponse.textContent = 'Message sent successfully!';
        contactForm.reset();
    });

    const apps = [
        { id: 1, name: 'Clash Royale', description: 'An exciting game.', price: 2.99, icon: 'images/cr.jpg', category: 'games' },
        { id: 2, name: 'Brawl Stars', description: 'A fun brawler game.', price: 0, icon: 'images/bs.jpg', category: 'games' },
        { id: 3, name: 'Brawlhalla', description: 'An epic platform fighter.', price: 1.99, icon: 'images/bh.jpg', category: 'games' },
        { id: 4, name: 'Instagram', description: 'Share your moments.', price: 0, icon: 'images/ig.jpg', category: 'social' },
        { id: 5, name: 'Facebook', description: 'Connect with friends.', price: 0, icon: 'images/fb.jpg', category: 'social' },
        { id: 6, name: 'Whatsapp', description: 'Chat with family.', price: 0, icon: 'images/wa.jpg', category: 'messaging' },
        { id: 7, name: 'Minecraft', description: 'A sandbox game.', price: 26.95, icon: 'images/mc.jpg', category: 'games' },
        { id: 8, name: 'Clash Of Clans', description: 'Build and battle.', price: 0, icon: 'images/coc.jpeg', category: 'games' },
        { id: 9, name: 'Roblox', description: 'Create and play.', price: 0, icon: 'images/rblx.png', category: 'games' }
    ];

    const searchButton = document.getElementById('confirm-button');
    const searchInput = document.getElementById('search');
    const searchResult = document.getElementById('search-result-bottom');

    function performSearch() {
        const searchTerm = searchInput.value.toLowerCase();
        const filteredApps = apps.filter(app => app.name.toLowerCase().includes(searchTerm));

        searchResult.innerHTML = '';
        filteredApps.forEach(app => {
            const appDiv = document.createElement('div');
            appDiv.className = 'col-12 col-md-6 col-lg-4';
            appDiv.innerHTML = `
                <div class="card mb-4">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="${app.icon}" class="card-img search-result-img" alt="${app.name}">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title">${app.name}</h5>
                                <p class="card-text">${app.description}</p>
                                <p class="card-text"><small class="text-muted">Price: $${app.price}</small></p>
                            </div>
                        </div>
                    </div>
                </div>
            `;
            searchResult.appendChild(appDiv);
        });

        if (filteredApps.length === 0) {
            searchResult.innerHTML = '<p class="col-12">No results found.</p>';
        }

        // Clear the search input after search
        searchInput.value = '';

        // Scroll to the search result
        searchResult.scrollIntoView({ behavior: 'smooth' });
    }

    searchButton.addEventListener('click', performSearch);

    searchInput.addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            performSearch();
        }
    });
});