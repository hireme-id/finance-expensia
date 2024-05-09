﻿const bgIconHistory = [
    { key: "approved", background: "bg-green", icon: "fa-check-circle" },
    { key: "waiting approval", background: "bg-yellow", icon: "fa-hourglass-start" },
    { key: "reject", background: "bg-red", icon: "fa-ban" }
];

const glbBaseRequest = {
    "timeout": 0,
    "headers": {
        "Authorization": "Bearer " + localStorage.getItem("accessToken"),
        "Content-Type": "application/json"
    },
};