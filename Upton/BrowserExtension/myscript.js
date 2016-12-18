var pageContent = document.documentElement.innerHTML;
var xhttp = new XMLHttpRequest();

xhttp.open("POST", "http://localhost:8001/api/ProcessPage", false);
xhttp.send(JSON.stringify({

    address: document.URL,
    content: pageContent
}));

alert(JSON.parse(xhttp.responseText));