'use strict';

// ES5 added something important to the language
// called "strict mode"
// it fixes old inconsistent behavior
// it turns some silent errors into thrown errors
// (e.g. assigning to undeclared variable no longer allowed)
// x = 3;

// we had, until ES6, two possible scopes in JS.
// 1. global
// 2. function

function operate(x) {
    var naem = 'typo';
    if (x == 0) {
        // (outside strict mode, doing this
        // injected that variable into global scope)
        // name = 'Mark';

        var name = 'Mark';
    }

    console.log(name);
}

operate(0);

// ES6 added block scope to JS

function operate2(x) {
    if (x == 0) {
        let name2 = 'Mark';
    }
    // console.log(name2);
}

operate2(0);

// always use "let" to declare your variables,
// not "var", to get block scope instead of function scope.

// ES6 also gave us "const", block scope like "let",
// but trying to change the value after first assignment
// will be an error.




// JavaScript converts between types quite freely
// we need to know what happens when any given value
// is converted to boolean

// all the ones that convert to true are called "truthy"
// all the ones that convert to false are called "falsy"

// let obj = {};

// if (obj) {

// }

// there are a handful of falsy values, and everything
// else is truthy
// falsy values:
// null
// undefined
// false
// '' (empty string)
// NaN
// 0

// we have two operators in JS for equality
// double equals == (loose equality)
// and triple equals === (strict equality)

// double equals tries to compare value
// without caring about type

function compare(a, b) {
    console.log('' + a + ' == ' + b + ' is ' + (a == b));
    console.log('' + a + ' === ' + b + ' is ' + (a === b));
    console.log('');
}

compare(0, 0);
compare(0, []);
compare(0, NaN);
compare(0, '');
compare(1, '1');

// https://dorey.github.io/JavaScript-Equality-Table/
