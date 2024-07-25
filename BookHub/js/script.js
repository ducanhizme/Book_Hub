const navbarMenu = document.getElementById("menu");
const burgerMenu = document.getElementById("burger");
const headerMenu = document.getElementById("header");

// Open Close Navbar Menu on Click Burger
let isMenuOpen = false;

// Function to toggle burger menu and navbar menu
function toggleMenu() {
    burgerMenu.classList.toggle("is-active");
    navbarMenu.classList.toggle("is-active");
    // Toggle the flag
    isMenuOpen = !isMenuOpen;
    // Change the burger icon based on the flag
    burgerMenu.innerHTML = isMenuOpen ?
        '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512"><path fill="#ffffff" d="M342.6 150.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0L192 210.7 86.6 105.4c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3L146.7 256 41.4 361.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0L192 301.3 297.4 406.6c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L237.3 256 342.6 150.6z"/></svg>' :
        '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="#ffffff" d="M0 96C0 78.3 14.3 64 32 64l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 128C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 288c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32L32 448c-17.7 0-32-14.3-32-32s14.3-32 32-32l384 0c17.7 0 32 14.3 32 32z"/></svg>';
}

// Open/Close Navbar Menu on Click Burger
if (burgerMenu && navbarMenu) {
    burgerMenu.addEventListener("click", toggleMenu);
}


// Change Header Background on Scrolling
window.addEventListener("scroll", () => {
    if (window.scrollY >= 85) {
        headerMenu.classList.add("on-scroll");
        if (!isMenuOpen) { // Only change the burger icon if the menu is not open
            burgerMenu.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="#937dc2" d="M0 96C0 78.3 14.3 64 32 64l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 128C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 288c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32L32 448c-17.7 0-32-14.3-32-32s14.3-32 32-32l384 0c17.7 0 32 14.3 32 32z"/></svg>';
        }
    } else {
        headerMenu.classList.remove("on-scroll");
        if (!isMenuOpen) { // Only revert the burger icon if the menu is not open
            burgerMenu.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="#ffffff" d="M0 96C0 78.3 14.3 64 32 64l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 128C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32l384 0c17.7 0 32 14.3 32 32s-14.3 32-32 32L32 288c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32L32 448c-17.7 0-32-14.3-32-32s14.3-32 32-32l384 0c17.7 0 32 14.3 32 32z"/></svg>';
        }
    }
});

// Fixed Navbar Menu on Window Resize
window.addEventListener("resize", () => {
    if (window.innerWidth > 768) {
        if (navbarMenu.classList.contains("is-active")) {
            navbarMenu.classList.remove("is-active");
        }
    }
});
window.addEventListener("load", () => {
    const simpleToast = document.querySelector("#simpleToast");
    if (simpleToast && simpleToast.classList.contains("show")) {
        setTimeout(() => {
            simpleToast.classList.remove("show");
        }, 3000);
    }
});

const swiper = new Swiper('.swiper', {
    // Optional parameters
    direction: 'horizontal',
    grabCursor: true,
    slidesPerView: 1,

    // And if we need scrollbar
    scrollbar: {
        el: '.swiper-scrollbar',
    },
    breakpoints: {
        // when window width is >= 480px
        480: {
            slidesPerView: 1,
            spaceBetween: 10
        },
        // when window width is >= 640px
        640: {
            slidesPerView: 2,
            spaceBetween: 10
        },
        // when window width is >= 768px
        768: {
            slidesPerView: 3,
            spaceBetween: 10
        },
        // when window width is >= 1024px
        1024: {
            slidesPerView: 4,
            spaceBetween: 10
        },
        1800: {
            slidesPerView: 5,
            spaceBetween: 10
        }
    }
});

