var $gbHttPip = "http://192.168.1.136:8081";
var $gbHttPSip = "https://192.168.1.136";

// var $gbHttPip = "http://192.168.1.6:7070";
// var $gbHttPSip = "https://192.168.1.6:7443";

var config = {
    //API 接口
    //公司注册处
    // urlApi_icris: $gbHttPSip + "/api/gwd_CompaniesRegistry_main", //post    
    // urlApi_icris_DisOrders: $gbHttPSip + "/api/GWDCompaniesRegistry/gwd_CompaniesRegistry_DisOrders", //post 
    urlApi_icris: $gbHttPSip + "/api/gwd_CompaniesRegistry_mainNew", //post New    
    urlApi_icris_DisOrders: $gbHttPSip + "/api/GWDCompaniesRegistryNew/gwd_CompaniesRegistry_DisOrders", //post New

    urlApi_GetWebDatasMaxName: $gbHttPSip + "/api/GWDCompaniesRegistry/GetWebDatasMaxName/",
    //案件，法院
    urlApi_judiciary: $gbHttPip + "/api/gwd_Case_main", //post
    //上诉记录
    urlApi_legalref: $gbHttPip + "/api/gwd_AppealCases", //post    
    urlApi_legalref_html: $gbHttPip + "/api/gwd_RatioDecidendis", //post 
    urlApi_GetWebDatasMaxTDis: $gbHttPip + "/api/GWDAppealCases/GetWebDatasMaxTDis",



    //律师界名录
    urlApi_withcert: $gbHttPip + "/api/i_WithCertLawyers", //post
    //注册外地律师
    urlApi_foreignlawyers: $gbHttPip + "/api/i_ForeignLawyers", //post
    //电话本
    urlApi_directory: $gbHttPip + "/api/i_GovPhonebook", //post
    //大律师
    urlApi_hkba: $gbHttPip + "/api/i_Barristers", //post
    //注册药剂师名单
    urlApi_RP_items: $gbHttPip + "/api/i_RegPharmacist", //post
    //香港测量师学会
    urlApi_IS_items: $gbHttPip + "/api/gwd_InstituteSurveyors_items", //post
    //香港心理学会 PsychologistsList
    urlApi_PL_items: $gbHttPip + "/api/gwd_PsychologistsList_items", //post
    //注册建筑师(Registered Professionals or Contractors)
    urlApi_RPC_P_items: $gbHttPip + "/api/gwd_RegArchitect_items", //post
    urlApi_RPC_C_items: $gbHttPip + "/api/gwd_RegBuildingCompany_items", //post
    //建筑师,公司
    urlApi_A_items: $gbHttPip + "/api/gwd_architect_items", //post
    urlApi_AC_items: $gbHttPip + "/api/gwd_ConstructionCompany_items", //post
    //香港特别行政区政府保安局
    urlApi_SB_items: $gbHttPip + "/api/gwd_SecurityBureau_items", //post
    //Secretaries
    urlApi_ST_items: $gbHttPip + "/api/gwd_Secretaries_items", //post    
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
    url_icris_home_lang: {
        country: "US",
        language: "en",
        flag: 0
    },
    // url_icris_home_lang: { country: "HK", language: "zh", flag: 1 },
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
    //中文(繁体)
    getUrl_tel_directory: "http://tel.directory.gov.hk/index_CHI.html",
    //英文
    getUrl_tel_directoryEN: "http://tel.directory.gov.hk/index_ENG.html",

    //注册药剂师名单
    getUrl_RP_items_prefix: "http://www.ppbhk.org.hk/",
    //中文(繁体)
    getUrl_RP_items: "http://www.ppbhk.org.hk/tc_chi/list_pharmacists/list.php",
    //英文
    getUrl_RP_itemsEN: "http://www.ppbhk.org.hk/eng/list_pharmacists/list.php",


    //InstituteSurveyors 香港测量师学会
    getUrl_IS_items_prefix: "http://www.hkis.org.hk/",
    //中文(繁体) ?id=47
    getUrl_IS_items: "http://www.hkis.org.hk/zh/company_list2.php",
    //英文 ?id=47
    getUrl_IS_itemsEN: "http://www.hkis.org.hk/en/company_list2.php",

    //香港心理学会 PsychologistsList
    getUrl_PL_items_prefix: "http://www.hkis.org.hk/",
    //中文(繁体) ?fi=public&lang=1
    getUrl_PL_items: "http://www.hkps.org.hk/index.php",
    //英文 ?fi=public&lang=2
    getUrl_PL_itemsEN: "http://www.hkps.org.hk/index.php",


    //注册建筑师(Registered Professionals or Contractors)
    getUrl_RPC_items_prefix: "https://mwerdr.bd.gov.hk",
    getUrl_RPC_items: "https://mwerdr.bd.gov.hk/REGISTER/RegistrationSearch.do",

    //建筑师 architect
    getUrl_A_items_prefix: "http://218.188.25.84/",
    //?keyword=a
    getUrl_A_items: "http://218.188.25.84/member_list_name.php",
    //?search=A
    //建筑公司
    getUrl_AC_items: "http://218.188.25.84/corporate_member/contact.php",
    //香港特别行政区政府保安局
    getUrl_SB_items: "http://www.sb.gov.hk/sc/links/sgsia/tall.htm",
    //Secretarie 特许秘书
    //?_room=member&searchDone=1&_page=112
    getUrl_ST_items: "https://www.hkics.org.hk/index.php"
}