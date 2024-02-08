var WC = window.chrome.webview.hostObjects.WallpaperClass;

window.onload = async function show() {
    var date = new Date();
    var chine2 = new Array(" Sunday", " Monday", "Tuesday", "Wednesday", "Thursday", " Friday", "Saturday");
    var chine3 = new Array("J A N", "F E B", "M A R", "A P R", "M A Y", "J U N", "J U L", "A U G", "S E P", "O C T", "N O V", "D E C");
    var month = date.getMonth();
    var date1 = date.getDate();
    var day = date.getDay();
    var hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    document.getElementById("timeHours").innerHTML = hour;
    document.getElementById("timeMinute").innerHTML = minute;
    document.getElementById("dataWeek").innerHTML = chine2[day];
    document.getElementById("dataData").innerHTML = chine3[month] + "&nbsp&nbsp.&nbsp&nbsp" + date1;
    //
    document.getElementById("cpu").innerText = await WC.W_CpuUsage() + "%";
    document.getElementById("ram").innerText = await WC.W_RamUsage() + "%";
    setTimeout(show, 1000);
    return "";
}

function showOrHide() {
    var x = document.getElementById("dockPage");
    if (x.style.visibility == "hidden") {
        x.style.visibility = "visible";
    } else {
        x.style.visibility = "hidden";
    }
}

var docEl = document.documentElement;
function setRemUnit() {
    var rem = docEl.clientWidth / 19.2;
    docEl.style.fontSize = rem + 'px'
}
setRemUnit()
window.addEventListener('resize', setRemUnit)
window.addEventListener('pageshow', function (e) {
    if (e.persisted) {
        setRemUnit()
    }
})