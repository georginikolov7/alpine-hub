

const rowsElements = document.querySelectorAll('.custom-table tbody tr');
for (const rowElement of rowsElements) {
    rowElement.addEventListener("click", (e) => {
        rowElement.classList.add('row-click-animation');

        // Remove the animation class after the animation is complete
        rowElement.addEventListener('animationend', function () {
            rowElement.classList.remove('row-click-animation');
        }, { once: true });
    });
}