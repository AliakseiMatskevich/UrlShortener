function redirectToPage() {
    window.location = '/Index';
}

const apiUrl = 'https://localhost:7131/api/Url';

const createUrl = async () => {

    const form = document.querySelector('form');

    const data = {
        OriginalUrl: document.getElementById("originalUrl").value,
        Host: location.protocol + '//' + location.host
    };

    console.log('Data to be sent:', JSON.stringify(data));

    const response = await fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    if (response.ok) {
        form.reset();        
        redirectToPage();
        alert("Url created successful!");
    }
    else {
        alert("Person creation failed! Try again!");
    }
};