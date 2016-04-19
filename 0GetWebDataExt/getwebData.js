
var currLocal = document.location.href;

var _updateWebURLTo = 'https://www.icris.cr.gov.hk/normal.html';
var _updateWebURL = 'https://www.icris.cr.gov.hk/preDown.html';

var _mainwebUrl0 = "https://www.icris.cr.gov.hk/csci/";
var _mainwebUrl1 = "http://www.icris.cr.gov.hk/csci/";

var _subWeb1Url = "https://www.icris.cr.gov.hk/csci/login_i.jsp";

var _subWeb2iguestUrl = "https://www.icris.cr.gov.hk/csci/login_i.do?loginType=iguest&username=iguest";
var _logout_warnUrl = 'https://www.icris.cr.gov.hk/csci/logout_warn.jsp';

var _CBDS_SearchUrl = "https://www.icris.cr.gov.hk/csci/CBDS_Search.do";
// for 0for_icris***********************************************

var _1for_judiciaryUrl = "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm";

$(function () {
    ///********************************************************
    ///********************************************************
    ///      https://www.icris.cr.gov.hk   公司注册处       ///
    ///********************************************************
    ///********************************************************    
    if (currLocal.indexOf(config.urlApi_GetWebDatasMaxName) > -1) {
        console.log("config.urlApi_GetWebDatasMaxName");
        sendMsg("removeUrl", config.urlApi_GetWebDatasMaxName);
    }
    if (currLocal === _updateWebURL) {
        console.log("_updateWebURL");
        window.open(_updateWebURLTo);
    }
    if (currLocal === _mainwebUrl0 || currLocal === _mainwebUrl1) {
        console.log("MainWeb");
        loginIguest("i");
    }
    if (currLocal === _subWeb1Url) {
        console.log("subWeb1");
        subWeb1();
    }
    if (currLocal === _subWeb2iguestUrl) {
        console.log("_subWeb2iguestUrl");
        subWeb2_CBDS_Search(config.urlApi_GetWebDatasMaxName, $ttype);
    }
    if (currLocal === _logout_warnUrl) {
        console.log("_logout_warnUrl");
        subWeb2_logout_warn();
    }
    if (currLocal.indexOf(_CBDS_SearchUrl) > -1) {
        console.log("_CBDS_SearchUrl");
        PostData();
        var s3 = window.setInterval(console.clear, 10 * 60 * 1000);
    }
    if (currLocal === _1for_judiciaryUrl) {
        console.log("_1for_judiciaryUrl");
        var getEnURL = j1_gotoListGetAllURLNow(_arrcrtkey, "MainCourtCal", true);
        //var getZhURL = j1_gotoListGetAllURL("cacfi", "MainCourtCal", false);
        //console.log(getEnURL);
        //console.log(getZhURL);
        j1_PostAll(getEnURL);

    }
    //console.log("no Listen:" + currLocal);
});





