const url = "https://swapi.dev/api";

fetch(`${url}/people/1`) // -> returns Promise from Response
  .then((response) => response.json()) // -> after resolved Promise from Response, return JSON data Promise
  .then((data) =>console.log(data)) // resolve JSON data promise and display it 
  .catch((error) => console.log('Something went wrong')); 
