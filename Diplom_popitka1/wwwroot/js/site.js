// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener('DOMContentLoaded', function () {
    createCalendar(document.getElementById('calendar'), 2023, 6);
});

function showNoteField() {
    document.getElementById('noteField').style.display = 'block';
}

function saveNote() {
    const important = document.getElementById('importantNote').checked;
    const note = document.getElementById('noteInput').value;

    alert(`Заметка сохранена! Важная: ${important}\nСодержимое: ${note}`);

    document.getElementById('noteInput').value = '';
    document.getElementById('importantNote').checked = false;
}
function filterRequestsByDate(date) {
    const form = document.getElementById('noteForm');
    form.submit();
}
function createCalendar(element, year, month) {
    const daysInMonth = new Date(year, month + 1, 0).getDate();

    const table = document.createElement('table');
    table.classList.add('calendar');

    const header = document.createElement('caption');
    header.textContent = `${year} год, ${month + 1} месяц`;
    table.appendChild(header);

    const thead = document.createElement('thead');
    const daysOfWeek = ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Вс'];
    const headerRow = document.createElement('tr');
    for (let i = 0; i < daysOfWeek.length; i++) {
        const th = document.createElement('th');
        th.textContent = daysOfWeek[i];
        headerRow.appendChild(th);
    }
    thead.appendChild(headerRow);
    table.appendChild(thead);

    const tbody = document.createElement('tbody');
    let row = document.createElement('tr');
    let firstDayOfWeek = new Date(year, month, 1).getDay();
    firstDayOfWeek = firstDayOfWeek === 0 ? 7 : firstDayOfWeek;

    for (let i = 1; i < firstDayOfWeek; i++) {
        const emptyCell = document.createElement('td');
        row.appendChild(emptyCell);
    }

    for (let i = 1; i <= daysInMonth; i++) {
        if ((i + firstDayOfWeek - 1) % 7 === 0) {
            tbody.appendChild(row);
            row = document.createElement('tr');
        }
        const cell = document.createElement('td');
        cell.textContent = i;
        cell.addEventListener('click', function () {
            const chosenDate = new Date(year, month, i).toISOString().split('T')[0];
            document.getElementById('dateChoicen').value = chosenDate;
            filterRequestsByDate(chosenDate);
        });
        row.appendChild(cell);
    }
    tbody.appendChild(row);
    table.appendChild(tbody);

    element.appendChild(table);
}


// Write your JavaScript code.
