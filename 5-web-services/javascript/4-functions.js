'use strict';

// in JS, we will often
// pass functions as parameters to other functions
// so that the parameters can be called later.
// "callback" function

function addSlowly(a, b, onSuccess) {
    // takes 1 second to connect to the
    // imaginary "calculator service"
    // debugger;
    setTimeout(function () {
        let result = a + b;
        onSuccess(result);
    }, 50);
    // not returning the result,
    // it's not ready yet
}

// addSlowly(1, 2, console.log);
console.log('still waiting...');

// ES6 added "arrow function" syntax
// which is the same as lambda expression in C#
addSlowly(1, 3, result => {
    if (result === 4) {
        console.log('it\'s 4, i was right');
    } else {
        console.log('math is broken');
    }
});
// this is one quirk about arrow functions
// that makes them different from any other function
// arrow functions do not get "this" value
// from how they are *called*.
// they get it from what value it has when they are *defined*.

let c = 100;

function newCounter () {
    let c = -1;
    // return () => c++;

    return function () {
        c++;
        return c;
    }
}
// newCounter returns a function
// THAT function returns a number.

// this behavior where a nested function
// can refer to an "keep alive" variables
// from the outer function's scope
// is called "closure"
// the inner function "closes over"
// those variables from the outer function

console.log('');

let counter1 = newCounter();
console.log(counter1()); // 0
console.log(counter1()); // 1
console.log(counter1()); // 2

let counter2 = newCounter();
console.log(counter2()); // 0
console.log(counter2()); // 1
console.log(counter2()); // 2

console.log(counter1()); // 3


// IIFE
// immediately invoked function expression

(function () {
    // IIFE lets me use variable "x"
    // without conflicting with
    // some other "x" in global scope
    let x = 'data';
    console.log(x);
})();

// this provides a little encapsulation

// combining closure and IIFE
let library = (function () {
    let privateData = 1;

    function privateFunction() {
        privateData *= 2;
        return privateData;
    }

    return {
        publicData: 56,

        publicFunction(x) {
            return x + privateFunction();
        }
    };
})();

library.publicData = 60;
console.log(library.publicFunction(4));
console.log(library.publicFunction(4));
console.log(library.publicFunction(4));
