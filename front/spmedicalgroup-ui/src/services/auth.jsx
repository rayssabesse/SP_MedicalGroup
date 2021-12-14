export const userAuth = () => localStorage.getItem("user-login") != null;

export const parseJWT = () => {
    let base64 = localStorage.getItem("user-login").split(".")[1];
    return JSON.parse(window.atob(base64));
}