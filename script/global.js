var ws = new Object();

ws.vervion = '1.0';
ws.isIE = false;

ws.dg = function(id) {
    return document.getElementById(id);
};

ws.dt = function(tag) {
    return document.getElementsByTagName(tag);
}

ws.checkBrowserType = function() {
    var browser = navigator.appName;
    if (browser == 'Microsoft Internet Explorer') ws.isIE = true;
};

ws.showLoginPanel = function() {
    var loginButton = ws.dg('login');
    var loginPanel = ws.dg('login_panel');
    loginPanel.style.display = 'block';
    loginButton.setAttribute('class', 'open');
    return false;
};

ws.hideLoginPanel = function(e) {
    var loginButton = ws.dg('login');
    var loginSpan = loginButton.childNodes[1];
    if (e.target != loginButton && e.target != loginSpan) {
        var loginPanel = ws.dg('login_panel');
        var posX = e.offsetX ? e.offsetX : e.pageX;
        var posY = e.offsetY ? e.offsetY : e.pageY;
        var minX = loginPanel.offsetLeft;
        var minY = loginPanel.offsetTop;
        if (minX != 0 && minY != 0) {
            var maxX = minX + loginPanel.offsetWidth;
            var maxY = minY + loginPanel.offsetHeight;
            if (posX < minX || posX > maxX || posY < minY || posY > maxY) {
                loginPanel.style.display = 'none';
                loginButton.setAttribute('class', '');
            }
        }
    }
}

ws.addEvent = function(el, action, func) {
    if (el.addEventListener){
        el.addEventListener(action, func, false);
    } else if (el.attachEvent){
        el.attachEvent('on'+action, func);
    }
};

ws.init = function() {
    // attach all event listener
    var loginButton = ws.dg('login');
    ws.addEvent(loginButton, 'click', ws.showLoginPanel);
    ws.addEvent(window, 'click', ws.hideLoginPanel);
};

ws.checkBrowserType();
if (window.onload != undefined) {
    var func = window.onload;
    window.onload = function() { 
        func();
        ws.init();
    };
} else {
    window.onload = ws.init;
}