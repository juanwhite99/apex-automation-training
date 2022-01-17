const form = document.getElementById("loginForm");
const result = document.getElementById("login-result");
form.addEventListener("submit", function (event) {
  event.preventDefault();
  const email = form["email"].value;
  const password = form["password"].value;
  if (email === "test@email.com" && password === "changeme") {
    result.innerHTML = "Login Successful";
  } else {
    result.innerHTML = "Login Failed";
  }
});
