async function promiseRejectionAsync() {
   let promise = new Promise ((resolve, reject) => {
      setTimeout(() => {
         reject(new Error('Sorry, there was an error!')) //when we use Error obj it give indication on which line the error occurred
      }, 1000);
   });

   try {
      await promise;
   }
   catch(err){
      console.log(err);
   }
}