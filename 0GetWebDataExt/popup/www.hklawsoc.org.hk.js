////律师界名录
var _allColNameZH = [];
var _allColNameEN = []
var _allPage = 100;
var _allcount = 0;
var currPage = 1;
var evenRun = 1;
var _intervalTime = 15 * 1000;
var tmpmsg = "";

$(function () {
    console.log("律师界名录初始化..");
    $('#btn1hklaw').click(function () {
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg1')
        gwd_mem_withcert($(this), $msg);
        //$(this).attr('disabled', null);
    });

})

function gwd_mem_withcert(btn, msgid) {

    console.log("律师界名录初始化..");
    msgid.text("律师界名录采集初始化..");
    //每10秒开始运行，一次取5个
    var s1_hklaw = window.setInterval(runEven5, _intervalTime);
    runEven5();

    function runEven5() {
        console.clear();
        tmpmsg = "正在运行--》当前更新页:" + currPage + ",总页数:" + _allPage + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun
        console.log(tmpmsg);


        if (currPage < 0) {
            currPage = 1;
        }
        for (var x = 1; x <= evenRun; x++) {

            console.log("CurrNowPage:" + currPage);
            if (currPage > _allPage) {

                clearInterval(s1_hklaw);
                msgid.text("有:" + _allPage + " 页已全部更新完成。总数量为：" + _allcount);
                btn.attr('disabled', null);
                break;
            }

            $.ajax({
                url: configGetUrl.getUrl_fjt2_mem_withcert,
                data: { name: '', pg: currPage, sj: 0 },
                tmpdata: currPage,
                timeout: 50000,
                type: "get",
                success: function (data, state, xhr) {
                    console.log(this.url);
                    var $body = $('<div></div>').html(data);
                    var $table0 = $body.find('table[width="750"]').eq(0);
                    var $table0TR = $table0.find('tr');

                    var $table0TR3 = $table0TR.eq(2);
                    //正常有table 6个
                    //第3个为总计
                    //第5个为记录
                    if ($table0TR3) {
                        var $table0TR3Table = $table0TR3.find('table');
                        console.log(this.tmpdata + " 有table数：" + $table0TR3Table.length);
                        if ($table0TR3Table.length > 4) {
                            var $table0TR3Table3 = $table0TR3Table.eq(2);
                            var $table0TR3Table5 = $table0TR3Table.eq(4);

                            var $table0TR3Table3TR = $table0TR3Table3.find('tr');
                            var $table0TR3Table5TR = $table0TR3Table5.find('tr');

                            var $table0TR3Table3TRB = $table0TR3Table3TR.eq(0).find('b');

                            _allcount = parseInt($table0TR3Table3TRB.eq(0).text().trim(), 10);
                            _allPage = Math.ceil((_allcount + 50) / 50);
                            console.log("总记录：" + _allcount + ",页：" + _allPage);
                            console.log(this.tmpdata + " 页有:" + $table0TR3Table5TR.length + " 条记录。");

                            tmpmsg = "正在运行--》当前更新页:" + this.tmpdata + "，有:" + ($table0TR3Table5TR.length - 1) + "条记录,总页数:" + _allPage + ", 每:" + (_intervalTime / 1000) + " 秒运行一次，每次取: " + evenRun + " 页."
                            msgid.text(tmpmsg);
                            // var $table0TR3Table5TR1TD = $table0TR3Table5TR.eq(1).find('td');
                            // console.log($table0TR3Table5TR1TD.eq(0).text().trim() + "," + $table0TR3Table5TR1TD.eq(1).text().trim() + "," + $table0TR3Table5TR1TD.eq(2).text().trim());

                            //开始处理获取明细记录
                            //$table0TR3Table5TR.length
                            for (var m = 1; m < $table0TR3Table5TR.length; m++) {
                                var tr = $table0TR3Table5TR.eq(m);
                                var allTd = tr.find('td');
                                var nameId = allTd.eq(0).text().trim();
                                var nameEn = allTd.eq(1).find('a').eq(0);
                                var nameZH = allTd.eq(2).find('a').eq(0);
                                var toHref = nameEn.attr('href');
                                var tmpId = GetQueryStringUrl(toHref, "id");
                                console.log(toHref + "," + tmpId + "," + nameEn.text().trim());
                                console.log(nameZH.text().trim());

                                if (tmpId) {
                                    //读出明细，并存入数据库
                                    var toPostMain = {
                                        Tid: tmpId,
                                        TIndex: 0,
                                        LawyerName: nameEn.text().trim(),
                                        ChineseName: nameZH.text().trim(),
                                        BeforeName: undefined,
                                        ApproveDate: undefined,
                                        ApproveCountry: undefined,
                                        OtherDate: undefined,
                                        LawyerEmail: undefined,
                                        Title: undefined,
                                        LawyerCompany: undefined,
                                        ChineseCompany: undefined,
                                        CompanyAddress: undefined,
                                        ChineseAddress: undefined,
                                        Companytel: undefined,
                                        CompanyFax: undefined,
                                        Dxnumber: undefined,
                                        CompanyEmail: undefined,
                                        tname: nameId,
                                        ttype: undefined,
                                        tcontent: undefined,
                                        tGetTable: undefined,
                                        thtml: undefined,
                                        Remark: undefined,
                                        tStatus: 0,
                                        ClientIP: undefined,
                                        addDate: undefined,
                                        UpdateDate: undefined
                                    }
                                    //英文
                                    $.ajax({
                                        url: configGetUrl.getUrl_fjt2_mem_withcertPageEN,
                                        data: { id: toPostMain.Tid },
                                        tmpdata: toPostMain,
                                        timeout: 50000,
                                        type: "get",
                                        success: function (data, state, xhr) {
                                            console.log("英文:" + this.url);
                                            var $body = $('<div></div>').html(data);
                                            var $table0 = $body.find('table[width="550"]').eq(0);
                                            var $table0TR = $table0.find('tr');

                                            var $table0TR3Table = $table0TR.eq(0).find('table').eq(0).find('table').eq(0);
                                            var $table0TR3TableChildTR = $table0TR3Table.children('tbody').eq(0).children('tr');
                                            console.log($table0TR3TableChildTR.length);

                                            var toPostMainEN = {
                                                Tid: this.tmpdata.Tid,
                                                TIndex: 1,
                                                LawyerName: this.tmpdata.LawyerName,
                                                ChineseName: this.tmpdata.ChineseName,
                                                BeforeName: undefined,
                                                ApproveDate: undefined,
                                                ApproveCountry: undefined,
                                                OtherDate: undefined,
                                                LawyerEmail: undefined,
                                                Title: undefined,
                                                LawyerCompany: undefined,
                                                ChineseCompany: undefined,
                                                CompanyAddress: undefined,
                                                ChineseAddress: undefined,
                                                Companytel: undefined,
                                                CompanyFax: undefined,
                                                Dxnumber: undefined,
                                                CompanyEmail: undefined,
                                                tname: this.tmpdata.tname,
                                                ttype: undefined,
                                                tcontent: undefined,
                                                tGetTable: undefined,
                                                thtml: undefined,
                                                Remark: undefined,
                                                tStatus: 0,
                                                ClientIP: undefined,
                                                addDate: undefined,
                                                UpdateDate: undefined
                                            }
                                            for (var x = 0; x < $table0TR3TableChildTR.length; x++) {
                                                var tr = $table0TR3TableChildTR.eq(x);
                                                var cTD = tr.children('td');
                                                if (cTD.length < 2) {
                                                    continue;
                                                }
                                                var $ctd0 = cTD.eq(0).text().trim();
                                                var $ctd1 = cTD.eq(1).text().trim();

                                                // if (_allColNameEN.indexOf($ctd0) < 0) {
                                                //     _allColNameEN.push($ctd0);
                                                // }
                                                //console.log($ctd0 + "," + $ctd1);

                                                // ["姓 名 (英 文)", "在 香 港 認 許 日 期",
                                                // "備 註", "在 其 他 法 域 認 許 日 期", "電 郵 地 址",
                                                // "職 位", "律 師 行 / 公 司 (英 文)",
                                                // "律 師 行 / 公 司 (中 文)", "地 址 (英 文)",
                                                // "地 址 (中 文)", "電 話", "傳 真",
                                                // "DX 號 碼", "姓 名 (中 文)",
                                                //     "前 稱 (中 文)"]
                                                // ["Name (English)", "Name (Chinese)", "Admission in Hong Kong",
                                                // "Remark", "Email", "Post", "Firm/Company (English)",
                                                // "Firm/Company (Chinese)", "Address (English)",
                                                // "Address (Chinese)", "Telephone",
                                                // "Fax", "E-mail", "Admission in Other Jurisdiction(s)", "DX No.",
                                                // "Former Name (Chinese)"]
                                                switch ($ctd0) {
                                                    case "姓 名 (英 文)": case "Name (English)":
                                                        toPostMainEN.LawyerName = $ctd1;
                                                        break;
                                                    case "姓 名 (中 文)": case "Name (Chinese)":
                                                        toPostMainEN.ChineseName = $ctd1;
                                                        break;
                                                    case "前 稱 (中 文)": case "Former Name (Chinese)":
                                                        toPostMainEN.BeforeName = $ctd1;
                                                        break;
                                                    case "在 香 港 認 許 日 期": case "Admission in Hong Kong":
                                                        toPostMainEN.ApproveDate = $ctd1;
                                                        break;
                                                    case "備 註": case "Remark":
                                                        toPostMainEN.Remark = $ctd1;
                                                        break;
                                                    case "在 其 他 法 域 認 許 日 期": case "Admission in Other Jurisdiction(s)":
                                                        toPostMainEN.OtherDate = $ctd1;
                                                        break;
                                                    case "電 郵 地 址": case "Email": case "E-mail":
                                                        if (!toPostMainEN.LawyerEmail) {
                                                            toPostMainEN.LawyerEmail = $ctd1;
                                                        } else {
                                                            toPostMainEN.CompanyEmail = $ctd1;
                                                        }

                                                        break;
                                                    case "職 位": case "Post":
                                                        toPostMainEN.Title = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (英 文)": case "Firm/Company (English)":
                                                        toPostMainEN.LawyerCompany = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (中 文)": case "Firm/Company (Chinese)":
                                                        toPostMainEN.ChineseCompany = $ctd1;
                                                        break;
                                                    case "地 址 (英 文)": case "Address (English)":
                                                        toPostMainEN.CompanyAddress = $ctd1;
                                                        break;
                                                    case "地 址 (中 文)": case "Address (Chinese)":
                                                        toPostMainEN.ChineseAddress = $ctd1;
                                                        break;
                                                    case "電 話": case "Telephone":
                                                        toPostMainEN.Companytel = $ctd1;
                                                        break;
                                                    case "傳 真": case "Fax":
                                                        toPostMainEN.CompanyFax = $ctd1;
                                                        break;
                                                    case "DX 號 碼": case "DX No.":
                                                        toPostMainEN.Dxnumber = $ctd1;
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }

                                            msgid.text(tmpmsg + "，正在提交第：" + this.tmpdata.tname + " 条记录。");
                                            //console.log(toPostMainEN);
                                            //console.log(_allColNameEN.length + "," + _allColNameEN);
                                            //提交数据库
                                            $.ajax({
                                                type: 'POST',
                                                url: config.urlApi_hklawsoc,
                                                tmpdata: toPostMainEN,
                                                timeout: 50000,
                                                contentType: 'application/json; charset=utf-8',
                                                data: JSON.stringify(toPostMainEN)
                                            }).done(function (data) {
                                                console.log(this.tmpdata.Tid + "," + ",Index:" + this.tmpdata.TIndex + ":英文 Post Done!");
                                                // sendMsg('jsonDate', "Set Date Now.");
                                                //console.log(data);
                                            }).fail(function (err) {
                                                //showError
                                                console.log(err);
                                            });
                                        },
                                        error: function (err) {
                                            console.log(this.url);
                                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                            console.log(err);
                                        },
                                        dataType: "text"
                                    });
                                    //中文
                                    $.ajax({
                                        url: configGetUrl.getUrl_fjt2_mem_withcertPageCN,
                                        data: { id: toPostMain.Tid },
                                        tmpdata: toPostMain,
                                        timeout: 50000,
                                        type: "get",
                                        success: function (data, state, xhr) {
                                            console.log("中文:" + this.url);
                                            var $body = $('<div></div>').html(data);
                                            var $table0 = $body.find('table[width="550"]').eq(0);
                                            var $table0TR = $table0.find('tr');

                                            var $table0TR3Table = $table0TR.eq(0).find('table').eq(0).find('table').eq(0);
                                            var $table0TR3TableChildTR = $table0TR3Table.children('tbody').eq(0).children('tr');
                                            console.log($table0TR3TableChildTR.length);

                                            var toPostMainCN = {
                                                Tid: this.tmpdata.Tid,
                                                TIndex: 0,
                                                LawyerName: this.tmpdata.LawyerName,
                                                ChineseName: this.tmpdata.ChineseName,
                                                BeforeName: undefined,
                                                ApproveDate: undefined,
                                                ApproveCountry: undefined,
                                                OtherDate: undefined,
                                                LawyerEmail: undefined,
                                                Title: undefined,
                                                LawyerCompany: undefined,
                                                ChineseCompany: undefined,
                                                CompanyAddress: undefined,
                                                ChineseAddress: undefined,
                                                Companytel: undefined,
                                                CompanyFax: undefined,
                                                Dxnumber: undefined,
                                                CompanyEmail: undefined,
                                                tname: this.tmpdata.tname,
                                                ttype: undefined,
                                                tcontent: undefined,
                                                tGetTable: undefined,
                                                thtml: undefined,
                                                Remark: undefined,
                                                tStatus: 0,
                                                ClientIP: undefined,
                                                addDate: undefined,
                                                UpdateDate: undefined
                                            }
                                            for (var x = 0; x < $table0TR3TableChildTR.length; x++) {
                                                var tr = $table0TR3TableChildTR.eq(x);
                                                var cTD = tr.children('td');
                                                if (cTD.length < 2) {
                                                    continue;
                                                }
                                                var $ctd0 = cTD.eq(0).text().trim();
                                                var $ctd1 = cTD.eq(1).text().trim();

                                                // if (_allColNameZH.indexOf($ctd0) < 0) {
                                                //     _allColNameZH.push($ctd0);
                                                // }
                                                //console.log($ctd0 + "," + $ctd1);

                                                // ["姓 名 (英 文)", "在 香 港 認 許 日 期",
                                                // "備 註", "在 其 他 法 域 認 許 日 期", "電 郵 地 址",
                                                // "職 位", "律 師 行 / 公 司 (英 文)",
                                                // "律 師 行 / 公 司 (中 文)", "地 址 (英 文)",
                                                // "地 址 (中 文)", "電 話", "傳 真",
                                                // "DX 號 碼", "姓 名 (中 文)",
                                                //     "前 稱 (中 文)"]
                                                // ["Name (English)", "Name (Chinese)", "Admission in Hong Kong",
                                                // "Remark", "Email", "Post", "Firm/Company (English)",
                                                // "Firm/Company (Chinese)", "Address (English)",
                                                // "Address (Chinese)", "Telephone",
                                                // "Fax", "E-mail", "Admission in Other Jurisdiction(s)", "DX No.",
                                                // "Former Name (Chinese)"]
                                                switch ($ctd0) {
                                                    case "姓 名 (英 文)": case "Name (English)":
                                                        toPostMainCN.LawyerName = $ctd1;
                                                        break;
                                                    case "姓 名 (中 文)": case "Name (Chinese)":
                                                        toPostMainCN.ChineseName = $ctd1;
                                                        break;
                                                    case "前 稱 (中 文)": case "Former Name (Chinese)":
                                                        toPostMainCN.BeforeName = $ctd1;
                                                        break;
                                                    case "在 香 港 認 許 日 期": case "Admission in Hong Kong":
                                                        toPostMainCN.ApproveDate = $ctd1;
                                                        break;
                                                    case "備 註": case "Remark":
                                                        toPostMainCN.Remark = $ctd1.replace(/\s/g, "");
                                                        break;
                                                    case "在 其 他 法 域 認 許 日 期": case "Admission in Other Jurisdiction(s)":
                                                        toPostMainCN.OtherDate = $ctd1;
                                                        break;
                                                    case "電 郵 地 址": case "Email": case "E-mail":
                                                        if (!toPostMainCN.LawyerEmail) {
                                                            toPostMainCN.LawyerEmail = $ctd1;
                                                        } else {
                                                            toPostMainCN.CompanyEmail = $ctd1;
                                                        }

                                                        break;
                                                    case "職 位": case "Post":
                                                        toPostMainCN.Title = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (英 文)": case "Firm/Company (English)":
                                                        toPostMainCN.LawyerCompany = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (中 文)": case "Firm/Company (Chinese)":
                                                        toPostMainCN.ChineseCompany = $ctd1;
                                                        break;
                                                    case "地 址 (英 文)": case "Address (English)":
                                                        toPostMainCN.CompanyAddress = $ctd1;
                                                        break;
                                                    case "地 址 (中 文)": case "Address (Chinese)":
                                                        toPostMainCN.ChineseAddress = $ctd1;
                                                        break;
                                                    case "電 話": case "Telephone":
                                                        toPostMainCN.Companytel = $ctd1;
                                                        break;
                                                    case "傳 真": case "Fax":
                                                        toPostMainCN.CompanyFax = $ctd1;
                                                        break;
                                                    case "DX 號 碼": case "DX No.":
                                                        toPostMainCN.Dxnumber = $ctd1;
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }
                                            //console.log(toPostMainCN);
                                            //console.log(_allColNameZH.length + "," + _allColNameZH);
                                            //提交数据库
                                            $.ajax({
                                                type: 'POST',
                                                url: config.urlApi_hklawsoc,
                                                tmpdata: toPostMainCN,
                                                timeout: 50000,
                                                contentType: 'application/json; charset=utf-8',
                                                data: JSON.stringify(toPostMainCN)
                                            }).done(function (data) {
                                                console.log(this.tmpdata.Tid + "," + ",Index:" + this.tmpdata.TIndex + ":中 文 Post Done!");
                                                // sendMsg('jsonDate', "Set Date Now.");
                                                //console.log(data);
                                            }).fail(function (err) {
                                                //showError
                                                console.log(err);
                                            });

                                        },
                                        error: function (err) {
                                            console.log(this.url);
                                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                            console.log(err);
                                        },
                                        dataType: "text"
                                    });


                                    //////////////////////////////
                                }
                                /////////////////
                            }
                            //end


                        } else {
                            console.log(this.tmpdata + " 页没有记录。")
                        }
                    } else {
                        console.log("非指定页面，没有记录。")
                    }
                },
                error: function (err) {
                    console.log(this.url);
                    console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                    console.log(err);
                },
                dataType: "text"
            });
            currPage += 1;
        }
    }



}

