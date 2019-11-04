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
        // getJokeWithXhr(display);
        getJokeWithFetch(display);
    });
});

// a Promise is an object
// that represents some result that can either
// succeed and arrive ("resolve")
// or fail with some error ("reject")

// when you have a Promise, you call one of two methods on it
// .then(success, fail)   -> for success or failure
// .catch(fail)           -> for failure

function getJokeWithFetch(display) {
    // fetch returns a promise of the response headers
    fetch('http://api.icndb.com/jokes/random')
        .then(res => res.json()) // .json returns a promise of the reponse body parsed from json
        .then(obj => {
            display.innerHTML = obj.value.joke;
        })
        .catch(err => console.error(err));
}

// challenge: look up "promisification"
// and write your own "fetch" based on XHR

function getJokeWithXhr(display) {
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
                let obj = JSON.parse(xhr.response);
                console.log(obj);
                let joke = obj.value.joke;
                display.innerHTML = joke;
            } else {
                // display error to user
                console.error('http error');
                console.log(xhr.response);
            }
        }
    });

    xhr.open('get', 'http://api.icndb.com/jokes/random');

    xhr.send();
}
