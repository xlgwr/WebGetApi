$(function() {
    console.log("香港特别行政区政府及有关机构电话薄初始化..");
    $('#btn4').click(function() {
        $('#panel4').removeClass('panel-default')
        $('#panel4').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg4')
        $msg.removeClass('hide')
        gwd_tel_directory($(this), $msg);
        //$(this).attr('disabled', null);
    });

    function getEmail(str) {
        try {
            var dd = str.split("'");
            return dd[1] + '@' + dd[3];
        } catch (error) {
            console.log(error);
            return undefined;
        }
    }

    function gwd_tel_directory(btn, msgid) {
        console.clear();

        var _allTclassCN = {};
        var _allTclassEN = {};

        var _allColNameCN = [];
        var _allColNameEN = [];

        var _tTitle = "电话薄";

        var _alltel_directoryCN = [];
        var _alltel_directoryEN = [];


        console.log(_tTitle + ":采集初始化..");
        msgid.text(_tTitle + ":采集初始化..");

        //获取记录 中文
        $.ajax({
            url: configGetUrl.getUrl_tel_directory,
            data: {
                accept_disclaimer: 'yes'
            },
            tmpdata: 0,
            timeout: 50000,
            type: "get",
            success: function(data, state, xhr) {
                console.log(_tTitle + this.url);
                var $body = $('<div></div>').html(data);
                var $table0 = $body.find('#tbl_dept_list').eq(0);
                var $table0TR = $table0.children('tbody').eq(0).children('tr');

                console.log($table0TR.length);

                var tmpid = "";
                var tmpitem = 1;
                for (var x = 0; x < $table0TR.length; x++) {
                    var tr = $table0TR.eq(x);
                    var alltd = tr.children('td');

                    if (!alltd.eq(0).text().trim() && !alltd.eq(1).text().trim()) {
                        console.log(x + " is null.");
                        continue;
                    }

                    var $td1 = alltd.eq(1)
                    var tmpname = $td1.text().trim();

                    if (alltd.eq(0).text().trim()) {
                        tmpid = alltd.eq(0).text();
                        _allTclassCN[tmpid] = tmpname;
                    }

                    var $td1A = $td1.find('a').eq(0);
                    var tmpurl = $td1A.attr('href');

                    if (!tmpurl) {
                        continue;
                    }

                    var curitem = {
                        id: tmpid,
                        itemNo: tmpitem,
                        tClass: _allTclassCN[tmpid],
                        tTitle: tmpname,
                        url: tmpurl
                    }
                    _alltel_directoryCN.push(curitem);
                    tmpitem += 1;
                } //
                ///end for
                //console.log(_alltel_directoryCN);

                //获取明细
                getItems_alltel_directoryCN(1, _tTitle + "(中文)", "电话薄");

            },
            error: function(err) {
                console.log(_tTitle + this.url);
                console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                console.log(err);
            },
            dataType: "text"
        });
        ///////////////////////////////////////
        //获取记录 中文 明细
        function getItems_alltel_directoryCN(tindex, typemsg, settype) {
            var _langFlag = 1;
            var _ttype = settype;
            var currX = 0;
            var evenRun = 1;
            var currCount = _alltel_directoryCN.length;

            var _intervalTime = 35 * 1000;
            var tmpmsg = _tTitle;


            var s1_tel_directoryCN = window.setInterval(evenRuntel_directoryCN, _intervalTime);
            evenRuntel_directoryCN();

            function evenRuntel_directoryCN() {
                console.clear();

                tmpmsg = _tTitle + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
                console.log(tmpmsg);
                msgid.text(tmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX >= currCount) {
                        tmpmsg = _tTitle + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(tmpmsg);
                        msgid.text(tmpmsg);
                        clearInterval(s1_tel_directoryCN);
                        btn.attr('disabled', null);
                        break;
                    }

                    var currItem = _alltel_directoryCN[currX];
                    console.log(currItem);

                    //获取明细-下级
                    $.ajax({
                        url: configGetUrl.getUrl_tel_directory_prefix + currItem.url,
                        data: {
                            accept_disclaimer: 'yes'
                        },
                        tmpdata: currItem,
                        timeout: 50000,
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(_tTitle + "," + this.tmpdata.tTitle + "," + this.url);
                            var $body = $('<div></div>').html(data);
                            var $table0 = $body.find('#content_container').eq(0);
                            var $divList = $table0.find('#dept_list_lv2_outline').eq(0);
                            var $getAllaLink = $divList.find('a');

                            console.log($getAllaLink.length);
                            for (var a = 0; a < $getAllaLink.length; a++) {
                                var currA = $getAllaLink.eq(a);
                                var currTitle = this.tmpdata.tTitle + "-" + currA.text().trim();
                                var currHref = configGetUrl.getUrl_tel_directory_prefix + currA.attr('href')
                                console.log(currTitle + ":" + currHref);

                                //获取电话号，提交
                                $.ajax({
                                    url: currHref,
                                    data: {
                                        accept_disclaimer: 'yes'
                                    },
                                    tmpdata: currTitle,
                                    tmpID: this.tmpdata.itemNo,
                                    timeout: 50000,
                                    type: "get",
                                    success: function(data, state, xhr) {
                                        console.log(_tTitle + "," + this.tmpdata + "," + this.url);
                                        var $body = $('<div></div>').html(data);
                                        var $table0 = $body.find('#content_container').eq(0);
                                        var $table0TR = $table0.find('.tbl_dept_contact').eq(0).children('tbody').eq(0).children('tr');
                                        var $table1TR = $table0.find('.tbl_dept_contact_list').eq(0).children('tbody').eq(0).children('tr');

                                        console.log(this.tmpdata + ",tbl_dept_contact:" + $table0TR.length);
                                        console.log(this.tmpdata + ",tbl_dept_contact_list:" + $table1TR.length);

                                        var postMain = {
                                            i_GovPhonebook: [],
                                            tLang: _langFlag,
                                            tname: this.tmpdata,
                                            ttype: _ttype,
                                            thtml: data,
                                            Tid: 0,
                                            Remark: this.url,
                                            tStatus: 0,
                                            ClientIP: undefined,
                                            addDate: undefined,
                                            UpdateDate: undefined
                                        }
                                        var postItemTop = {
                                                $id: 1,
                                                htmlID: 0,
                                                GovId: this.tmpID,
                                                GovName: this.tmpdata,
                                                FullName: undefined,
                                                PostTitle: undefined,
                                                OfficePhone: undefined,
                                                Email: undefined,
                                                Address: undefined,
                                                Fax: undefined,
                                                tLang: _langFlag,
                                                tkeyNo: this.tmpdata,
                                                tIndex: 1,
                                                tname: undefined,
                                                ttype: _ttype,
                                                Tid: 0,
                                                Remark: this.url,
                                                tStatus: 1,
                                                ClientIP: undefined,
                                                addDate: undefined,
                                                UpdateDate: undefined
                                            }
                                            //电话薄，列表头
                                        for (var r = 1; r < $table0TR.length; r++) {
                                            var tr = $table0TR.eq(r);
                                            var alltd = tr.children('td');

                                            var tmptitle = alltd.eq(0).text().trim();
                                            var $ctd1 = alltd.eq(1).text().trim();

                                            //console.log("Title:" + tmptitle);
                                            if (_allColNameCN.indexOf(tmptitle) < 0) {
                                                _allColNameCN.push(tmptitle);
                                            }
                                            //["地址", "辦公室電話", "傳真", "電郵"]
                                            switch (tmptitle) {
                                                case "地址":
                                                case "Address":
                                                    postItemTop.Address = $ctd1;
                                                    break;
                                                case "辦公室電話":
                                                case "Office Tel":
                                                    postItemTop.OfficePhone = $ctd1;
                                                    break;
                                                case "傳真":
                                                case "Fax":
                                                    postItemTop.Fax = $ctd1;
                                                    break;
                                                case "電郵":
                                                case "Email":
                                                    postItemTop.Email = getEmail($ctd1);
                                                    break;
                                                default:
                                                    break;
                                            }

                                        }
                                        postMain.i_GovPhonebook.push(postItemTop);
                                        //
                                        //console.log(_allColNameCN);
                                        //列表明细
                                        for (var r = 1; r < $table1TR.length; r++) {
                                            var tr = $table1TR.eq(r);
                                            var alltd = tr.children('td');
                                            var tmpemail = alltd.eq(3).text().trim();

                                            var postItem = {
                                                    $id: (r + 1),
                                                    htmlID: 0,
                                                    GovId: this.tmpID,
                                                    GovName: this.tmpdata,
                                                    FullName: alltd.eq(0).text().trim(),
                                                    PostTitle: alltd.eq(1).text().trim(),
                                                    OfficePhone: alltd.eq(2).text().trim(),
                                                    Email: getEmail(tmpemail),
                                                    tLang: _langFlag,
                                                    tkeyNo: this.tmpdata,
                                                    tIndex: (r + 1),
                                                    tname: undefined,
                                                    ttype: _ttype,
                                                    Tid: 0,
                                                    Remark: this.url,
                                                    tStatus: 0,
                                                    ClientIP: undefined,
                                                    addDate: undefined,
                                                    UpdateDate: undefined
                                                }
                                                //
                                            postMain.i_GovPhonebook.push(postItem);
                                        }
                                        //end

                                        //console.log(postMain);

                                        //提交数据库
                                        $.ajax({
                                            type: 'POST',
                                            url: config.urlApi_directory,
                                            tmpdata: postMain,
                                            timeout: 50000,
                                            contentType: 'application/json; charset=utf-8',
                                            data: JSON.stringify(postMain)
                                        }).done(function(data) {
                                            console.log(_tTitle + "," + this.tmpdata.tname + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                                            // sendMsg('jsonDate', "Set Date Now.");
                                            //console.log(data);
                                        }).fail(function(err) {
                                            //showError
                                            console.log(this.tmpdata);
                                            console.log(err);
                                        });
                                        ////////////////////////////////////


                                    },
                                    error: function(err) {
                                        console.log(_tTitle + "," + this.tmpdata + "," + this.url);
                                        console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                        console.log(err);
                                    },
                                    dataType: "text"
                                });

                                ////////////end ajax
                            }
                            ///////////////////////////end for

                        },
                        error: function(err) {
                            console.log(_tTitle + "," + this.tmpdata.tTitle + "," + this.url);
                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                            console.log(err);
                        },
                        dataType: "text"
                    });
                    ///////////////////end ajax


                    /////////////////////////////
                    currX += 1;
                }
            }
        }
        /////////////////////

        //获取记录 英文
        $.ajax({
            url: configGetUrl.getUrl_tel_directoryEN,
            data: {
                accept_disclaimer: 'yes'
            },
            tmpdata: 0,
            timeout: 50000,
            type: "get",
            success: function(data, state, xhr) {
                console.log(_tTitle + this.url);
                var $body = $('<div></div>').html(data);
                var $table0 = $body.find('#tbl_dept_list').eq(0);
                var $table0TR = $table0.children('tbody').eq(0).children('tr');

                console.log($table0TR.length);

                var tmpid = "";
                var tmpitem = 1;
                for (var x = 0; x < $table0TR.length; x++) {
                    var tr = $table0TR.eq(x);
                    var alltd = tr.children('td');

                    if (!alltd.eq(0).text().trim() && !alltd.eq(1).text().trim()) {
                        console.log(x + " is null.");
                        continue;
                    }

                    var $td1 = alltd.eq(1)
                    var tmpname = $td1.text().trim();

                    if (alltd.eq(0).text().trim()) {
                        tmpid = alltd.eq(0).text();
                        _allTclassCN[tmpid] = tmpname;
                    }

                    var $td1A = $td1.find('a').eq(0);
                    var tmpurl = $td1A.attr('href');

                    if (!tmpurl) {
                        continue;
                    }

                    var curitem = {
                        id: tmpid,
                        itemNo: tmpitem,
                        tClass: _allTclassCN[tmpid],
                        tTitle: tmpname,
                        url: tmpurl
                    }
                    _alltel_directoryEN.push(curitem);
                    tmpitem += 1;
                } //
                ///end for
                //console.log(_alltel_directoryCN);

                //获取明细
                getItems_alltel_directoryEN(1, _tTitle + "(英文)", "Full List");

            },
            error: function(err) {
                console.log(_tTitle + this.url);
                console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                console.log(err);
            },
            dataType: "text"
        });
        ///////////////////////////////////////
        //获取记录 英文 明细
        function getItems_alltel_directoryEN(tindex, typemsg, settype) {
            var _langFlag = 0;
            var _ttype = settype;
            var currX = 0;
            var evenRun = 1;
            var currCount = _alltel_directoryEN.length;

            var _intervalTime = 25 * 1000;
            var tmpmsg = _tTitle;


            var s1_tel_directoryEN = window.setInterval(evenRuntel_directoryEN, _intervalTime);
            evenRuntel_directoryEN();

            function evenRuntel_directoryEN() {
                console.clear();
                tmpmsg = _tTitle + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
                console.log(tmpmsg);
                msgid.text(tmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX >= currCount) {
                        tmpmsg = _tTitle + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(tmpmsg);
                        msgid.text(tmpmsg);
                        clearInterval(s1_tel_directoryEN);
                        break;
                    }

                    var currItem = _alltel_directoryEN[currX];
                    console.log(currItem);

                    //获取明细-下级
                    $.ajax({
                        url: configGetUrl.getUrl_tel_directory_prefix + currItem.url,
                        data: {
                            accept_disclaimer: 'yes'
                        },
                        tmpdata: currItem,
                        timeout: 50000,
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(_tTitle + "," + this.tmpdata.tTitle + "," + this.url);
                            var $body = $('<div></div>').html(data);
                            var $table0 = $body.find('#content_container').eq(0);
                            var $divList = $table0.find('#dept_list_lv2_outline').eq(0);
                            var $getAllaLink = $divList.find('a');

                            console.log($getAllaLink.length);



                            for (var a = 0; a < $getAllaLink.length; a++) {
                                var currA = $getAllaLink.eq(a);
                                var currTitle = this.tmpdata.tTitle + "-" + currA.text().trim();
                                var currHref = configGetUrl.getUrl_tel_directory_prefix + currA.attr('href')
                                console.log(currTitle + ":" + currHref);

                                //获取电话号，提交
                                $.ajax({
                                    url: currHref,
                                    data: {
                                        accept_disclaimer: 'yes'
                                    },
                                    tmpdata: currTitle,
                                    tmpID: this.tmpdata.itemNo,
                                    timeout: (2 * 60 * 1000),
                                    type: "get",
                                    success: function(data, state, xhr) {
                                        console.log(_tTitle + "," + this.tmpdata + "," + this.url);
                                        var $body = $('<div></div>').html(data);
                                        var $table0 = $body.find('#content_container').eq(0);
                                        var $table0TR = $table0.find('.tbl_dept_contact').eq(0).children('tbody').eq(0).children('tr');
                                        var $table1TR = $table0.find('.tbl_dept_contact_list').eq(0).children('tbody').eq(0).children('tr');

                                        console.log(this.tmpdata + ",tbl_dept_contact:" + $table0TR.length);
                                        console.log(this.tmpdata + ",tbl_dept_contact_list:" + $table1TR.length);

                                        var postMain = {
                                            i_GovPhonebook: [],
                                            tLang: _langFlag,
                                            tname: this.tmpdata,
                                            ttype: _ttype,
                                            thtml: data,
                                            Tid: 0,
                                            Remark: this.url,
                                            tStatus: 0,
                                            ClientIP: undefined,
                                            addDate: undefined,
                                            UpdateDate: undefined
                                        }
                                        var postItemTop = {
                                                $id: 1,
                                                htmlID: 0,
                                                GovId: this.tmpID,
                                                GovName: this.tmpdata,
                                                FullName: undefined,
                                                PostTitle: undefined,
                                                OfficePhone: undefined,
                                                Email: undefined,
                                                Address: undefined,
                                                Fax: undefined,
                                                tLang: _langFlag,
                                                tkeyNo: this.tmpdata,
                                                tIndex: 1,
                                                tname: undefined,
                                                ttype: _ttype,
                                                Tid: 0,
                                                Remark: this.url,
                                                tStatus: 1,
                                                ClientIP: undefined,
                                                addDate: undefined,
                                                UpdateDate: undefined
                                            }
                                            //电话薄，列表头
                                        for (var r = 1; r < $table0TR.length; r++) {
                                            var tr = $table0TR.eq(r);
                                            var alltd = tr.children('td');

                                            var tmptitle = alltd.eq(0).text().trim();
                                            var $ctd1 = alltd.eq(1).text().trim();

                                            //console.log("Title:" + tmptitle);
                                            if (_allColNameCN.indexOf(tmptitle) < 0) {
                                                _allColNameCN.push(tmptitle);
                                            }
                                            //["地址", "辦公室電話", "傳真", "電郵"]
                                            switch (tmptitle) {
                                                case "地址":
                                                case "Address":
                                                    postItemTop.Address = $ctd1;
                                                    break;
                                                case "辦公室電話":
                                                case "Office Tel":
                                                    postItemTop.OfficePhone = $ctd1;
                                                    break;
                                                case "傳真":
                                                case "Fax":
                                                    postItemTop.Fax = $ctd1;
                                                    break;
                                                case "電郵":
                                                case "Email":
                                                    postItemTop.Email = getEmail($ctd1);
                                                    break;
                                                default:
                                                    break;
                                            }

                                        }
                                        postMain.i_GovPhonebook.push(postItemTop);
                                        //
                                        //console.log(_allColNameCN);
                                        //列表明细
                                        for (var r = 1; r < $table1TR.length; r++) {
                                            var tr = $table1TR.eq(r);
                                            var alltd = tr.children('td');
                                            var tmpemail = alltd.eq(3).text().trim();

                                            var postItem = {
                                                    $id: (r + 1),
                                                    htmlID: 0,
                                                    GovId: this.tmpID,
                                                    GovName: this.tmpdata,
                                                    FullName: alltd.eq(0).text().trim(),
                                                    PostTitle: alltd.eq(1).text().trim(),
                                                    OfficePhone: alltd.eq(2).text().trim(),
                                                    Email: getEmail(tmpemail),
                                                    tLang: _langFlag,
                                                    tkeyNo: this.tmpdata,
                                                    tIndex: (r + 1),
                                                    tname: undefined,
                                                    ttype: _ttype,
                                                    Tid: 0,
                                                    Remark: this.url,
                                                    tStatus: 0,
                                                    ClientIP: undefined,
                                                    addDate: undefined,
                                                    UpdateDate: undefined
                                                }
                                                //
                                            postMain.i_GovPhonebook.push(postItem);
                                        }
                                        //end

                                        //console.log(postMain);

                                        //提交数据库
                                        $.ajax({
                                            type: 'POST',
                                            url: config.urlApi_directory,
                                            tmpdata: postMain,
                                            timeout: 50000,
                                            contentType: 'application/json; charset=utf-8',
                                            data: JSON.stringify(postMain)
                                        }).done(function(data) {
                                            console.log(_tTitle + "," + this.tmpdata.tname + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                                            // sendMsg('jsonDate', "Set Date Now.");
                                            //console.log(data);
                                        }).fail(function(err) {
                                            //showError
                                            console.log(this.tmpdata);
                                            console.log(err);
                                        });
                                        ////////////////////////////////////


                                    },
                                    error: function(err) {
                                        console.log(_tTitle + "," + this.tmpdata + "," + this.url);
                                        console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                                        console.log(err);
                                    },
                                    dataType: "text"
                                });

                                ////////////end ajax
                            }
                            ///////////////////////////end for

                        },
                        error: function(err) {
                            console.log(_tTitle + "," + this.tmpdata.tTitle + "," + this.url);
                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                            console.log(err);
                        },
                        dataType: "text"
                    });
                    ///////////////////end ajax


                    /////////////////////////////
                    currX += 1;
                }
            }
        }
    }
});