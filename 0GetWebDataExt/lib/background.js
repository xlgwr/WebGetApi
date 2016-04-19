// chrome.runtime.sendMessage({greeting: "hello"}, function(response) {
//     console.log(response.farewell);
// });

var $ttype = "icrisCRNo";
var $runTnter = 3 * 60 * 1000;
var $jsonDate = Date.now();
var _clickOne = false;
var _paramvalue_1evenyDataGet = "04:30";
var _getm_parameter = [];
//1.终审及高等法院
var _paramkey_1 = 'evenyDataGet';
var _postOK_1 = true;

chrome.runtime.onMessage.addListener(
    function(request, sender, sendResponse) {
        var tmpid = sender.tab.id;
        //console.log(request);
        //console.log(tmpid);
        //console.log(sender.tab ?
        // "from a content script:" + sender.tab.url :
        // "from the extension");
        if (request.greeting == "hello") {
            bootStrap(tmpid, request.msg);
            sendResponse({ farewell: "goodbye" });
        }
        if (request.greeting == "removeUrl") {
            removeTabUrl(tmpid, request.msg);
            sendResponse({ farewell: "goodbye Url" });
        }
        if (request.greeting == "jsonDate") {
            $jsonDate = Date.now();
            sendResponse({ farewell: "jsonDate set now" });
        }
        if (request.greeting == "postOK") {
            _postOK_1 = false;
            sendResponse({ farewell: "postOK set false" });
        }
    });

chrome.browserAction.onClicked.addListener(function(tab) {
    chrome.tabs.create({ url: chrome.extension.getURL("popup.html") });
});

function openURLjudiciary() {
    try {
        var tmpCurrDate = new Date();
        var tmpGethour = tmpCurrDate.getHours();
        var tmpGetMin = tmpCurrDate.getMinutes();

        var tmpRunHour = 4;
        var tmpRunMin = 30;
        if (_paramvalue_1evenyDataGet.indexOf(':') > 0) {
            tmpRunHour = Number(_paramvalue_1evenyDataGet.split(':')[0]);
            tmpRunMin = Number(_paramvalue_1evenyDataGet.split(':')[1]);
        }

        console.log("Start Time:" + _paramvalue_1evenyDataGet + ",Date:" + tmpCurrDate + ",Hours:" + tmpGethour + ",Min:" + tmpGetMin + ",RunHours:" + tmpRunHour + ",RunMin:" + tmpRunMin);

        if (tmpGethour === tmpRunHour && (tmpGetMin === tmpRunMin || tmpRunMin + 1 == tmpGetMin)) {
            chrome.tabs.create({ url: "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm" });
        } else {
            if (!_postOK_1) {
                _postOK_1 = true;
                chrome.tabs.create({ url: "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm" });
            } else {
                console.log("now is no Run Time.");
            }
        }



    } catch (error) {
        console.log(error);
    }

}

function openURL() {
    console.clear();
    console.log("RunInterval Check:" + $runTnter / (60 * 1000) + " Min,Restart url: https://www.icris.cr.gov.hk/csci/  Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S"));
    var $nowDate = Date.now();
    if ($nowDate - $jsonDate >= (1 * 60 * 1000)) {
        console.log("Json Post is Over,Open new Windows。Now:" + $nowDate + ",JsonDate:" + $jsonDate + ",Diff:" + ($nowDate - $jsonDate) / (60 * 1000) + " Min");
        chrome.tabs.create({ url: "https://www.icris.cr.gov.hk/csci/" });
    } else {
        console.log("Json Post is Run。Now:" + $nowDate + ",JsonDate:" + $jsonDate + ",Diff:" + ($nowDate - $jsonDate) / (60 * 1000) + " Min");
    }

}
function getParameter() {
    ////获取参数
    console.log("获取参数");
    $.ajax({
        type: 'GET',
        timeout: 10000,
        url: config.urlApim_parameter
    }).done(function(data) {

        _getm_parameter = data;
        //console.log(data);

        _getm_parameter.forEach(function(d) {
            if (d["paramkey"] === _paramkey_1) {
                console.log(d["paramkey"] + ":" + d["paramvalue"])
                _paramvalue_1evenyDataGet = d["paramvalue"];
            }
        }, this);

    }).fail(function(err) {
        console.log(err);
        //alert("获取参数失败。");
    });
}
//must be jquery
$(function() {
    //每5秒检查一次参数
    var sgetParameter = window.setInterval(getParameter, 1 * 5 * 1000);
    //法庭数据-审查案件表
    chrome.tabs.create({ url: "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm" });
    //每30秒检查一次
    var sjudiciary = window.setInterval(openURLjudiciary, 1 * 30 * 1000);
    //for 公司注册处
    chrome.tabs.create({ url: config.urlApi_GetWebDatasMaxName + $ttype });
    chrome.tabs.create({ url: "https://www.icris.cr.gov.hk/csci/" });

    var s4 = window.setInterval(openURL, $runTnter);
});