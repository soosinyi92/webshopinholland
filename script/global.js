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

ws.showLoginPanel = function (e) {
    var loginButton = ws.dg('login');
    var loginPanel = ws.dg('login_panel');
    loginPanel.style.display = 'block';
    loginButton.setAttribute('class', 'open');
    if (typeof e.preventDefault != 'undefined') {
        e.preventDefault(); // W3C 
    } else {
        e.returnValue = false; // IE 
    }
};

ws.hideLoginPanel = function (e) {
    var loginButton = ws.dg('login');
    var loginSpan = loginButton.childNodes[1];
    var target = e.target ? e.target : e.srcElement;
    if (target != loginButton && target != loginSpan && target.innerHTML != '<SPAN>Login</SPAN>' && target.innerHTML != 'Login') {
        var loginPanel = ws.dg('login_panel');
        var posX = e.pageX ? e.pageX : e.offsetX;
        var posY = e.pageY ? e.pageY : e.offsetY;
        if (ws.isIE) {
            posX = e.clientX + document.body.scrollLeft;
            posY = e.clientY + document.body.scrollTop;
        }
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

ws.hideNavigation = function (e) {
    var target = e.target ? e.target : e.srcElement;
    if (ws.navigationOn && target != ws.dg('navi_caption')) {
        var navi = ws.dg('navi');
        var posX = e.pageX ? e.pageX : e.offsetX;
        var posY = e.pageY ? e.pageY : e.offsetY;
        if (ws.isIE) {
            posX = e.clientX + document.body.scrollLeft;
            posY = e.clientY + document.body.scrollTop;
        }
        var minX = navi.offsetLeft;
        var minY = navi.offsetTop;
        if (minX != undefined && minY != undefined) {
            var maxX = minX + navi.offsetWidth;
            var maxY = minY + navi.offsetHeight;
            if (posX < minX || posX > maxX || posY < minY || posY > maxY) {
                ws.navigationOn = false;
                (function () {
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
    var target = e.target ? e.target : e.srcElement;
    target.style.display = 'none';
    target.parentNode.childNodes[3].style.display = 'block';
    target.parentNode.childNodes[3].focus();
    target.parentNode.parentNode.childNodes[9].childNodes[1].style.display = 'inline-block';
};

ws.hideUpdate = function(e) {
    var target = e.target ? e.target : e.srcElement;
    ws.dg('shoppingcartwrap').childNodes[3].value = target.value;
    target.style.display = 'none';
    target.parentNode.childNodes[1].style.display = 'block';
    setTimeout('ws.dg(\'' + target.parentNode.parentNode.childNodes[9].childNodes[1].id + '\').style.display = \'none\';', 200);
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
    if (shoppingcart) {
        var labels = ws.dc(shoppingcart, 'SPAN', 'quantity_label');
        var length = labels.length;
        for(var i = 0; i < length; i ++) {
            ws.addEvent(labels[i], 'click', ws.showUpdate);
        }
        var boxes = ws.dc(shoppingcart, 'INPUT', 'quantity_box');
        length = boxes.length;
        for(var i = 0; i < length; i ++) {
            ws.addEvent(boxes[i], 'blur', ws.hideUpdate);
        }
    }
};

var imgs = new Array();
var currImg = 0;
ws.getImages = function() {
    var album = ws.dg('album');
    var count = 0;
    if (album) {
        var nodes = album.childNodes;
        for(var i = 0; i < nodes.length; i ++) {
            
            if (nodes[i] && nodes[i].tagName && nodes[i].tagName == 'IMG') {
                count++;
                imgs[imgs.length] = nodes[i];
                if (count > 1) {
                    
                    nodes[i].style.display = 'none';
                }
            }
        }
        if (imgs.length > 1) {
            var buttons = document.createElement('div');
            buttons.style.width = '100%';
            buttons.style.textAlign = 'center';
            buttons.innerHTML = '<a href="#" onclick="ws.prevImg();return false;">&lt;</a>&nbsp;&nbsp;<a href="#" onclick="ws.nextImg();return false;">&gt;</a>';
            album.appendChild(buttons);
        }
    }
    
};

ws.nextImg = function() {
    if (currImg < imgs.length - 1) {
        imgs[currImg].style.display = 'none';
        currImg++;
        imgs[currImg].style.display = 'block';
    }
};

ws.prevImg = function() {
    if (currImg > 0) {
        imgs[currImg].style.display = 'none';
        currImg--;
        imgs[currImg].style.display = 'block';
    }
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