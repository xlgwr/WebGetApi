var $gbHttPip = "http://192.168.1.6:7070";// "http://192.168.1.136:8081";
var $gbHttPSip = "https://192.168.1.6:7443";// "https://192.168.1.136";

var config = {
    //API 接口
    urlApi_icris: $gbHttPSip + "/api/gwd_ICRIS_main",//post    
    urlApi_GetWebDatasMaxName: $gbHttPSip + "/api/GWDICRIS/GetWebDatasMaxName/",
    urlApi_judiciary: $gbHttPip + "/api/gwd_Judiciary_main",//post
    urlApi_legalref: $gbHttPip + "/api/gwd_legalref_main",
    urlApi_GetWebDatasMaxTDis: $gbHttPip + "/api/GWDlegalref/GetWebDatasMaxTDis",
    urlApim_parameter: $gbHttPip + "/api/m_parameter",
    //for 上诉记录
    urlRedict_legalrefMain: "http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=",
    urlRedict_legalrefItem: "http://legalref.judiciary.gov.hk/lrs/common/ju/ju_body.jsp?DIS=",
    //每5秒开始运行，一次取5个
    getSetInterval: 5 * 1000,
    getEven5Count: 5

}