$(function () {
    const DEFAULT_PATH = "D:\\MODEL_COMP_HIACUSTIC";
    //Клик по таблице
    let $tr = $('table tbody tr');
    let changedTDIndexes = [];

    if (!getCookie("currPath")) {
        let result = prompt("Якщо шлях до кореневої папки з файлами на Вашому комп'ютері відрізняеться від того що за замовуванням (\"" + DEFAULT_PATH + "\"), введіть його. Інакше відкривати потрібні файли буде неможливо", DEFAULT_PATH);
        setCookie("currPath", result ? result : DEFAULT_PATH);
    }

    $('#changeCurrPath').click(function () {
        let currPath = getCookie("currPath");
        if (currPath) {
            let result = prompt("Введіть новий шлях до кореневої папки", currPath);
            if (result) {
                setCookie("currPath", result ? result : DEFAULT_PATH);
            }
        }
    });

    $tr.click(function () {

        $(this).addClass("selectedRow").siblings().removeClass("selectedRow");

        let headersArray = getHeadersArray();

        //Выбраная строка
        let $clickedRowData = ($(this)).children('td');

        let dataArr = getDataFromTr($clickedRowData);

        let headers = getHeadersArray();

        let inputItems = getFormElements();

        let inputNames = inputItems.map((input, i) => $(input).attr('name'));

        $clickedRowData.map((i, td) => {
            let name = $(td).attr('name');
            let index = inputNames.indexOf(name);
            if (index != -1) {
                inputItems[index].val($(td).text());
            }
        });
        
    });

    function getDataFromTr($tr) {
        return Array.prototype.map.call($tr, (td, i) => $(td).text());
    }

    $('#fixChangesInTable').click(function (event) {
        let id = $('form input#Id').val();
        if (id) {
            if (!changedTDIndexes.includes(id)) {
                changedTDIndexes.push(id);
            }

            let $currentTd = getTdWithCurrId(id);

            let inputItems = getFormElements();

            let tableHeaders = getHeadersArray();

            inputItems.map((item) => {
                if (tableHeaders.includes(item[0].name)) {
                    let index = tableHeaders.indexOf(item[0].name);
                    $($currentTd[index]).text($(item[0]).val());
                }
            });
        }
    });

    $('#updateDB').click(function (event) {
        let obj = {
            "updateStringJson" : JSON.stringify(formUpdateStringsArr())
        };

        $.ajax({
            type: "POST",
            url: myUrl,
            data: obj,
            success: function () {
                $("#success").fadeIn(500).delay(100).fadeOut(500);
            },
            error: function (xhr) {
                console.log(xhr.responseText);
                $("#error").fadeIn(500).delay(100).fadeOut(500);
            }
        });


        function formUpdateStringsArr() {
            let arrayOfObjects = [];
            changedTDIndexes.forEach(function (item, i, arr) {
                let object = UpdateObject(item);
                arrayOfObjects.push(object);
            });
            return arrayOfObjects;

            function UpdateObject(item) {
                let headers = getHeadersArray();
                let $td = getTdWithCurrId(item);
                let object = {};
                $td.each(function () {
                    let index = $td.index($(this));
                    object[headers[index]] = $(this).text().trim();
                });
                return object;
            }
        }
    });

    $('#createMap').click(function (event) {
        let inputItems = getFormElements();
        inputItems.forEach(function (item, i, arr) {
            item.val("");
        });
        $tr = $('table tbody tr');
        $tr.removeClass("selectedRow");
        let $newTr = $tr.last().clone();
        $newTr.children('td').each(function () {
            $(this).text("");
        });
        let nextID = parseInt($('table tbody tr').last().children().first().text().trim()) + 1;
        $newTr.children().first().text(nextID);
        $('table').append($newTr);

    });

    //Дані полів форми
    function getFormElements() {
        let headersArray = getHeadersArray();
        let formElements = [];
        for (let i = 0; i < headersArray.length; i++) {
            let $item = $('form input[name="' + headersArray[i] + '"], textarea[name="' + headersArray[i] + '"], select[name="' + headersArray[i] + '"]');
            //$item = ($item.length > 0) ? $item : $('input, textarea, select').eq(i);
            if ($item.length > 0) {
                formElements.push($item);
            }
        }
        return formElements;
    }

    //Дані таблиці
    function getHeadersArray() {
        return Array.prototype.map.call($('table thead tr td'), (td, i) => $(td).text());
    }

    function getTdWithCurrId(id) {
        let $currentTd;
        let $tr = $('table tbody tr');
        for (let i = 0; i < $tr.size() ; i++) {
            let $td = $('td', $tr.eq(i));
            let tdText = $td.eq(0).text().trim();
            if (tdText == id) {
                $currentTd = $td;
                break;
            }
        }
        return $currentTd;
    }
});