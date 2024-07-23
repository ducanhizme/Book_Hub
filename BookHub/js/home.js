
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