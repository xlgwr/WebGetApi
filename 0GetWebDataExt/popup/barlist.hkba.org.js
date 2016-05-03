$(function () {
    console.log("香港大律师初始化..");
    $('#btn1hklaw3').click(function () {
        $('#panelhklaw3').removeClass('panel-default')
        $('#panelhklaw3').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg3')
        $msg.removeClass('hide')
        gwd_hkba_barlist($(this), $msg);
        //$(this).attr('disabled', null);
    });
});

function gwd_hkba_barlist(btn, msgid) {
    console.clear();

    var _allColNameZH = [];
    var _allColNameEN = [];

    ///資深大律師
    var _allColNameList_seniorityZH = [];
    //大律師
    var _allColNameList_JuniorCounselZH = [];

    ///資深大律師
    var _allColNameList_seniorityEH = [];
    //大律師
    var _allColNameList_JuniorCounselEH = [];

    var _allcount = 0;
    var currPage = 1;
    var evenRun = 10;
    var _intervalTime = 25 * 1000;
    var tmpmsg = "";
    var _ttype = "香港大律师";


    console.log(_ttype + ":采集初始化..");
    msgid.text(_ttype + ":采集初始化..");

    //btn.attr('disabled', null);

    //获取记录 資深大律師 中文
    $.ajax({
        url: configGetUrl.getUrl_hkba_seniority_CN,
        //data: { name: '', pg: currPage, sj: 0 },
        tmpdata: currPage,
        timeout: 50000,
        type: "get",
        success: function (data, state, xhr) {
            console.log(this.url);
            var $body = $('<div></div>').html(data);
            var $table0 = $body.find('table[border="1"]').eq(0);
            var $table0TR = $table0.find('tr');

            console.log($table0TR.length);

            for (var x = 0; x < $table0TR.length; x++) {
                var tr = $table0TR.eq(x);
                var alltd = tr.children('td');

                var $td1 = alltd.eq(1)
                var $td1A = $td1.find('a').eq(0);
                var tmpid = $td1A.attr('href');
                var tmpname = $td1A.text().trim();
                var tmpsex = '男';
                if (tmpname.indexOf("女士") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf('女士') - 2)
                }
                if (tmpname.indexOf("(Ms)") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf("(Ms)") - 1)
                }
                if (tmpname.indexOf("S.C.") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('S.C.') - 2)
                }
                if (tmpname.indexOf("名譽資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('名譽資深大律師') - 1)
                }
                if (tmpname.indexOf("資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('資深大律師') - 1)
                }
                var curitem = {
                    id: tmpid,
                    LawyerName: tmpname,
                    Sex: tmpsex,
                    Title: "資深大律師"
                }

                _allColNameList_seniorityZH.push(curitem);
            }
            ///
            //console.log(_allColNameList_seniorityZH);

            //获取明细
            getItems_seniorityStep5(1, "資深大律師(中文)");
        },
        error: function (err) {
            console.log("資深大律師:" + this.url);
            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
            console.log(err);
        },
        dataType: "text"
    });
    //获取记录 資深大律師 中文 明细
    function getItems_seniorityStep5(tindex, typemsg) {
        var currX = 0;
        var evenRun = 15;
        var currCount = _allColNameList_seniorityZH.length;

        var _intervalTime = 5 * 1000;
        var tmpmsg = _ttype;


        var s1_hkbaZh1 = window.setInterval(evenRunhkbaZh, _intervalTime);
        evenRunhkbaZh();

        function evenRunhkbaZh() {
            tmpmsg = _ttype + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
            console.log(tmpmsg);
            msgid.text(tmpmsg);

            for (var x = 0; x < evenRun; x++) {

                if (currX >= currCount) {
                    tmpmsg = _ttype + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                    console.log(tmpmsg);
                    msgid.text(tmpmsg);
                    clearInterval(s1_hkbaZh1);
                    break;
                }

                var currItem = _allColNameList_seniorityZH[currX];

                $.ajax({
                    url: configGetUrl.getUrl_hkba_seniority_details_CN + currItem.id,
                    //data: { name: '', pg: currPage, sj: 0 },
                    tmpdata: currItem,
                    timeout: 50000,
                    type: "get",
                    success: function (data, state, xhr) {
                        console.log(this.url);
                        var $body = $('<div></div>').html(data);
                        var $div0 = $body.children('div').eq(0);
                        var $table0 = $div0.children('table').eq(0);
                        var $table0TR = $table0.find('tr');

                        var $table0NextAllTable = $div0.find('table');

                        var tmpIsMandarin = "";
                        if ($table0NextAllTable.length > 3) {
                            tmpIsMandarin = $table0NextAllTable.eq(2).text().trim();
                        }


                        console.log($table0TR.length);
                        console.log($table0NextAllTable.length);
                        var toPostMain = {
                            tLang: tindex,
                            tname: this.tmpdata.id.split(".")[0],
                            ttype: this.tmpdata.Title,
                            thtml: data,
                            Tid: 0,
                            Remark: this.url,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined,
                            gwd_Barristers_items: []
                        }
                        var postItem = {
                            tLang: tindex,
                            tkeyNo: this.tmpdata.id.split(".")[0],
                            tIndex: 0,
                            Tid: 0,
                            LawyerName: this.tmpdata.LawyerName,
                            ChineseName: this.tmpdata.LawyerName,
                            Sex: this.tmpdata.Sex,
                            Title: this.tmpdata.Title,
                            Address: undefined,
                            Telphone: undefined,
                            Mobile: undefined,
                            Fax: undefined,
                            PracticeAreas: undefined,
                            Email: undefined,
                            Quals: undefined,
                            ApproveYear: undefined,
                            IsMandarin: tmpIsMandarin,
                            tname: undefined,
                            ttype: this.tmpdata.Title,
                            tcontent: undefined,
                            tGetTable: undefined,
                            thtml: data,
                            Remark: undefined,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        for (var m = 0; m < $table0TR.length; m++) {
                            var tr = $table0TR.eq(m);
                            var cTD = tr.children('td');
                            if (cTD.length < 2) {
                                continue;
                            }
                            var $ctd0 = cTD.eq(0).text().trim();
                            var $ctd1 = cTD.eq(1).text().trim();
                            if (!$ctd0) {
                                continue;
                            }

                            if (_allColNameZH.indexOf($ctd0) < 0) {
                                _allColNameZH.push($ctd0);
                            }

                            // ["地址:", "電話:", "傳真:", "", "認許年份:", "電郵:", "執業範圍:", "學歷/資歷:", "手提電話:"]
                            //["Address:", "Tel. No.:", "Fax  No.:", "Call:", "Areas of Practice:", "E-mail:", "Quals:", "Mob:"]
                            switch ($ctd0) {
                                case "地址:": case "Address:":
                                    postItem.Address = $ctd1;
                                    break;
                                case "電話:": case "Tel. No.:":
                                    postItem.Telphone = $ctd1;
                                    break;
                                case "傳真:": case "Fax  No.:":
                                    postItem.Fax = $ctd1;
                                    break;
                                case "認許年份:": case "Call:":
                                    postItem.ApproveYear = $ctd1;
                                    break;
                                case "電郵:": case "E-mail:":
                                    postItem.Email = $ctd1;
                                    break;
                                case "執業範圍:": case "Areas of Practice:":
                                    postItem.PracticeAreas = $ctd1;
                                    break;
                                case "學歷/資歷:": case "Quals:":
                                    postItem.Quals = $ctd1;
                                    break;
                                case "手提電話:": case "Mob:":
                                    postItem.Mobile = $ctd1;
                                    break;
                                default:
                                    break;
                            }
                        }

                        /////
                        //console.log(_allColNameZH);
                        //console.log(postItem);
                        toPostMain.gwd_Barristers_items.push(postItem);
                        //提交数据库
                        $.ajax({
                            type: 'POST',
                            url: config.urlApi_hkba,
                            tmpdata: toPostMain,
                            timeout: 50000,
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(toPostMain)
                        }).done(function (data) {
                            console.log(_ttype + "," + typemsg + "," + this.tmpdata.tname + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                            // sendMsg('jsonDate', "Set Date Now.");
                            //console.log(data);
                        }).fail(function (err) {
                            //showError
                            console.log(this.tmpdata);
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
                /////////////////////////////
                currX += 1;
            }
        }
    }

    //获取记录 資深大律師 英文
    $.ajax({
        url: configGetUrl.getUrl_hkba_seniority_EN,
        //data: { name: '', pg: currPage, sj: 0 },
        tmpdata: currPage,
        timeout: 50000,
        type: "get",
        success: function (data, state, xhr) {
            console.log(this.url);
            var $body = $('<div></div>').html(data);
            var $table0 = $body.find('table[border="1"]').eq(0);
            var $table0TR = $table0.find('tr');

            console.log($table0TR.length);

            for (var x = 0; x < $table0TR.length; x++) {
                var tr = $table0TR.eq(x);
                var alltd = tr.children('td');

                var $td1 = alltd.eq(1)
                var $td1A = $td1.find('a').eq(0);
                var tmpid = $td1A.attr('href');
                var tmpname = $td1A.text().trim();

                var tmpsex = '男';
                if (tmpname.indexOf("(女士)") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf('(女士)') - 1)
                }
                if (tmpname.indexOf("(Ms)") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf('(Ms)') - 1)
                }
                if (tmpname.indexOf("S.C.") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('S.C.') - 2)
                }
                if (tmpname.indexOf("名譽資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('名譽資深大律師') - 1)
                }
                if (tmpname.indexOf("資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('資深大律師') - 1)
                }
                var curitem = {
                    id: tmpid,
                    LawyerName: tmpname,
                    Sex: tmpsex,
                    Title: "Senior Counsel"
                }

                _allColNameList_seniorityEH.push(curitem);
            }
            ///
            //console.log(_allColNameList_seniorityZH);

            //获取明细
            getItems_Counsel_EnStep5(0, "資深大律師 英文");
        },
        error: function (err) {
            console.log(this.url);
            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
            console.log(err);
        },
        dataType: "text"
    });
    //获取记录 資深大律師 英文 明细
    function getItems_Counsel_EnStep5(tindex, typemsg) {
        var currX = 0;
        var evenRun = 15;
        var currCount = _allColNameList_seniorityEH.length;

        var _intervalTime = 6 * 1000;
        var tmpmsg = _ttype;


        var s1_hkbaEN1 = window.setInterval(evenRunhkbaEN1, _intervalTime);
        evenRunhkbaEN1();

        function evenRunhkbaEN1() {
            tmpmsg = _ttype + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
            console.log(tmpmsg);
            msgid.text(tmpmsg);

            for (var x = 0; x < evenRun; x++) {

                if (currX >= currCount) {
                    tmpmsg = _ttype + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                    console.log(tmpmsg);
                    msgid.text(tmpmsg);
                    clearInterval(s1_hkbaEN1);
                    break;
                }

                var currItem = _allColNameList_seniorityEH[currX];

                $.ajax({
                    url: configGetUrl.getUrl_hkba_seniority_details_EN + currItem.id,
                    //data: { name: '', pg: currPage, sj: 0 },
                    tmpdata: currItem,
                    timeout: 50000,
                    type: "get",
                    success: function (data, state, xhr) {
                        console.log(typemsg + "," + this.url);
                        var $body = $('<div></div>').html(data);
                        var $div0 = $body.children('div').eq(0);
                        var $table0 = $div0.children('table').eq(0);
                        var $table0TR = $table0.find('tr');

                        var $table0NextAllTable = $div0.find('table');

                        var tmpIsMandarin = "";
                        if ($table0NextAllTable.length > 3) {
                            tmpIsMandarin = $table0NextAllTable.eq(2).text().trim();
                        }


                        console.log($table0TR.length);
                        console.log($table0NextAllTable.length);

                        var toPostMain = {
                            tLang: tindex,
                            tname: this.tmpdata.id.split(".")[0],
                            ttype: this.tmpdata.Title,
                            thtml: data,
                            Tid: 0,
                            Remark: this.url,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined,
                            gwd_Barristers_items: []
                        }
                        var postItem = {
                            tLang: tindex,
                            tkeyNo: this.tmpdata.id.split(".")[0],
                            tIndex: 0,
                            Tid: 0,
                            LawyerName: this.tmpdata.LawyerName,
                            ChineseName: this.tmpdata.LawyerName,
                            Sex: this.tmpdata.Sex,
                            Title: this.tmpdata.Title,
                            Address: undefined,
                            Telphone: undefined,
                            Mobile: undefined,
                            Fax: undefined,
                            PracticeAreas: undefined,
                            Email: undefined,
                            Quals: undefined,
                            ApproveYear: undefined,
                            IsMandarin: tmpIsMandarin,
                            tname: undefined,
                            ttype: this.tmpdata.Title,
                            tcontent: undefined,
                            tGetTable: undefined,
                            thtml: data,
                            Remark: undefined,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        for (var m = 0; m < $table0TR.length; m++) {
                            var tr = $table0TR.eq(m);
                            var cTD = tr.children('td');
                            if (cTD.length < 2) {
                                continue;
                            }
                            var $ctd0 = cTD.eq(0).text().trim();
                            var $ctd1 = cTD.eq(1).text().trim();
                            if (!$ctd0) {
                                continue;
                            }

                            if (_allColNameZH.indexOf($ctd0) < 0) {
                                _allColNameZH.push($ctd0);
                            }

                            // ["地址:", "電話:", "傳真:", "", "認許年份:", "電郵:", "執業範圍:", "學歷/資歷:", "手提電話:"]
                            //["Address:", "Tel. No.:", "Fax  No.:", "Call:", "Areas of Practice:", "E-mail:", "Quals:", "Mob:"]
                            switch ($ctd0) {
                                case "地址:": case "Address:":
                                    postItem.Address = $ctd1;
                                    break;
                                case "電話:": case "Tel. No.:":
                                    postItem.Telphone = $ctd1;
                                    break;
                                case "傳真:": case "Fax  No.:":
                                    postItem.Fax = $ctd1;
                                    break;
                                case "認許年份:": case "Call:":
                                    postItem.ApproveYear = $ctd1;
                                    break;
                                case "電郵:": case "E-mail:":
                                    postItem.Email = $ctd1;
                                    break;
                                case "執業範圍:": case "Areas of Practice:":
                                    postItem.PracticeAreas = $ctd1;
                                    break;
                                case "學歷/資歷:": case "Quals:":
                                    postItem.Quals = $ctd1;
                                    break;
                                case "手提電話:": case "Mob:":
                                    postItem.Mobile = $ctd1;
                                    break;
                                default:
                                    break;
                            }
                        }

                        /////
                        //console.log(_allColNameZH);
                        //console.log(postItem);
                        toPostMain.gwd_Barristers_items.push(postItem);
                        //提交数据库
                        $.ajax({
                            type: 'POST',
                            url: config.urlApi_hkba,
                            tmpdata: toPostMain,
                            timeout: 50000,
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(toPostMain)
                        }).done(function (data) {
                            console.log(_ttype + "," + typemsg + "," + this.tmpdata.tname + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                            // sendMsg('jsonDate', "Set Date Now.");
                            //console.log(data);
                        }).fail(function (err) {
                            //showError
                            console.log(this.tmpdata);
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
                /////////////////////////////
                currX += 1;
            }
        }
    }


    //获取记录 大律師 中文
    $.ajax({
        url: configGetUrl.getUrl_hkba_JuniorCounsel_CN,
        //data: { name: '', pg: currPage, sj: 0 },
        tmpdata: currPage,
        timeout: 50000,
        type: "get",
        success: function (data, state, xhr) {
            console.log(this.url);
            var $body = $('<div></div>').html(data);
            var $table0 = $body.find('table[border="1"]').eq(0);
            var $table0TR = $table0.find('tr');

            console.log($table0TR.length);

            for (var x = 0; x < $table0TR.length; x++) {
                var tr = $table0TR.eq(x);
                var alltd = tr.children('td');

                var $td1 = alltd.eq(1)
                var $td1A = $td1.find('a').eq(0);
                var tmpid = $td1A.attr('href');
                var tmpname = $td1A.text().trim();

                var tmpsex = '男';
                if (tmpname.indexOf("女士") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf('女士') - 2)
                }
                if (tmpname.indexOf("(Ms)") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf("(Ms)") - 1)
                }
                if (tmpname.indexOf("S.C.") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('S.C.') - 2)
                }
                if (tmpname.indexOf("名譽資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('名譽資深大律師') - 1)
                }
                if (tmpname.indexOf("資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('資深大律師') - 1)
                }
                var curitem = {
                    id: tmpid,
                    LawyerName: tmpname,
                    Sex: tmpsex,
                    Title: "大律師"
                }

                _allColNameList_JuniorCounselZH.push(curitem);
            }
            ///
            //console.log(_allColNameList_seniorityZH);

            //获取明细
            getItems_JuniorCounselStep5(1, "大律師（中文）");
        },
        error: function (err) {
            console.log("大律師:" + this.url);
            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
            console.log(err);
        },
        dataType: "text"
    });

    //获取记录 大律師 中文 明细
    function getItems_JuniorCounselStep5(tindex, typemsg) {
        var currX = 0;
        var evenRun = 30;
        var currCount = _allColNameList_JuniorCounselZH.length;

        var _intervalTime = 15 * 1000;
        var tmpmsg = _ttype;


        var s1_hkbaZh2 = window.setInterval(evenRunhkbaZh2, _intervalTime);
        //evenRunhkbaZh2();

        function evenRunhkbaZh2() {
            tmpmsg = _ttype + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
            console.log(tmpmsg);
            msgid.text(tmpmsg);

            for (var x = 0; x < evenRun; x++) {

                if (currX >= currCount) {
                    tmpmsg = _ttype + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                    console.log(tmpmsg);
                    msgid.text(tmpmsg);
                    clearInterval(s1_hkbaZh2);
                    btn.attr('disabled', null);
                    break;
                }

                var currItem = _allColNameList_JuniorCounselZH[currX];

                $.ajax({
                    url: configGetUrl.getUrl_hkba_JuniorCounsel_details_CN + currItem.id,
                    //data: { name: '', pg: currPage, sj: 0 },
                    tmpdata: currItem,
                    timeout: 50000,
                    type: "get",
                    success: function (data, state, xhr) {
                        console.log(typemsg + "," + this.url);
                        var $body = $('<div></div>').html(data);
                        var $div0 = $body.children('div').eq(0);
                        var $table0 = $div0.children('table').eq(0);
                        var $table0TR = $table0.find('tr');

                        var $table0NextAllTable = $div0.find('table');

                        var tmpIsMandarin = "";
                        if ($table0NextAllTable.length > 3) {
                            tmpIsMandarin = $table0NextAllTable.eq(2).text().trim();
                        }


                        console.log($table0TR.length);
                        console.log($table0NextAllTable.length);

                        var toPostMain = {
                            tLang: tindex,
                            tname: this.tmpdata.id.split(".")[0],
                            ttype: this.tmpdata.Title,
                            thtml: data,
                            Tid: 0,
                            Remark: this.url,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined,
                            gwd_Barristers_items: []
                        }
                        var postItem = {
                            tLang: tindex,
                            tkeyNo: this.tmpdata.id.split(".")[0],
                            tIndex: 0,
                            Tid: 0,
                            LawyerName: this.tmpdata.LawyerName,
                            ChineseName: this.tmpdata.LawyerName,
                            Sex: this.tmpdata.Sex,
                            Title: this.tmpdata.Title,
                            Address: undefined,
                            Telphone: undefined,
                            Mobile: undefined,
                            Fax: undefined,
                            PracticeAreas: undefined,
                            Email: undefined,
                            Quals: undefined,
                            ApproveYear: undefined,
                            IsMandarin: tmpIsMandarin,
                            tname: undefined,
                            ttype: this.tmpdata.Title,
                            tcontent: undefined,
                            tGetTable: undefined,
                            thtml: data,
                            Remark: undefined,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        for (var m = 0; m < $table0TR.length; m++) {
                            var tr = $table0TR.eq(m);
                            var cTD = tr.children('td');
                            if (cTD.length < 2) {
                                continue;
                            }
                            var $ctd0 = cTD.eq(0).text().trim();
                            var $ctd1 = cTD.eq(1).text().trim();
                            if (!$ctd0) {
                                continue;
                            }

                            if (_allColNameZH.indexOf($ctd0) < 0) {
                                _allColNameZH.push($ctd0);
                            }

                            // ["地址:", "電話:", "傳真:", "", "認許年份:", "電郵:", "執業範圍:", "學歷/資歷:", "手提電話:"]
                            //["Address:", "Tel. No.:", "Fax  No.:", "Call:", "Areas of Practice:", "E-mail:", "Quals:", "Mob:"]
                            switch ($ctd0) {
                                case "地址:": case "Address:":
                                    postItem.Address = $ctd1;
                                    break;
                                case "電話:": case "Tel. No.:":
                                    postItem.Telphone = $ctd1;
                                    break;
                                case "傳真:": case "Fax  No.:":
                                    postItem.Fax = $ctd1;
                                    break;
                                case "認許年份:": case "Call:":
                                    postItem.ApproveYear = $ctd1;
                                    break;
                                case "電郵:": case "E-mail:":
                                    postItem.Email = $ctd1;
                                    break;
                                case "執業範圍:": case "Areas of Practice:":
                                    postItem.PracticeAreas = $ctd1;
                                    break;
                                case "學歷/資歷:": case "Quals:":
                                    postItem.Quals = $ctd1;
                                    break;
                                case "手提電話:": case "Mob:":
                                    postItem.Mobile = $ctd1;
                                    break;
                                default:
                                    break;
                            }
                        }

                        /////
                        //console.log(_allColNameZH);
                        //console.log(postItem);
                        toPostMain.gwd_Barristers_items.push(postItem);
                        //提交数据库
                        $.ajax({
                            type: 'POST',
                            url: config.urlApi_hkba,
                            tmpdata: toPostMain,
                            timeout: 50000,
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(toPostMain)
                        }).done(function (data) {
                            console.log(_ttype + "," + typemsg + "," + this.tmpdata.tname + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                            // sendMsg('jsonDate', "Set Date Now.");
                            //console.log(data);
                        }).fail(function (err) {
                            //showError
                            console.log(this.tmpdata);
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
                /////////////////////////////
                currX += 1;
            }
        }
    }
    //获取记录 大律師 英文
    $.ajax({
        url: configGetUrl.getUrl_hkba_JuniorCounsel_EN,
        //data: { name: '', pg: currPage, sj: 0 },
        tmpdata: currPage,
        timeout: 50000,
        type: "get",
        success: function (data, state, xhr) {
            console.log(this.url);
            var $body = $('<div></div>').html(data);
            var $table0 = $body.find('table[border="1"]').eq(0);
            var $table0TR = $table0.find('tr');

            console.log($table0TR.length);

            for (var x = 0; x < $table0TR.length; x++) {
                var tr = $table0TR.eq(x);
                var alltd = tr.children('td');

                var $td1 = alltd.eq(1)
                var $td1A = $td1.find('a').eq(0);
                var tmpid = $td1A.attr('href');
                var tmpname = $td1A.text().trim();

                var tmpsex = '男';
                if (tmpname.indexOf("女士") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf('女士') - 2)
                }
                if (tmpname.indexOf("(Ms)") > 0) {
                    tmpsex = '女'
                    tmpname = tmpname.substring(0, tmpname.indexOf("(Ms)") - 1)
                }
                if (tmpname.indexOf("S.C.") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('S.C.') - 2)
                }
                if (tmpname.indexOf("名譽資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('名譽資深大律師') - 1)
                }
                if (tmpname.indexOf("資深大律師") > 0) {
                    tmpname = tmpname.substring(0, tmpname.indexOf('資深大律師') - 1)
                }
                var curitem = {
                    id: tmpid,
                    LawyerName: tmpname,
                    Sex: tmpsex,
                    Title: "Junior Counsel"
                }

                _allColNameList_JuniorCounselEH.push(curitem);
            }
            ///
            //console.log(_allColNameList_seniorityZH);

            //获取明细
            getItems_JuniorCounselEnStep5(0, "大律師（英文）");
        },
        error: function (err) {
            console.log(this.url);
            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
            console.log(err);
        },
        dataType: "text"
    });

    //获取记录 大律師 英文 明细
    function getItems_JuniorCounselEnStep5(tindex, typemsg) {
        var currX = 0;
        var evenRun = 30;
        var currCount = _allColNameList_JuniorCounselEH.length;

        var _intervalTime = 17 * 1000;
        var tmpmsg = _ttype;


        var s1_hkbaEN3 = window.setInterval(evenRunhkbaEN3, _intervalTime);
        //evenRunhkbaEN3();

        function evenRunhkbaEN3() {
            tmpmsg = _ttype + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
            console.log(tmpmsg);
            msgid.text(tmpmsg);

            for (var x = 0; x < evenRun; x++) {

                if (currX >= currCount) {
                    tmpmsg = _ttype + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                    console.log(tmpmsg);
                    msgid.text(tmpmsg);
                    clearInterval(s1_hkbaEN3);
                    btn.attr('disabled', null);
                    break;
                }

                var currItem = _allColNameList_JuniorCounselEH[currX];

                $.ajax({
                    url: configGetUrl.getUrl_hkba_JuniorCounsel_details_EN + currItem.id,
                    //data: { name: '', pg: currPage, sj: 0 },
                    tmpdata: currItem,
                    timeout: 50000,
                    type: "get",
                    success: function (data, state, xhr) {
                        console.log(typemsg + "," + this.url);
                        var $body = $('<div></div>').html(data);
                        var $div0 = $body.children('div').eq(0);
                        var $table0 = $div0.children('table').eq(0);
                        var $table0TR = $table0.find('tr');

                        var $table0NextAllTable = $div0.find('table');

                        var tmpIsMandarin = "";
                        if ($table0NextAllTable.length > 3) {
                            tmpIsMandarin = $table0NextAllTable.eq(2).text().trim();
                        }

                        console.log($table0TR.length);
                        console.log($table0NextAllTable.length);

                        var toPostMain = {
                            tLang: tindex,
                            tname: this.tmpdata.id.split(".")[0],
                            ttype: this.tmpdata.Title,
                            thtml: data,
                            Tid: 0,
                            Remark: this.url,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined,
                            gwd_Barristers_items: []
                        }
                        var postItem = {
                            tLang: tindex,
                            tkeyNo: this.tmpdata.id.split(".")[0],
                            tIndex: 0,
                            Tid: 0,
                            LawyerName: this.tmpdata.LawyerName,
                            ChineseName: this.tmpdata.LawyerName,
                            Sex: this.tmpdata.Sex,
                            Title: this.tmpdata.Title,
                            Address: undefined,
                            Telphone: undefined,
                            Mobile: undefined,
                            Fax: undefined,
                            PracticeAreas: undefined,
                            Email: undefined,
                            Quals: undefined,
                            ApproveYear: undefined,
                            IsMandarin: tmpIsMandarin,
                            tname: undefined,
                            ttype: this.tmpdata.Title,
                            tcontent: undefined,
                            tGetTable: undefined,
                            thtml: data,
                            Remark: undefined,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        for (var m = 0; m < $table0TR.length; m++) {
                            var tr = $table0TR.eq(m);
                            var cTD = tr.children('td');
                            if (cTD.length < 2) {
                                continue;
                            }
                            var $ctd0 = cTD.eq(0).text().trim();
                            var $ctd1 = cTD.eq(1).text().trim();
                            if (!$ctd0) {
                                continue;
                            }

                            if (_allColNameZH.indexOf($ctd0) < 0) {
                                _allColNameZH.push($ctd0);
                            }

                            // ["地址:", "電話:", "傳真:", "", "認許年份:", "電郵:", "執業範圍:", "學歷/資歷:", "手提電話:"]
                            //["Address:", "Tel. No.:", "Fax  No.:", "Call:", "Areas of Practice:", "E-mail:", "Quals:", "Mob:"]
                            switch ($ctd0) {
                                case "地址:": case "Address:":
                                    postItem.Address = $ctd1;
                                    break;
                                case "電話:": case "Tel. No.:":
                                    postItem.Telphone = $ctd1;
                                    break;
                                case "傳真:": case "Fax  No.:":
                                    postItem.Fax = $ctd1;
                                    break;
                                case "認許年份:": case "Call:":
                                    postItem.ApproveYear = $ctd1;
                                    break;
                                case "電郵:": case "E-mail:":
                                    postItem.Email = $ctd1;
                                    break;
                                case "執業範圍:": case "Areas of Practice:":
                                    postItem.PracticeAreas = $ctd1;
                                    break;
                                case "學歷/資歷:": case "Quals:":
                                    postItem.Quals = $ctd1;
                                    break;
                                case "手提電話:": case "Mob:":
                                    postItem.Mobile = $ctd1;
                                    break;
                                default:
                                    break;
                            }
                        }

                        /////
                        //console.log(_allColNameZH);
                        //console.log(postItem);
                        toPostMain.gwd_Barristers_items.push(postItem);
                        //提交数据库
                        $.ajax({
                            type: 'POST',
                            url: config.urlApi_hkba,
                            tmpdata: toPostMain,
                            timeout: 50000,
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(toPostMain)
                        }).done(function (data) {
                            console.log(_ttype + "," + typemsg + "," + this.tmpdata.tname + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                            // sendMsg('jsonDate', "Set Date Now.");
                            //console.log(data);
                        }).fail(function (err) {
                            //showError
                            console.log(this.tmpdata);
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
                /////////////////////////////
                currX += 1;
            }
        }
    }
}