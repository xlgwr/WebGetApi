
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
    sendMsg("removeUrl", config.urlRedict_legalrefMain);

    console.log("text legalref ok. Tdis:" + _legalrefTdis);
    //每5秒开始运行，一次取5个
    var s1_legalref = window.setInterval(runEven5, config.getSetInterval);
    // //for test    
    // config.getEven5Count = 1;
    // runEven5();

    function runEven5() {

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
                    var tmpDate1 = "";
                    var tmpReportedin2 = "";
                    var tmpRemarks3 = "";
                    var tmpGetItemURL = "";
                    var tmpTDis = 0;
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
                            Tdate: tmpDate1,
                            TDis: tmpTDis,
                            TIndex: 0,
                            TGetDis: this.tmpdata,
                            ReportedIn: tmpReportedin2,
                            gwd_legalref_items: [],
                            Tid: tmpCaseNum0,
                            tname: tmpTname,
                            ttype: "上诉记录",
                            tcontent: "上诉记录",
                            tGetTable: tmpGetItemURL,
                            thtml: "记录判案书",
                            Remark: tmpRemarks3,
                            tStatus: 0,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        //console.log(getWebDatas);

                        _getAllMain_legalref.push(getWebDatas);


                        //提取 判案书
                        $.ajax({
                            url: config.urlRedict_legalrefItem + getWebDatas.TDis,
                            data: {},
                            tmpdata: getWebDatas,
                            timeout: 20000,
                            type: "get",
                            success: function (data, state, xhr) {

                                this.tmpdata.thtml = data;

                                //提交数据库
                                $.ajax({
                                    type: 'POST',
                                    url: config.urlApi_legalref,
                                    tmpdata: this.tmpdata,
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify(this.tmpdata)
                                }).done(function (data) {
                                    console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.TIndex + ":Post Done!");
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

                                            var tmpData1 = this.tmpdata;
                                            tmpData1.tGetTable = this.url;
                                            tmpData1.thtml = data;
                                            tmpData1.tStatus = 1;
                                            tmpData1.TIndex = 1;
                                            //提交数据库
                                            $.ajax({
                                                type: 'POST',
                                                url: config.urlApi_legalref,
                                                tmpdata: tmpData1,
                                                contentType: 'application/json; charset=utf-8',
                                                data: JSON.stringify(tmpData1)
                                            }).done(function (data) {
                                                console.log(this.tmpdata);
                                                console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.TIndex + ":Press Summary English Post Done!");
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

                                            var tmpData2 = this.tmpdata;
                                            tmpData2.tGetTable = this.url;
                                            tmpData2.thtml = data;
                                            tmpData2.tStatus = 1;
                                            tmpData2.TIndex = 2;
                                            //提交数据库
                                            $.ajax({
                                                type: 'POST',
                                                url: config.urlApi_legalref,
                                                tmpdata: tmpData2,
                                                contentType: 'application/json; charset=utf-8',
                                                data: JSON.stringify(tmpData2)
                                            }).done(function (data) {
                                                console.log(this.tmpdata.TGetDis + "," + this.tmpdata.TDis + ",Index:" + this.tmpdata.TIndex + ":Press Summary Chinese Post Done!");
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
