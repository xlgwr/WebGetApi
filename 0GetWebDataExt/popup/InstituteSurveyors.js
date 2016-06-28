$(function() {
    var allTtype = "香港测量师学会(InstituteSurveyors)";
    console.log(allTtype + " 初始化..");
    $('#btn6').click(function() {
        $('#panel6').removeClass('panel-default')
        $('#panel6').addClass('panel-success')

        var $msg = $('#msg6')
        $msg.removeClass('hide')

        //检查 id 号
        var _iIdValue = $('#setMaxId6').val();

        if (_iIdValue && validateMe.digits(_iIdValue) && _iIdValue > 10) {
            _iIdValue = parseInt(_iIdValue, 10);
            $msg.text("设置最大ID:" + _iIdValue);
        } else {
            $('#setMaxId6').focus();
            $msg.text("请输入正确的整数(>10)。");
            return;
        }


        $(this).attr('disabled', 'disabled');

        gwd_IS_items(allTtype, $(this), $msg, _iIdValue);
        //$(this).attr('disabled', null);

    });

    function gwd_IS_items(tmptype, btn, msgid, maxid) {
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

        //获取记录 中文 明细
        getItems_alltel_directoryCN(1, _tTitle, maxid)
            //获取记录 中文 明细
        function getItems_alltel_directoryCN(tlangFlag, typemsg, tmaxid) {
            var _langFlag = tlangFlag;
            var currX = 1;
            var evenRun = 3;
            var currCount = tmaxid;

            var _intervalTime = 10 * 1000;
            var tmpmsg = typemsg + "(中文)";


            var s1_IS_CN = window.setInterval(even5_IS_CN, _intervalTime);
            even5_IS_CN();

            function even5_IS_CN() {
                console.clear();
                var Showtmpmsg = tmpmsg + ",正在运行--》第：" + currX + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
                console.log(Showtmpmsg);
                msgid.text(Showtmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX > currCount) {
                        Showtmpmsg = tmpmsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(Showtmpmsg);
                        msgid.text(Showtmpmsg);
                        clearInterval(s1_IS_CN);
                        // btn.attr('disabled', null);
                        break;
                    }
                    if (currX <= 0) {
                        currX = 1;
                    }
                    //获取记录 中文/英文一样
                    $.ajax({
                        url: configGetUrl.getUrl_IS_items,
                        data: {
                            id: currX
                        },
                        tmpdata: currX,
                        tmpdataLang: tlangFlag,
                        timeout: (1 * 60 * 1000),
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(tmpmsg + this.url);

                            var $body = $('<div></div>').html(data);
                            var $table0 = $body.find('table[width="760"][cellspacing="3"]');

                            console.log("hasTable:" + $table0.length);

                            var $Gettable0 = $table0.eq(0);
                            var $Gettable0TR = $Gettable0.find('tr');

                            console.log($Gettable0TR.length);

                            //msgid.text(tmpmsg + ":取得数居成功..有：" + $Gettable0TR.length + " 条记录。");

                            if ($Gettable0TR.length < 5) {
                                console.log(tmpmsg + " 没有记录。" + this.url);
                                return;
                            }

                            var postMain = {
                                i_InstituteSurveyors: [],
                                tLang: this.tmpdataLang,
                                tname: this.tmpdata,
                                ttype: tmpmsg,
                                thtml: data,
                                Tid: 0,
                                Remark: this.url,
                                tStatus: 0,
                                ClientIP: undefined,
                                addDate: undefined,
                                UpdateDate: undefined
                            }

                            var postItem = {
                                $id: 1,
                                htmlID: 0,
                                InstituteId: this.tmpdata,

                                CompanyName: $Gettable0TR.eq(0).find('td').eq(2).text().trim(),
                                Address: $Gettable0TR.eq(1).find('td').eq(2).text().trim(),
                                ContactPerson: $Gettable0TR.eq(2).find('td').eq(2).text().trim(),
                                Tel: $Gettable0TR.eq(3).find('td').eq(2).text().trim(),
                                Fax: $Gettable0TR.eq(4).find('td').eq(2).text().trim(),
                                Email: $Gettable0TR.eq(5).find('td').eq(2).text().trim(),
                                Website: $Gettable0TR.eq(6).find('td').eq(2).text().trim(),

                                tLang: this.tmpdataLang,
                                tkeyNo: this.tmpdata,
                                tIndex: 1,
                                tname: undefined,
                                ttype: tmpmsg,
                                Tid: 0,
                                Remark: this.url,
                                tStatus: 0,
                                ClientIP: undefined,
                                addDate: undefined,
                                UpdateDate: undefined
                            }
                            postMain.i_InstituteSurveyors.push(postItem);
                            ///end for
                            //console.log(postMain);

                            //提交数据库
                            $.ajax({
                                type: 'POST',
                                url: config.urlApi_IS_items,
                                tmpdata: postMain,
                                timeout: 50000,
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify(postMain)
                            }).done(function(data) {
                                console.log(tmpmsg + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                                // sendMsg('jsonDate', "Set Date Now.");
                                //console.log(data);                            
                            }).fail(function(err) {
                                //showError
                                console.log(this.tmpdata);
                                console.log(err);
                                currX -= evenRun;
                            });
                            ////////////////////////////////////
                        },
                        error: function(err) {
                            console.log(tmpmsg + this.url);
                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                            console.log(err);
                            currX -= evenRun;
                        },
                        dataType: "text"
                    });
                    //////////////////////////////////////////////////////
                    currX += 1;
                }
            }
        }
        ///////////////////////////////////////
        //获取记录 英文 明细
        getItems_alltel_directoryEN(0, _tTitle, maxid)
            //获取记录 英文 明细
        function getItems_alltel_directoryEN(tlangFlag, typemsg, tmaxid) {
            var _langFlag = tlangFlag;
            var currX = 1;
            var evenRun = 3;
            var currCount = tmaxid;

            var _intervalTime = 15 * 1000;
            var tmpmsg = typemsg + "(英文)";


            var s1_IS_EN = window.setInterval(even5_IS_EN, _intervalTime);
            even5_IS_EN();

            function even5_IS_EN() {
                console.clear();
                var Showtmpmsg = tmpmsg + ",正在运行--》第：" + currX + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
                console.log(Showtmpmsg);
                msgid.text(Showtmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX > currCount) {
                        Showtmpmsg = tmpmsg + ",处理完成.数量：" + currCount + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(Showtmpmsg);
                        msgid.text(Showtmpmsg);
                        clearInterval(s1_IS_EN);
                        btn.attr('disabled', null);
                        break;
                    }
                    if (currX <= 0) {
                        currX = 1;
                    }
                    //获取记录 中文/英文一样
                    $.ajax({
                        url: configGetUrl.getUrl_IS_itemsEN,
                        data: {
                            id: currX
                        },
                        tmpdata: currX,
                        tmpdataLang: tlangFlag,
                        timeout: (1 * 60 * 1000),
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(tmpmsg + this.url);

                            var $body = $('<div></div>').html(data);
                            var $table0 = $body.find('table[width="760"][cellspacing="3"]');

                            console.log("hasTable:" + $table0.length);

                            var $Gettable0 = $table0.eq(0);
                            var $Gettable0TR = $Gettable0.find('tr');

                            console.log($Gettable0TR.length);

                            //msgid.text(tmpmsg + ":取得数居成功..有：" + $Gettable0TR.length + " 条记录。");

                            if ($Gettable0TR.length < 5) {
                                console.log(tmpmsg + " 没有记录。" + this.url);
                                return;
                            }

                            var postMain = {
                                i_InstituteSurveyors: [],
                                tLang: this.tmpdataLang,
                                tname: this.tmpdata,
                                ttype: tmpmsg,
                                thtml: data,
                                Tid: 0,
                                Remark: this.url,
                                tStatus: 0,
                                ClientIP: undefined,
                                addDate: undefined,
                                UpdateDate: undefined
                            }

                            var postItem = {
                                $id: 1,
                                htmlID: 0,
                                InstituteId: this.tmpdata,

                                CompanyName: $Gettable0TR.eq(0).find('td').eq(2).text().trim(),
                                Address: $Gettable0TR.eq(1).find('td').eq(2).text().trim(),
                                ContactPerson: $Gettable0TR.eq(2).find('td').eq(2).text().trim(),
                                Tel: $Gettable0TR.eq(3).find('td').eq(2).text().trim(),
                                Fax: $Gettable0TR.eq(4).find('td').eq(2).text().trim(),
                                Email: $Gettable0TR.eq(5).find('td').eq(2).text().trim(),
                                Website: $Gettable0TR.eq(6).find('td').eq(2).text().trim(),

                                tLang: this.tmpdataLang,
                                tkeyNo: this.tmpdata,
                                tIndex: 1,
                                tname: undefined,
                                ttype: tmpmsg,
                                Tid: 0,
                                Remark: this.url,
                                tStatus: 0,
                                ClientIP: undefined,
                                addDate: undefined,
                                UpdateDate: undefined
                            }
                            postMain.i_InstituteSurveyors.push(postItem);
                            ///end for
                            //console.log(postMain);

                            //提交数据库
                            $.ajax({
                                type: 'POST',
                                url: config.urlApi_IS_items,
                                tmpdata: postMain,
                                timeout: 50000,
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify(postMain)
                            }).done(function(data) {
                                console.log(tmpmsg + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                                // sendMsg('jsonDate', "Set Date Now.");
                                //console.log(data);                            
                            }).fail(function(err) {
                                //showError
                                console.log(this.tmpdata);
                                console.log(err);
                                currX -= evenRun;
                            });
                            ////////////////////////////////////
                        },
                        error: function(err) {
                            console.log(tmpmsg + this.url);
                            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                            console.log(err);
                            currX -= evenRun;
                        },
                        dataType: "text"
                    });
                    //////////////////////////////////////////////////////
                    currX += 1;
                }
            }
        }
        /////////////////////

    }
});