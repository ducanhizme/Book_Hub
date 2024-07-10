const loginForm = document.querySelector("#loginForm");
const registerForm = document.querySelector("#registerForm");
const switchToRegister = document.querySelector("#switchToRegister");
const switchToLogin = document.querySelector("#switchToLogin");
const overlay = document.querySelector("#overlay");
document.addEventListener("DOMContentLoaded", function () {
    if (window.innerWidth <= 768) {
        registerForm.classList.add("hidden");
    }
})
function switchForm(direction) {
    if (window.innerWidth <= 768) {
        if (direction === "left") {
            registerForm.classList.remove("hidden");
            loginForm.classList.add("hidden");
        } else {
            loginForm.classList.remove("hidden");
            registerForm.classList.add("hidden");
        }
    } else {
        if (direction === "right") {
            overlay.classList.add("move-right");
        } else {
            overlay.classList.remove("move-right");
            overlay.classList.add("move-left");
        }
    }
}

switchToRegister.addEventListener("click", function (event) {
    event.preventDefault();
    switchForm("left");
});

switchToLogin.addEventListener("click", function (event) {
    event.preventDefault();
    switchForm("right");
});