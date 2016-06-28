$(function() {
    var allTtype = "香港特别行政区政府保安局";
    console.log(allTtype + "初始化..");
    $('#btn11').click(function() {
        $('#panel11').removeClass('panel-default')
        $('#panel11').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg11')
        $msg.removeClass('hide')
        gwd_SB_items(allTtype, $(this), $msg);
        //$(this).attr('disabled', null);
    });



    function gwd_SB_items(tmptype, btn, msgid) {
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
            url: configGetUrl.getUrl_SB_items,
            data: {
                fi: 'public',
                lang: 1
            },
            tmpdata: 0,
            tmpdataLang: 0,
            timeout: (1 * 60 * 1000),
            type: "get",
            success: function(data, state, xhr) {
                console.log(_tTitle + this.url);

                var $body = $('<div></div>').html(data);
                var $table0 = $body.find('ol');

                var $Gettable0 = $table0.eq(0);
                var $Gettable0TR = $Gettable0.find('li');

                console.log($Gettable0TR.length);

                msgid.text(_tTitle + ":取得数居成功..有：" + $Gettable0TR.length + " 条记录。");

                var postMain = {
                    i_SecurityBureau: [],
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
                    tr.find('br').replaceWith("@");

                    var allText = tr.text().split('@');

                    // console.log(allText.length);
                    // console.log(allText);

                    if (!allText[0].trim() && !allText[1].trim() && allText.length < 7) {
                        console.log("At：" + x + " row is null." + "Text:" + allText);
                        continue;
                    }

                    var postItem = {
                        $id: tmpitem,
                        htmlID: 0,
                        SecurityComId: tmpitem,
                        tLang: this.tmpdataLang,
                        tkeyNo: undefined,
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
                    switch (allText.length) {
                        case 7:
                            postItem.CompanyNameEn = allText[0].trim();
                            postItem.CompanyNameCn = undefined;
                            postItem.WorkType = allText[1].substring(allText[1].indexOf(':') + 1).trim();
                            postItem.LicenceNo = allText[2].substring(allText[2].indexOf(':') + 1).trim();
                            postItem.address = allText[3].substring(allText[3].indexOf(':') + 1).trim();
                            postItem.Tel = allText[4].substring(allText[4].indexOf(':') + 1).trim();
                            break;
                        case 8:
                            postItem.CompanyNameEn = allText[0].trim();
                            postItem.CompanyNameCn = allText[1].trim();
                            postItem.WorkType = allText[2].substring(allText[2].indexOf(':') + 1).trim();
                            postItem.LicenceNo = allText[3].substring(allText[3].indexOf(':') + 1).trim();
                            postItem.address = allText[4].substring(allText[4].indexOf(':') + 1).trim();
                            postItem.Tel = allText[5].substring(allText[5].indexOf(':') + 1).trim();
                            break;

                        default:
                            break;
                    }
                    postItem.tkeyNo = postItem.LicenceNo ? postItem.LicenceNo : tmpitem;
                    postMain.i_SecurityBureau.push(postItem);

                    tmpitem += 1;
                }
                ///end for
                postMain.tname = _tTitle + ":" + postMain.i_SecurityBureau.length;
                console.log(postMain);

                msgid.text(postMain.tname + "条，分析数据完成,准备更新到数据库..");
                //提交数据库
                $.ajax({
                    type: 'POST',
                    url: config.urlApi_SB_items,
                    tmpdata: postMain,
                    timeout: 80000,
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(postMain)
                }).done(function(data) {
                    console.log(_tTitle + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                    // sendMsg('jsonDate', "Set Date Now.");
                    //console.log(data);
                    msgid.text(_tTitle + " 更新完成，已更新：" + this.tmpdata.i_SecurityBureau.length + " 条成功.");
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