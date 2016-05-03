// var $gbHttPip = "http://192.168.1.136:8081";
// var $gbHttPSip = "https://192.168.1.136";

var $gbHttPip = "http://192.168.1.6:7070";
var $gbHttPSip = "https://192.168.1.6:7443";

var config = {
    //API 接口
    //公司注册处
    urlApi_icris: $gbHttPSip + "/api/gwd_CompaniesRegistry_main",//post    
    urlApi_icris_DisOrders: $gbHttPSip + "/api/GWDCompaniesRegistry/gwd_CompaniesRegistry_DisOrders",//post    
    urlApi_GetWebDatasMaxName: $gbHttPSip + "/api/GWDCompaniesRegistry/GetWebDatasMaxName/",
    //案件，法院
    urlApi_judiciary: $gbHttPip + "/api/gwd_Case_main",//post
    //上诉记录
    urlApi_legalref: $gbHttPip + "/api/gwd_AppealRecord_main",//post    
    urlApi_GetWebDatasMaxTDis: $gbHttPip + "/api/GWDAppealRecord/GetWebDatasMaxTDis",
    //律师界名录
    urlApi_hklawsoc: $gbHttPip + "/api/gwd_Lawyers_main",//post
    //电话本
    urlApi_directory: $gbHttPip + "/api/gwd_GovernmentPhonebook_main",//post
    //大律师
    urlApi_hkba: $gbHttPip + "/api/gwd_Barristers_main",//post
    //参数
    urlApim_parameter: $gbHttPip + "/api/m_parameter",
    urlApim_parameterMax: $gbHttPip + "/api/m_parameterSetMax",
    //for 上诉记录
    urlRedict_legalrefHOME: "http://legalref.judiciary.gov.hk",
    urlRedict_legalrefMain: "http://legalref.judiciary.gov.hk/lrs/common/search/search_appeal.jsp?DIS=",
    urlRedict_legalrefItem: "http://legalref.judiciary.gov.hk/lrs/common/ju/ju_body.jsp?DIS=",
    //每5秒开始运行，一次取5个
    //公司注册处
    getSetInterval: 5 * 1000,
    getEven5Count: 6

}
var configGetUrl = {
    //公司注册处    
    url_icris_home: "https://www.icris.cr.gov.hk/csci/",
    //0:US,1:HK,2:ZH
    //0:英文,1:繁体,2:简体
    //0:US,en,1:HK,zh,2:CN,zh

    // url_icris_home_lang: { country: "US", language: "en", flag: 0 },

    url_icris_home_lang: { country: "HK", language: "zh", flag: 1 },

    // url_icris_home_lang: {country:"CN",language:"zh", flag: 2},


    ///律师界名录
    //{ name: '', pg: currCRNo, sj: 0 }
    getUrl_fjt2_mem_withcert: "http://www.hklawsoc.org.hk/pub_c/memberlawlist/mem_withcert.asp",
    //{id:944512}
    getUrl_fjt2_mem_withcertPageEN: "http://www.hklawsoc.org.hk/pub_e/memberlawlist/member.asp",
    getUrl_fjt2_mem_withcertPageCN: "http://www.hklawsoc.org.hk/pub_c/memberlawlist/member.asp",
    //注册外地律师
    //?name=&pg=2&sort=eng&order=&sj=&sessionid=
    getUrl_fjt2_mem_foreignlawyers: "http://www.hklawsoc.org.hk/pub_c/memberlawlist/mem_foreignlawyers.asp",

    ///
    //香港大律师表
    getUrl_hkba_seniority_CN: "http://barlist.hkba.org/hkba/SeniorityCN/seniority.htm",
    getUrl_hkba_seniority_details_CN: "http://barlist.hkba.org/hkba/SeniorityCN/",
    getUrl_hkba_JuniorCounsel_CN: "http://barlist.hkba.org/hkba/Seniority_JuniorCN/JuniorCounsel.htm",
    getUrl_hkba_JuniorCounsel_details_CN: "http://barlist.hkba.org/hkba/Seniority_JuniorCN/",
    getUrl_hkba_seniority_EN: "http://barlist.hkba.org/hkba/Seniority/seniority.htm",
    getUrl_hkba_seniority_details_EN: "http://barlist.hkba.org/hkba/Seniority/",
    getUrl_hkba_JuniorCounsel_EN: "http://barlist.hkba.org/hkba/SeniorityJunior/JuniorCounsel.htm",
    getUrl_hkba_JuniorCounsel_details_EN: "http://barlist.hkba.org/hkba/SeniorityJunior/",

    ///
    //香港特别行政区政府及有关机构电话薄
    getUrl_tel_directory_prefix: "http://tel.directory.gov.hk/",
    //中文
    getUrl_tel_directory: "http://tel.directory.gov.hk/index_CHI.html",
    //英文
    getUrl_tel_directoryEN: "http://tel.directory.gov.hk/index_ENG.html"



}