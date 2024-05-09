function IsTokenNotExist() {
    if (localStorage.getItem("accessToken") == null ||
        localStorage.getItem("expiredAt") == null ||
        localStorage.getItem("refreshToken") == null ||
        localStorage.getItem("sessionExpiredAt") == null ||
        localStorage.getItem("displayName") == null ||
        localStorage.getItem("photoUrl") == null)
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
        if (result.isConfirmed)
            RedirectToLogin();
    });
}