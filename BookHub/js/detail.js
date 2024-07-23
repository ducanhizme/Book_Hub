const decrease = document.getElementById('decrease');
const increase = document.getElementById('increase');

increase.addEventListener('click', () => {
    let value = parseInt(document.getElementById('quantity').value,10);
    value = isNaN(value) ? 0 : value;
    value++;
    document.getElementById('quantity').value = value;
})

decrease.addEventListener('click', () => {
    let value = parseInt(document.getElementById('quantity').value, 10);
    value = isNaN(value) ? 0 : value;
    value < 1 ? value = 1 : '';
    value--;
    document.getElementById('quantity').value = value;
});