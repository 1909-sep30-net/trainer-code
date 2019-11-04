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

    button.addEventListener('click', function () {
        // make request to api
        let xhr = new XMLHttpRequest();

        xhr.addEventListener('readystatechange', function () {
            // "readyState" property
        })
    });
});
