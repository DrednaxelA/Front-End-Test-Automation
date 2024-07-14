//etma script standard of importing functions
import { add, substract } from "../functions.js";

QUnit.module('add'); //create a module to attach tests to it

QUnit.test('test function add', function (assert){ //each test will automatically attach to our module
    assert.equal(add(1,2), 3)
});

QUnit.module('Math operations', {
    beforeEach: () => {
        //execute code before each test
    },
    afterEach: () => {
        //execute code after each test
    }
}, () => {
    QUnit.test('add test', function(assert) {
        assert.equal(add(1,2), 3, '1 + 2 should equal 3');
    });
    QUnit.test('substraction test', function(assert) {
        assert.equal(substract(2, 2), 0, '2 - 2 should equal 0')
    })
});

QUnit.module('Assertion Tests');

QUnit.test('ok() assertion method test', function (assert) {
    assert.ok(1, "1 is true");
    assert.ok('Hello', 'Hello string is true');

});