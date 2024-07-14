function chainedPromises() {
  console.log("Start");
  setTimeout(() => {
    console.log("1");
    setTimeout(() => {
      console.log("2");
      setTimeout(() => {
        console.log("3");
      }, 1000);
    }, 1000);
  }, 1000);
}

//--------------------------------------------------------

function wait(ms) {
  // helper function that returns a Promise object which will wait the given MS param
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve();
    }, ms);
  });
}

function chainedPromisesWithPromise() {
  console.log("Start");

  wait(1000)
    .then(() => {
      console.log("1");
      return wait(1000); //wait returns another Promise, so we chain it
    })
    .then(() => {
      console.log("2");
      return wait(1000); //wait returns another Promise, so we chain it
    })
    .then(() => {
      console.log("3"); //our last Promise, we don't need to go further
    });
}
