//Post Type
var $PostType1for_judiciary = "1for_judiciary";
// all Define
//"hcmc",
//"mcl",
//"fmc"
var _arrcrtkey = [
    //终审及高等法院
    "cacfi",
    "ct",
    "lands",
    "dc",
    "dcmc",
    // //所有裁判法院
    "wtnmag",
    //勞資審裁處
    "lt",
    //小额钱债审裁处
    "smt"


];
var curDate = new Date();
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
    } else {
        return urlforward + "/en/crt_lists/lists/" + day + '/' + key + ".html";
    }

}

function addDate(dd, dadd) {
    a = dd.valueOf()
    a = a + dadd * 24 * 60 * 60 * 1000
    a = new Date(a)
    return a;
}

function listdaykey(day) {
    // day = addDate(day, 3);
    // if (day.getDay() === 0) {
    //     day = addDate(day, 1);
    // }
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
        timeout: 50000,
        type: "get",
        success: function (data, state, xhr) {
            console.log(this.tmpdata);
            //console.log(data);
            var $findTable = $('<div></div>').html(data);

            var $tableAll = $findTable.find('table');
            var $tableAllDiv = $findTable.find('div').eq(0);

            console.log($tableAll.length);

            var gwd_Case_items = [];

            var getWebDatas = {
                gwd_Case_items: gwd_Case_items,
                tLang: 0,
                tname: _haxCrtKey[this.tmpdata],
                ttype: $PostType1for_judiciary,
                thtml: data,
                Tid: 0,
                Remark: this.url,
                tStatus: 0,
                ClientIP: undefined,
                addDate: undefined,
                UpdateDate: undefined
            }
            //提交到数据库

            if ($tableAll.length < 2) {
                var tmpmsg = "当日,无资料"
                console.log(tmpmsg);
                getWebDatas.tStatus = 1;
                getWebDatas.tGetTable = tmpmsg;
                //getWebDatas.thtml = tmpmsg;
                getWebDatas.gwd_Case_items = undefined;
            } else {
                var tIndex = 0;
                ///*********************************************///
                switch (_haxCrtKey[this.tmpdata]) {
                    case "cacfi":
                    case "ct":
                    case "lands":
                    case "dc":
                    case "dcmc":
                        var tmpremark = "终审及高等法院:"
                        console.log(tmpremark + _haxCrtKey[this.tmpdata]);
                        //审查案件表-终审及高等法院
                        //所有表，从第4个表开始
                        var tmpStartTable = 3;
                        var tmpStartTR = 0;
                        switch (_haxCrtKey[this.tmpdata]) {
                            case "dc":
                            case "dcmc":
                                tmpStartTable = 1;
                                tmpStartTR = 1;
                                break;
                            case "lands":
                                tmpStartTable = 2;
                                tmpStartTR = 0;
                                break;
                            default:
                                tmpStartTable = 3;
                                tmpStartTR = 0;
                                break;
                        }

                        for (var r = tmpStartTable; r < ($tableAll.length - 1); r++) {
                            var $tableAllTr = $tableAll.eq(r).find('tr');
                            console.log("TR:" + $tableAllTr.length);

                            var tmpCourtID = '';
                            var tmpJudge = '';
                            var tmpCourtDay = '';
                            var tmpCaseNo = '';
                            var tmpPlainTiff = '';
                            var tmpNature = '';
                            var tmpRepresentation = '';
                            for (var t = tmpStartTR; t < $tableAllTr.length; t++) {

                                var $tmptr = $tableAllTr.eq(t);
                                var $tmptrTDall = $tmptr.find('td');

                                console.log($tmptrTDall.length);

                                if (tmpCourtID == "Court" || $tmptrTDall.length < 7 || ($tmptrTDall.eq(4).text().trim().length < 7 && $tmptrTDall.eq(0).text().trim().length < 7)) {
                                    console.log("td<7,td4:" + $tmptrTDall.eq(4).text().trim().length + $tmptrTDall.eq(0).text().trim().length);
                                    //console.log($tmptr.text());
                                    continue;
                                }
                                tmpCourtID = getContenTD($tmptrTDall.eq(0), tmpCourtID, 2);
                                tmpJudge = getContenTD($tmptrTDall.eq(1), tmpJudge, 2);
                                tmpCourtDay = getContenTD($tmptrTDall.eq(2), tmpCourtDay, 2);
                                tmpCaseNo = getContenTD($tmptrTDall.eq(3), tmpCaseNo, 2);
                                tmpPlainTiff = getContenTD($tmptrTDall.eq(4), tmpPlainTiff, 2);
                                tmpNature = getContenTD($tmptrTDall.eq(5), tmpNature, 2);
                                tmpRepresentation = getContenTD($tmptrTDall.eq(6), tmpRepresentation, 2);

                                if (!tmpCaseNo) continue;
                                if (tmpCaseNo.indexOf('/') < 0) continue;


                                tIndex++;
                                var tmpItem = {
                                    $id: tIndex,
                                    htmlID: 0,
                                    Tid: 0,
                                    tLang: 0,
                                    tkeyNo: _haxCrtKeyID[this.tmpdata],
                                    tIndex: tIndex,
                                    tname: _haxCrtKey[this.tmpdata],
                                    ttype: $PostType1for_judiciary,
                                    SerialNo: tIndex,
                                    CourtID: tmpCourtID,
                                    Judge: tmpJudge,
                                    CYear: curDate.getFullYear(),
                                    CourtDay: tmpCourtDay,
                                    Hearing: undefined,
                                    CaseNo: tmpCaseNo,
                                    CaseType: undefined,
                                    PlainTiff: tmpPlainTiff,
                                    Defendant: undefined,
                                    Cause: undefined, //$tmptrTDall.eq(5).text(),
                                    Nature: tmpNature,
                                    Representation: tmpRepresentation,
                                    Remark: tmpremark + _haxCrtKey[this.tmpdata],
                                    tStatus: 0,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }
                                gwd_Case_items.push(tmpItem);
                                //console.log($tableAllTr.eq(t).html());
                            }
                        }
                        //showall    
                        break;
                    case "wtnmag":
                        var tmpremark = "所有裁判法院:";
                        console.log(tmpremark + _haxCrtKey[this.tmpdata]);
                        //all mag
                        var $allDivCenter = $tableAllDiv.find('div[class="MsoNormal"]')
                        console.log(_haxCrtKey[this.tmpdata] + ",Div:" + $allDivCenter.length);
                        console.log($allDivCenter);
                        //////////////////////////////////////////////////////////////////////////
                        //div 前两个表
                        console.log("前面三个表")

                        var $tdPreAll = $tableAllDiv.find('td[width="34%"]');

                        console.log($tdPreAll.length);
                        for (var d = 0; d < $tdPreAll.length; d++) {
                            if (d % 2 === 0) {
                                // console.log(d);
                                var $currPartd = $tdPreAll.eq(d);
                                var $currParTable = $currPartd.parents("table").eq(0);
                                // console.log($currParTable.find('tr').eq(0).text());

                                var $curNextTable = $currParTable.nextAll('table');

                                // console.log($curNextTable.length);
                                //首表两行3列
                                var $next1table = $curNextTable.eq(1);
                                var $next1tableTR = $next1table.find('tr');
                                //尾表N行5列
                                var $next2table = $curNextTable.eq(3);
                                var $next2tableTR = $next2table.find('tr');
                                // console.log($next1table.find('tr').eq(0).text());
                                // console.log($next2table.find('tr').eq(0).text());

                                var _tmpCourtID = getContenP($next1tableTR.eq(0).find('td').eq(2), "", 1, 1);
                                var _Judge = getContenP($next1tableTR.eq(1).find('td').eq(2), "", 1, 1);

                                var tmpCourtDay = '';
                                var tmpCaseNo = '';
                                var tmpPlainTiff = '';
                                var tmpNature = '';
                                var tmpHearing = '';

                                for (var m = 0; m <= $next2tableTR.length; m++) {
                                    var $tmptr = $next2tableTR.eq(m);
                                    var $tmptrTDall = $tmptr.find('td');

                                    //console.log($tmptrTDall.length);

                                    if (_tmpCourtID === "Court" || $tmptrTDall.length < 5 || ($tmptrTDall.eq(2).text().length <= 7 && $tmptrTDall.eq(1).text() <= 7)) {
                                        // console.log("td<5,td2:" + $tmptrTDall.eq(2).text().length);
                                        // console.log($tmptr.text());
                                        continue;
                                    }

                                    tmpCourtDay = getContenP($tmptrTDall.eq(0), tmpCourtDay, 1, 0);
                                    tmpCaseNo = getContenP($tmptrTDall.eq(1), tmpCaseNo, 1, 0);
                                    tmpPlainTiff = getContenP($tmptrTDall.eq(2), tmpPlainTiff, 1, 0);
                                    tmpNature = getContenP($tmptrTDall.eq(3), tmpNature, 1, 0);
                                    tmpHearing = getContenP($tmptrTDall.eq(4), tmpHearing, 1, 0);

                                    if (!tmpCaseNo) continue;
                                    if (tmpCaseNo.indexOf('/') < 0) continue;

                                    tIndex++;
                                    var tmpItem = {
                                        $id: tIndex,
                                        htmlID: 0,
                                        Tid: 0,
                                        tLang: 0,
                                        tkeyNo: _haxCrtKeyID[this.tmpdata],
                                        tIndex: tIndex,
                                        tname: _haxCrtKey[this.tmpdata],
                                        ttype: $PostType1for_judiciary,
                                        SerialNo: tIndex,
                                        CourtID: _tmpCourtID.replace(/[\↵\t\n\v\r]/g, ''),
                                        Judge: _Judge.replace(/[\↵\t\n\v\r]/g, ''),
                                        CYear: curDate.getFullYear(),
                                        CourtDay: tmpCourtDay,
                                        Hearing: tmpHearing,
                                        CaseNo: tmpCaseNo,
                                        CaseType: undefined,
                                        PlainTiff: tmpPlainTiff,
                                        Defendant: undefined,
                                        Cause: undefined,
                                        Nature: tmpNature,
                                        Representation: undefined,
                                        Remark: _haxCrtKey[this.tmpdata],
                                        tStatus: 1,
                                        addDate: undefined,
                                        UpdateDate: undefined
                                    }
                                    gwd_Case_items.push(tmpItem);
                                }

                            }
                        }

                        ///////////////////////////////////////////////////////////////
                        console.log("后面的表")
                        //后面的表
                        for (var x = 0; x < $allDivCenter.length; x++) {
                            var $curDivCenter = $allDivCenter.eq(x);
                            var $curNextTable = $curDivCenter.nextAll('table');
                            //console.log($curNextTable.length);
                            //首表两行3列
                            var $next1table = $curNextTable.eq(0);
                            var $next1tableTR = $next1table.find('tr');
                            //尾表N行5列
                            var $next2table = $curNextTable.eq(2);
                            var $next2tableTR = $next2table.find('tr');
                            // console.log($next1table.find('tr').eq(0).text());
                            // console.log($next2table.find('tr').eq(0).text());
                            var _tmpCourtID = getContenP($next1tableTR.eq(0).find('td').eq(2), '', 1, 1);
                            var _Judge = getContenP($next1tableTR.eq(1).find('td').eq(2), '', 1, 1);

                            var tmpCourtDay = '';
                            var tmpCaseNo = '';
                            var tmpPlainTiff = '';
                            var tmpNature = '';
                            var tmpHearing = '';

                            for (var m = 0; m <= $next2tableTR.length; m++) {
                                var $tmptr = $next2tableTR.eq(m);
                                var $tmptrTDall = $tmptr.find('td');

                                //console.log($tmptrTDall.length);

                                if (_tmpCourtID == "Court" || $tmptrTDall.length < 5 || ($tmptrTDall.eq(2).text().length <= 7 && $tmptrTDall.eq(1).text() <= 7)) {
                                    // console.log("td<5,td2:" + $tmptrTDall.eq(2).text().length);
                                    // console.log($tmptr.text());
                                    continue;
                                }


                                tmpCourtDay = getContenP($tmptrTDall.eq(0), tmpCourtDay, 1, 0);
                                tmpCaseNo = getContenP($tmptrTDall.eq(1), tmpCaseNo, 1, 0);
                                tmpPlainTiff = getContenP($tmptrTDall.eq(2), tmpPlainTiff, 1, 0);
                                tmpNature = getContenP($tmptrTDall.eq(3), tmpNature, 1, 0);
                                tmpHearing = getContenP($tmptrTDall.eq(4), tmpHearing, 1, 0);

                                if (!tmpCaseNo) continue;
                                if (tmpCaseNo.indexOf('/') < 0) continue;

                                tIndex++;
                                var tmpItem = {
                                    $id: tIndex,
                                    htmlID: 0,
                                    Tid: 0,
                                    tLang: 0,
                                    tkeyNo: _haxCrtKeyID[this.tmpdata],
                                    tIndex: tIndex,
                                    tname: _haxCrtKey[this.tmpdata],
                                    ttype: $PostType1for_judiciary,
                                    SerialNo: tIndex,
                                    CourtID: _tmpCourtID.replace(/[\↵\t\n\v\r]/g, ''),
                                    Judge: _Judge.replace(/[\↵\t\n\v\r]/g, ''),
                                    CYear: curDate.getFullYear(),
                                    CourtDay: tmpCourtDay,
                                    Hearing: tmpHearing,
                                    CaseNo: tmpCaseNo,
                                    CaseType: undefined,
                                    PlainTiff: tmpPlainTiff,
                                    Defendant: undefined,
                                    Cause: undefined,
                                    Nature: tmpNature,
                                    Representation: undefined,
                                    Remark: tmpremark + _haxCrtKey[this.tmpdata],
                                    tStatus: 0,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }
                                gwd_Case_items.push(tmpItem);
                            }
                        }
                        //end
                        //////////////////////////////////////////////////////
                        break;
                    case "lt":
                        var tmpremark = "勞資審裁處:";
                        console.log(tmpremark + _haxCrtKey[this.tmpdata]);
                        var $getAllLtDiv = $findTable.find("div[class^='WordSection']");
                        console.log($getAllLtDiv)
                        for (var x = 0; x < $getAllLtDiv.length; x++) {
                            var $currLtDiv = $getAllLtDiv.eq(x);
                            var $currLtDivTable = $currLtDiv.find('table');
                            if ($currLtDivTable.length < 2) {
                                continue;
                            }
                            var $currLtDivTable1 = $currLtDivTable.eq(0);
                            var $currLtDivTable1TR = $currLtDivTable1.find('tr');

                            var $currLtDivTable2 = $currLtDivTable.eq(1);
                            var $currLtDivTable2TR = $currLtDivTable2.find('tr');

                            var _tmpCourtID = $currLtDivTable1TR.eq(0).find('td').eq(0).text().trim();
                            var _Judge = $currLtDivTable2TR.eq(0).find('td').eq(0).text().trim();

                            var tmpCourtDay = '';
                            var tmpCaseNo = '';
                            var tmpPlainTiff = '';
                            //从第三行开始
                            for (var m = 3; m <= $currLtDivTable2TR.length; m++) {
                                var $tmptr = $currLtDivTable2TR.eq(m);
                                var $tmptrTDall = $tmptr.find('td');

                                //console.log($tmptrTDall.length);

                                if (_tmpCourtID == "Court" || $tmptrTDall.length < 3 || ($tmptrTDall.eq(0).text().length <= 7 && $tmptrTDall.eq(1).text() <= 7)) {
                                    // console.log("td<5,td2:" + $tmptrTDall.eq(2).text().length);
                                    // console.log($tmptr.text());
                                    continue;
                                }

                                tmpCourtDay = getContenTD($tmptrTDall.eq(2), tmpCourtDay, 1);
                                tmpCaseNo = getContenTD($tmptrTDall.eq(0), '', 1);
                                tmpPlainTiff = getContenTD($tmptrTDall.eq(1), '', 1);

                                if (!tmpCaseNo) continue;
                                if (tmpCaseNo.indexOf('/') < 0) continue;

                                tIndex++;
                                var tmpItem = {
                                    $id: tIndex,
                                    htmlID: 0,
                                    Tid: 0,
                                    tLang: 0,
                                    tkeyNo: _haxCrtKeyID[this.tmpdata],
                                    tIndex: tIndex,
                                    tname: _haxCrtKey[this.tmpdata],
                                    ttype: $PostType1for_judiciary,
                                    SerialNo: tIndex,
                                    CourtID: _tmpCourtID.replace(/[\↵\t\n\v\r]/g, ''),
                                    Judge: _Judge.replace(/[\↵\t\n\v\r]/g, ''),
                                    CYear: curDate.getFullYear(),
                                    CourtDay: tmpCourtDay,
                                    Hearing: undefined,
                                    CaseNo: tmpCaseNo,
                                    CaseType: undefined,
                                    PlainTiff: tmpPlainTiff,
                                    Defendant: undefined,
                                    Cause: undefined,
                                    Nature: undefined,
                                    Representation: undefined,
                                    Remark: tmpremark + _haxCrtKey[this.tmpdata],
                                    tStatus: 1,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }
                                gwd_Case_items.push(tmpItem);
                            }
                            //end for
                        }
                        //end for all div
                        break;
                    case "smt":
                        var tmpremark = "小额钱债审裁处:"
                        console.log(tmpremark + _haxCrtKey[this.tmpdata]);
                        var $tdPreAll = $tableAllDiv.find('td[width="34%"]');
                        for (var d = 0; d < $tdPreAll.length; d++) {
                            if (d % 3 === 0) {
                                //console.log(d);
                                var $currPartd = $tdPreAll.eq(d);
                                //console.log($currPartd.text());
                                var $currParTable = $currPartd.parents("table").eq(0);
                                var $currParTableTR = $currParTable.find('tr')

                                var $curNextTable = $currParTable.nextAll('table');

                                var $currParTableN1 = $curNextTable.eq(0);
                                var $currParTableNTR1 = $currParTableN1.find('tr')

                                var $currParTableN3 = $curNextTable.eq(2);
                                var $currParTableNTR3 = $currParTableN3.find('tr')

                                var $currParTableN4 = $curNextTable.eq(3);
                                var $currParTableNTR4 = $currParTableN4.find('tr')

                                //console.log($currParTableTR.eq(0).find('td').eq(0).text());

                                var _Judge = $currParTableTR.eq(0).find('td').eq(0).text() + "@" +
                                    $currParTableNTR1.eq(0).find('td').eq(0).text();
                                var _tmpCourtID = $currParTableNTR3.eq(0).text() + "@" +
                                    $currParTableNTR4.eq(0).text();

                                var tmpCourtDay = '';
                                var tmpCaseNo = '';
                                var tmpPlainTiff = '';
                                var tmpNature = '';
                                var tmpHearing = '';
                                var tmpDefendant = '';

                                //console.log("nextTableCount:" + $curNextTable.length);
                                for (var t = 5; t < $curNextTable.length; t++) {

                                    var $currNextTableCurr = $curNextTable.eq(t);
                                    var $currNextTableCurrTR = $currNextTableCurr.find('tr');

                                    if ($currNextTableCurr.find('hr').length > 0) {
                                        // console.log('Find a hr:' + t);
                                        //console.log($currNextTableCurrTR)
                                        break;
                                    }


                                    for (var z = 0; z < $currNextTableCurrTR.length; z++) {
                                        var $tmptr = $currNextTableCurrTR.eq(z);
                                        var $tmptrTDall = $tmptr.find('td');
                                        //console.log($tmptrTDall.length);

                                        if ($tmptrTDall.length < 6 || ($tmptrTDall.eq(3).text().length <= 7 && $tmptrTDall.eq(4).text() <= 7)) {
                                            // console.log("td<5,td2:" + $tmptrTDall.eq(2).text().length);
                                            // console.log($tmptr.text());
                                            continue;
                                        }

                                        tmpCourtDay = getContenP($tmptrTDall.eq(0), tmpCourtDay, 1, 1);
                                        tmpCaseNo = getContenP($tmptrTDall.eq(1), tmpCaseNo, 1, 1);
                                        tmpPlainTiff = getContenP($tmptrTDall.eq(2), tmpPlainTiff, 1, 0);
                                        tmpDefendant = getContenP($tmptrTDall.eq(3), tmpDefendant, 1, 0);
                                        tmpNature = getContenP($tmptrTDall.eq(4), tmpNature, 1, 1);
                                        tmpHearing = getContenP($tmptrTDall.eq(5), tmpHearing, 1, 1);

                                        if (!tmpCaseNo) continue;
                                        if (tmpCaseNo.indexOf('/') < 0) continue;

                                        tIndex++;
                                        var tmpItem = {
                                            $id: tIndex,
                                            htmlID: 0,
                                            Tid: 0,
                                            tLang: 0,
                                            tkeyNo: _haxCrtKeyID[this.tmpdata],
                                            tIndex: tIndex,
                                            tname: _haxCrtKey[this.tmpdata],
                                            ttype: $PostType1for_judiciary,
                                            SerialNo: tIndex,
                                            CourtID: _tmpCourtID.replace(/[\↵\t\n\v\r]/g, ''),
                                            Judge: _Judge.replace(/[\↵\t\n\v\r]/g, ''),
                                            CYear: curDate.getFullYear(),
                                            CourtDay: tmpCourtDay,
                                            Hearing: tmpHearing,
                                            CaseNo: tmpCaseNo,
                                            CaseType: undefined,
                                            PlainTiff: tmpPlainTiff,
                                            Defendant: tmpDefendant,
                                            Cause: undefined,
                                            Nature: tmpNature,
                                            Representation: undefined,
                                            Remark: tmpremark + _haxCrtKey[this.tmpdata],
                                            tStatus: 1,
                                            addDate: undefined,
                                            UpdateDate: undefined
                                        }
                                        gwd_Case_items.push(tmpItem);
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        console.log("default case!********* Do nothing.");
                        break;
                }
                //end switch
            }

            console.log(getWebDatas);

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
    sendMsg("removeUrl", "http://www.judiciary.gov.hk/en/crt_lists/daily_caulist.htm");
    arrurl.forEach(function (url) {
        j1_PostData_1for_judiciary(url);
    }, this);
}

function getContenTD($td, tmpText, lenP) {
    var allp = $td.children('p');

    if (allp.length === 1) return (allp.eq(0).find('span').length > 0 && allp.eq(0).find('span').eq(0).text().trim().length < 1) || allp.eq(0).text().trim().length < 1 ? tmpText : allp.eq(0).text().trim();
    if (allp.length < lenP) return tmpText;

    var tmpAllText = '';
    for (var x = 0; x < allp.length; x++) {
        var p = allp.eq(x);

        if (!p.text().trim()) continue;

        tmpAllText = !tmpAllText ? p.text().trim() : tmpAllText + "@" + p.text().trim()
    }
    return tmpAllText.replace(/[\↵\t\n\v\r]/g, '').trim();
}

function getContenP($td, tmpText, lenP, isSpanZH) {
    if (isSpanZH === 1) {
        var allspan = $td.find('span[lang="ZH-CN"]');
        for (var x = 0; x < allspan.length; x++) {
            var $span = allspan.eq(x);
            if (!$span.text().trim()) continue;

            var reText = $span.text().trim() + "@"
            $span.replaceWith(reText);
        }
    }

    var allp = $td.find('p');

    if (allp.length === 1) return (allp.eq(0).find('span').length > 0 && allp.eq(0).find('span').eq(0).text().trim().length < 1) || allp.eq(0).text().trim().length < 1 ? tmpText : allp.eq(0).text().trim();
    if (allp.length < lenP) return tmpText;


    return $td.text().replace(/[\↵\t\n\v\r]/g, '').trim();
}