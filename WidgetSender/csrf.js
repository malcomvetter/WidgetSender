function readBody(xhr) {
    var data;
    if (!xhr.responseType || xhr.responseType === "text") {
        data = xhr.responseText;
    } else if (xhr.responseType === "document") {
        data = xhr.responseXML;
    } else {
        data = xhr.response;
    }
    var parser = new DOMParser();
    var resp = parser.parseFromString(data, "text/html");
    token = resp.getElementsByName('__RequestVerificationToken')[0].value; //grab first available token
    console.log('token: ' + token);
    csrf(token);
    return data;
}

var xhr = new XMLHttpRequest();
xhr.onreadystatechange = function () {
    if (xhr.readyState == 4) {
        response = readBody(xhr);
        //console.log(response);
    }
}
xhr.open('GET', 'http://localhost:49246/Widget/MvcJson', true);
xhr.send(null);

function csrf(token) {
    var sendWidgetModel = {
        "toEmail": 'john@doe.com',
        "widgetMessage": "I hate you, John!",
    };
    var x1 = new XMLHttpRequest();
    x1.open("POST", "http://localhost:49246/Widget/MvcJson");
    x1.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    x1.setRequestHeader('__RequestVerificationToken', token);
    x1.send(JSON.stringify(sendWidgetModel));
}