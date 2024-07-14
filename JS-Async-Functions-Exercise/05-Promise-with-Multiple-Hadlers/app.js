function promiseWithMultipleHandlers() {
   let promise = new Promise ((resolve, reject) => {
    setTimeout(() => {
        resolve('Hello World');
    }, 2000);
   });

   promise.then((result) => {
    console.log(result);
    return result; //returns a Promise again
   }).then((result) => {
    console.log(result);
   });
}