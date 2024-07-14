function helloWorld() {
    console.log('Hello');
    setTimeout(() => {
        console.log('World');
    }, 2000);
}

let button = document.querySelector("button");
button.addEventListener("click", helloWorld);

//--------------------------------------------------------------------

function helloWorldWithPromise () {
    console.log('Hello');

    let promise = new Promise ((resolve, reject) => {
        setTimeout(() => {
            resolve("World"); // print this word only when the code is executed successfully
        }, 2000);
    })

    promise.then((result) => { // the successful parameter returned by our Promise will come under "result"
        console.log(result);
    })
}

//--------------------------------------------------------------------

async function helloWorldWithAsyncAwait() { //to use async await we need a Promise object

    console.log('Hello');
    let promise = new Promise ((resolve, reject) => {
        setTimeout(() => {
            resolve("World"); 
        }, 2000);
    });

    let result = await promise; //call promise asynchrosly and wait 2 secs before proceeding
    console.log(result); //print only after the promise has returned
}