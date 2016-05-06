$(function () {
    var allTtype = "注册建筑师(Registered Professionals or Contractors)";
    console.log(allTtype + "初始化..");
    $('#btn8').click(function () {
        $('#panel8').removeClass('panel-default')
        $('#panel8').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg8')
        $msg.removeClass('hide')
        gwd_RPC_items(allTtype, $(this), $msg);
        //$(this).attr('disabled', null);
    });



    function gwd_RPC_items(tmptype, btn, msgid) {
        console.clear();

        var _allTclassCN = {};
        var _allTclassEN = {};

        var _allColNameCN = [];
        var _allColNameEN = [];

        var _tTitle = tmptype;

        var _alltel_directoryCN = [];
        var _alltel_directoryEN = [];
        //?method=PageRegistration
        //?method=SetPage&page=2&type=AP(A)#AP(A)
        var _postData = {

            method: 'PageRegistration',
            page: 0,
            type: 'AP(A)',

            searchAction: 'search',
            langCode: 1,
            searchName: '',
            searchRegType: '',
            searchRegNo: '',
            searchClass: '',
            searchType: '',
            searchItem: '',
            searchDistrict: '',
            searchSafety: '',
            itemOption: 'all',
            typeOption: 'all',
            districtFlag: 0,
            regTypeFlag: 0,
            safetyFlag: 0,
            typeFlag: 0,
            classFlag: 0,
            itemFlag: 0,
            apaPageNo: 0,
            apePageNo: 0,
            apsPageNo: 0,
            riaPageNo: 0,
            riePageNo: 0,
            risPageNo: 0,
            mwcPageNo: 0,
            mwcwPageNo: 0,
            mwcpPageNo: 0,
            rsePageNo: 0,
            rgePageNo: 0,
            gbcPageNo: 0,
            scdPageNo: 0,
            scfPageNo: 0,
            scsfPageNo: 0,
            scgiPageNo: 0,
            scvPageNo: 0,
            apaMaxPageNo: 0,//24,
            apeMaxPageNo: 0,//3,
            apsMaxPageNo: 0,//5,
            riaMaxPageNo: 0,//4,
            rieMaxPageNo: 0,//4,
            risMaxPageNo: 0,//3,
            mwcMaxPageNo: 0,//253,
            mwcwMaxPageNo: 0,//160,
            mwcpMaxPageNo: 0,//0,
            rseMaxPageNo: 0,//9,
            rgeMaxPageNo: 0,//2,
            gbcMaxPageNo: 0,//14,
            scdMaxPageNo: 0,//3,
            scfMaxPageNo: 0,//3,
            scsfMaxPageNo: 0,//4,
            scgiMaxPageNo: 0,//1,
            scvMaxPageNo: 0,//4,
            districtNotProvidedFlag: 0,
            classNotProvidedFlag: 0,
            itemNotProvidedFlag: 0,
            typeNotProvidedFlag: 0,
            safetyNotProvidedFlag: 0,
            showLogo: '',
            displaySearchName: '',
            displaySearchRegNo: '',
            displaySearchRegType: 'AP(A)',
            displaySearchSafety: '',
            displaySearchClass: ''
        }

        console.log(_tTitle + ":采集初始化..");
        msgid.text(_tTitle + ":采集初始化..");
        $.ajax({
            url: configGetUrl.getUrl_RPC_items,
            data: { method: 'PageRegistration' },
            tmpdata: _postData,
            tmpdataLang: 0,
            timeout: (1 * 60 * 1000),
            type: "get",
            success: function (data, state, xhr) {
                console.log(_tTitle + this.url);
                console.log(this.tmpdata);

                var $body = $('<div></div>').html(data);
                var $table0 = $body.find('#registrationSearchForm').eq(0);
                var $table0TR = $table0.find('input[type="hidden"]');

                console.log($table0TR.length);

                for (var i = 0; i < $table0TR.length; i++) {
                    var item = $table0TR.eq(i);
                    var tmpkey = item.attr('name');
                    var tmpvalue = item.val();
                    //console.log(tmpkey + "," + tmpvalue);
                    _postData[tmpkey] = tmpvalue;
                }
                // var _allTrTd0Name = $table0TR.eq(0);
                // var _allTrTd0Value = $table0TR.eq(0);
                // console.log(_allTrTd0Name.attr('name'));
                // console.log(_allTrTd0Value.val());

                console.log(_postData);
                var evenTime = 5;
                //person
                getItem_All(_postData, 3, 'AP(A)', (evenTime * 1000), 0, 5);
                getItem_All(_postData, 3, 'AP(E)', ((evenTime + 1) * 1000), 0, 5);
                getItem_All(_postData, 3, 'AP(S)', ((evenTime + 2) * 1000), 0, 5);
                getItem_All(_postData, 3, 'RSE', ((evenTime + 3) * 1000), 0, 5);
                getItem_All(_postData, 3, 'RGE', ((evenTime + 4) * 1000), 0, 5);
                getItem_All(_postData, 3, 'RI(A)', ((evenTime + 5) * 1000), 0, 4);
                getItem_All(_postData, 3, 'RI(E)', ((evenTime + 6) * 1000), 0, 4);
                getItem_All(_postData, 3, 'RI(S)', ((evenTime + 7) * 1000), 0, 4);
                //compane
                getItem_All(_postData, 3, 'GBC', ((evenTime + 9) * 1000), 0, 6);
                getItem_All(_postData, 3, 'SC(D)', ((evenTime + 9) * 1000), 0, 6);
                getItem_All(_postData, 2, 'SC(F)', ((evenTime + 8) * 1000), 0, 6);//4
                getItem_All(_postData, 3, 'SC(SF)', ((evenTime + 8) * 1000), 0, 6);
                getItem_All(_postData, 2, 'SC(V)', ((evenTime + 10) * 1000), 0, 6);//5
                getItem_All(_postData, 2, 'SC(GI)', ((evenTime + 10) * 1000), 0, 6);//4
                //compane 2
                getItem_All(_postData, 3, 'MWC', ((evenTime + 3) * 1000), 1, 11);
                getItem_All(_postData, 3, 'MWC(W)', ((evenTime + 3) * 1000), 0, 8);



            },
            error: function (err) {
                console.log(_tTitle + this.url);
                console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                console.log(err);
            },
            dataType: "text"
        });


        function getItem_All(tdata, trStart, typeFlag, intTime, btnflag, trLen) {
            tdata.method = 'SetPage';
            tdata.type = typeFlag;
            tdata.searchRegType = typeFlag;
            tdata.displaySearchRegType = typeFlag;

            //获取记录 中文/英文一样
            $.ajax({
                url: configGetUrl.getUrl_RPC_items,
                data: tdata,
                tmpdata: tdata,
                tmpdataLang: 0,
                timeout: (1 * 60 * 1000),
                type: "post",
                success: function (data, state, xhr) {
                    console.log(_tTitle + this.url);
                    console.log(this.tmpdata);

                    var $body = $('<div></div>').html(data);
                    var $table0 = $body.find('#Table2').eq(0);
                    var $table0TR = $table0.children('tbody').eq(0).children('tr');


                    var _allTrTd0 = $table0TR.eq(0).children('th').eq(1).find('a');
                    console.log($table0TR.length);
                    console.log(_allTrTd0);

                    //分批处理
                    getItem_AP_A(_allTrTd0.length, this.tmpdata, intTime)

                },
                error: function (err) {
                    console.log(_tTitle + this.url);
                    console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
                    console.log(err);
                },
                dataType: "text"
            });

            function getItem_AP_A(allcount, tmpdata, tmpInterValtime) {

                var _langFlag = 1;
                var _ttype = tmpdata.type;
                var currX = 0;
                var evenRun = 1;
                var currCount = allcount;

                var _intervalTime = tmpInterValtime;
                var tmpmsg = tmpdata.type;


                var s1AP_A = window.setInterval(evenAP_A, _intervalTime);
                //evenAP_A();

                function evenAP_A() {
                    //console.clear();

                    tmpmsg = tmpdata.type + ",正在运行--》第：" + (currX + 1) + " 页,总数:" + (currCount + 1) + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "页。"
                    console.log(tmpmsg);
                    msgid.text(tmpmsg);

                    for (var x = 0; x < evenRun; x++) {

                        if (currX > currCount) {
                            tmpmsg = tmpdata.type + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                            console.log(tmpmsg);
                            msgid.text(tmpmsg);
                            clearInterval(s1AP_A);
                            if (btnflag) {
                                btn.attr('disabled', null);
                            }
                            break;
                        }
                        if (currX < 0) {
                            currX = 0;
                        }

                        //获取记录 中文/英文一样
                        tmpdata.method = 'SetPage';
                        tmpdata.page = currX;
                        tmpdata.apaPageNo = currX;

                        $.ajax({
                            url: configGetUrl.getUrl_RPC_items,
                            data: tmpdata,
                            tmpdata: tmpdata,
                            tmpdataLang: 0,
                            timeout: (1 * 60 * 1000),
                            type: "post",
                            success: function (data, state, xhr) {
                                //console.log(this.tmpdata);
                                var $body = $('<div></div>').html(data);
                                var $table0 = $body.find('#Table2').eq(0);
                                var $table0TR = $table0.children('tbody').eq(0).children('tr');

                                console.log(this.tmpdata.type + ":" + this.tmpdata.page + ":" + $table0TR.length + "," + this.url);

                                //var _allTrTd0 = $table0TR.eq(3).children('td').eq(0).text();
                                //console.log(_allTrTd0);

                                var postMain = {
                                    gwd_RegArchitect_items: [],
                                    gwd_RegBuildingCompany_items: [],
                                    tLang: this.tmpdataLang,
                                    tname: _ttype + ":" + (this.tmpdata.page + 1),
                                    ttype: _ttype,
                                    thtml: data,
                                    Tid: 0,
                                    Remark: this.url,
                                    tStatus: 0,
                                    ClientIP: undefined,
                                    addDate: undefined,
                                    UpdateDate: undefined
                                }
                                var tmpid = "";
                                var tmpitem = (this.tmpdata.page * 50) + 1;

                                for (var x = trStart; x < ($table0TR.length - 1); x++) {
                                    var tr = $table0TR.eq(x);
                                    var alltd = tr.children('td');

                                    if (!alltd.eq(0).text().trim() && !alltd.eq(1).text().trim()) {
                                        console.log(this.tmpdata.type + ":" + (this.tmpdata.page + 1) + ",At：" + x + " row is null." + "Text:" + alltd.text());
                                        continue;
                                    }
                                    if (alltd.length < 3) {
                                        console.log(this.tmpdata.type + ":" + (this.tmpdata.page + 1) + ",At：" + x + " row td size.(<4) is:" + alltd.length);
                                        continue;
                                    }
                                    alltd.eq(0).find('br').replaceWith("@");
                                    alltd.eq(1).find('br').replaceWith("@");

                                    var postItem = {
                                        $id: tmpitem,
                                        htmlID: 0,

                                        RegNo: alltd.eq(1).text().trim(),
                                        ArchitectsName: alltd.eq(0).text().trim(),
                                        ArchitectsNameZH: undefined,
                                        ExpiryDate: alltd.eq(2).text().trim(),

                                        // BuildingSafety: alltd.eq(3).text().trim(),
                                        // PhoneNo: alltd.eq(4).text().trim(),

                                        tLang: this.tmpdataLang,
                                        tkeyNo: alltd.eq(1).text().trim(),
                                        tIndex: tmpitem,
                                        tname: _ttype + ":" + (this.tmpdata.page + 1) + ":" + (x + 1),
                                        ttype: _ttype,
                                        Tid: 0,
                                        Remark: this.url,
                                        tStatus: 0,
                                        ClientIP: undefined,
                                        addDate: undefined,
                                        UpdateDate: undefined
                                    }
                                    switch (trLen) {
                                        case 4:
                                            postItem.BuildingSafety = undefined;
                                            postItem.PhoneNo = alltd.eq(3).text().trim();

                                            postMain.gwd_RegArchitect_items.push(postItem);
                                            tmpitem += 1;
                                            break;
                                        case 5:
                                            postItem.BuildingSafety = alltd.eq(3).text().trim();
                                            postItem.PhoneNo = alltd.eq(4).text().trim();


                                            postMain.gwd_RegArchitect_items.push(postItem);
                                            tmpitem += 1;
                                            break;
                                        case 6:
                                            var allName = alltd.eq(1).text().trim();
                                            var allNameArr = allName.split('@');

                                            allNameArr.forEach(function (tmpname) {
                                                var postItemArr = {
                                                    $id: tmpitem,
                                                    htmlID: 0,

                                                    //compane
                                                    CompanyName: alltd.eq(0).text().trim(),
                                                    CompanyNameZH: undefined,
                                                    AuthorizedSignatory: tmpname,
                                                    RegNo: alltd.eq(2).text().trim(),
                                                    ExpiryDate: alltd.eq(3).text().trim(),
                                                    BuildingSafety: alltd.eq(4).text().trim(),
                                                    PhoneNo: alltd.eq(5).text().trim(),

                                                    tLang: this.tmpdataLang,
                                                    tkeyNo: alltd.eq(2).text().trim() + "@" + tmpname,
                                                    tIndex: tmpitem,
                                                    tname: _ttype + ":" + (this.tmpdata.page + 1) + ":" + (x + 1),
                                                    ttype: _ttype,
                                                    Tid: 0,
                                                    Remark: this.url,
                                                    tStatus: 0,
                                                    ClientIP: undefined,
                                                    addDate: undefined,
                                                    UpdateDate: undefined
                                                }
                                                if (alltd.length === 5) {
                                                    postItemArr.BuildingSafety = undefined;
                                                    postItemArr.PhoneNo = alltd.eq(4).text().trim();
                                                }
                                                postMain.gwd_RegBuildingCompany_items.push(postItemArr);
                                                tmpitem += 1;
                                            }, this);

                                            break;
                                        case 8:
                                            var postItemArr8 = {
                                                $id: tmpitem,
                                                htmlID: 0,

                                                //compane
                                                CompanyName: alltd.eq(0).text().trim(),
                                                CompanyNameZH: undefined,
                                                AuthorizedSignatory: undefined,
                                                RegNo: alltd.eq(2).text().trim(),
                                                ExpiryDate: alltd.eq(3).text().trim(),
                                                BuildingSafety: undefined,
                                                PhoneNo: alltd.eq(4).text().trim(),

                                                classType: alltd.eq(1).text().trim(),
                                                Districtarea: alltd.eq(5).text().trim(),
                                                Emailaddress: alltd.eq(6).text().trim(),
                                                Faxno: alltd.eq(7).text().trim(),

                                                tLang: this.tmpdataLang,
                                                tkeyNo: alltd.eq(2).text().trim(),
                                                tIndex: tmpitem,
                                                tname: _ttype + ":" + (this.tmpdata.page + 1) + ":" + (x + 1),
                                                ttype: _ttype,
                                                Tid: 0,
                                                Remark: this.url,
                                                tStatus: 0,
                                                ClientIP: undefined,
                                                addDate: undefined,
                                                UpdateDate: undefined
                                            }
                                            postMain.gwd_RegBuildingCompany_items.push(postItemArr8);
                                            tmpitem += 1;
                                            break;
                                        case 11:
                                            var postItemArr11 = {
                                                $id: tmpitem,
                                                htmlID: 0,

                                                //compane
                                                CompanyName: alltd.eq(0).text().trim(),
                                                CompanyNameZH: undefined,
                                                AuthorizedSignatory: alltd.eq(3).text().trim(),
                                                RegNo: alltd.eq(5).text().trim(),
                                                ExpiryDate: alltd.eq(6).text().trim(),
                                                BuildingSafety: undefined,
                                                PhoneNo: alltd.eq(7).text().trim(),

                                                classType: alltd.eq(1).text().trim() + "@" + alltd.eq(2).text().trim(),
                                                Districtarea: alltd.eq(8).text().trim(),
                                                Emailaddress: alltd.eq(9).text().trim(),
                                                Faxno: alltd.eq(10).text().trim(),

                                                tLang: this.tmpdataLang,
                                                tkeyNo: alltd.eq(5).text().trim() + "@" + alltd.eq(3).text().trim(),
                                                tIndex: tmpitem,
                                                tname: _ttype + ":" + (this.tmpdata.page + 1) + ":" + (x + 1),
                                                ttype: _ttype,
                                                Tid: 0,
                                                Remark: this.url,
                                                tStatus: 0,
                                                ClientIP: undefined,
                                                addDate: undefined,
                                                UpdateDate: undefined
                                            }
                                            postMain.gwd_RegBuildingCompany_items.push(postItemArr11);
                                            tmpitem += 1;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                ///end for

                                console.log(postMain);

                                var tmpUrlpost = config.urlApi_RPC_P_items;
                                switch (trLen) {
                                    case 4: case 5:
                                        tmpUrlpost = config.urlApi_RPC_P_items;
                                        break;
                                    case 6: case 8: case 11:
                                        tmpUrlpost = config.urlApi_RPC_C_items;
                                        break;
                                    default:
                                        break;
                                }

                                //提交数据库
                                $.ajax({
                                    type: 'POST',
                                    url: tmpUrlpost,
                                    tmpdata: postMain,
                                    timeout: 50000,
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify(postMain)
                                }).done(function (data) {
                                    console.log(tmpmsg + "," + this.tmpdata.ttype + "," + ",Index:" + this.tmpdata.tLang + "PostUrl:" + this.url + "--> Post Done!");
                                    // sendMsg('jsonDate', "Set Date Now.");
                                    //console.log(data);                            
                                }).fail(function (err) {
                                    //showError
                                    console.log(this.tmpdata);
                                    console.log(err);
                                    currX -= evenRun;
                                });

                            },
                            error: function (err) {
                                console.log(this.tmpdata.type + ":" + this.url);
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
        ///////////////////////////////////////
    }
});