﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification


function saveNote(event) {
    if (event) {
        event.preventDefault(); // предотвращает перезагрузку страницы
    }
    var requestId = $('input[name="requestId"]:checked').val();
    var note = $('#noteInput').val();

    $.ajax({
        url: '@Url.Action("SaveNote", "Mechanic")',
        type: 'POST',
        data: {
            requestId: requestId,
            note: note
        },
        success: function (response) {
            if (response.success) {
                //alert('Заметка успешно сохранена!');
                $('#noteInput').val(''); // Очистить поле заметки
            } else {
                //alert('Ошибка при сохранении заметки.');
            }
        },
        error: function () {
            alert('Произошла ошибка при отправке запроса.');
        }
    });
}


//выбираем даты
function selectDate(day, month, year) {
    // Формируем строку с датой
    var selectedDate = day.toString().padStart(2, '0') + '-' + (month + 1).toString().padStart(2, '0') + '-' + year;

    // Выводим выбранную дату в элемент на странице (например, с id="selectedDateDisplay")
    document.getElementById('selectedDateDisplay').innerText = "Вы выбрали дату: " + selectedDate;
    document.getElementById('selectedDateDisplay').style.color = "white";
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



function showNoteField() {
    var requestId = $('input[name="requestId"]:checked').val();
    document.getElementById('noteField').style.display = 'block';
   
    $.ajax({
        url: '/Mechanic/NotesInThisRequest', // URL контроллера
        type: 'POST',
        data: { requestId: requestId }, // Отправка значения строки
        success: function (response) {

            // Замените содержимое div с id="selectedDateDisplay"
            $('#notesInThisRequest').html(response);
        },
        error: function (error) {
            // Обработка ошибки
            console.error(error);
        }
    });
}




// Write your JavaScript code.
