
//上诉记录
//http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=98875

//判案书
//判刑理由
//裁决理由
//http://legalref.judiciary.gov.hk/lrs/common/ju/ju_body.jsp?DIS=102431
//Press Summary ：102431
var _legalrefTdis = GetQueryString("DIS") ? parseInt(GetQueryString("DIS"), 10) : 0;
var _getAllMain_legalref = [];
var _getUrl2PressPrefix = "http://legalref.judiciary.gov.hk/";

function legalref() {
    sendMsg("removeUrl", config.urlRedict_legalrefHOME);
	sendMsg("removeUrl", "http://www.judiciary.gov.hk/maintenance");
	sendMsg("removeUrl", "http://legalref.judiciary.gov.hk/lrs/notFileFound.jsp");

    console.log("text legalref ok. Tdis:" + _legalrefTdis);
    //每5秒开始运行，一次取5个
    var s1_legalref = window.setInterval(runEven5, config.getSetInterval);
    // //for test    
    // config.getEven5Count = 1;
    // runEven5();

    function runEven5() {

	    sendMsg("removeUrl", "http://www.judiciary.gov.hk/maintenance");
	    sendMsg("removeUrl", "http://legalref.judiciary.gov.hk/lrs/notFileFound.jsp");
		
        _getAllMain_legalref = [];

        console.log("CurrTDis:" + _legalrefTdis + ",每:" + (config.getSetInterval / 1000) + "秒运行一次，每次取:" + config.getEven5Count);

        if (_legalrefTdis < 0) {
            _legalrefTdis = 0;
        }
        var currCRNo = _legalrefTdis;

        for (var i = 1; i <= config.getEven5Count; i++) {

            $.ajax({
                url: config.urlRedict_legalrefMain + currCRNo,
                data: {},
                tmpdata: currCRNo,
                timeout: 20000,
                type: "get",
                success: function (data, state, xhr) {
                    if (data.indexOf('绿色上网提示') > -1) {
                        console.log("绿色上网提示");
                        _legalrefTdis -= config.getEven5Count;
                        document.location.href = document.location.href;
                        return;
                    }
                    //当前查询Tdis this.tmpdata
                    console.log("Curr:" + this.tmpdata);
                    //   console.log(data);
                    var $body = $('<div></div>').html(data);
                    var $table0 = $body.find('table').eq(1);
                    var $table0TR = $table0.find('tr');

                    console.log($table0TR.length);

                    if ($table0TR.length < 2) {
                        console.log(this.tmpdata + '：没有记录。table tr Length < 2. ');
                        //console.log(data);
                        //setMsg('m_parameterSetMax', "legalrefCurrMax", this.tmpdata);
                        return;
                    }
                    //读出记录
                    //取第二行第一单元格记录
                    var tmpTname = $table0TR.eq(1).find('td').eq(0).text().trim();
                    var tmpCaseNum0 = "";
                    var tmpCaseNum0Last = "";
                    var tmpDate1 = "";
                    var tmpReportedin2 = "";
                    var tmpRemarks3 = "";
                    var tmpGetItemURL = "";
                    var tmpTDis = 0;

                    var tmpLenTR = $table0TR.length - 1;
                    for (var x = tmpLenTR; x > 0; x--) {
                        //console.log(x);
                        var $tmpCurrTrLast = $table0TR.eq(x);
                        var $tmpCurrTrTdLast = $tmpCurrTrLast.find('td');
                        if ($tmpCurrTrTdLast.length < 4) {
                            continue;
                        } else {
                            tmpCaseNum0Last = $tmpCurrTrTdLast.eq(0).text().trim();
                            break;
                        }
                    }
                    console.log("Last:" + tmpCaseNum0Last);
                    if (!tmpCaseNum0Last) {
                        console.log("Error 没有找到最后一个CaseNo.")
                        return;
                    }

                    for (m = 1; m < $table0TR.length; m++) {
                        var $tmpCurrTrPre = $table0TR.eq(m - 1);
                        var $tmpCurrTr = $table0TR.eq(m);
                        //console.log($tmpCurrTr.text());
                        var $tmpCurrTrTd = $tmpCurrTr.find('td');
                        var $tmpCurrTrTdPre = $tmpCurrTrPre.find('td');

                        console.log("TD Len:" + $tmpCurrTrTd.length);

                        if ($tmpCurrTrTd.length < 4) {
                            if ($tmpCurrTrTdPre.length >= 4) {
                                tmpCaseNum0 = $tmpCurrTrTdPre.eq(0).text().trim();
                            }
                            tmpDate1 = $tmpCurrTrTd.eq(0).text().trim();
                            tmpGetItemURL = $tmpCurrTrTd.eq(0).find('a').eq(0).attr('href');
                            tmpReportedin2 = $tmpCurrTrTd.eq(1).text().trim();
                            tmpRemarks3 = $tmpCurrTrTd.eq(2).text().trim();
                        } else {
                            tmpCaseNum0 = $tmpCurrTrTd.eq(0).text().trim();
                            tmpDate1 = $tmpCurrTrTd.eq(1).text().trim();
                            tmpGetItemURL = $tmpCurrTrTd.eq(1).find('a').eq(0).attr('href');
                            tmpReportedin2 = $tmpCurrTrTd.eq(2).text().trim();
                            tmpRemarks3 = $tmpCurrTrTd.eq(3).text().trim();
                        }
                        tmpTDis = GetQueryStringUrl(tmpGetItemURL, "DIS");
                        //提交到数据库 
                        var getWebDatas = {
                            caseNo: tmpCaseNum0,
                            caseDate: tmpDate1,
                            TDis: tmpTDis,
                            TGetDis: this.tmpdata,
                            ReportedIn: tmpReportedin2,
                            tLang: 0,
                            tkeyNo: tmpCaseNum0Last,
                            tIndex: m,
                            tname: tmpRemarks3,
                            ttype: "上诉记录",
                            Tid: 0,
                            Remark: this.url,
                            tStatus: 0,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        var getWebDatasForLang = {
                            caseNo: tmpCaseNum0,
                            caseDate: tmpDate1,
                            tLang: 0,
                            tname: undefined,
                            ttype: "判案书",
                            thtml: undefined,
                            Tid: 0,
                            Remark: tmpGetItemURL,
                            tStatus: 0,
                            addDate: undefined,
                            UpdateDate: undefined,

                            TDis: tmpTDis,
                            TGetDis: this.tmpdata,
                            tIndex: 0
                        }

                        _getAllMain_legalref.push(getWebDatas);

                        //提取 上诉记录
                        $.ajax({
                            type: 'POST',
                            url: config.urlApi_legalref,
                            tmpdata: getWebDatas,
                            tmpdataLang: getWebDatasForLang,
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(getWebDatas)
                        }).done(function (data) {
                            console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.tIndex + ":Post Done!");
                            sendMsg('jsonDate2_legalref', "Set jsonDate2_legalref Now.");
                            //console.log(data);

                            //提交判案书
                            $.ajax({
                                url: config.urlRedict_legalrefItem + this.tmpdata.TDis,
                                data: {},
                                tmpdata: this.tmpdataLang,
                                timeout: 20000,
                                type: "get",
                                success: function (data, state, xhr) {
                                    if (data.indexOf('绿色上网提示') > -1) {
                                        console.log("绿色上网提示");
                                        _legalrefTdis -= config.getEven5Count;
                                        document.location.href = document.location.href;
                                        return;
                                    }
                                    this.tmpdata.thtml = data;

                                    //提交数据库 提交判案书
                                    $.ajax({
                                        type: 'POST',
                                        url: config.urlApi_legalref_html,
                                        tmpdata: this.tmpdata,
                                        contentType: 'application/json; charset=utf-8',
                                        data: JSON.stringify(this.tmpdata)
                                    }).done(function (data) {
                                        console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.tIndex + ":Post Done!");
                                        sendMsg('jsonDate2_legalref', "Set jsonDate2_legalref Now.");
                                        //console.log(data);
                                    }).fail(function (err) {
                                        //showError
                                        sendMsg('postOK2legalref', "Set _postOK_2_legalref false.");
                                        _legalrefTdis -= config.getEven5Count;
                                        console.log(err);
                                    });
                                    //查询是否有摘要记录
                                    var $body2 = $('<div></div>').html(data);
                                    var $tmpGet2Urla = $body2.find('a');
                                    var aEnglisht = $tmpGet2Urla.eq(0);
                                    var aChinese = $tmpGet2Urla.eq(1);
                                    // console.log(aEnglisht.text());
                                    // console.log(aChinese.text());

                                    //提交英文
                                    if (aEnglisht.text().indexOf('Press Summary (English)') > -1) {
                                        var getEnglishUrl = _getUrl2PressPrefix + aEnglisht.attr('href')
                                        console.log("aEnglisht:" + getEnglishUrl);
                                        $.ajax({
                                            url: getEnglishUrl,
                                            data: {},
                                            tmpdata: this.tmpdata,
                                            timeout: 20000,
                                            type: "get",
                                            success: function (data, state, xhr) {
                                                if (data.indexOf('绿色上网提示') > -1) {
                                                    console.log("绿色上网提示");
                                                    _legalrefTdis -= config.getEven5Count;
                                                    document.location.href = document.location.href;
                                                    return;
                                                }
                                                var tmpData1 = this.tmpdata;
                                                tmpData1.Remark = this.url;
                                                tmpData1.thtml = data;
                                                tmpData1.tStatus = 1;
                                                tmpData1.tLang = 1;
                                                //提交数据库
                                                $.ajax({
                                                    type: 'POST',
                                                    url: config.urlApi_legalref_html,
                                                    tmpdata: tmpData1,
                                                    contentType: 'application/json; charset=utf-8',
                                                    data: JSON.stringify(tmpData1)
                                                }).done(function (data) {
                                                    console.log(this.tmpdata);
                                                    console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.tIndex + ":Press Summary English Post Done!");
                                                    // sendMsg('jsonDate', "Set Date Now.");
                                                    //console.log(data);
                                                }).fail(function (err) {
                                                    //showError
                                                    _legalrefTdis -= config.getEven5Count;
                                                    console.log(err);
                                                });
                                            },
                                            error: function () {
                                                console.log("提交预定请求发生错误，稍等重试！" + this.url);
                                            },
                                            dataType: "text"
                                        });
                                    }
                                    //提交中文
                                    if (aChinese.text().indexOf('Press Summary (Chinese)') > -1) {
                                        var getaChineseUrl = _getUrl2PressPrefix + aChinese.attr('href')
                                        console.log("aChinese:" + getaChineseUrl);

                                        $.ajax({
                                            url: getaChineseUrl,
                                            data: {},
                                            tmpdata: this.tmpdata,
                                            timeout: 20000,
                                            type: "get",
                                            success: function (data, state, xhr) {
                                                if (data.indexOf('绿色上网提示') > -1) {
                                                    console.log("绿色上网提示");
                                                    _legalrefTdis -= config.getEven5Count;
                                                    document.location.href = document.location.href;
                                                    return;
                                                }
                                                var tmpData2 = this.tmpdata;
                                                tmpData2.Remark = this.url;
                                                tmpData2.thtml = data;
                                                tmpData2.tStatus = 1;
                                                tmpData2.tLang = 2;
                                                //提交数据库
                                                $.ajax({
                                                    type: 'POST',
                                                    url: config.urlApi_legalref_html,
                                                    tmpdata: tmpData2,
                                                    contentType: 'application/json; charset=utf-8',
                                                    data: JSON.stringify(tmpData2)
                                                }).done(function (data) {
                                                    console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.tIndex + ":Press Summary Chinese Post Done!");
                                                    // sendMsg('jsonDate', "Set Date Now.");
                                                    //console.log(data);
                                                }).fail(function (err) {
                                                    //showError
                                                    _legalrefTdis -= config.getEven5Count;
                                                    console.log(err);
                                                });
                                            },
                                            error: function () {
                                                console.log("提交预定请求发生错误，稍等重试！" + this.url);
                                            },
                                            dataType: "text"
                                        });
                                    }
                                    ////////////////////////
                                },
                                error: function () {
                                    console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                    _legalrefTdis -= config.getEven5Count;
                                    sendMsg('postOK2legalref', "Set _postOK_2_legalref false.");
                                },
                                dataType: "text"
                            });
                            //end   提取 判案书

                        }).fail(function (err) {
                            //showError
                            sendMsg('postOK2legalref', "Set _postOK_2_legalref false.");
                            _legalrefTdis -= config.getEven5Count;
                            console.log(err);
                        });
                        /// 
                    }
                    //show array
                    //console.log(_getAllMain_legalref);
                    //end for
                },
                error: function () {
                    console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                    _legalrefTdis -= config.getEven5Count;
                    sendMsg('postOK2legalref', "Set _postOK_2_legalref false.");
                },
                dataType: "text"
            });
            currCRNo += 1;
            ////
        }
        _legalrefTdis += config.getEven5Count;
        ////
    }
}
