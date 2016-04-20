var config = {
    //API 接口
    urlApi_icris: "https://192.168.1.136/api/gwd_ICRIS_main",//post
    urlApi_judiciary: "http://192.168.1.136:8081/api/gwd_Judiciary_main",//post
    urlApi_legalref: "http://192.168.1.136:8081/api/gwd_legalref_main",
    urlApi_GetWebDatasMaxName: "https://192.168.1.136/api/GWDICRIS/GetWebDatasMaxName/",
    urlApi_GetWebDatasMaxTDis: "http://192.168.1.136:8081/api/GWDlegalref/GetWebDatasMaxTDis",
    urlApim_parameter: "http://192.168.1.136:8081/api/m_parameter",
    //for 上诉记录
    urlRedict_legalrefMain: "http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=",
    urlRedict_legalrefItem: "http://legalref.judiciary.gov.hk/lrs/common/ju/ju_body.jsp?DIS=",
    //每5秒开始运行，一次取5个
    getSetInterval: 5 * 1000,
    getEven5Count: 5

}

// var config = {
//     urlApi_icris: "https://192.168.1.6:7443/api/gwd_ICRIS_main",
//     urlApi_judiciary: "http://192.168.1.6:7070/api/gwd_Judiciary_main",//api/GetWebDatas
//     urlApi_GetWebDatasMaxName: "https://192.168.1.6:7443/api/GWDICRIS/GetWebDatasMaxName/",
//     urlApim_parameter: "http://192.168.1.6:7070/api/m_parameter"
// }