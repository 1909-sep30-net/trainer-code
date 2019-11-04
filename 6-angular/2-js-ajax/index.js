'use strict';

// the browser exposes some extra APIs
// to JavaScript besides just the DOM

// XMLHttpRequest object for example

// AJAX - Asynchronous JavaScript
//  And XML

// what it really means is,
// making HTTP requests and receiving
// responses from the browser via javascript.

document.addEventListener('DOMContentLoaded', function () {
    let button = document.getElementById('jokeButton');
    let display = document.getElementById('jokeDisplay');

    button.addEventListener('click', function () {
        // make request to api
        let xhr = new XMLHttpRequest();

        xhr.addEventListener('readystatechange', function () {
            // "xhr.readyState" property indicates
            // progress through request-response cycle
            // 4 means, response is loaded
            if (xhr.readyState === 4) {
                if (xhr.status >= 200 && xhr.status < 300) {
                    // success; the "xhr.response" property
                    // now has the response body.
                    // if the response body is in JSON...
                    // we have JSON serializer
                    // - JSON.stringify() serializes
                    // - JSON.parse() deserializes

                    // task: get the joke
                    let joke = '';
                    display.innerHTML = joke;
                } else {
                    // display error to user
                    console.error('http error');
                    console.log(xhr.response);
                }
            }
        });

        xhr.open('(method goes here)', '(url goes here)');

        xhr.send();
    });
});
