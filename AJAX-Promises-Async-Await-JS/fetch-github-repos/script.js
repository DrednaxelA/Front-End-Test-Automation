let button = document.querySelector("#load")
let httpRequest
button.addEventListener("click", evenListenerFunc)

function evenListenerFunc() {
  let url = "https://api.github.com/users/testnakov/repos"
  httpRequest = new XMLHttpRequest()
  httpRequest.addEventListener("readystatechange", httpAjaxHandler)
  httpRequest.open("GET", url)
  httpRequest.send()
}

function httpAjaxHandler() {
    if (httpRequest.readyState == 4 && httpRequest.status == 200) {
      document.getElementById("res").textContent = httpRequest.responseText
    }
  }
