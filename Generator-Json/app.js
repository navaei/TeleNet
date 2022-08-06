'use strict';

var fs = require('fs')

var args = process.argv.slice(2);

function compact(array) {
    var index = -1,
        length = array == null ? 0 : array.length,
        resIndex = 0,
        result = [];

    while (++index < length) {
        var value = array[index];
        if (value) {
            result[resIndex++] = value;
        }
    }
    return result;
}

var source = fs.readFileSync(`${args[0]}.tl`, 'utf8');

// Remove all comments and end ';'
var pass1 = source.replace(/\/\/.*/g, '').replace(/;/g, '');

// Split it in Array and remove invalid items
var pass2 = compact(pass1.split('\n'));

var schemes = { constructors: [], methods: [] };
var cursor_type = 0; // 0: constructors(types), 1: methods
pass2.forEach((line) => {
    try {
        if (line.replace(/\r/g, "") === '---types---') cursor_type = 0;
        else if (line.replace(/\r/g, "") === '---functions---') cursor_type = 1;
        else {
            var scheme = {
                id: '',
                params: [],
                type: ''
            }
            var argu = line.trim().split(' ')

            // ID: Hex to Dec
            scheme.id = (parseInt(argu[0].split('#')[1], 16) | 0).toString()
            scheme.type = argu[argu.length - 1]
            if (argu.length > 3) {
                var params_a = argu.slice(1, -2)
                params_a.forEach((param) => {
                    // Process params
                    // Seems they are comments.
                    if (param.slice(0, 1) == '{') return
                    // Vector no params
                    if (argu[0].split('#')[0] == 'vector') return
                    var param_a = param.split(':')
                    scheme.params.push({
                        name: param_a[0],
                        type: param_a[1]
                    })
                })
            }
            if (cursor_type === 0) {
                scheme.predicate = argu[0].split('#')[0]
                schemes.constructors.push(scheme)
            }
            else if (cursor_type === 1) {
                scheme.method = argu[0].split('#')[0]
                schemes.methods.push(scheme)
            }
        }
    } catch (e) {
        throw e;
    }

});

fs.writeFileSync(`${args[0]}.json`, JSON.stringify(schemes));