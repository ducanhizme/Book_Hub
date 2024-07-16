const swiper = new Swiper('.swiper', {
    // Optional parameters
    direction: 'horizontal',
    loop: true,
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
        }
    }
});

const genreBooks = document.querySelectorAll('#genreBooks');
const genre_btn = document.querySelectorAll('.genre-btn');
function showBookWithGenre(htmlTemplate) {
    console.log(htmlTemplate);
    genreBooks.innerHTML = `htmlTemplate`;
}
genre_btn.forEach((btn) => {
    btn.addEventListener('click', () => {
        genre_btn.forEach((otherBtn) => {
            otherBtn.classList.remove('active');
        });
        btn.classList.add('active');
    });
});