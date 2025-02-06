function IsTokenNotExist() {
    if (localStorage.getItem("accessToken") == null ||
        localStorage.getItem("expiredAt") == null ||
        localStorage.getItem("refreshToken") == null ||
        localStorage.getItem("sessionExpiredAt") == null ||
        localStorage.getItem("displayName") == null ||
        localStorage.getItem("photoUrl") == null ||
        localStorage.getItem("permissions") == null)
        return true;

    return false;
}

function RedirectToLogin() {
    localStorage.clear();

    window.location.href = '/';
}

function Logout() {
    Swal.fire({
        title: "Keluar dari aplikasi",
        html: "Apakah anda yakin ingin keluar dari aplikasi?",
        showCancelButton: true,
        confirmButtonText: "Keluar",
        confirmButtonColor: "#D92D20",
        customClass: {
            actions: 'my-actions',
            cancelButton: 'order-1 right-gap',
            confirmButton: 'order-2',
        },
        icon: "warning"
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Keluar dari aplikasi",
                html: "Anda telah berhasil keluar dari aplikasi",
                showCancelButton: false,
                confirmButtonText: "Ok",
                confirmButtonColor: "#D92D20",
                customClass: {
                    actions: 'my-actions',
                    cancelButton: 'order-1 right-gap',
                    confirmButton: 'order-2',
                },
                icon: "info"
            }).then((result) => {
                RedirectToLogin();
            })
        }
    });
}