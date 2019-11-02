'use strict';

// object literal syntax
// objects have properties
//    (work like C# fields, not like C# properties)
let mark = {
    name: 'Mark',
    age: 15
};

mark.sayName = function () {
    // debugger; // breakpoint
    console.log(this.name);
};

// in JavaScript, "this"
// gets assigned in the context of any given function
// the value it gets is, whatever was to the left
// of the "." when the function was called.

mark.sayName();

let say = mark.sayName;
// say(); // doesn't work! this === undefined

let nick = { name: 'Nick', sayName: mark.sayName };
nick.sayName();

// before ES6, JS did not have classes
// we did have inheritance
// "prototypal" inheritance

// set the prototype of mark to nick
mark.__proto__ = nick;

nick.campus = 'uta';

console.log(mark.campus);
// the fundamental way prototypal
// inheritance works is based on how
// property access works.

// whenever you try to access a property on an object,
// if it's not found, then the JS engine
// will search for it on the prototype.
// and then on the prototype's prototype.

// this only applies for *access*, not for
// assignment

mark.campus = 'usf';

nick.sayCampus = function () {
    console.log(this.campus);
}

mark.sayCampus();

// ES5 doesn't have classes, but
// it does have constructors

function Person(name, campus) {
    this.name = name;
    this.campus = campus;
    this.sayName = function () {
        console.log(this.name);
    }
}

// (by convention, we name constructors
// with TitleCase)

nick = new Person('Nick', 'uta');

// what "new" does, is make a new empty object, and call the given function (the constructor) with "this" set to that new object.
console.log(nick);

function Student(name, campus, gpa) {
    this.__proto__ = new Person(name, campus);
    this.gpa = gpa;
    this.isFailing = function () {
        return this.gpa < 2.0;
    }
}

let sam = new Student('Sam', 'uta', 3.0);

console.log(sam);


// now, with ES6, we have classes

class Appliance {
    constructor(name, wattage) {
        this.name = name;
        this.wattage = wattage;
    }

    // ES6 has "method syntax"
    isAToaster() {
        return this.name === 'toaster';
    }
}

let toaster = new Appliance('toaster', 60);

class Refridgerator extends Appliance {
    constructor(brand, wattage) {
        super('refridgerator', wattage);
        this.brand = brand;
    }

    isRunning() {
        return true;
    }
}

// this is really just syntactic sugar for
// what we wrote in ES5 - prototypal inheritance
// with constructors.
