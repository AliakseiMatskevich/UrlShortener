function redirectToPage() {
    window.location = '/Index';
}

const apiUrl = 'https://localhost:7131/api/Url';

const createUrl = async () => {

    const form = document.querySelector('form');

    const data = {
        OriginalUrl: document.getElementById("originalUrl").value,
        Host: location.protocol + '//' + location.host,
        UserId: getCookie("CurrentUserId")
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
        alert("Url creation failed! Try again!");
    }
};

const deleteUrl = async (id) => {

    fetch(apiUrl + "/" + id, {
        method: 'DELETE'
    }).then(() => {
        const row = document.getElementById(id);
        row.remove();
        console.log('removed');
    }).catch(err => {
        console.error(err)
    });
};

function getCookie(cookieName) {
    let cookie = {};
    document.cookie.split(';').forEach(function (el) {
        let [key, value] = el.split('=');
        cookie[key.trim()] = value;
    })
    return cookie[cookieName];
}