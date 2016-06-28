$(function() {
    var allTtype = "注册药剂师名单(Registered Pharmacists)";
    console.log(allTtype + "初始化..");
    $('#btn5').click(function() {
        $('#panel5').removeClass('panel-default')
        $('#panel5').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg5')
        $msg.removeClass('hide')
        gwd_RP_items(allTtype, $(this), $msg);
        //$(this).attr('disabled', null);
    });

    function gwd_RP_items(tmptype, btn, msgid) {
        console.clear();

        var _allTclassCN = {};
        var _allTclassEN = {};

        var _allColNameCN = [];
        var _allColNameEN = [];

        var _tTitle = tmptype;

        var _alltel_directoryCN = [];
        var _alltel_directoryEN = [];


        console.log(_tTitle + ":采集初始化..");
        msgid.text(_tTitle + ":采集初始化..");

        //获取记录 中文/英文一样
        $.ajax({
            url: configGetUrl.getUrl_RP_items,
            data: {
                key: ''
            },
            tmpdata: 0,
            tmpdataLang: 0,
            timeout: (1 * 60 * 1000),
            type: "get",
            success: function(data, state, xhr) {
                console.log(_tTitle + this.url);

                var $body = $('<div></div>').html(data);
                var $table0 = $body.find('#Table_5').eq(0);

                var $Gettable0 = $table0.find('table').eq(0);
                var $Gettable0TR = $Gettable0.find('tr');

                console.log($Gettable0TR.length);

                msgid.text(_tTitle + ":取得数居成功..有：" + $Gettable0TR.length + " 条记录。");

                var postMain = {
                    i_RegPharmacist: [],
                    tLang: this.tmpdataLang,
                    tname: undefined,
                    ttype: _tTitle,
                    thtml: data,
                    Tid: 0,
                    Remark: this.url,
                    tStatus: 0,
                    ClientIP: undefined,
                    addDate: undefined,
                    UpdateDate: undefined
                }

                var tmpid = "";
                var tmpitem = 1;

                for (var x = 1; x < $Gettable0TR.length; x++) {
                    var tr = $Gettable0TR.eq(x);
                    var alltd = tr.children('td');

                    if (!alltd.eq(0).text().trim() && !alltd.eq(1).text().trim()) {
                        console.log("At：" + x + " row is null." + "Text:" + alltd.text());
                        continue;
                    }

                    alltd.eq(1).find('br').replaceWith("@");

                    var nameEn = alltd.eq(1).text().trim();
                    var nameZH = undefined;
                    var nameSp = nameEn.split('@');
                    if (nameSp.length > 1) {
                        nameEn = nameSp[0];
                        nameZH = nameSp[1];
                    }
                    var postItem = {
                        $id: tmpitem,
                        htmlID: 0,

                        RegNo: alltd.eq(0).text().trim(),
                        RegNameEn: nameEn,
                        RegNameCn: nameZH,
                        Qualifications: alltd.eq(3).text().trim(),
                        RegDate: alltd.eq(5).text().trim(),

                        tLang: this.tmpdataLang,
                        tkeyNo: alltd.eq(0).text().trim(),
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

                    postMain.i_RegPharmacist.push(postItem);

                    tmpitem += 1;
                }
                ///end for
                postMain.tname = _tTitle + ":" + postMain.i_RegPharmacist.length;
                //console.log(postMain);
                msgid.text(postMain.tname + "条，分析数据完成,准备更新到数据库..");
                //提交数据库
                $.ajax({
                    type: 'POST',
                    url: config.urlApi_RP_items,
                    tmpdata: postMain,
                    timeout: 80000,
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(postMain)
                }).done(function(data) {
                    console.log(_tTitle + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                    // sendMsg('jsonDate', "Set Date Now.");
                    //console.log(data);
                    msgid.text(_tTitle + " 更新完成，已更新：" + this.tmpdata.i_RegPharmacist.length + " 条成功.");
                    btn.attr('disabled', null);
                }).fail(function(err) {
                    //showError
                    config.log(this.url);
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