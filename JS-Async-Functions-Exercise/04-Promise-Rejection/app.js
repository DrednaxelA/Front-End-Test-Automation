function promiseRejection() {
    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            reject('Something went wrong!');
        }, 1000);
    });
    promise.catch((err) => {
        console.log(err);
    });
}