function fmtMoney(angka) {
    return new Number(angka).toLocaleString('id-ID', {
        style: 'decimal',
        minimumFractionDigits: 0,
        maximumFractionDigits: 0
    });
}