function fmtDate(originalDate) {
    var date = new Date(originalDate);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();

    const newdate = `${day}/${month}/${year}`;

    return newdate;
}

function fmtDate2(originalDate) {
    var date = new Date(originalDate);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();

    const newdate = `${year}-${month}-${day}`;

    return newdate;
}

function fmtDate3(originalDate) {
    var date = new Date(originalDate);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    const hour = date.getHours().toString().padStart(2, '0');
    const minute = date.getMinutes().toString().padStart(2, '0');

    const newdate = `${day}/${month}/${year} ${hour}:${minute}`;

    return newdate;
}

function fmtDate4(originalDate) {
    let listMonth = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    var date = new Date(originalDate);
    const day = date.getDate().toString().padStart(2, '0');
    const month = listMonth[date.getMonth()];
    const year = date.getFullYear();

    const newdate = `${day} ${month} ${year}`;

    return newdate;
}