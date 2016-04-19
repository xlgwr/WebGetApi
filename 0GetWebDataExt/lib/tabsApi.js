tabsURLNoClose = [
    "chrome://extensions/",
    "chrome-extension://",
    "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm",
    "http://www.judiciary.gov.hk/chs/crt_lists/daily_caulist.htm",
    "http://www.judiciary.gov.hk/tc/crt_lists/daily_caulist.htm"
]
tabs = {};
tabIds = [];

focusedWindowId = undefined;
currentWindowId = undefined;
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function(fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
function bootStrap(i, msg) {
    chrome.windows.getCurrent(function(currentWindow) {
        currentWindowId = currentWindow.id;
        chrome.windows.getLastFocused(function(focusedWindow) {
            focusedWindowId = focusedWindow.id;
            loadWindowList();
        });
        console.log(currentWindowId + ":" + i + ",Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S"));
        //console.log(tabIds);
        tabIds.forEach(function(t) {
            //console.log(t);
            if (t === i || tabsURLNoClose.indexOf(tabs[t].url) > -1 || tabs[t].url.indexOf("background.html") > -1) {
                //console.log(i + ": is ok.backID:" + tabs[t].url);
            } else {
                if (tabs[t].url.indexOf(msg) > -1) {
                    //console.log('removeTab');
                    //console.log(t + "," + tabs[t].url + "--->" + msg);
                    removeTab(t);
                }

            }
        }, this);

    });
};
function removeTabUrl(id, msg) {
    //remove id
    tabIds.forEach(function(t) {
        //console.log(t);
        if (t === id) {
            console.log(id + ": is ok removeTabUrl.backID:" + tabs[t].url);
        } else {
            if (tabs[t].url.indexOf(msg) > -1) {
                console.log('removeTabUrl ');
                console.log(t + "," + tabs[t].url + "--->" + msg);
                removeTab(t);
            }

        }
    }, this);
    loadWindowList();
}

function isInt(i) {
    return (typeof i == "number") && !(i % 1) && !isNaN(i);
};

function loadWindowList() {
    chrome.windows.getAll({ populate: true }, function(windowList) {
        tabs = {};
        tabIds = [];
        for (var i = 0; i < windowList.length; i++) {
            windowList[i].current = (windowList[i].id == currentWindowId);
            windowList[i].focused = (windowList[i].id == focusedWindowId);

            for (var j = 0; j < windowList[i].tabs.length; j++) {
                tabIds[tabIds.length] = windowList[i].tabs[j].id;
                tabs[windowList[i].tabs[j].id] = windowList[i].tabs[j];
            }
        }
    });
};
function updateTabData(id) {
    var retval = {
        url: document.getElementById('url_' + id).value,
        selected: document.getElementById('selected_' + id).value ? true : false
    }

    return retval;
};

function updateTab(id) {
    try {
        chrome.tabs.update(id, updateTabData(id));
    } catch (e) {
        console.log(e);
    }
};

function moveTabData(id) {
    return {
        'index': parseInt(document.getElementById('index_' + id).value),
        'windowId': parseInt(document.getElementById('windowId_' + id).value)
    }
}
function moveTab(id) {
    try {
        chrome.tabs.move(id, moveTabData(id));
    } catch (e) {
        console.log(e);
    }
}

function createTabData(id) {
    return {
        'index': parseInt(document.getElementById('index_' + id).value),
        'windowId': parseInt(document.getElementById('windowId_' + id).value),
        'url': document.getElementById('url_' + id).value,
        'selected': document.getElementById('selected_' + id).value ? true : false
    }
}

function createTab() {
    var args = createTabData('new')

    if (!isInt(args.windowId))
        delete args.windowId;
    if (!isInt(args.index))
        delete args.index;

    try {
        chrome.tabs.create(args);
    } catch (e) {
        console.log(e);
    }
}

function updateAll() {
    try {
        for (var i = 0; i < tabIds.length; i++) {
            chrome.tabs.update(tabIds[i], updateTabData(tabIds[i]));
        }
    } catch (e) {
        console.log(e);
    }
}

function moveAll() {
    console.log('moving all');
    try {
        for (var i = 0; i < tabIds.length; i++) {
            chrome.tabs.move(tabIds[i], moveTabData(tabIds[i]));
        }
    } catch (e) {
        console.log(e);
    }
}

function removeTab(tabId) {
    try {
        chrome.tabs.remove(tabId, function() {
            console.log('tab: ' + tabId + ' removed.');
        });
    } catch (e) {
        console.log(e);
    }
}
document.addEventListener('DOMContentLoaded', function() {
    bootStrap(1, "testme");
});

