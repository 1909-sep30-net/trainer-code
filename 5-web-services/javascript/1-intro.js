console.log('Hello world');

// JS is at heart not OOP
// it's object-based
// JS has a lot of support for
//    functional programming
// JS is multi-paradigm

// JS is weakly-typed
// variables do not have any particular type

// JS is interpreted, not compiled
// it runs first of all, in the browser
// (but also, there are server-side runtimes
//        like Node.js)

// there are 7 types in JS
// 1. number
//    for whole numbers and fractional numbers
//   under the hood it is basically "double"
let x = 5;
x = 5.5;
x = Infinity;
x = -0;
x = NaN;
x = 3 / 0;
x = 2 + true;
x = 'abc' / 3;
// isNaN for checking NaN

// boolean
x = true;
x = false;
x = 3 < 4;
x = true || false;
x = true ? 3 : 4;
// all the same operators as in C, C#, etc.

// string
x = 'asdf';
x = "nick's string";
x = x + x;

// object
// behaves like "dynamic" in C#
x = {}; // object literal
x.name = 'Bill';
x = x.age;

// "typeof" says function, but it's object
x = console.log;
// arrays are objects
x = [1, 2, 3];

// undefined
// x = undefined;
// special type for
// uninitialized variables or properties,
// or the return value of functions that don't
// return anything.

// null
// "typeof" says object, but it's really its
// own type.
x = null;

// Symbol
// this type was added in ES6
// it's a way to make globally-unique identifiers
//   and use them

console.log(x);
console.log(typeof(x));

// in JS, funcitons are just data like anything else,
// just objects

// in JS, you don't define parameter types,
// or return type.
// this is "function statement"
function printSomething(thing) {
    console.log(thing);
}

// "function expression"
let printSomethingElse = function (thing) {
    console.log(thing);
};

// JS does not stop you from passing
// too many arguments
printSomethingElse(1, 2, 3);
// nor, too few
// the unassigned ones are just "undefined"
printSomethingElse();

// we have all the C-style control structures
// if (condition) {

// } else if (condition) {

// } else {

// }

// for (let index = 0; index < array.length; index++) {
//     const element = array[index];
// }

// while (condition) {

// }

// switch (key) {
//     case value:

//         break;

//     default:
//         break;
// }

// new in ES6, the equivalent to foreach
// is "for of"

for (let item of [1, 2, 3]) {
    console.log(item);
}
