
var currLocal = document.location.href;

var _updateWebURLTo = 'https://www.icris.cr.gov.hk/normal.html';
var _updateWebURL = 'https://www.icris.cr.gov.hk/preDown.html';

var _mainwebUrl0 = "https://www.icris.cr.gov.hk/csci/";
var _mainwebUrl1 = "http://www.icris.cr.gov.hk/csci/";

var _subWeb1Url = "https://www.icris.cr.gov.hk/csci/login_i.jsp";

var _subWeb2iguestUrl = "https://www.icris.cr.gov.hk/csci/login_i.do?loginType=iguest";
var _logout_warnUrl = 'https://www.icris.cr.gov.hk/csci/logout_warn.jsp';

var _CBDS_SearchUrl = "https://www.icris.cr.gov.hk/csci/CBDS_Search.do";
// for 0for_icris***********************************************
//终审及高等法院,所有裁判法院,勞資審裁處,小额钱债审裁处
var _1for_judiciaryUrl = "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm";
//上诉记录,//判案书//判刑理由//裁决理由
var _2for_legalref = "http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=";//DIS=000001

$(function () {
    //绿色安全
    //http://121.15.207.49:3006/
    if (currLocal.indexOf("121.15.207.49:3006") > -1) {
        console.clear();
        console.log("绿色安全");
        $.ajax({
            type: "POST",
            url: "http://121.15.207.49:3006/Intercept/GoOnVist",
            data: { FilterType: "" + $("#hid_filtertype").attr("value") + "", UserId: "" + $("#hid_userid").attr("value") + "", Urlpath: "" + $("#hid_urlpath").attr("value") + "", Logid: "" + $("#hid_logid").attr("value") + "", Password: '88888888' },
            success: function (data, textStatus) {
                console.log(this.data);
                if (data[0].code != 0)
                    console.log(data[0].msg)
                else {
                    window.location.href = data[0].msg;
                    window.event.returnValue = false;
                }
            },
            error: function (e) {
                console.log(e)
            }
        });
    }
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
    if (currLocal.indexOf(_subWeb2iguestUrl) > -1) {
        console.log("_subWeb2iguestUrl");
        sendMsg('openURLForICRIS', "openURLForICRIS.");
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
        j1_PostAll(getEnURL);

    }
    if (currLocal.indexOf(_2for_legalref) > -1) {
        console.log("_2for_legalref");
        legalref();
        var s3_legalref = window.setInterval(console.clear, 10 * 1000);
    }
    //console.log("no Listen:" + currLocal);
});





