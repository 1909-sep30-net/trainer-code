'use strict';

 //          serializer
// JSON etc.  <=======> C# objects
//   HTML     =======> DOM

// let textElement = document.getElementById('textElement');
// we have getElementsByTagName
// we have getElementsByClass
// we have selector
// we have selectorAll
// textElement.innerHTML = 'text modified from script';

// most stuff we do in javascript
// is done in response to events

window.onload = function () {
    console.log('runs once the whole window is loaded');
    // (when the "load" event fires on the window object)
};

// better way to do this
window.addEventListener('load', function () {
    console.log('also runs once the whole window is loaded');
});

// "load" event fires on each element on the page
// once it and its children are fully loaded by the browser
document.addEventListener('DOMContentLoaded', function () {
    // this event doesn't wait that long
    console.log('runs before those other callbacks');

    // here we know all the DOM exists
    // good place to set up all our other event listeners
    // (aka callbacks)

    let textElement = document.getElementById('textElement');
    textElement.addEventListener('click', function () {
        textElement.innerHTML += '!';
    });

    let button = document.getElementById('button');
    let list = document.getElementById('list');

    let counter = 1;

    button.addEventListener('click', function () {
        // to add elements, first you create them,
        // then you insert them in the DOM at the right spot
        let item = document.createElement('li');
        item.innerHTML = 'item #' + counter++;
        list.appendChild(item);
    });

    let link = document.getElementsByTagName('a')[0];
    link.addEventListener('click', function (event) {
        // if we set "window.location", it navigates to a
        // new page.
        window.location = 'https://microsoft.com';
        // the browser has default event listeners...
        // we can switch them off like this
        event.preventDefault();
    });

    let table = document.getElementById('table1');
    let numberCell = table.tHead.rows[0].cells[0];
    numberCell.addEventListener('click', function (event) {
        printEventDetails(event);
    });


    table.addEventListener('click', function (event) {
        event.target.innerHTML += '!';
        printEventDetails(event);

        // other methods on events...
        // disable all future event listeners on other elements
        // for this specific event
        // event.stopPropagation();
        // also disable future listeners on this current element
        event.stopImmediatePropagation();
        // "this" = event.currentTarget in most contexts
        // console.log(`this: ${this}`);
        // those are bad practice
    }, true);
    table.addEventListener('click', function (event) {
        console.log('second event listener, same event type, same element');
    }, true);
    // true as third parameter puts your event listener
    // in capturing mode. it will run *before* the target's
    // listeners on any events fired among this element's descendants
});

function printEventDetails(event) {
    // spring interpolation
    // JS has "back-tick strings" using ``
    // console.log(event);
    // console.log(`event.type: ${event.type}`);
    console.log(`event.target: ${event.target}`);
    console.log(`event.currentTarget: ${event.currentTarget}`);
    console.log('');
    console.log(`this: ${this}`);
}

// apparently async attribute on script has some
// effect on DOMContentLoaded event...
