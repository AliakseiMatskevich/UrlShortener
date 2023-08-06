function redirectToPage() {
    window.location = '/Index';
}

const apiUrl = 'https://localhost:7131/api/Url';

const createUrl = async () => {

    const originalUrl = document.getElementById("originalUrl").value;
    if (isValidUrl(originalUrl)) {
        document.getElementById("originalUrlValidation").innerHTML = ""
        const form = document.querySelector('form');

        const data = {
            OriginalUrl: originalUrl,
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
    }
    else {
        document.getElementById("originalUrlValidation").innerHTML = "Url is not valid. Creation failed.";
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

function isValidUrl(str) {
    const pattern = new RegExp(
        '^(https?:\\/\\/)?' + // protocol
        '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|' + // domain name
        '((\\d{1,3}\\.){3}\\d{1,3}))' + // OR ip (v4) address
        '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' + // port and path
        '(\\?[;&a-z\\d%_.~+=-]*)?' + // query string
        '(\\#[-a-z\\d_]*)?$', // fragment locator
        'i'
    );
    return pattern.test(str);
}