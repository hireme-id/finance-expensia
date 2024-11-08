function fmtMoney(angka) {
    return new Number(angka).toLocaleString('id-ID', {
        style: 'decimal',
        minimumFractionDigits: 0,
        maximumFractionDigits: 0
    });
}

function revertFmtMoney(formattedString) {
    return Number(formattedString.replace(/\./g, '').replace(',', '.'));
}