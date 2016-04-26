var $gbHttPip = "http://192.168.1.6:7070";// "http://192.168.1.136:8081";
var $gbHttPSip = "https://192.168.1.6:7443";// "https://192.168.1.136";

var config = {
    //API 接口
    urlApi_icris: $gbHttPSip + "/api/gwd_ICRIS_main",//post    
    urlApi_icris_DisOrders: $gbHttPSip + "/api/GWDICRIS/gwd_ICRIS_DisOrders",//post    
    urlApi_GetWebDatasMaxName: $gbHttPSip + "/api/GWDICRIS/GetWebDatasMaxName/",
    urlApi_judiciary: $gbHttPip + "/api/gwd_Judiciary_main",//post
    urlApi_legalref: $gbHttPip + "/api/gwd_legalref_main",//post
    urlApi_hklawsoc: $gbHttPip + "/api/gwd_hklawsoc_main",//post
    urlApi_GetWebDatasMaxTDis: $gbHttPip + "/api/GWDlegalref/GetWebDatasMaxTDis",
    urlApim_parameter: $gbHttPip + "/api/m_parameter",
    urlApim_parameterMax: $gbHttPip + "/api/m_parameterSetMax",
    //for 上诉记录
    urlRedict_legalrefMain: "http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=",
    urlRedict_legalrefItem: "http://legalref.judiciary.gov.hk/lrs/common/ju/ju_body.jsp?DIS=",
    //每5秒开始运行，一次取5个
    //公司注册处
    getSetInterval: 5 * 1000,
    getEven5Count: 5

}
var configGetUrl = {
    ///律师界名录
    //{ name: '', pg: currCRNo, sj: 0 }
    getUrl_fjt2_mem_withcert: "http://www.hklawsoc.org.hk/pub_c/memberlawlist/mem_withcert.asp",
    //{id:944512}
    getUrl_fjt2_mem_withcertPageEN: "http://www.hklawsoc.org.hk/pub_e/memberlawlist/member.asp",
    getUrl_fjt2_mem_withcertPageCN: "http://www.hklawsoc.org.hk/pub_c/memberlawlist/member.asp",
    //注册外地律师
    //?name=&pg=2&sort=eng&order=&sj=&sessionid=
    getUrl_fjt2_mem_foreignlawyers: "http://www.hklawsoc.org.hk/pub_c/memberlawlist/mem_foreignlawyers.asp"
}