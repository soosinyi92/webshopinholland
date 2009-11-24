var ws = new Object();

ws.vervion = '1.0';
ws.isIE = false;
ws.navigationOn = false;

ws.dg = function(id) {
    return document.getElementById(id);
};

ws.dt = function(tag) {
    return document.getElementsByTagName(tag);
}

ws.dc = function(oElm, strTagName, strClassName){
	var arrElements = (strTagName == "*" && oElm.all)? oElm.all : oElm.getElementsByTagName(strTagName);
	var arrReturnElements = new Array();
	strClassName = strClassName.replace(/\-/g, "\\-");
	var oRegExp = new RegExp("(^|\\s)" + strClassName + "(\\s|$)");
	var oElement;
	for(var i=0; i<arrElements.length; i++){
		oElement = arrElements[i];
		if(oRegExp.test(oElement.className)){
			arrReturnElements.push(oElement);
		}
	}
	return (arrReturnElements)
};

ws.addEvent = function(el, action, func) {
    if (el.addEventListener) {
        el.addEventListener(action, func, false);
    } else if (el.attachEvent) {
        el.attachEvent('on' + action, func);
    }
};

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
        var posX = e.pageX ? e.pageX : e.offsetX;
        var posY = e.pageY ? e.pageY : e.offsetY;
        var minX = loginPanel.offsetLeft;
        var minY = loginPanel.offsetTop;
        if (minX != 0 && minY != 0) {
            var maxX = minX + loginPanel.offsetWidth;
            var maxY = minY + loginPanel.offsetHeight;
            //alert(posX + ' ' + posY + '\n' + minX + ' ' + minY + '\n' + maxX + ' ' + maxY);
            if (posX < minX || posX > maxX || posY < minY || posY > maxY) {
                loginPanel.style.display = 'none';
                loginButton.setAttribute('class', '');
            }
        }
    }
}

ws.showNavigation = function() {
    if (!ws.navigationOn) {
        ws.navigationOn = true;
        var navi = ws.dg('navi');
        navi.style.paddingTop = '10px';
        navi.style.paddingRight = '10px';
        navi.style.paddingBottom = '10px';
        ws.dg('navi_caption').style.display = 'none';
        (function() {
            if (ws.navigationOn) {
                if (parseInt(ws.dg('navi').style.left.replace('px', '')) != 0) {
                    navi.style.left = (parseInt(ws.dg('navi').style.left.replace('px', '')) + 5) + 'px';
                    setTimeout(arguments.callee, 10);
                }
            }
        })();
    }
};

ws.hideNavigation = function(e) {
    if (ws.navigationOn && e.target != ws.dg('navi_caption')) {
        var navi = ws.dg('navi');
        var posX = e.pageX ? e.pageX : e.offsetX;
        var posY = e.pageY ? e.pageY : e.offsetY;
        var minX = navi.offsetLeft;
        var minY = navi.offsetTop;
        if (minX != undefined && minY != undefined) {
            var maxX = minX + navi.offsetWidth;
            var maxY = minY + navi.offsetHeight;
            if (posX < minX || posX > maxX || posY < minY || posY > maxY) {
                ws.navigationOn = false;
                (function() {
                    if (!ws.navigationOn) {
                        var navi = ws.dg('navi');
                        var left = -195;
                        if (navi.offsetWidth <= 130) left = -100;
                        if (parseInt(navi.style.left.replace('px', '')) > left) {
                            navi.style.left = (parseInt(ws.dg('navi').style.left.replace('px', '')) - 5) + 'px';
                            setTimeout(arguments.callee, 10);
                        } else {
                            navi.style.padding = 0;
                            ws.dg('navi_caption').style.display = 'block';
                        }
                    }
                })();
            }
        }
    }
};

ws.windowClick = function(e) {
    if(ws.dg('login'))
        ws.hideLoginPanel(e);
    ws.hideNavigation(e);
};

ws.showUpdate = function(e) {

};

ws.init = function() {
    // initialize navi menu position
    var navi = ws.dg('navi');
    if (navi) {
        navi.style.left = '-195px';
    }
    // attach all event listener
    var loginButton = ws.dg('login');
    if (loginButton)
        ws.addEvent(loginButton, 'click', ws.showLoginPanel);
    ws.addEvent(document, 'click', ws.windowClick);
    ws.addEvent(ws.dg('navi_caption'), 'click', ws.showNavigation);
    var shoppingcart = ws.dg('shoppingcart');
    
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