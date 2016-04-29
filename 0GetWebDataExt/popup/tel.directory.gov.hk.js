$(function () {
    console.log("香港特别行政区政府及有关机构电话薄初始化..");
    $('#btn4').click(function () {
        $('#panel4').removeClass('panel-default')
        $('#panel4').addClass('panel-success')
        $(this).attr('disabled', 'disabled');
        var $msg = $('#msg4')
        $msg.removeClass('hide')
        gwd_tel_directory($(this), $msg);
        //$(this).attr('disabled', null);
    });
});
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


    $.ajax({
        url: configGetUrl.getUrl_tel_directory,
        data: { accept_disclaimer: 'yes' },
        tmpdata: 0,
        timeout: 50000,
        type: "get",
        success: function (data, state, xhr) {
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
            }//
            ///end for
            //console.log(_alltel_directoryCN);

            //获取明细
            getItems_alltel_directoryCN(0, _tTitle + "(中文)");

        },
        error: function (err) {
            console.log(_tTitle + this.url);
            console.log("提交预定请求发生错误，稍等重试！" + this.tmpdata);
            console.log(err);
        },
        dataType: "text"
    });
    ///////////////////////////////////////
    //获取记录 中文 明细
    function getItems_alltel_directoryCN(tindex, typemsg) {
        var currX = 0;
        var evenRun = 15;
        var currCount = _alltel_directoryCN.length;

        var _intervalTime = 25 * 1000;
        var tmpmsg = _tTitle;


        var s1_tel_directoryCN = window.setInterval(evenRuntel_directoryCN, _intervalTime);
        evenRuntel_directoryCN();

        function evenRuntel_directoryCN() {
            tmpmsg = _tTitle + "," + typemsg + ",正在运行--》第：" + (currX + 1) + " 条,总数:" + currCount + ",每:" + (_intervalTime / 1000) + " 秒运行一次，每次取:" + evenRun + "条。"
            console.log(tmpmsg);
            msgid.text(tmpmsg);

            for (var x = 0; x < evenRun; x++) {

                if (currX >= currCount) {
                    tmpmsg = _tTitle + "," + typemsg + ",处理完成.数量：" + currX + " ,Time:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S");
                    console.log(tmpmsg);
                    msgid.text(tmpmsg);
                    clearInterval(s1_tel_directoryCN);
                    break;
                }

                var currItem = _alltel_directoryCN[currX];
                console.log(currItem);

                //获取明细-下级
                $.ajax({
                    url: configGetUrl.getUrl_tel_directory_prefix + currItem.url,
                    data: { accept_disclaimer: 'yes' },
                    tmpdata: currItem,
                    timeout: 50000,
                    type: "get",
                    success: function (data, state, xhr) {
                        console.log(_tTitle + "," + this.tmpdata.tTitle + "," + this.url);
                        var $body = $('<div></div>').html(data);
                        var $table0 = $body.find('#content_container').eq(0);
                        var $table0TR = $table0.find('.tbl_dept_contact').eq(0).children('tbody').eq(0).children('tr');
                        var $table1TR = $table0.find('.tbl_dept_contact_list').eq(0).children('tbody').eq(0).children('tr');

                        console.log(this.tmpdata.url + ",tbl_dept_contact:" + $table0TR.length);
                        console.log(this.tmpdata.url + ",tbl_dept_contact_list:" + $table1TR.length);
                    },
                    error: function (err) {
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
}