var _getm_parameter = [];
//

var _paramkey_1 = 'evenyDataGet';
var _paramkey_1_type = '1for_judiciary';
var _paramvalue_1evenyDataGet = '';

$(function() {
    console.log("popup:" + (new Date()).Format("yyyy-MM-dd hh:mm:ss.S"));
    sendMsg("removeUrl", "popup.html");
    //1.
    $('#evenyDataGet').datetimepicker({
        format: 'hh:ii',
        startView: 0,
        //autoclose: true,
        //todayBtn: true,
        startDate: "2016-04-12 00:00"
            //minuteStep: 30,
    });

    //获取参数
    $.ajax({
        type: 'GET',
        timeout: 50000,
        url: config.urlApim_parameter
    }).done(function(data) {

        _getm_parameter = data;
        console.log(data);

        _getm_parameter.forEach(function(d) {
            if (d["paramkey"] === _paramkey_1) {
                console.log(d["paramkey"] + ":" + d["paramvalue"])
                _paramvalue_1evenyDataGet = d["paramvalue"];
                $('#evenyDataGet').val(_paramvalue_1evenyDataGet);
            }
        }, this);

    }).fail(function(err) {
        console.log(err);
        //alert("获取参数失败。");
    });

    //提交参数-1.终审及高等法院
    $('#btnEvenyDataGet').click(function() {
        //data
        var tmpGetdate = $('#evenyDataGet').val();
        if (!tmpGetdate) {
            alert("请输入时间.");
            return;
        }
        var m_parameter = {
            "paramkey": _paramkey_1,
            "paramvalue": tmpGetdate,
            "paramtype": _paramkey_1_type,
            "Remark": "终审及高等法院,每日开始采集时间",
            "tStatus": 0,
            "addDate": undefined,
            "UpdateDate": undefined
        };
        $('#btnEvenyDataGet').attr('disabled', 'disabled');
        $.ajax({
            type: 'POST',
            timeout: 20000,
            url: config.urlApim_parameter,
            tmpdata: _paramkey_1,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(m_parameter)
        }).done(function(data) {
            console.log(this.tmpdata + ":Post Done!");
            console.log(data);
            $('#btnEvenyDataGet').attr('disabled', null);
            alert("提交成功.");

        }).fail(function(err) {
            $('#btnEvenyDataGet').attr('disabled', null);
            //showError
            console.log(err);
        });
    });
    /////////////////start 


    /////////////////end
});