//Post Type
var $PostType1for_judiciary = "1for_judiciary";
// all Define
var _arrcrtkey = [
    "cacfi",
    //"hcmc",
    //"mcl",
    "ct",
    "lands",
    "dc",
    "dcmc",
    //"fmc"
];
var _haxCrtKey = {

};
var _haxCrtKeyID = {

};
//http://www.judiciary.gov.hk/en/crt_lists/lists/14042016/cacfi.html
function getListURL(key, day, eng) {
    var urlforward = '';
    if (window.location.href.indexOf('test') >= 0) {
        urlforward = "http" + ":" + "/" + "/" + "www0.judiciary.gov.hk";
    } else if (window.location.href.indexOf('www0') >= 0) {
        urlforward = "http" + ":" + "/" + "/" + "www0.judiciary.gov.hk";
    } else {
        urlforward = "http" + ":" + "/" + "/" + "www.judiciary.gov.hk";
    }
    if (key == "wtnmag") {
        return urlforward + "/en/crt_lists/lists/" + day + '/' + "allmag" + ".html";
    }
    else {
        return urlforward + "/en/crt_lists/lists/" + day + '/' + key + ".html";
    }

}
function listdaykey(day) {
    var r = '';
    r += ((day.getDate() < 10) ? '0' : '') + day.getDate();
    r += (((day.getMonth() + 1) < 10) ? '0' : '') + (day.getMonth() + 1);
    r += day.getFullYear();
    return r;
}
////***************
// home http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm
////***************
///("MainCourtForm", "MainCourt", "cacfi", "MainCourtCal", true) 英文
///javascript:gotoList("MainCourtForm", "MainCourt", "cacfi", "MainCourtCal", false) 中文

function j1_gotoListGetAllURL(arrCrtKey, calname, eng) {
    var allUrl = [];
    _haxCrtKey = {};
    _haxCrtKeyID = {};

    var $d = 'select[name="' + calname + '"]';
    //console.log($d);
    var $getSelect = $($d)[0];
    var calidx = $getSelect.length;
    //console.log(calidx);

    for (var i = 0; i < calidx; i++) {

        //console.log($getSelect[i]);
        var getDateText = $getSelect[i].text.split(' ')[0];
        var getSplitDate = getDateText.split('/');
        var getDate = new Date(getSplitDate[2], getSplitDate[1] - 1, getSplitDate[0], 0, 0, 0, 0);
        var getDateUrl = listdaykey(getDate);

        arrCrtKey.forEach(function (key) {
            var url = getListURL(key, getDateUrl, eng);
            allUrl.push(url);
            _haxCrtKey[url] = key;
            _haxCrtKeyID[url] = key + getDateUrl;
        }, this);
    }
    console.log(_haxCrtKeyID);
    return allUrl;
}
//取当天的
function j1_gotoListGetAllURLNow(arrCrtKey, calname, eng) {
    var allUrl = [];
    _haxCrtKey = {};
    _haxCrtKeyID = {};

    var getDate = new Date();
    var getDateUrl = listdaykey(getDate);

    arrCrtKey.forEach(function (key) {
        var url = getListURL(key, getDateUrl, eng);
        allUrl.push(url);
        _haxCrtKey[url] = key;
        _haxCrtKeyID[url] = key + getDateUrl;
    }, this);

    console.log(_haxCrtKeyID);
    return allUrl;
}
function j1_PostData_1for_judiciary(url) {
    //console.log(url);
    $.ajax({
        url: url,
        data: {},
        tmpdata: url,
        timeout: 10000,
        type: "get",
        success: function (data, state, xhr) {
            console.log(this.tmpdata);
            //console.log(data);
            var $findTable = $('<div></div>').html(data);

            var $tableAll = $findTable.find('table');
            var $tableAllDiv = $findTable.find('div').eq(0);

            console.log($tableAll.length);


            //提交到数据库
            var getWebDatas = {
                gwd_Judiciary_items: {
                    $id: "2",
                    Tid: _haxCrtKeyID[this.tmpdata],
                    SerialNo: 2,
                    CourtID: "sample string 3",
                    Judge: "sample string 4",
                    CYear: "sample string 5",
                    CourtDay: "sample string 6",
                    Hearing: "sample string 7",
                    CaseNo: "sample string 8",
                    CaseType: "sample string 9",
                    PlainTiff: "sample string 10",
                    Defendant: "sample string 11",
                    Cause: "sample string 12",
                    Nature: "sample string 13",
                    Representation: "sample string 14",
                    Remark: "sample string 15",
                    tStatus: 16,
                    addDate: undefined,
                    UpdateDate: undefined
                },
                Tid: _haxCrtKeyID[this.tmpdata],
                tname: _haxCrtKey[this.tmpdata],
                ttype: $PostType1for_judiciary,
                tcontent: this.tmpdata,
                tGetTable: $tableAllDiv.html(),
                thtml: data,
                Remark: this.tmpdata,
                tStatus: 0,
                addDate: undefined,
                UpdateDate: undefined
            }

            if ($tableAll.length < 2) {
                var tmpmsg = "当日,无资料"
                console.log(tmpmsg);
                getWebDatas.tStatus = 1;
                getWebDatas.tGetTable = tmpmsg;
                //getWebDatas.thtml = tmpmsg;
                getWebDatas.GetWebDatas_ICRIS = undefined;
            }

            //console.log(getWebDatas);
            $.ajax({
                type: 'POST',
                url: config.urlApi_judiciary,
                tmpdata: getWebDatas.tname,
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(getWebDatas)
            }).done(function (data) {
                console.log(this.tmpdata + ":Post Done!");
                //console.log(data);
            }).fail(function (err) {
                //showError
                sendMsg('postOK', "Set Date false.");
                console.log(err);
            });
        },
        error: function () {
            sendMsg('postOK', "Set Date false.");
            console.log(this.tmpdata);
            console.log("提交预定请求发生错误，稍等重试！");
        },
        dataType: "text"
    });
}
function j1_PostAll(arrurl) {
    sendMsg("removeUrl", "judiciary.gov.hk");
    arrurl.forEach(function (url) {
        j1_PostData_1for_judiciary(url);
    }, this);
}