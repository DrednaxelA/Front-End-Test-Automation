function simplePromise() {

    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            console.log('Success!');
        }, 2000);
    })

    promise.then((result) => {
        console.log(result);
    })
}