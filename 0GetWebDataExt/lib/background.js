// chrome.runtime.sendMessage({greeting: "hello"}, function(response) {
//     console.log(response.farewell);
// });
// User-Agent: Fiddler
// Content-Type: application/json; charset=utf-8  
// Content-Length: 1696
// Host: 192.168.1.136:8081

var $ttype = "icrisCRNo";
var $runTnter = 3 * 60 * 1000;
var $jsonDate = Date.now();
var $jsonDate2_legalref = Date.now();
var _clickOne = false;
var _paramvalue_1evenyDataGet = "04:30";
var _getm_parameter = [];
//1.终审及高等法院
var _paramkey_1 = 'evenyDataGet';
var _postOK_1 = true;
var _postOK_2_legalref = true;

chrome.runtime.onMessage.addListener(
    function (request, sender, sendResponse) {
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
        //openURLForICRIS
        if (request.greeting == "openURLForICRIS") {                            
            removeTabUrl(tmpid, request.msg);
            openURLForICRIS("icrisCRNo");        
        }
        ///Post OK
        if (request.greeting == "jsonDate") {
            $jsonDate = Date.now();
            sendResponse({ farewell: "jsonDate set now" });
        }
        if (request.greeting == "jsonDate2_legalref") {
            $jsonDate2_legalref = Date.now();
            sendResponse({ farewell: "jsonDate2_legalref set now" });
        }
        //Post fail
        if (request.greeting == "postOK") {
            _postOK_1 = false;
            sendResponse({ farewell: "postOK set false" });
        }
        if (request.greeting == "postOK2legalref") {
            _postOK_2_legalref = false;
            sendResponse({ farewell: "postOK_2_legalref set false" });
        }
    });

chrome.browserAction.onClicked.addListener(function (tab) {
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
    }).done(function (data) {

        _getm_parameter = data;
        //console.log(data);

        _getm_parameter.forEach(function (d) {
            if (d["paramkey"] === _paramkey_1) {
                console.log(d["paramkey"] + ":" + d["paramvalue"])
                _paramvalue_1evenyDataGet = d["paramvalue"];
            }
        }, this);

    }).fail(function (err) {
        console.log(err);
        //alert("获取参数失败。");
    });
}
function openURLForICRIS(ttype) {

    $.ajax({
        type: 'GET',
        url: config.urlApi_GetWebDatasMaxName + ttype,
        timeout: 10000
    }).done(function (data) {
        console.log(data);
        var tmpUrl = 'https://www.icris.cr.gov.hk/csci/CBDS_Search.do?nextAction=CBDS_Search&CRNo=' + data + '&showMedium=true&showBack=true&searchPage=True';
        chrome.tabs.create({ url: tmpUrl });
        console.log(tmpUrl);
    }).fail(function (err) {
        //showError
        var tmpUrl = 'https://www.icris.cr.gov.hk/csci/CBDS_Search.do?nextAction=CBDS_Search&CRNo=0000000&showMedium=true&showBack=true&searchPage=True';
        chrome.tabs.create({ url: tmpUrl });
        console.log(tmpUrl);
    });
}
//上诉记录
function GetWebDatasMaxTDisToOpen() {
    ////获取上诉记录,最大一记录
    console.log("上诉记录,每30秒检查一次:" + _postOK_2_legalref);
    if (!_postOK_2_legalref) {
        _postOK_2_legalref = true;
        $.ajax({
            type: 'GET',
            timeout: 10000,
            url: config.urlApi_GetWebDatasMaxTDis
        }).done(function (data) {

            var tmpUrl = config.urlRedict_legalrefMain + data
            chrome.tabs.create({ url: tmpUrl });
            console.log(tmpUrl);

        }).fail(function (err) {
            var tmpUrl = config.urlRedict_legalrefMain + "1"
            chrome.tabs.create({ url: tmpUrl });
            console.log(tmpUrl);
            console.log(err);
            //alert("上诉记录失败。");
        });
    }
    var $nowDate2 = Date.now();
    if ($nowDate2 - $jsonDate2_legalref >= (1 * 60 * 1000)) {
        console.log("2legalref Json Post is Over,Open new Windows。Now:" + $nowDate2 + ",JsonDate:" + $jsonDate2_legalref + ",Diff:" + ($nowDate2 - $jsonDate2_legalref) / (60 * 1000) + " Min");
        $.ajax({
            type: 'GET',
            timeout: 10000,
            url: config.urlApi_GetWebDatasMaxTDis
        }).done(function (data) {

            var tmpUrl = config.urlRedict_legalrefMain + data
            chrome.tabs.create({ url: tmpUrl });
            console.log(tmpUrl);

        }).fail(function (err) {
            var tmpUrl = config.urlRedict_legalrefMain + "1"
            chrome.tabs.create({ url: tmpUrl });
            console.log(tmpUrl);
            console.log(err);
            //alert("上诉记录失败。");
        });
    } else {
        console.log("2legalref Json Post is Run。Now:" + $nowDate2 + ",JsonDate:" + $jsonDate2_legalref + ",Diff:" + ($nowDate2 - $jsonDate2_legalref) / (60 * 1000) + " Min");
    }

}
//must be jquery
$(function () {
    //////////////////////////////1111111111111111111111111111111    
    //法庭数据
    //每5秒检查一次参数
    var sgetParameter = window.setInterval(getParameter, 1 * 5 * 1000);
    //法庭数据-审查案件表
    chrome.tabs.create({ url: "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm" });
    //每30秒检查一次
    var sjudiciary = window.setInterval(openURLjudiciary, 1 * 30 * 1000);

    ///////////////////////////////3333333333333333333333333333333333333
    //上诉记录
    _postOK_2_legalref = false;
    GetWebDatasMaxTDisToOpen();
    //每30秒检查一次
    var sjudiciary = window.setInterval(GetWebDatasMaxTDisToOpen, 1 * 30 * 1000);

    //////////////////////////////2222222222222222222222222222222222    
    //公司注册处
    chrome.tabs.create({ url: config.urlApi_GetWebDatasMaxName + $ttype });
    chrome.tabs.create({ url: "https://www.icris.cr.gov.hk/csci/" });
    var s4 = window.setInterval(openURL, $runTnter);

    ///////////////////////////////3333333333333333333333333333333333333


});