$(function () {
    //Клик по таблице
    var $tr = $('table tbody tr');
    var changedTDIndexes = [];
    $tr.click(function () {

        $(this).addClass("selectedRow").siblings().removeClass("selectedRow");

        var headersArray = getHeadersArray();

        //Выбраная строка
        var $clickedRowData = ($(this)).children('td');

        setDataFromTrToForm($clickedRowData);
        
    });

    function setDataFromTrToForm($RowData) {
        //Элементы ввода формы
        var inputItems = getFormElements();

        //Записать данные из выбраной строки в элементы ввода
        for (var i = 0; i < inputItems.length ; i++) {
            if (inputItems[i].get(0).tagName != 'SELECT') {
                inputItems[i].val($RowData.eq(i).text().trim());
            }
            else {
                inputItems[i].children('option').each(function () {
                    if ($(this).text() == $RowData.eq(i).text().trim()) {
                        $(this).attr("selected", "selected");
                    }
                });
            }
        }
    }

    $('#fixChangesInTable').click(function (event) {
        var id = $('form input#Id').val();
        if (id) {
            if (!changedTDIndexes.includes(id)) {
                changedTDIndexes.push(id);
            }

            var $currentTd = getTdWithCurrId(id);

            var inputItems = getFormElements();

            $currentTd.each(function () { $(this).text(inputItems.shift().val().trim()) });
        }
    });

    $('#updateDB').click(function (event) {
        var obj = {
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
            var arrayOfObjects = [];
            changedTDIndexes.forEach(function (item, i, arr) {
                var object = UpdateObject(item);
                arrayOfObjects.push(object);
            });
            return arrayOfObjects;

            function UpdateObject(item) {
                var headers = getHeadersArray();
                var $td = getTdWithCurrId(item);
                var object = {};
                $td.each(function () {
                    var index = $td.index($(this));
                    object[headers[index]] = $(this).text().trim();
                });
                return object;
            }
        }
    });

    $('#createMap').click(function (event) {
        var inputItems = getFormElements();
        inputItems.forEach(function (item, i, arr) {
            item.val("");
        });
        $tr = $('table tbody tr');
        $tr.removeClass("selectedRow");
        var $newTr = $tr.last().clone();
        $newTr.children('td').each(function () {
            $(this).text("");
        });
        var nextID = parseInt($('table tbody tr').last().children().first().text().trim()) + 1;
        $newTr.children().first().text(nextID);
        $('table').append($newTr);
        setDataFromTrToForm($newTr);

    });


    function getFormElements() {
        var headersArray = getHeadersArray();
        var formElements = [];
        for (var i = 0; i < headersArray.length; i++) {
            var $item = $('form input[name="' + headersArray[i] + '"], textarea[name="' + headersArray[i] + '"], select[name="' + headersArray[i] + '"]');
            $item = ($item.length > 0) ? $item : $('input, textarea, select').eq(i);
            formElements.push($item);
        }
        return formElements;
    }

    function getHeadersArray() {
        var headersArray = [];
        $('table thead tr td').map(function () { headersArray.push($(this).text()) });
        return headersArray;
    }

    function getTdWithCurrId(id) {
        var $currentTd;
        var $tr = $('table tbody tr');
        for (var i = 0; i < $tr.size() ; i++) {
            var $td = $('td', $tr.eq(i));
            var tdText = $td.eq(0).text().trim();
            if (tdText == id) {
                $currentTd = $td;
                break;
            }
        }
        return $currentTd;
    }
});