//async programming with callback - synchronous code is always executed before asynchronous code

function delayStart(callback) {
    setTimeout(() => {
        callback();
    }, 2000);
}
console.log('start');
delayStart(() => console.log('delayed start'));
console.log('finish');