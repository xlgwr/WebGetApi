
//上诉记录
//http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=98875

//判案书
//判刑理由
//裁决理由
//http://legalref.judiciary.gov.hk/lrs/common/ju/ju_body.jsp?DIS=98875
//Press Summary ：102431
var _legalrefTdis = GetQueryString("DIS") ? parseInt(GetQueryString("DIS"), 10) : 0;
var _getAllMain_legalref = [];

function legalref() {
    sendMsg("removeUrl", config.urlRedict_legalrefMain);

    console.log("text legalref ok. Tdis:" + _legalrefTdis);
    //每5秒开始运行，一次取5个
    //var s1_legalref = window.setInterval(runEven5, config.getSetInterval);
    //for test    
    config.getEven5Count = 1;
    runEven5();

    function runEven5() {
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
                timeout: 10000,
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
                        console.log('没有记录。table tr Length < 2. ');
                        console.log(data);
                        return;
                    }
                    //读出记录
                    //取第二行第一单元格记录
                    var tmpTname = $table0TR.eq(1).find('td').eq(0).text().trim();
                    for (m = 1; m < $table0TR.length; m++) {
                        var $tmpCurrTrPre = $table0TR.eq(m - 1);
                        var $tmpCurrTr = $table0TR.eq(m);
                        //console.log($tmpCurrTr.text());
                        var $tmpCurrTrTd = $tmpCurrTr.find('td');
                        var $tmpCurrTrTdPre = $tmpCurrTrPre.find('td');

                        console.log("TD Len:" + $tmpCurrTrTd.length);
                        var tmpCaseNum0 = "";
                        var tmpDate1 = "";
                        var tmpReportedin2 = "";
                        var tmpRemarks3 = "";
                        var tmpGetItemURL = "";
                        var tmpTDis = 0;

                        if ($tmpCurrTrTd.length < 4) {
                            tmpCaseNum0 = $tmpCurrTrTdPre.eq(0).text().trim();
                            tmpDate1 = $tmpCurrTrTd.eq(0).text().trim();
                            tmpGetItemURL = $tmpCurrTrTd.eq(0).find('a').eq(0).attr('href');
                            tmpReportedin2 = $tmpCurrTrTd.eq(1).text().trim();
                            tmpRemarks3 = $tmpCurrTrTd.eq(2).text().trim().substring(0, 100);
                        } else {
                            tmpCaseNum0 = $tmpCurrTrTd.eq(0).text().trim();
                            tmpDate1 = $tmpCurrTrTd.eq(1).text().trim();
                            tmpGetItemURL = $tmpCurrTrTd.eq(1).find('a').eq(0).attr('href');
                            tmpReportedin2 = $tmpCurrTrTd.eq(2).text().trim();
                            tmpRemarks3 = $tmpCurrTrTd.eq(3).text().trim().substring(0, 100);
                        }
                        tmpTDis = GetQueryStringUrl(tmpGetItemURL, "DIS");
                        //提交到数据库
                        var getWebDatas = {
                            Tdate: tmpDate1,
                            TDis: tmpTDis,
                            ReportedIn: tmpReportedin2,
                            gwd_legalref_items: [],
                            Tid: tmpCaseNum0,
                            tname: tmpTname,
                            ttype: "上诉记录",
                            tcontent: tmpRemarks3,
                            tGetTable: tmpGetItemURL,
                            thtml: "记录判案书",
                            Remark: "上诉记录",
                            tStatus: 0,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        //console.log(getWebDatas);
                        var gwd_legalref_items = {
                            $id: "2",
                            Tid: "sample string 1",
                            Tdate: "sample string 2",
                            TIndex: 3,
                            tlang: "sample string 4",
                            isPressSummary: 5,
                            thtml: "sample string 6",
                            Remark: "sample string 7",
                            tStatus: 8,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        _getAllMain_legalref.push(getWebDatas);


                        //提取 判案书
                        $.ajax({
                            url: config.urlRedict_legalrefItem + getWebDatas.TDis,
                            data: {},
                            tmpdata: getWebDatas,
                            timeout: 10000,
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
                                    console.log(this.tmpdata.TDis + ":Post Done!");
                                    // sendMsg('jsonDate', "Set Date Now.");
                                    //console.log(data);
                                }).fail(function (err) {
                                    //showError
                                    _legalrefTdis -= config.getEven5Count;
                                    console.log(err);
                                });

                            },
                            error: function () {
                                console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                _legalrefTdis -= config.getEven5Count;
                            },
                            dataType: "text"
                        });
                        //end   提取 判案书


                        /// 
                    }
                    //show array
                    console.log(_getAllMain_legalref);
                    //end for
                },
                error: function () {
                    console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                    _legalrefTdis -= config.getEven5Count;
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
