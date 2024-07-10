const swiper = new Swiper('.swiper', {
    // Optional parameters
    direction: 'horizontal',
    loop: true,
    grabCursor: true,

    // And if we need scrollbar
    scrollbar: {
        el: '.swiper-scrollbar',
    },
    breakpoints: {
        // when window width is >= 320px
        320: {
            slidesPerView: 1,
            spaceBetween: 10
        },
        // when window width is >= 480px
        480: {
            slidesPerView: 2,
            spaceBetween: 20
        },
        // when window width is >= 640px
        640: {
            slidesPerView: 3,
            spaceBetween: 30
        },
        // when window width is >= 768px
        768: {
            slidesPerView: 4,
            spaceBetween: 40
        },
        // when window width is >= 1024px
        1024: {
            slidesPerView: 5,
            spaceBetween: 50
        }
    }
});