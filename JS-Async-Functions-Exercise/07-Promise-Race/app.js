function racePromise() {
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

    Promise.race([firstPromise, secondPromise, thirdPromise]) // return the result only of the first promise to resolve itself
    .then((result) => {
        console.log(result);
    })
}