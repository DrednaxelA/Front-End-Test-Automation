function allPromise() {

    let firstPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('First promise resolved!');     
        }, 1000);
    });

    let secondPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            reject('Second promise rejected!');     
        }, 2000);
    });

    let thirdPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('Third promise resolved!');     
        }, 3000);
    });

    Promise.all([firstPromise, secondPromise, thirdPromise]) //returns resolved only if all promises are resolved, otherwise returns first rejection only
        .then((result) => {
            console.log(result);
        }).catch((err) => {
            console.log(err);
        })
}