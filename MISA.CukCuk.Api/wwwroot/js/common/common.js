
/**----------------------------------
 * Hàm định dạng ngày tháng
 * @param {any} date
 * CREATEBY : Duong(4/1/2021)
 */

function formatDate(date) {
    var date = new Date(date);
    if (date.getTime() == NaN) {
        return "";
    } else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;
        return year + '-' + month + '-' + day;
    } 
}

/**------------------------------------------
 * Hàm định dang ngày tháng dành cho dữ liệu hiển thị
 * @param {any} money
 */
function formatDateDisplay(date) {
    var date = new Date(date);
    if (date.getTime() == NaN) {
        return "";
    } else {
        var day = date.getDate(),
            month = date.getMonth() + 1;
        year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;
        return day + '/' + month + '/' + year;
    }
}


/**--------------------------------
 * Hàm định dạng tiền tệ
 * @param {any} money
 * CREATEBY : Duong (4/1/2021)
 */
function formatMoney(money) {
    if (money == null) {
        return "";
    }
    else {
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        return num;
    }
}