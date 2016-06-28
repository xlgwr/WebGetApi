$(function() {
    var allTtype = "建筑";
    console.log(allTtype + "初始化..");
    $('#btn9').click(function() {
        $('#panel9').removeClass('panel-default')
        $('#panel9').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg9')
        $msg.removeClass('hide')
        gwd_A_items(allTtype, $(this), $msg, 1);
        //$(this).attr('disabled', null);
    });

    $('#btn10').click(function() {
        $('#panel10').removeClass('panel-default')
        $('#panel10').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg10')
        $msg.removeClass('hide')
        gwd_A_items(allTtype, $(this), $msg, 0);
        //$(this).attr('disabled', null);
    });

    function gwd_A_items(tmptype, btn, msgid, isflag) {
        console.clear();

        var _AllSearch = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];

        //var _AllSearch = ["s"];

        if (isflag) {
            getItem_A_All(tmptype + "师", configGetUrl.getUrl_A_items, config.urlApi_A_items,
                _AllSearch, (6 * 1000), 1, "keyword");
        } else {

            getItem_A_C_All(tmptype + "公司", configGetUrl.getUrl_AC_items, config.urlApi_AC_items,
                _AllSearch, (9 * 1000), 1, "search");
        }

        //师
        function getItem_A_All(tTitle, urlget, urlpost, tmpdata, tmpInterValtime, btnflag, parm) {

            var _tTitle = tTitle;

            console.log(_tTitle + ":采集初始化..");
            msgid.text(_tTitle + ":采集初始化..");

            var _langFlag = 1;
            var currX = 0;
            var evenRun = 1;
            var currCount = tmpdata.length;

            var _intervalTime = tmpInterValtime;
            var tmpmsg = _tTitle;


            var s1A_A = window.setInterval(evenA_A, _intervalTime);
            //evenAP_A();

            function evenA_A() {

                //console.clear();
                // if (currX >= currCount) {
                //     clearInterval(s1A_A);
                //     btn.attr('disabled', null);
                //     return;
                // }

                tmpmsg = _tTitle + ",正在运行--》第：" + (currX + 1) + " 页,总数:" + (currCount) + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "页。"
                console.log(tmpmsg);
                msgid.text(tmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX >= currCount) {
                        tmpmsg = _tTitle + ",处理完成.数量：" + currCount + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(tmpmsg);
                        msgid.text(tmpmsg);
                        clearInterval(s1A_A);
                        if (btnflag) {
                            btn.attr('disabled', null);
                        }
                        break;
                    }
                    if (currX < 0) {
                        currX = 0;
                    }
                    var parmData = {};
                    parmData[parm] = tmpdata[currX];
                    //获取记录 中文/英文一样
                    $.ajax({
                        url: urlget,
                        data: parmData,
                        tmpdata: tmpdata[currX],
                        tmpdataLang: 0,
                        timeout: (1 * 60 * 1000),
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(_tTitle + this.url);

                            var $body = $('<div></div>').html(data);
                            var $table0 = $body.find('table');

                            var $Gettable0 = $table0.eq(0);
                            var $Gettable0TR = $Gettable0.find('tr');

                            console.log($Gettable0TR.length);

                            msgid.text(_tTitle + ":取得数居成功..有：" + $Gettable0TR.length + " 条记录。");

                            var postMain = {
                                i_Architect: [],
                                tLang: this.tmpdataLang,
                                tname: undefined,
                                ttype: _tTitle + ":" + this.tmpdata,
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

                                alltd.eq(0).find('br').replaceWith("@");

                                var nameEN = alltd.eq(0).text().trim();
                                var nameZH = undefined;
                                var nameNo = undefined;
                                var nameSp = nameEN.split('(');

                                if (nameSp.length > 1) {
                                    nameEN = nameSp[0].trim();
                                    nameNo = nameSp[1].split(')')[0].trim();

                                    nameZH = nameEN.substring(nameEN.lastIndexOf(' ') + 1).trim();
                                    nameEN = nameEN.substring(0, nameEN.lastIndexOf(' ')).trim();

                                    if (validateMe.isAlt(nameZH)) {
                                        nameZH = undefined;
                                        nameEN = nameSp[0].trim();
                                    }

                                }

                                var postItem = {
                                    $id: tmpitem,
                                    htmlID: 0,

                                    ArchitectId: nameNo,
                                    MembershipEn: nameEN,
                                    MembershipCn: nameZH,
                                    MembershipType: alltd.eq(2).text().trim(),
                                    MembershipYear: alltd.eq(1).text().trim(),

                                    tLang: this.tmpdataLang,
                                    tkeyNo: alltd.eq(0).text().trim(),
                                    tIndex: tmpitem,
                                    tname: undefined,
                                    ttype: _tTitle + ":" + this.tmpdata,
                                    Tid: 0,
                                    Remark: this.url,
                                    tStatus: 0,
                                    ClientIP: undefined,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }

                                postMain.i_Architect.push(postItem);

                                tmpitem += 1;
                            }
                            ///end for
                            postMain.tname = postMain.ttype + ":" + postMain.i_Architect.length;
                            //console.log(postMain);

                            msgid.text(postMain.tname + "条，分析数据完成,准备更新到数据库..");
                            //提交数据库
                            $.ajax({
                                type: 'POST',
                                url: urlpost,
                                tmpdata: postMain,
                                timeout: 80000,
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify(postMain)
                            }).done(function(data) {
                                console.log(_tTitle + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                                // sendMsg('jsonDate', "Set Date Now.");
                                //console.log(data);
                                //msgid.text(_tTitle + " 更新完成，已更新：" + this.tmpdata.i_Architect.length + " 条成功.");
                                //btn.attr('disabled', null);
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

                    currX += 1;
                }
            }
        }
        //公司
        function getItem_A_C_All(tTitle, urlget, urlpost, tmpdata, tmpInterValtime, btnflag, parm) {

            var _tTitle = tTitle;

            console.log(_tTitle + ":采集初始化..");
            msgid.text(_tTitle + ":采集初始化..");

            var _langFlag = 1;
            var currX = 0;
            var evenRun = 1;
            var currCount = tmpdata.length;

            var _intervalTime = tmpInterValtime;
            var tmpmsg = _tTitle;


            var s1A_A = window.setInterval(evenA_A, _intervalTime);
            //evenAP_A();

            function evenA_A() {
                //console.clear();

                tmpmsg = _tTitle + ",正在运行--》第：" + (currX + 1) + " 页,总数:" + (currCount) + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "页。"
                console.log(tmpmsg);
                msgid.text(tmpmsg);

                for (var x = 0; x < evenRun; x++) {

                    if (currX >= currCount) {
                        tmpmsg = _tTitle + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                        console.log(tmpmsg);
                        msgid.text(tmpmsg);
                        clearInterval(s1A_A);
                        if (btnflag) {
                            btn.attr('disabled', null);
                        }
                        break;
                    }
                    if (currX < 0) {
                        currX = 0;
                    }
                    var parmData = {};
                    parmData[parm] = tmpdata[currX];
                    //获取记录 中文/英文一样
                    $.ajax({
                        url: urlget,
                        data: parmData,
                        tmpdata: tmpdata[currX],
                        tmpdataLang: 0,
                        timeout: (1 * 60 * 1000),
                        type: "get",
                        success: function(data, state, xhr) {
                            console.log(_tTitle + this.url);

                            var $body = $('<div></div>').html(data);

                            var $Gettable0TD = $body.find('td[width="350"][valign="top"]');

                            console.log($Gettable0TD.length);

                            msgid.text(_tTitle + ":取得数居成功..有：" + $Gettable0TD.length + " 条记录。");

                            var postMain = {
                                i_BuildingCom: [],
                                tLang: this.tmpdataLang,
                                tname: undefined,
                                ttype: _tTitle + ":" + this.tmpdata,
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

                            for (var x = 0; x < $Gettable0TD.length; x++) {
                                var tr = $Gettable0TD.eq(x);
                                var currDiv = tr.children('div').eq(0);

                                var currB = currDiv.find('b').eq(0);

                                if (!currDiv.text().trim() || !currB.text().trim()) {
                                    console.log("At：" + x + " row is null." + "Text:" + currDiv.text());
                                    continue;
                                }

                                currB.find('br').replaceWith("@");
                                currDiv.find('br').replaceWith("_");

                                var nameEN = currB.text().trim();
                                var nameZH = undefined;
                                var nameSp = nameEN.split('@');

                                if (nameSp.length > 1) {
                                    nameZH = nameSp[1].trim();
                                    nameEN = nameSp[0].trim();
                                }

                                var allText = currDiv.text().split('_');

                                // console.log(allText);
                                // console.log(allText.length);

                                var taddress = undefined;
                                var taddressZH = undefined;
                                var tTel = undefined;
                                var tFax = undefined;
                                var tEmail = undefined;
                                var twebUrl = undefined;

                                if (allText.length === 9) {
                                    if (allText[8].indexOf('URL') === 0 && allText[7].indexOf('E-mail') === 0) {
                                        taddress = allText[2] + " " + allText[3];
                                        taddressZH = allText[4];
                                        tTel = allText[5].substring(allText[5].indexOf(':') + 1).trim();
                                        tFax = allText[6].substring(allText[6].indexOf(':') + 1).trim();
                                        tEmail = allText[7].substring(allText[7].indexOf(':') + 1).trim();
                                        twebUrl = allText[8].substring(allText[8].indexOf(':') + 1).trim();
                                    }
                                } else {
                                    var lastValue = allText[(allText.length - 1)];
                                    if (lastValue.indexOf('URL') === 0) {
                                        twebUrl = lastValue.substring(lastValue.indexOf(':') + 1).trim();
                                    }
                                }



                                var postItem = {
                                    $id: tmpitem,
                                    htmlID: 0,

                                    BuildingComID: tmpitem,
                                    CompanyNameEn: nameEN,
                                    CompanyNameCn: nameZH,
                                    Summary: currDiv.text(),

                                    AddressEn: taddress,
                                    AddressCn: taddressZH,
                                    Tel: tTel,
                                    Fax: tFax,
                                    Email: tEmail,
                                    webUrl: twebUrl,

                                    tLang: this.tmpdataLang,
                                    tkeyNo: currB.text().trim(),
                                    tIndex: tmpitem,
                                    tname: undefined,
                                    ttype: _tTitle + ":" + this.tmpdata,
                                    Tid: 0,
                                    Remark: this.url,
                                    tStatus: 0,
                                    ClientIP: undefined,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }

                                postMain.i_BuildingCom.push(postItem);

                                tmpitem += 1;
                            }
                            ///end for
                            postMain.tname = postMain.ttype + ":" + postMain.i_BuildingCom.length;
                            //console.log(postMain);

                            msgid.text(postMain.tname + "条，分析数据完成,准备更新到数据库..");
                            //提交数据库
                            $.ajax({
                                type: 'POST',
                                url: urlpost,
                                tmpdata: postMain,
                                timeout: 80000,
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify(postMain)
                            }).done(function(data) {
                                console.log(_tTitle + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "--> Post Done!");
                                // sendMsg('jsonDate', "Set Date Now.");
                                //console.log(data);
                                //msgid.text(_tTitle + " 更新完成，已更新：" + this.tmpdata.i_BuildingCom.length + " 条成功.");
                                //btn.attr('disabled', null);
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

                    currX += 1;
                }
            }
        }
        ///////////////////////////////////////
    }
});