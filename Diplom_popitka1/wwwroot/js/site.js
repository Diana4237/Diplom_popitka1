﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification

function selectDate(day, month, year) {
    // Формируем строку с датой
    var selectedDate = day.toString().padStart(2, '0') + '-' + (month + 1).toString().padStart(2, '0') + '-' + year;

    // Выводим выбранную дату в элемент на странице (например, с id="selectedDateDisplay")
    document.getElementById('selectedDateDisplay').innerText = "Вы выбрали дату: " + selectedDate;
    $.ajax({
        url: '/Mechanic/RequestsInThisDay', // URL контроллера
        type: 'POST',
        data: { selectedDate: selectedDate }, // Отправка значения строки
        success: function (response) {
            
                // Замените содержимое div с id="selectedDateDisplay"
            $('#repairRequestsContainer').html(response);
        },
        error: function (error) {
            // Обработка ошибки
            console.error(error);
        }
    });
    
}


//var selectedDate = '';

//// Функция для получения выбранной даты
//function selectDate(day, month, year) {
//    // Формируем строку с датой
//    selectedDate = `${day.toString().padStart(2, '0')}-${(month + 1).toString().padStart(2, '0')}-${year}`;

//    // Выводим выбранную дату в элемент на странице (например, с id="selectedDateDisplay")
//    document.getElementById('selectedDateDisplay').innerText = "Вы выбрали дату: " + selectedDate;
//    fetch('/Mechanic/RequestsInThisDay', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({ date: selectedDate })
//    })
//        .then(response => {
//            // Проверяем статус ответа
//            if (!response.ok) {
//                throw new Error('Ошибка при отправке данных: ' + response.statusText);
//            }
//            return response.text(); // Или response.json() в зависимости от того, что возвращает сервер
//        })
//        .then(html => {
//            // Выводим полученный HTML в нужный контейнер
//            document.getElementById('repairRequestsContainer').innerHTML = html;
//        })
//        .catch(error => {
//            // Логируем ошибки для отладки
//            console.error('Ошибка при получении ответа от сервера:', error);
//        });
//}



//выбираем даты




//календарь создаем
var Cal = function (divId) {

    //Сохраняем идентификатор div
    this.divId = divId;

    // Дни недели с понедельника
    this.DaysOfWeek = [
        'Пн',
        'Вт',
        'Ср',
        'Чтв',
        'Птн',
        'Суб',
        'Вск'
    ];

    // Месяцы начиная с января
    this.Months = ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'];

    //Устанавливаем текущий месяц, год
    var d = new Date();

    this.currMonth = d.getMonth('9');
    this.currYear = d.getFullYear('22');
    this.currDay = d.getDate('3');
};

// Переход к следующему месяцу
Cal.prototype.nextMonth = function () {
    if (this.currMonth == 11) {
        this.currMonth = 0;
        this.currYear = this.currYear + 1;
    }
    else {
        this.currMonth = this.currMonth + 1;
    }
    this.showcurr();
};

// Переход к предыдущему месяцу
Cal.prototype.previousMonth = function () {
    if (this.currMonth == 0) {
        this.currMonth = 11;
        this.currYear = this.currYear - 1;
    }
    else {
        this.currMonth = this.currMonth - 1;
    }
    this.showcurr();
};

// Показать текущий месяц
Cal.prototype.showcurr = function () {
    this.showMonth(this.currYear, this.currMonth);
};



// Показать месяц (год, месяц)
Cal.prototype.showMonth = function (y, m) {

    var d = new Date()
        // Первый день недели в выбранном месяце 
        , firstDayOfMonth = new Date(y, m, 7).getDay()
        // Последний день выбранного месяца
        , lastDateOfMonth = new Date(y, m + 1, 0).getDate()
        // Последний день предыдущего месяца
        , lastDayOfLastMonth = m == 0 ? new Date(y - 1, 11, 0).getDate() : new Date(y, m, 0).getDate();


    var html = '<table class="calendar-table">';

    // Запись выбранного месяца и года
    html += '<thead><tr>';
    html += '<td colspan="7" class="calendar-td">' + this.Months[m] + ' ' + y + '</td>';
    html += '</tr></thead>';


    // заголовок дней недели
    html += '<tr class="days">';
    for (var i = 0; i < this.DaysOfWeek.length; i++) {
        html += '<td class="calendar-td">' + this.DaysOfWeek[i] + '</td>';
    }
    html += '</tr>';

    // Записываем дни
    var i = 1;
    do {

        var dow = new Date(y, m, i).getDay();

        // Начать новую строку в понедельник
        if (dow == 1) {
            html += '<tr>';
        }

        // Если первый день недели не понедельник показать последние дни предидущего месяца
        else if (i == 1) {
            html += '<tr>';
            var k = lastDayOfLastMonth - firstDayOfMonth + 1;
            for (var j = 0; j < firstDayOfMonth; j++) {
                html += '<td class="calendar-td not-current">' + k + '</td>';
                k++;
            }
        }

        // Записываем текущий день в цикл
        var chk = new Date();
        var chkY = chk.getFullYear();
        var chkM = chk.getMonth();
        if (chkY == this.currYear && chkM == this.currMonth && i == this.currDay) {
            html += '<td class="calendar-td today" onclick="selectDate(' + i + ', ' + m + ', ' + y + ')">' + i + '</td>';
        } else {
            html += '<td class="calendar-td normal" onclick="selectDate(' + i + ', ' + m + ', ' + y + ')">' + i + '</td>';
        }
        // закрыть строку в воскресенье
        if (dow == 0) {
            html += '</tr>';
        }
        // Если последний день месяца не воскресенье, показать первые дни следующего месяца
        else if (i == lastDateOfMonth) {
            var k = 1;
            for (dow; dow < 7; dow++) {
                html += '<td class="calendar-td not-current">' + k + '</td>';
                k++;
            }
        }

        i++;
    } while (i <= lastDateOfMonth);

    // Конец таблицы
    html += '</table>';

    // Записываем HTML в div
    document.getElementById(this.divId).innerHTML = html;
};

// При загрузке окна
window.onload = function () {

    // Начать календарь
    var c = new Cal("divCal");
    c.showcurr();

    // Привязываем кнопки «Следующий» и «Предыдущий»
    getId('btnNext').onclick = function () {
        c.nextMonth();
    };
    getId('btnPrev').onclick = function () {
        c.previousMonth();
    };
}

// Получить элемент по id
function getId(id) {
    return document.getElementById(id);
}


//аккаунт механика
//document.addEventListener('DOMContentLoaded', function () {
//    createCalendar(document.getElementById('calendar'), 2023, 6);
//});

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
//function filterRequestsByDate(date) {
//    const form = document.getElementById('noteForm');
//    form.submit();
//}
//function createCalendar(element, year, month) {
//    const daysInMonth = new Date(year, month + 1, 0).getDate();

//    const table = document.createElement('table');
//    table.classList.add('calendar');

//    const header = document.createElement('caption');
//    header.textContent = `${year} год, ${month + 1} месяц`;
//    table.appendChild(header);

//    const thead = document.createElement('thead');
//    const daysOfWeek = ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Вс'];
//    const headerRow = document.createElement('tr');
//    for (let i = 0; i < daysOfWeek.length; i++) {
//        const th = document.createElement('th');
//        th.textContent = daysOfWeek[i];
//        headerRow.appendChild(th);
//    }
//    thead.appendChild(headerRow);
//    table.appendChild(thead);

//    const tbody = document.createElement('tbody');
//    let row = document.createElement('tr');
//    let firstDayOfWeek = new Date(year, month, 1).getDay();
//    firstDayOfWeek = firstDayOfWeek === 0 ? 7 : firstDayOfWeek;

//    for (let i = 1; i < firstDayOfWeek; i++) {
//        const emptyCell = document.createElement('td');
//        row.appendChild(emptyCell);
//    }

//    for (let i = 1; i <= daysInMonth; i++) {
//        if ((i + firstDayOfWeek - 1) % 7 === 0) {
//            tbody.appendChild(row);
//            row = document.createElement('tr');
//        }
//        const cell = document.createElement('td');
//        cell.textContent = i;
//        cell.addEventListener('click', function () {
//            const chosenDate = new Date(year, month, i).toISOString().split('T')[0];
//            document.getElementById('dateChoicen').value = chosenDate;
//            filterRequestsByDate(chosenDate);
//        });
//        row.appendChild(cell);
//    }
//    tbody.appendChild(row);
//    table.appendChild(tbody);

//    element.appendChild(table);
//}


// Write your JavaScript code.
