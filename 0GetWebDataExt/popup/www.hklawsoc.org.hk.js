var _getm_parameter = [];
//

var _paramkey_1 = 'evenyDataGet';
var _paramkey_1_type = '1for_judiciary';
var _paramvalue_1evenyDataGet = '';

$(function() {
    console.log("popup:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S"));
    sendMsg("removeUrl", "popup.html");
    //1.
    $('#evenyDataGet').datetimepicker({
        format: 'hh:ii',
        startView: 0,
        //autoclose: true,
        //todayBtn: true,
        startDate: "2016-04-12 00:00"
            //minuteStep: 30,
    });

    //获取参数
    $.ajax({
        type: 'GET',
        timeout: 80000,
        url: config.urlApim_parameter
    }).done(function(data) {

        _getm_parameter = data;
        console.log(data);

        _getm_parameter.forEach(function(d) {
            if (d["paramkey"] === _paramkey_1) {
                console.log(d["paramkey"] + ":" + d["paramvalue"])
                _paramvalue_1evenyDataGet = d["paramvalue"];
                $('#evenyDataGet').val(_paramvalue_1evenyDataGet);
            }
        }, this);

    }).fail(function(err) {
        console.log(err);
        //alert("获取参数失败。");
    });

    //提交参数-1.终审及高等法院
    $('#btnEvenyDataGet').click(function() {
        //data
        var tmpGetdate = $('#evenyDataGet').val();
        if (!tmpGetdate) {
            alert("请输入时间.");
            return;
        }
        var m_parameter = {
            "paramkey": _paramkey_1,
            "paramvalue": tmpGetdate,
            "paramtype": _paramkey_1_type,
            "Remark": "终审及高等法院,每日开始采集时间",
            "tStatus": 0,
            "addDate": undefined,
            "UpdateDate": undefined
        };
        $('#btnEvenyDataGet').attr('disabled', 'disabled');
        $.ajax({
            type: 'POST',
            timeout: 20000,
            url: config.urlApim_parameter,
            tmpdata: _paramkey_1,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(m_parameter)
        }).done(function(data) {
            console.log(this.tmpdata + ":Post Done!");
            console.log(data);
            $('#btnEvenyDataGet').attr('disabled', null);
            alert("提交成功.");

        }).fail(function(err) {
            $('#btnEvenyDataGet').attr('disabled', null);
            //showError
            console.log(err);
        });
    });
    /////////////////start 


    /////////////////end
});
var nameAll = alltd.eq(0).text().trim();
var nameEn = undefined;
var nameZH = undefined;
var nameSp = nameAll.split('@');
if (nameSp.length > 1) {
    nameEn = nameSp[0];
    nameZH = nameSp[1];
} else {
    nameEn = nameAll;
}

var postItem = {
    $id: tmpitem,
    htmlID: 0,
    PsychologicalId: tmpitem,

    Name_En: nameEn,
    Name_Cn: nameZH,
    Address: alltd.eq(6).text().trim(),
    RegisteredNo: alltd.eq(1).text().trim(),
    Specialization: alltd.eq(2).text().trim(),
    Tel: alltd.eq(4).text().trim(),
    Fax: alltd.eq(5).text().trim(),
    Email: alltd.eq(3).find('img').eq(0).attr('alt'),

    tLang: this.tmpdataLang,
    tkeyNo: nameAll,
    tIndex: tmpitem,
    tname: undefined,
    ttype: _tTitle,
    Tid: 0,
    Remark: this.url,
    tStatus: 0,
    ClientIP: undefined,
    addDate: undefined,
    UpdateDate: undefined
}

postMain.i_PsychologicalSociety.push(postItem);

tmpitem += 1;
}
///end for
postMain.tname = _tTitle + ":" + postMain.i_PsychologicalSociety.length;
//console.log(postMain);

msgid.text(postMain.tname + "条，分析数据完成,准备更新到数据库..");
//提交数据库
$.ajax({
    type: 'POST',
    url: config.urlApi_PL_items,
    tmpdata: postMain,
    timeout: 80000,
    contentType: 'application/json; charset=utf-8',
    data: JSON.stringify(postMain)
}).done(function(data) {
    console.log(_tTitle + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
    // sendMsg('jsonDate', "Set Date Now.");
    //console.log(data);
    msgid.text(_tTitle + " 更新完成，已更新：" + this.tmpdata.i_PsychologicalSociety.length + " 条成功.");
    btn.attr('disabled', null);
}).fail(function(err) {
    //showError
    console.log(this.tmpdata);
    console.log(err);
});
////////////////////////////////////
},
error: function(err) {
        console.log(_tTitle + this.url);
        console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
        console.log(err);
    },
    dataType: "text"
});
/////////////////////
///////////////////////////////////////
}
});
tStatus: 0,
    ClientIP: undefined,
    addDate: undefined,
    UpdateDate: undefined
}
//英文
$.ajax({
    url: configGetUrl.getUrl_fjt2_mem_withcertPageEN,
    data: {
        id: tmpId
    },
    tmpdata: toPostMain,
    tmpdataItem: i_WithCertLawyers,
    timeout: 80000,
    type: "get",
    success: function(data, state, xhr) {
        console.log("英文:" + this.url);
        var $body = $('<div></div>').html(data);
        var $table0 = $body.find('table[width="550"]').eq(0);
        var $table0TR = $table0.find('tr');

        var $table0TR3Table = $table0TR.eq(0).find('table').eq(0).find('table').eq(0);
        var $table0TR3TableChildTR = $table0TR3Table.children('tbody').eq(0).children('tr');
        console.log($table0TR3TableChildTR.length);

        this.tmpdata.thtml = data;
        this.tmpdata.Remark = this.url;
        this.tmpdataItem.tLang = 0;

        for (var x = 0; x < $table0TR3TableChildTR.length; x++) {
            var tr = $table0TR3TableChildTR.eq(x);
            var cTD = tr.children('td');
            if (cTD.length < 2) {
                continue;
            }
            var $ctd0 = cTD.eq(0).text().trim();
            var $ctd1 = cTD.eq(1).text().trim();
            var $ctd1Table = cTD.eq(1).find('table').eq(0);

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
                case "姓 名 (英 文)":
                case "Name (English)":
                    this.tmpdataItem.LawyerNameEn = $ctd1;
                    break;
                case "姓 名 (中 文)":
                case "Name (Chinese)":
                    this.tmpdataItem.LawyerNameCn = $ctd1;
                    break;
                case "法 域":
                case "Jurisdiction":
                    this.tmpdataItem.Jurisdiction = $ctd1;
                    break;
                case "前 稱 (中 文)":
                case "Former Name (Chinese)":
                    this.tmpdataItem.BeforeName = $ctd1;
                    break;
                case "在 香 港 認 許 日 期":
                case "Admission in Hong Kong":
                    this.tmpdataItem.ApproveDate = $ctd1;
                    break;
                case "備 註":
                case "Remark":
                    this.tmpdataItem.Remark = $ctd1;
                    break;
                case "在 其 他 法 域 認 許 日 期":
                case "Admission in Other Jurisdiction(s)":
                    if ($ctd1Table) {
                        var tmpAlltr = $ctd1Table.find('tr');

                        for (var index = 1; index < tmpAlltr.length; index++) {
                            var tr = tmpAlltr.eq(index);
                            var tdAll = tr.find('td');
                            this.tmpdataItem.ApproveCountry += tdAll.eq(0).text().trim() + ",";
                            this.tmpdataItem.OtherDate += tdAll.eq(1).text().trim() + ",";

                        }
                    } else {
                        this.tmpdataItem.OtherDate = $ctd1;
                    }
                    break;
                case "電 郵 地 址":
                case "Email":
                case "E-mail":
                    if (!this.tmpdataItem.LawyerEmail) {
                        this.tmpdataItem.LawyerEmail = $ctd1;
                    } else {
                        this.tmpdataItem.ComEmail = $ctd1;
                    }

                    break;
                case "職 位":
                case "職 銜":
                case "Title":
                case "Post":
                    this.tmpdataItem.Title = $ctd1;
                    break;
                case "律 師 行 / 公 司 (英 文)":
                case "Firm/Company (English)":
                    this.tmpdataItem.LawyerCompanyEn = $ctd1;
                    break;
                case "律 師 行 / 公 司 (中 文)":
                case "Firm/Company (Chinese)":
                    this.tmpdataItem.LawyerCompanyCn = $ctd1;
                    break;
                case "地 址 (英 文)":
                case "Address (English)":
                    this.tmpdataItem.ComAddressEn = $ctd1;
                    break;
                case "地 址 (中 文)":
                case "Address (Chinese)":
                    this.tmpdataItem.ComAddressCn = $ctd1;
                    break;
                case "電 話":
                case "Telephone":
                    this.tmpdataItem.ComTel = $ctd1;
                    break;
                case "傳 真":
                case "Fax":
                    this.tmpdataItem.ComFax = $ctd1;
                    break;
                case "DX 號 碼":
                case "DX No.":
                    this.tmpdataItem.DxNO = $ctd1;
                    break;

                default:
                    break;
            }
        }

        msgid.text(tmpmsg + "，正在提交第：" + this.tmpdataItem.tname + " 条记录。");
        //console.log(this.tmpdataItem);
        //console.log(_allColNameEN.length + "," + _allColNameEN);

        this.tmpdata.i_WithCertLawyers.push(this.tmpdataItem);

        //console.log(this.tmpdata);
        //提交数据库
        $.ajax({
            type: 'POST',
            url: config.urlApi_withcert,
            tmpdata: this.tmpdata,
            timeout: 80000,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(this.tmpdata)
        }).done(function(data) {
            console.log(_ttype + "," + this.tmpdata.Tid + "," + ",Index:" + this.tmpdata.TIndex + ":英文 Post Done!");
            // sendMsg('jsonDate', "Set Date Now.");
            //console.log(data);
        }).fail(function(err) {
            //showError
            console.log(this.url);
            console.log(err);
        });
    },
    error: function(err) {
        console.log(this.url);
        console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
        console.log(err);
    },
    dataType: "text"
});
//中文
$.ajax({
    url: configGetUrl.getUrl_fjt2_mem_withcertPageCN,
    data: {
        id: tmpId
    },
    tmpdata: toPostMain,
    tmpdataItem: i_WithCertLawyers,
    timeout: 80000,
    type: "get",
    success: function(data, state, xhr) {
        console.log("中文:" + this.url);
        var $body = $('<div></div>').html(data);
        var $table0 = $body.find('table[width="550"]').eq(0);
        var $table0TR = $table0.find('tr');

        var $table0TR3Table = $table0TR.eq(0).find('table').eq(0).find('table').eq(0);
        var $table0TR3TableChildTR = $table0TR3Table.children('tbody').eq(0).children('tr');
        console.log($table0TR3TableChildTR.length);

        this.tmpdata.thtml = data;
        this.tmpdata.Remark = this.url;
        this.tmpdataItem.tLang = 1;

        for (var x = 0; x < $table0TR3TableChildTR.length; x++) {
            var tr = $table0TR3TableChildTR.eq(x);
            var cTD = tr.children('td');
            if (cTD.length < 2) {
                continue;
            }
            var $ctd0 = cTD.eq(0).text().trim();
            var $ctd1 = cTD.eq(1).text().trim();
            var $ctd1Table = cTD.eq(1).find('table').eq(0);

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
                case "姓 名 (英 文)":
                case "Name (English)":
                    this.tmpdataItem.LawyerNameEn = $ctd1;
                    break;
                case "姓 名 (中 文)":
                case "Name (Chinese)":
                    this.tmpdataItem.LawyerNameCn = $ctd1;
                    break;
                case "法 域":
                case "Jurisdiction":
                    this.tmpdataItem.Jurisdiction = $ctd1;
                    break;
                case "前 稱 (中 文)":
                case "Former Name (Chinese)":
                    this.tmpdataItem.BeforeName = $ctd1;
                    break;
                case "在 香 港 認 許 日 期":
                case "Admission in Hong Kong":
                    this.tmpdataItem.ApproveDate = $ctd1;
                    break;
                case "備 註":
                case "Remark":
                    this.tmpdataItem.Remark = $ctd1.replace(/\s/g, "");
                    break;
                case "在 其 他 法 域 認 許 日 期":
                case "Admission in Other Jurisdiction(s)":
                    if ($ctd1Table) {
                        var tmpAlltr = $ctd1Table.find('tr');

                        for (var index = 1; index < tmpAlltr.length; index++) {
                            var tr = tmpAlltr.eq(index);
                            var tdAll = tr.find('td');
                            this.tmpdataItem.ApproveCountry += tdAll.eq(0).text().trim() + ",";
                            this.tmpdataItem.OtherDate += tdAll.eq(1).text().trim() + ",";

                        }
                    } else {
                        this.tmpdataItem.OtherDate = $ctd1;
                    }
                    break;
                case "電 郵 地 址":
                case "Email":
                case "E-mail":
                    if (!this.tmpdataItem.LawyerEmail) {
                        this.tmpdataItem.LawyerEmail = $ctd1;
                    } else {
                        this.tmpdataItem.ComEmail = $ctd1;
                    }

                    break;
                case "職 位":
                case "職 銜":
                case "Title":
                case "Post":
                    this.tmpdataItem.Title = $ctd1;
                    break;
                case "律 師 行 / 公 司 (英 文)":
                case "Firm/Company (English)":
                    this.tmpdataItem.LawyerCompanyEn = $ctd1;
                    break;
                case "律 師 行 / 公 司 (中 文)":
                case "Firm/Company (Chinese)":
                    this.tmpdataItem.LawyerCompanyCn = $ctd1;
                    break;
                case "地 址 (英 文)":
                case "Address (English)":
                    this.tmpdataItem.ComAddressEn = $ctd1;
                    break;
                case "地 址 (中 文)":
                case "Address (Chinese)":
                    this.tmpdataItem.ComAddressCn = $ctd1;
                    break;
                case "電 話":
                case "Telephone":
                    this.tmpdataItem.ComTel = $ctd1;
                    break;
                case "傳 真":
                case "Fax":
                    this.tmpdataItem.ComFax = $ctd1;
                    break;
                case "DX 號 碼":
                case "DX No.":
                    this.tmpdataItem.DxNO = $ctd1;
                    break;

                default:
                    break;
            }
        }
        msgid.text(tmpmsg + "，正在提交第：" + this.tmpdataItem.tname + " 条记录。");
        //console.log(this.tmpdataItem);
        //console.log(_allColNameZH.length + "," + _allColNameZH);
        //提交数据库
        this.tmpdata.i_WithCertLawyers.push(this.tmpdataItem);
        //console.log(this.tmpdata);

        $.ajax({
            type: 'POST',
            url: config.urlApi_withcert,
            tmpdata: this.tmpdata,
            timeout: 80000,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(this.tmpdata)
        }).done(function(data) {
            console.log(_ttype + "," + this.tmpdata.Tid + "," + ",Index:" + this.tmpdata.TIndex + ":中 文 Post Done!");
            // sendMsg('jsonDate', "Set Date Now.");
            //console.log(data);
        }).fail(function(err) {
            //showError
            console.log(err);
        });

    },
    error: function(err) {
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


}
else {
    console.log(this.tmpdata + " 页没有记录。")
}
} else {
    console.log("非指定页面，没有记录。")
}
},
error: function(err) {
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

function gwd_mem_foreignlawyers(btn, msgid) {
    var _allColNameZH = [];
    var _allColNameEN = []
    var _allPage = 100;
    var _allcount = 0;
    var currPage = 1;
    var evenRun = 1;
    var _intervalTime = 35 * 1000;
    var tmpmsg = "";
    var _ttype = "注册外地律师";
    console.log(_ttype + ":采集初始化..");
    msgid.text(_ttype + ":采集初始化..");

    //每10秒开始运行，一次取5个
    var s1_foreignlawyers = window.setInterval(runEven6, _intervalTime);
    runEven6();

    function runEven6() {
        console.clear();
        tmpmsg = _ttype + ",正在运行--》当前更新页:" + currPage + ",总页数:" + _allPage + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun
        console.log(tmpmsg);


        if (currPage < 0) {
            currPage = 1;
        }
        for (var x = 1; x <= evenRun; x++) {

            console.log("CurrNowPage:" + currPage);
            if (currPage > _allPage) {

                clearInterval(s1_foreignlawyers);
                msgid.text("有:" + _allPage + " 页已全部更新完成。总数量为：" + _allcount);
                btn.attr('disabled', null);
                break;
            }

            $.ajax({
                url: configGetUrl.getUrl_fjt2_mem_foreignlawyers,
                data: {
                    name: '',
                    pg: currPage,
                    sj: 0,
                    sort: 'eng',
                    order: '',
                    sessionid: ''
                },
                tmpdata: currPage,
                timeout: 80000,
                type: "get",
                success: function(data, state, xhr) {
                    console.log(this.url);
                    var $body = $('<div></div>').html(data);
                    var $table0 = $body.find('table[width="750"]').eq(0);
                    var $table0TR = $table0.children('tbody').eq(0).children('tr');

                    console.log($table0TR.length);
                    var $table0TR3 = $table0TR.eq(1);
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
                            _allPage = Math.ceil((_allcount) / 50);
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
                                var nameZH = allTd.eq(1).find('a').eq(0);
                                var nameEn = allTd.eq(2).find('a').eq(0);
                                var Jurisdiction = allTd.eq(3).text().trim();

                                var toHref = nameEn.attr('href');
                                var tmpId = GetQueryStringUrl(toHref, "id");
                                console.log(toHref + "," + tmpId + "," + nameEn.text().trim());
                                console.log(nameZH.text().trim());

                                if (tmpId) {
                                    var toPostMain = {
                                        tLang: 0,
                                        tname: tmpId,
                                        ttype: _ttype,
                                        thtml: undefined,
                                        Tid: 0,
                                        Remark: Jurisdiction,
                                        tStatus: 0,
                                        ClientIP: undefined,
                                        addDate: undefined,
                                        UpdateDate: undefined,
                                        i_ForeignLawyers: []
                                    }
                                    var i_ForeignLawyers = {
                                            $id: "1",
                                            htmlID: 0,

                                            LawyerId: tmpId,
                                            LawyerName: nameEn.text().trim(),
                                            LawyerNameCn: nameZH.text().trim(),
                                            BeforeName: undefined,


                                            Title: undefined,
                                            LawyerCompanyEn: undefined,
                                            LawyerCompanyCn: undefined,
                                            ComAddressEn: undefined,
                                            ComAddressCn: undefined,
                                            ComTel: undefined,
                                            ComFax: undefined,
                                            DxNO: undefined,
                                            ComEmail: undefined,

                                            tLang: 0,
                                            tkeyNo: tmpId,
                                            tIndex: 0,
                                            tname: nameId,
                                            ttype: _ttype,
                                            Tid: 0,
                                            Remark: Jurisdiction,
                                            tStatus: 0,
                                            ClientIP: undefined,
                                            addDate: undefined,
                                            UpdateDate: undefined
                                        }
                                        //英文
                                    $.ajax({
                                        url: configGetUrl.getUrl_fjt2_mem_withcertPageEN,
                                        data: {
                                            id: tmpId
                                        },
                                        tmpdata: toPostMain,
                                        tmpdataItem: i_ForeignLawyers,
                                        timeout: 80000,
                                        type: "get",
                                        success: function(data, state, xhr) {
                                            console.log("英文:" + this.url);
                                            var $body = $('<div></div>').html(data);
                                            var $table0 = $body.find('table[width="550"]').eq(0);
                                            var $table0TR = $table0.find('tr');

                                            var $table0TR3Table = $table0TR.eq(0).find('table').eq(0).find('table').eq(0);
                                            var $table0TR3TableChildTR = $table0TR3Table.children('tbody').eq(0).children('tr');
                                            console.log($table0TR3TableChildTR.length);



                                            this.tmpdata.thtml = data;
                                            this.tmpdata.Remark = this.url;
                                            this.tmpdataItem.tLang = 0;

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
                                                    case "姓 名 (英 文)":
                                                    case "Name (English)":
                                                        this.tmpdataItem.LawyerNameEn = $ctd1;
                                                        break;
                                                    case "姓 名 (中 文)":
                                                    case "Name (Chinese)":
                                                        this.tmpdataItem.LawyerNameCn = $ctd1;
                                                        break;
                                                    case "法 域":
                                                    case "Jurisdiction":
                                                        this.tmpdataItem.Jurisdiction = $ctd1;
                                                        break;
                                                    case "前 稱 (中 文)":
                                                    case "Former Name (Chinese)":
                                                        this.tmpdataItem.BeforeName = $ctd1;
                                                        break;
                                                    case "在 香 港 認 許 日 期":
                                                    case "Admission in Hong Kong":
                                                        this.tmpdataItem.ApproveDate = $ctd1;
                                                        break;
                                                    case "備 註":
                                                    case "Remark":
                                                        this.tmpdataItem.Remark = $ctd1;
                                                        break;
                                                    case "在 其 他 法 域 認 許 日 期":
                                                    case "Admission in Other Jurisdiction(s)":
                                                        this.tmpdataItem.OtherDate = $ctd1;
                                                        break;
                                                    case "電 郵 地 址":
                                                    case "Email":
                                                    case "E-mail":
                                                        if (!this.tmpdataItem.LawyerEmail) {
                                                            this.tmpdataItem.LawyerEmail = $ctd1;
                                                        } else {
                                                            this.tmpdataItem.ComEmail = $ctd1;
                                                        }
                                                        break;
                                                    case "職 位":
                                                    case "職 銜":
                                                    case "Title":
                                                    case "Post":
                                                        this.tmpdataItem.Title = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (英 文)":
                                                    case "Firm/Company (English)":
                                                        this.tmpdataItem.LawyerCompanyEn = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (中 文)":
                                                    case "Firm/Company (Chinese)":
                                                        this.tmpdataItem.LawyerCompanyCn = $ctd1;
                                                        break;
                                                    case "地 址 (英 文)":
                                                    case "Address (English)":
                                                        this.tmpdataItem.ComAddressEn = $ctd1;
                                                        break;
                                                    case "地 址 (中 文)":
                                                    case "Address (Chinese)":
                                                        this.tmpdataItem.ComAddressCn = $ctd1;
                                                        break;
                                                    case "電 話":
                                                    case "Telephone":
                                                        this.tmpdataItem.ComTel = $ctd1;
                                                        break;
                                                    case "傳 真":
                                                    case "Fax":
                                                        this.tmpdataItem.ComFax = $ctd1;
                                                        break;
                                                    case "DX 號 碼":
                                                    case "DX No.":
                                                        this.tmpdataItem.DxNO = $ctd1;
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }

                                            msgid.text(tmpmsg + "，正在提交第：" + this.tmpdataItem.tname + " 条记录。");
                                            //console.log(this.tmpdataItem);
                                            //console.log(_allColNameEN.length + "," + _allColNameEN);
                                            //提交数据库
                                            this.tmpdata.i_ForeignLawyers.push(this.tmpdataItem);
                                            $.ajax({
                                                type: 'POST',
                                                url: config.urlApi_foreignlawyers,
                                                tmpdata: this.tmpdata,
                                                timeout: 80000,
                                                contentType: 'application/json; charset=utf-8',
                                                data: JSON.stringify(this.tmpdata)
                                            }).done(function(data) {
                                                console.log(_ttype + "," + this.tmpdata.Tid + "," + ",Index:" + this.tmpdata.TIndex + ":英文 Post Done!");
                                                // sendMsg('jsonDate', "Set Date Now.");
                                                //console.log(data);
                                            }).fail(function(err) {
                                                //showError
                                                console.log(err);
                                            });
                                        },
                                        error: function(err) {
                                            console.log(this.url);
                                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                            console.log(err);
                                        },
                                        dataType: "text"
                                    });
                                    //中文
                                    $.ajax({
                                        url: configGetUrl.getUrl_fjt2_mem_withcertPageCN,
                                        data: {
                                            id: tmpId
                                        },
                                        tmpdata: toPostMain,
                                        tmpdataItem: i_ForeignLawyers,
                                        timeout: 80000,
                                        type: "get",
                                        success: function(data, state, xhr) {
                                            console.log("中文:" + this.url);
                                            var $body = $('<div></div>').html(data);
                                            var $table0 = $body.find('table[width="550"]').eq(0);
                                            var $table0TR = $table0.find('tr');

                                            var $table0TR3Table = $table0TR.eq(0).find('table').eq(0).find('table').eq(0);
                                            var $table0TR3TableChildTR = $table0TR3Table.children('tbody').eq(0).children('tr');
                                            console.log($table0TR3TableChildTR.length);

                                            this.tmpdata.thtml = data;
                                            this.tmpdata.Remark = this.url;
                                            this.tmpdataItem.tLang = 1;

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
                                                // console.log($ctd0 + "," + $ctd1);

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
                                                    case "姓 名 (英 文)":
                                                    case "Name (English)":
                                                        this.tmpdataItem.LawyerNameEn = $ctd1;
                                                        break;
                                                    case "姓 名 (中 文)":
                                                    case "Name (Chinese)":
                                                        this.tmpdataItem.LawyerNameCn = $ctd1;
                                                        break;
                                                    case "法 域":
                                                    case "Jurisdiction":
                                                        this.tmpdataItem.Jurisdiction = $ctd1;
                                                        break;
                                                    case "前 稱 (中 文)":
                                                    case "Former Name (Chinese)":
                                                        this.tmpdataItem.BeforeName = $ctd1;
                                                        break;
                                                    case "在 香 港 認 許 日 期":
                                                    case "Admission in Hong Kong":
                                                        this.tmpdataItem.ApproveDate = $ctd1;
                                                        break;
                                                    case "備 註":
                                                    case "Remark":
                                                        this.tmpdataItem.Remark = $ctd1.replace(/\s/g, "");
                                                        break;
                                                    case "在 其 他 法 域 認 許 日 期":
                                                    case "Admission in Other Jurisdiction(s)":
                                                        this.tmpdataItem.OtherDate = $ctd1;
                                                        break;
                                                    case "電 郵 地 址":
                                                    case "Email":
                                                    case "E-mail":
                                                        if (!this.tmpdataItem.LawyerEmail) {
                                                            this.tmpdataItem.LawyerEmail = $ctd1;
                                                        } else {
                                                            this.tmpdataItem.ComEmail = $ctd1;
                                                        }

                                                        break;
                                                    case "職 位":
                                                    case "職 銜":
                                                    case "Title":
                                                    case "Post":
                                                        this.tmpdataItem.Title = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (英 文)":
                                                    case "Firm/Company (English)":
                                                        this.tmpdataItem.LawyerCompanyEn = $ctd1;
                                                        break;
                                                    case "律 師 行 / 公 司 (中 文)":
                                                    case "Firm/Company (Chinese)":
                                                        this.tmpdataItem.LawyerCompanyCn = $ctd1;
                                                        break;
                                                    case "地 址 (英 文)":
                                                    case "Address (English)":
                                                        this.tmpdataItem.ComAddressEn = $ctd1;
                                                        break;
                                                    case "地 址 (中 文)":
                                                    case "Address (Chinese)":
                                                        this.tmpdataItem.ComAddressCn = $ctd1;
                                                        break;
                                                    case "電 話":
                                                    case "Telephone":
                                                        this.tmpdataItem.ComTel = $ctd1;
                                                        break;
                                                    case "傳 真":
                                                    case "Fax":
                                                        this.tmpdataItem.ComFax = $ctd1;
                                                        break;
                                                    case "DX 號 碼":
                                                    case "DX No.":
                                                        this.tmpdataItem.DxNO = $ctd1;
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }
                                            msgid.text(tmpmsg + "，正在提交第：" + this.tmpdataItem.tname + " 条记录。");
                                            //console.log(this.tmpdataItem);
                                            //console.log(_allColNameZH.length + "," + _allColNameZH);
                                            this.tmpdata.i_ForeignLawyers.push(this.tmpdataItem);
                                            //提交数据库
                                            $.ajax({
                                                type: 'POST',
                                                url: config.urlApi_foreignlawyers,
                                                tmpdata: this.tmpdata,
                                                timeout: 80000,
                                                contentType: 'application/json; charset=utf-8',
                                                data: JSON.stringify(this.tmpdata)
                                            }).done(function(data) {
                                                console.log(_ttype + "," + this.tmpdata.Tid + "," + ",Index:" + this.tmpdata.TIndex + ":中 文 Post Done!");
                                                // sendMsg('jsonDate', "Set Date Now.");
                                                //console.log(data);
                                            }).fail(function(err) {
                                                //showError
                                                console.log(err);
                                            });

                                        },
                                        error: function(err) {
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
                error: function(err) {
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

///////////////////////////////////////
});