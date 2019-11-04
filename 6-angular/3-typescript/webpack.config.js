const path = require('path');

// this will take JS from out folder, starting at index.js
// and bundle it into one dist/main.js
module.exports = {
    entry: './out/index.js',
    output: {
        filename: 'main.js',
        path: path.resolve(__dirname, 'dist'),
    },
    mode: 'development'
};
