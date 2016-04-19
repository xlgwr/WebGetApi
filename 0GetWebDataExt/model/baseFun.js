function padLeft(str, lenght) {
    if (str.length >= lenght)
        return str;
    else
        return padLeft("0" + str, lenght);
}
function padRight(str, lenght) {
    if (str.length >= lenght)
        return str;
    else
        return padRight(str + "0", lenght);
}
function SetCookie(name, value, exdays, path) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    document.cookie = name + "=" + encodeURIComponent(value) + ";expires=" + d.toGMTString() + ";path=" + path;
    return true;
};
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return (decodeURI(r[2])); return null;
}