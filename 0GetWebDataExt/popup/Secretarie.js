$(function() {
    var allTtype = "特许秘书";
    console.log(allTtype + " 初始化..");
    $('#btn12').click(function() {
        $('#panel12').removeClass('panel-default')
        $('#panel12').addClass('panel-success')

        var $msg = $('#msg12')
        $msg.removeClass('hide')

        //检查 id 号
        var _iIdValue12 = $('#setMaxId12').val();

        if (_iIdValue12 && validateMe.digits(_iIdValue12) && _iIdValue12 > 10) {
            _iIdValue12 = parseInt(_iIdValue12, 10);
            $msg.text("设置最多页数:" + _iIdValue12);
        } else {
            $('#setMaxId12').focus();
            $msg.text("请输入正确的整数(>10)。");
            return;
        }


        $(this).attr('disabled', 'disabled');

        gwd_ST_items(allTtype, $(this), $msg, _iIdValue12);
        //$(this).attr('disabled', null);

    });

    function gwd_ST_items(tmptype, btn, msgid, maxid) {
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

        //获取记录  明细
        getItems_ST(1, _tTitle, maxid)
            //获取记录  明细
        function getItems_ST(tlangFlag, typemsg, tmaxid) {
            var _langFlag = tlangFlag;
            var currX = 1;
            var evenRun = 2;
            var currCount = tmaxid;

            var _intervalTime = 10 * 1000;
            var tmpmsg = typemsg;
            var tmpitem = 1;

            var s1_ST_CN = window.setInterval(even5_ST_CN, _intervalTime);
            even5_ST_CN();

            function even5_ST_CN() {
                console.clear();
                var Showtmpmsg = tmpmsg + ",正在运行--》第：" + currX + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
                console.log(Showtmpmsg);
                msgid.text(Showtmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX > currCount) {
                        Showtmpmsg = tmpmsg + ",处理完成.数量：" + currCount + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(Showtmpmsg);
                        msgid.text(Showtmpmsg);
                        clearInterval(s1_ST_CN);
                        btn.attr('disabled', null);
                        break;
                    }
                    if (currX <= 0) {
                        currX = 1;
                    }
                    //获取记录 中文/英文一样
                    $.ajax({
                        url: configGetUrl.getUrl_ST_items,
                        data: {
                            _room: "member",
                            searchDone: 1,
                            _page: currX
                        },
                        tmpdata: currX,
                        tmpdataLang: tlangFlag,
                        timeout: (1 * 60 * 1000),
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(tmpmsg + this.url);

                            var $body = $('<div></div>').html(data);
                            var $table0 = $body.find('#thinList');

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
                                i_Secretaries: [],
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


                            for (var x = 1; x < $Gettable0TR.length; x++) {
                                var tr = $Gettable0TR.eq(x);
                                var alltd = tr.children('td');

                                if (!alltd.eq(0).text().trim() && !alltd.eq(1).text().trim()) {
                                    console.log("At：" + x + " row is null." + "Text:" + alltd.text());
                                    continue;
                                }
                                var postItem = {
                                    $id: tmpitem,
                                    htmlID: 0,

                                    Name: alltd.eq(0).text().trim(),
                                    Grade: alltd.eq(1).text().trim(),

                                    tLang: this.tmpdataLang,
                                    tkeyNo: alltd.eq(0).text().trim() + "@" + alltd.eq(1).text().trim(),
                                    tIndex: tmpitem,
                                    tname: undefined,
                                    ttype: tmpmsg,
                                    Tid: 0,
                                    Remark: this.url,
                                    tStatus: 0,
                                    ClientIP: undefined,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }
                                postMain.i_Secretaries.push(postItem);

                                tmpitem += 1;
                            }
                            ///end for
                            //console.log(postMain);

                            //提交数据库
                            $.ajax({
                                type: 'POST',
                                url: config.urlApi_ST_items,
                                tmpdata: postMain,
                                timeout: 80000,
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

    }
});