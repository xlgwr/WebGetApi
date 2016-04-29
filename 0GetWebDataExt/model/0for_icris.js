
var $getHtml = "";
var $countCurr = 0;
//每10秒提交数 5
var $countPost = 5;
var isCheck = false;
//提交到数据库类型
var $ttype = "icrisCRNo";

//******************mainweb************************//
var hostStringOrig = "http://www.icris.cr.gov.hk:80/csci/index.jsp";
var hostString = "http://www.icris.cr.gov.hk:80/csci/index.jsp";
var hostString = hostString.substring(hostString.indexOf(":") + 3, hostString.lastIndexOf("/"));
var httphostString = hostString.substring(0, hostString.indexOf(":")) + hostString.substring(hostString.indexOf("/"), hostString.length);

function loginIguest() {
    //window.open('https://' + httphostString + '/clearsession.jsp?user_type=iguest', 'loginIguest', 'status=1,resizable=yes,scrollbars=yes,left=0,top=0,width=800,height=' + screen.height * 0.8);
    window.open('https://' + httphostString + '/clearsession.jsp?user_type=iguest', 'loginIguest');
}
//exec
// "http://www.icris.cr.gov.hk/csci/",
// "https://www.icris.cr.gov.hk/csci/"
// loginIguest("i");

//******************************************//
//******************subWeb1************************//
// "https://www.icris.cr.gov.hk/csci/login_i.jsp"
function subWeb1() {
    //this.location.href = this.location.href;  
    var $submit = $("input:submit");
    console.log($submit);
    if ($submit) {
        SetCookie('web.country', configGetUrl.url_icris_home_lang.country, 1, '/csci')
        SetCookie('web.language', configGetUrl.url_icris_home_lang.language, 1, '/csci')
        //console.log($submit);
        $submit.click();
        //window.open ('https://www.icris.cr.gov.hk/csci/cps_criteria.jsp') 
        //window.close();       
    }
}
//******************************************//

//******************subWeb2************************//
// "https://www.icris.cr.gov.hk/csci/login_i.do?loginType=iguest&username=iguest",
// "https://www.icris.cr.gov.hk/csci/logout_warn.jsp"

function subWeb2_logout_warn() {
    console.log(currLocal + ",20 min is over.");
    window.open(configGetUrl.url_icris_home);
}

function subWeb2_CBDS_Search(getURLApi, icrisCRNo) {
    if (!icrisCRNo) {
        icrisCRNo = "demo";
    }
    var $urlApigetmax = getURLApi + icrisCRNo;
    //var $urlApi = "https://192.168.1.136/api/GetWebDatas/GetWebDatasMaxName/" + icrisCRNo;//api/GetWebDatas/name/{name}
    //var $urlApi = "https://localhost:44300/api/GetWebDatas/GetWebDatasMaxName/" + "icrisCRNo";//api/GetWebDatas/name/{name}
    //this.location.href = this.location.href;
    console.log($urlApigetmax);
    sendMsg('openURLForICRIS', "www.icris.cr.gov.hk/csci");
}

//******************************************//

//******************subWeb4************************//

// "https://www.icris.cr.gov.hk/csci/CBDS_Search.do",
// "https://www.icris.cr.gov.hk/csci/CBDS_Search.do*"



function PostData() {
    closeTabs("www.icris.cr.gov.hk");
    //init chrome    
    if (GetQueryString("CRNo")) {
        $countCurr = parseInt(GetQueryString("CRNo"), 10)
    }

    runeven50()
    openURLForGetDisOrderICRIS()

    var s1_icris = window.setInterval(runeven50, (10 * 1000));
    var s1_icris_dis = window.setInterval(openURLForGetDisOrderICRIS, (3 * 60 * 1000));

    function runeven50() {
        closeTabs("www.icris.cr.gov.hk");
        console.log("CurrNo:" + $countCurr);
        //clearInterval(s1);
        //console.log($form);
        if (isCheck) {
            var msg = "需要有验证密码return:" + $countCurr;
            console.log(msg);
            //clearInterval(s1);
            //alert(msg);
            SetCookie('JSESSIONID', '', -1, '/')
            SetCookie('BIGipServerUXPWEB_443', '', -1, '/')
            location.href = configGetUrl.url_icris_home;
            isCheck = false;
            $countCurr -= 5;
            //window.open(configGetUrl.url_icris_home);
            //window.close();
            return;
        }
        if ($countCurr < 0) {
            $countCurr = 0;
        }
        var currCRNo = $countCurr
        for (var i = 1; i <= $countPost; i++) {
            if (isCheck) {
                break;
            }
            var tmpCRNo = padLeft(currCRNo.toString(), 7);
            console.log(tmpCRNo);
            currCRNo += 1;
            //$CRNo.val(tmpCRNo);
            //console.log($form.serialize());
            $.ajax({
                url: 'https://www.icris.cr.gov.hk/csci/CBDS_Search.do?nextAction=CBDS_Search&CRNo=' + tmpCRNo + '&showMedium=true&showBack=true&searchPage=True',
                data: {},
                tmpdata: tmpCRNo,
                timeout: 20000,
                type: "get",
                success: function (data, state, xhr) {

                    if (data.length < 10) {
                        console.log('没有记录。Length < 10. ');
                        console.log(data.length);
                        return;
                    }

                    if (data.indexOf('验证密码') > -1 || data.indexOf('驗證密碼') > -1 || data.indexOf('VERIFICATION CODE') > -1) {
                        console.log("需要有验证密码ajax:" + this.url);
                        SetCookie('JSESSIONID', '', -1, '/')
                        SetCookie('BIGipServerUXPWEB_443', '', -1, '/')
                        isCheck = true;
                        $countCurr -= 5;
                        return;
                    };
                    var $div = $('<div></div>').html(data);
                    var $findTable = $div.find('div#PageContent').eq(0).find('table').eq(2);
                    var $table0 = $findTable.find('table').eq(0);
                    var $table1 = $findTable.find('table').eq(1);
                    if (!$findTable) {
                        console.log('没有记录。');
                        setMsg('m_parameterSetMax', "ICRISCurrMax", this.tmpdata);
                        return;
                    }

                    //console.log($findTable);
                    //console.log($table0.html());
                    //console.log($table0.html());
                    //console.log($table0.find('tr').eq(0).find('td').eq(1).html());  
                    var $table0Tr = $table0.find('tr');
                    var $table1Tr = $table1.find('tr');

                    //console.log($table0Tr.eq(1).find('td').eq(1).text());
                    //console.log($table0Tr.eq(2).find('td').eq(1).text());
                    //console.log($table0Tr.eq(3).find('td').eq(1).text());
                    //console.log($table0Tr.eq(4).find('td').eq(1).text());
                    //console.log($table0Tr.eq(5).find('td').eq(1).text());
                    //console.log($table0Tr.eq(6).find('td').eq(1).text());

                    //console.log($table1Tr.eq(1).find('td').eq(0).text());
                    //console.log($table1Tr.eq(1).find('td').eq(1).text());
                    //console.log($table1Tr.eq(2).find('td').eq(0).text());



                    //var $getHtml = data.replace(/\'/gi, "\\\'");
                    //$getHtml = $getHtml.replace(/\"/gi, "\\\"");
                    //$getHtml = $getHtml.replace(/\//gi, "\\\/");
                    //var dd = $.parseHTML($getHtml);
                    //console.log($getHtml);
                    //console.log(dd);
                    $table0Tr.eq(1).find('td').eq(1).find('br').replaceWith("@");
                    var tmpname = $table0Tr.eq(1).find('td').eq(1).text().trim().split('@');
                    var tmpnameZh = tmpname.length > 1 ? tmpname[1].replace('-THE-', '').trim() : undefined;

                    //提交到数据库
                    var getWebDatas = {
                        gwd_ICRIS_items: [],
                        gwd_ICRIS_itemsChange: [],
                        tname: "icris",
                        ttype: $ttype,
                        thtml: data,
                        Tid: 0,
                        tLang: configGetUrl.url_icris_home_lang.flag,//0:US,1:HK,2:ZH
                        Remark: undefined,
                        tStatus: 0,
                        ClientIP: undefined,
                        addDate: undefined,
                        UpdateDate: undefined
                    }
                    var gwd_ICRIS_items = {
                        $id: "1",
                        htmlID: 0,
                        CompanyName: tmpname[0].replace('-THE-', '').trim(),
                        CompanyNameZH: tmpnameZh,
                        CompanyType: $table0Tr.eq(2).find('td').eq(1).text().trim(),
                        FoundDate: $table0Tr.eq(3).find('td').eq(1).text().trim(),
                        CurrentState: $table0Tr.eq(4).find('td').eq(1).text().trim(),
                        tRemarkNow: $table0Tr.eq(5).find('td').eq(1).text().trim(),
                        LiquidationMode: $table0Tr.eq(6).find('td').eq(1).text().trim(),
                        DisbandDate: $table0Tr.eq(7).find('td').eq(1).text().trim(),
                        ChargeState: $table0Tr.eq(8).find('td').eq(1).text().trim(),
                        Important: $table0Tr.eq(9).find('td').eq(1).text().trim(),
                        tSearchRes: $table0Tr.eq(10).find('td').eq(1).text().trim(),
                        tLang: configGetUrl.url_icris_home_lang.flag,//0:US,1:HK,2:ZH
                        tkeyNo: this.tmpdata,
                        tIndex: 0,
                        tname: "icris",
                        ttype: $ttype,
                        Tid: 0,
                        Remark: undefined,
                        tStatus: 0,
                        ClientIP: undefined,
                        addDate: undefined,
                        UpdateDate: undefined
                    }
                    getWebDatas.gwd_ICRIS_items.push(gwd_ICRIS_items);

                    var tmpindex = 1;
                    var tmpDate = "";
                    var tmpName = "";
                    for (r = 1; r < $table1Tr.length; r++) {
                        var alltd = $table1Tr.eq(r).children('td');

                        tmpName = alltd.eq(1).text().trim();
                        var gwd_ICRIS_itemsChange = {
                            $id: tmpindex + 1,
                            htmlID: 0,
                            CompanyName: undefined,
                            CompanyNameZH: undefined,
                            EffectiveDate: undefined,
                            tLang: configGetUrl.url_icris_home_lang.flag,//0:US,1:HK,2:ZH
                            tkeyNo: this.tmpdata,
                            tIndex: tmpindex,
                            tname: "icris",
                            ttype: $ttype,
                            Tid: 0,
                            Remark: undefined,
                            tStatus: 0,
                            ClientIP: undefined,
                            addDate: undefined,
                            UpdateDate: undefined
                        }

                        if (alltd.length > 1) {
                            tmpDate = alltd.eq(0).text().trim();
                            gwd_ICRIS_itemsChange.CompanyName = tmpName.replace('-THE-', '').trim();
                        } else {
                            tmpName = alltd.eq(0).text().trim();
                            gwd_ICRIS_itemsChange.CompanyNameZH = tmpName.replace('-THE-', '').trim();
                        }

                        gwd_ICRIS_itemsChange.EffectiveDate = tmpDate;

                        getWebDatas.gwd_ICRIS_itemsChange.push(gwd_ICRIS_itemsChange);
                        tmpindex += 1;
                    }

                    if ($table0Tr.length < 7) {

                        console.log('没有纪录与输入的查询资料相符');
                        getWebDatas.tStatus = 1;
                        getWebDatas.Remark = '没有纪录与输入的查询资料相符';
                        getWebDatas.gwd_ICRIS_items = undefined;
                        getWebDatas.gwd_ICRIS_itemsChange = undefined;
                        
                    };
                    //console.log(getWebDatas);

                    $.ajax({
                        type: 'POST',
                        url: config.urlApi_icris,
                        tmpdata: this.tmpdata,
                        contentType: 'application/json; charset=utf-8',
                        timeout: 20000,
                        data: JSON.stringify(getWebDatas)
                    }).done(function (data) {
                        console.log(this.tmpdata + ":Post Done!");
                        sendMsg('jsonDate', "Set Date Now.");
                        //console.log(data);
                    }).fail(function (err) {
                        //showError
                        $countCurr -= 5;
                        console.log(err);
                    });
                },
                error: function () {
                    console.log("提交预定请求发生错误，稍等重试！");
                    $countCurr -= 5;
                },
                dataType: "text"
            });
        }
        $countCurr += $countPost;


    }
    ///每3分钟更新一次
    function openURLForGetDisOrderICRIS() {
        var tmpPostUrl = "https://www.icris.cr.gov.hk/csci/DO_Index.do?PageNO=";
        //$('select[name="SelectPage"]').length
        $.ajax({
            type: 'GET',
            timeout: 20000,
            url: tmpPostUrl + "1"
        }).done(function (data) {
            if (data.length < 10) {
                console.log('PageNO=1没有记录. ：' + data.length);
                return;
            }
            if (data.indexOf('验证密码') > -1 || data.indexOf('驗證密碼') > -1 || data.indexOf('VERIFICATION CODE') > -1) {
                console.log('PageNO=1要验证密码. ：' + data.length);
                return;
            }
            var $div = $('<div></div>').html(data);
            var $findDiv = $div.find('div#PageContent').eq(0);
            var $findform = $findDiv.find('form[name="DOIndex"]').eq(0);
            var $findTable = $findform.find('table');
            var $table0 = $findTable.eq(0);
            var $table1 = $findTable.eq(1);
            var $seletPagesselect = $table1.find('select[name="SelectPage"]').eq(0).find('option');

            // console.log($findform);
            // console.log($seletPagesselect);
            var Tindex = 0;
            for (x = 1; x <= $seletPagesselect.length; x++) {
                $.ajax({
                    type: 'GET',
                    tmpdata: x,
                    timeout: 20000,
                    url: tmpPostUrl + x
                }).done(function (data) {
                    if (data.length < 10) {
                        console.log(this.tmpdata + ":" + '没有记录. ：' + data.length);
                        return;
                    }
                    if (data.indexOf('验证密码') > -1 || data.indexOf('驗證密碼') > -1 || data.indexOf('VERIFICATION CODE') > -1) {
                        console.log(this.tmpdata + ":" + '要验证密码. ：' + data.length);
                        return;
                    }
                    var $div = $('<div></div>').html(data);
                    var $findDiv = $div.find('div#PageContent').eq(0);
                    var $findform = $findDiv.find('form[name="DOIndex"]').eq(0);
                    var $findTable = $findform.find('table');
                    var $table0 = $findTable.eq(0);
                    var $table0TR = $table0.find('tr');

                    var arrToPost = [];

                    for (y = 2; y < $table0TR.length; y++) {
                        var $table0TRTD = $table0TR.eq(y).find('td');
                        console.log(this.tmpdata + ":" + $table0TRTD.length);

                        var tmpitem = {
                            $id: $table0TRTD.eq(0).text().trim(),
                            RecordID: $table0TRTD.eq(1).text().trim(),
                            ItemNo: $table0TRTD.eq(0).text().trim(),
                            CampanyNo: $table0TRTD.eq(1).text().trim(),
                            CorporateName: getText($table0TRTD.eq(2).text().trim()),
                            ChineseName: getText($table0TRTD.eq(3).text().trim()),
                            IDCard: getText($table0TRTD.eq(4).text().trim()),
                            OverseasPassportID: getText($table0TRTD.eq(5).text().trim()),
                            PassportCountry: getText($table0TRTD.eq(6).text().trim()),
                            SameNo: getText($table0TRTD.eq(7).text().trim()),
                            Remark: "取消资格令纪录册:" + this.url,
                            tStatus: 0,
                            thtml: data,
                            addDate: undefined,
                            UpdateDate: undefined
                        }
                        arrToPost.push(tmpitem);
                    }
                    // console.log(arrToPost);
                    if (arrToPost.length > 0) {
                        $.ajax({
                            type: 'POST',
                            url: config.urlApi_icris_DisOrders,
                            tmpdata: this.tmpdata,
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(arrToPost),
                            timeout: 20000
                        }).done(function (data) {
                            console.log(this.tmpdata + ":Page Post Done!");
                            //console.log(data);
                        }).fail(function (err) {
                            //showError
                            console.log(err);
                        });
                    }


                }).fail(function (err) {
                    console.log(err);
                });
            }
            //end for

        }).fail(function (err) {
            console.log(err);
        });
    }
    function getText(value) {
        if (value.indexOf("'") > -1) {
            var arrS = value.split("'");
            return arrS[1];
        } else {
            return value;
        }
    }
}
//******************************************//
