
//Promise Array + For Of loop solution
async function chainedPromisesAsyncArraySolution() {

    let promises = 
    [
        firstPromise = new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve('First promise resolved successfully!')
            }, 1000);
        }),
    
        secondPromise = new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve('Second promise resolved successfully')
            }, 2000);
        }),
    
        thirdPromise = new Promise((resolve, reject) => {
            setTimeout(() => {
                console.log('Third promise resolved successfully');
            }, 3000);
        }),   
    ];

    for (const promise of promises) {
        await promise.then((result) => console.log(result));
    }

}

async function chainedPromisesAsyncArrayGeneralSolution() {
    let firstPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('First promise resolved');
        }, 1000);
    });

    let secondPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('Second promise resolved');
        }, 2000);
    });

    let thirdPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve('Third promise resolved');
        }, 3000);
    });

    let result1 = await firstPromise;
    let result2 = await secondPromise;
    let result3 = await thirdPromise;

    console.log(result1, result2, result3);
}