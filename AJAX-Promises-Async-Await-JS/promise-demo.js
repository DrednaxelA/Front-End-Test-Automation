const weddingPromise = new Promise((resolve, reject) => {
  if (Math.random() < 0.3) {
    return reject("Sorry, it's me!");
  }

  setTimeout(() => {
    resolve("Just married!");
  }, 5000);
});

weddingPromise
  .then((message) => {
    console.log(message);
  })
  .catch((message) => {
    console.log(message);
  });

//Always rejecting promise
const rejectingPromise = Promise.reject("Sorry, try again next time");
console.log(rejectingPromise);
rejectingPromise.catch((message) => console.log(message));

//Multiple parallel promises
const createTimeoutPromise = function(message, time) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
        resolve(message)
    }, time);
  });
};

const groupPromise = Promise.all([
    Promise.resolve("First promise"),
    createTimeoutPromise('second promise', 3000),
    createTimeoutPromise('third promise', 1000)
]);

groupPromise.then((values) => {
    console.log(values);
})
