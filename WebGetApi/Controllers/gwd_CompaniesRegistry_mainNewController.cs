using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EFLibEMMS.EMMS;
using System.Web;
using System.Reflection;
using Common.Logging;
using EFLibForApi.emms.models;
using EFLibForApi.emms;
using EFLibEMMS.viewsModels;

namespace WebGetApi.Controllers
{

    [RoutePrefix("api/GWDCompaniesRegistryNew")]
    public class gwd_CompaniesRegistry_mainNewController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private EMMSDbContext db = new EMMSDbContext();
        private EFLibForApi.emms.emmsApiDbContext dbGet = new emmsApiDbContext();

        // GET: api/s_Entity
        public IQueryable<s_Entity> Gets_Entity()
        {
            return db.s_Entity.Take(10);
        }

        // GET: api/s_Entity/5
        [ResponseType(typeof(s_Entity))]
        public async Task<IHttpActionResult> Gets_Entity(string id)
        {
            s_Entity s_Entity = await db.s_Entity.FindAsync(id);
            if (s_Entity == null)
            {
                return NotFound();
            }

            return Ok(s_Entity);
        }
        // GET: api/GetWebDatas/GetWebDatasMaxName/{ttype}
        [ResponseType(typeof(string))]
        [Route("GetWebDatasMaxName/{id}")]
        public async Task<IHttpActionResult> GetWebDatasMaxAsync(string id)
        {
            long getMaxSetCurrValue = 1;
            try
            {
                logger.Info(id);
                var tmpkey = "CompaniesRegistryCurrMax" + id;
                m_parameter m_parameterCurr = await dbGet.m_parameter.FindAsync(tmpkey);

                if (m_parameterCurr == null)
                {
                    m_parameterCurr = new m_parameter();
                    m_parameterCurr.paramkey = tmpkey;
                    m_parameterCurr.paramvalue = "1";
                    m_parameterCurr.paramtype = "0CompaniesRegistry";
                    m_parameterCurr.Remark = "公司注册处，当前取得最大ID,0:英文,1:繁体,2:简体.0:US,en,1:HK,zh,2:CN,zh";
                    m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameterCurr.tStatus = 0;
                    m_parameterCurr.UpdateDate = DateTime.Now;
                    dbGet.m_parameter.Add(m_parameterCurr);
                    dbGet.SaveChanges();
                }
                long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);
                getMaxSetCurrValue -= 10;
                if (getMaxSetCurrValue < 1)
                {
                    getMaxSetCurrValue = 1;
                }
                return Ok((getMaxSetCurrValue).ToString("0000000"));
            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpPost]
        // POST: api/gwd_CompaniesRegistry_DisOrders
        [ResponseType(typeof(bool))]
        [Route("gwd_CompaniesRegistry_DisOrders")]
        public async Task<IHttpActionResult> t_Disqualification(ICollection<gwd_CompaniesRegistry_DisOrders> t_Disqualification)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var s_Entity_model = new s_Entity();

                s_Entity_model.Type = 2;
                s_Entity_model.Flag = 2;

                var t_HtmlPage_model = new t_HtmlPage();
                //set t_HtmlPage_model
                if (t_Disqualification != null && t_Disqualification.Count > 0)
                {
                    var tmpFirst = t_Disqualification.ElementAt(0);

                    t_HtmlPage_model.HtmlPage = tmpFirst.thtml;
                    t_HtmlPage_model.Language = 0;
                    t_HtmlPage_model.Title = "Disqualification";
                    t_HtmlPage_model.HtmlURL = tmpFirst.Remark;

                    t_HtmlPage_model.addDate = DateTime.Now;

                    //保存网页
                    var saveModel = db.t_HtmlPage.Add(t_HtmlPage_model);
                    db.SaveChanges();

                    foreach (var item in t_Disqualification)
                    {
                        //item.UpdateDate = DateTime.Now;
                        //item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        var tmodel = new t_Disqualification();

                        tmodel.HtmlPageID = saveModel.HtmlID;

                        tmodel.ChineseName = item.ChineseName;
                        tmodel.CorporateName = item.CorporateName;
                        tmodel.IDCard = item.IDCard;
                        tmodel.ItemNo = item.RecordID;
                        tmodel.Language = 0;
                        tmodel.OverseasPassportID = item.OverseasPassportID;
                        tmodel.PassportCountry = item.PassportCountry;
                        tmodel.SameNo = item.SameNo;

                        if (!t_DisqualificationExists(tmodel.ItemNo))
                        {
                            s_Entity_model.t_Disqualification.Add(tmodel);
                        }
                    }
                    if (s_Entity_model.t_Disqualification.Count > 0)
                    {
                        db.s_Entity.Add(s_Entity_model);
                        await db.SaveChangesAsync();
                    }
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(true);
        }

        // POST: api/s_Entity
        [ResponseType(typeof(gwd_CompaniesRegistry_main))]
        public async Task<IHttpActionResult> Posts_Entity(gwd_CompaniesRegistry_main postModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            long getMaxSetCurrValue = 1;
            long getNowValue = 1;
            m_parameter m_parameterCurr = new m_parameter();
            var tmpfirst = new s_Company();
            var t_HtmlPage_model = new t_HtmlPage();
            var s_Entity_model = new s_Entity();

            try
            {
                //set t_HtmlPage_model

                t_HtmlPage_model.HtmlPage = postModel.thtml;
                t_HtmlPage_model.Language = (int)postModel.tLang;
                t_HtmlPage_model.Title = postModel.tname;
                t_HtmlPage_model.HtmlURL = postModel.Remark;

                //set s_Entity_model
                s_Entity_model.Type = 2;
                s_Entity_model.Flag = 2;

                foreach (var item in postModel.gwd_CompaniesRegistry_items)
                {
                    if (string.IsNullOrEmpty(item.CompanyName) && string.IsNullOrEmpty(item.CompanyNameZH))
                    {
                        continue;
                    }
                    var getItem = new s_Company();
                    getItem.ActiveStatus = item.CurrentState;
                    //getItem.Areas = item.Areas;
                    //getItem.AuthorizedCapital = item.AuthorizedCapital;
                    getItem.CompanyType = item.CompanyType;
                    //getItem.CountryID = item.CountryID;
                    getItem.CRNo = item.tkeyNo;
                    //getItem.DataGradeID = item.DataGradeID;
                    getItem.DissolutionDate = item.DisbandDate;
                    getItem.FullName_En = item.CompanyName;
                    getItem.FullName_Cn = item.CompanyNameZH;
                    getItem.ImportantNote = item.Important;
                    getItem.IncorporationDate = item.FoundDate;
                    //getItem.IssuedShares = item.IssuedShares;
                    //getItem.Listed = item.Listed;
                    //getItem.PlaceRegistration = item.PlaceRegistration;
                    getItem.RegisterOfCharges = item.ChargeState;
                    getItem.Remarks = item.tRemarkNow;
                    //getItem.Show = item.Show;
                    getItem.Language = (int)item.tLang;
                    getItem.WindingUpMode = item.LiquidationMode;
                    s_Entity_model.s_Company.Add(getItem);
                }

                foreach (var item in postModel.gwd_CompaniesRegistry_itemsChange)
                {
                    if (string.IsNullOrEmpty(item.CompanyName) && string.IsNullOrEmpty(item.CompanyNameZH))
                    {
                        continue;
                    }
                    var getItemChange = new t_CompanyChange();
                    getItemChange.CRNo = item.tkeyNo;
                    getItemChange.ChangeContent_En = item.CompanyName;
                    getItemChange.ChangeContent_Cn = item.CompanyNameZH;
                    getItemChange.EffectiveDate = item.EffectiveDate;
                    getItemChange.Remark = item.Remark;
                    getItemChange.Sort = (int)item.tIndex;
                    getItemChange.Language = (int)item.tLang;

                    s_Entity_model.t_CompanyChange.Add(getItemChange);
                }



                if (t_HtmlPage_model != null && s_Entity_model.s_Company != null)
                {
                    if (t_HtmlPage_model.HtmlPage.Length > 10 && s_Entity_model.s_Company.Count > 0)
                    {
                        t_HtmlPage_model.addDate = DateTime.Now;

                        //保存网页
                        var saveModel = db.t_HtmlPage.Add(t_HtmlPage_model);
                        db.SaveChanges();

                        //处理明细
                        foreach (var item in s_Entity_model.s_Company)
                        {
                            item.HtmlPageID = saveModel.HtmlID;
                        }


                        tmpfirst = s_Entity_model.s_Company.First();

                        try
                        {
                            var tmpkeyParam = "CompaniesRegistryCurrMax" + tmpfirst.Language.ToString();
                            // logger.Info("Param:" + tmpkeyParam);

                            m_parameterCurr = await dbGet.m_parameter.FindAsync(tmpkeyParam);
                            if (m_parameterCurr != null)
                            {
                                // logger.Info("Param2:" + tmpkeyParam + "," + m_parameterCurr.paramvalue);
                                long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);
                                long.TryParse(tmpfirst.CRNo, out getNowValue);
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);
                        }

                        var tmpexit = s_CompanyExists(tmpfirst.CRNo, tmpfirst.Language);
                        if (tmpexit)
                        {
                            /////////////
                            var tmpChangeEntityList = new s_Entity();
                            tmpChangeEntityList.Type = 2;
                            tmpChangeEntityList.Flag = 2;
                            ///

                            foreach (var item in s_Entity_model.s_Company)
                            {
                                if (!string.IsNullOrEmpty(item.FullName_En) || !string.IsNullOrEmpty(item.FullName_Cn))
                                {
                                    var getItem = s_CompanyExistsByTkeyNo(item.CRNo, item.Language);
                                    if (getItem != null)
                                    {

                                        //change item
                                        getItem.ActiveStatus = item.ActiveStatus;
                                        getItem.Areas = item.Areas;
                                        getItem.AuthorizedCapital = item.AuthorizedCapital;
                                        getItem.CompanyType = item.CompanyType;
                                        getItem.CountryID = item.CountryID;
                                        getItem.CRNo = item.CRNo;
                                        getItem.DataGradeID = item.DataGradeID;
                                        getItem.DissolutionDate = item.DissolutionDate;
                                        getItem.FullName_Cn = item.FullName_Cn;
                                        getItem.FullName_En = item.FullName_En;
                                        getItem.ImportantNote = item.ImportantNote;
                                        getItem.IncorporationDate = item.IncorporationDate;
                                        getItem.IssuedShares = item.IssuedShares;
                                        getItem.Listed = item.Listed;
                                        getItem.PlaceRegistration = item.PlaceRegistration;
                                        getItem.RegisterOfCharges = item.RegisterOfCharges;
                                        getItem.Remarks = item.Remarks;
                                        getItem.Show = item.Show;
                                        getItem.Language = item.Language;
                                        getItem.WindingUpMode = item.WindingUpMode;

                                        //change main
                                        var getMain = getHtmlById(getItem.HtmlPageID);
                                        if (getMain != null)
                                        {
                                            getMain.HtmlPage = t_HtmlPage_model.HtmlPage;
                                            getMain.HtmlURL = t_HtmlPage_model.HtmlURL;
                                            getMain.Language = t_HtmlPage_model.Language;
                                            getMain.Remark = t_HtmlPage_model.Remark;
                                            getMain.Title = t_HtmlPage_model.Title;
                                            getMain.addDate = DateTime.Now;

                                        }
                                    }
                                    else
                                    {
                                        tmpChangeEntityList.s_Company.Add(getItem);
                                    }
                                    //end fi
                                }
                            }

                            //for change
                            var tcount = s_Entity_model.t_CompanyChange.Count;
                            for (int i = 0; i < tcount; i++)
                            {
                                var item = s_Entity_model.t_CompanyChange.ElementAt(i);
                                if (!string.IsNullOrEmpty(item.ChangeContent_En) || !string.IsNullOrEmpty(item.ChangeContent_Cn))
                                {
                                    var getItemChange = t_CompanyChangeExistsByTkeyNo(item.CRNo, item.Language, item.Sort);
                                    if (getItemChange != null)
                                    {
                                        getItemChange.ChangeContent_En = item.ChangeContent_En;
                                        getItemChange.ChangeContent_Cn = item.ChangeContent_Cn;
                                        getItemChange.EffectiveDate = item.EffectiveDate;
                                        getItemChange.Remark = item.Remark;
                                        getItemChange.Sort = item.Sort;
                                        getItemChange.Language = item.Language;
                                    }
                                    else
                                    {
                                        tmpChangeEntityList.t_CompanyChange.Add(item);
                                    }
                                }
                            }
                            try
                            {
                                if (tmpChangeEntityList.t_CompanyChange.Count > 0 || tmpChangeEntityList.s_Company.Count > 0)
                                {
                                    db.s_Entity.Add(tmpChangeEntityList);
                                }
                            }
                            catch (Exception ex)
                            {

                                logger.ErrorFormat("error save 0:{0}", ex);
                            }
                            /////////////////////////////////////end

                        }
                        else
                        {
                            db.s_Entity.Add(s_Entity_model);
                        }

                        if (m_parameterCurr != null)
                        {
                            logger.Info("Param2:" + getNowValue + "," + getMaxSetCurrValue + "," + m_parameterCurr.paramvalue);
                            if (getNowValue > getMaxSetCurrValue)
                            {
                                m_parameterCurr.paramvalue = getNowValue.ToString();
                                m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                                m_parameterCurr.UpdateDate = DateTime.Now;
                                dbGet.SaveChanges();
                            }

                        }

                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = s_Entity.Tid }, s_Entity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool s_EntityExists(long id)
        {
            return db.s_Entity.Count(e => e.Entityid == id) > 0;
        }
        private s_Entity s_EntityById(long id)
        {
            try
            {
                return db.s_Entity.Where(e => e.Entityid == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("error-1:{0}", ex);
                return null;
            }
        }

        private t_HtmlPage getHtmlById(long id)
        {
            try
            {
                return db.t_HtmlPage.Where(e => e.HtmlID == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("error0:{0}", ex);
                return null;
            }
        }

        private bool s_CompanyExists(string id, long lang)
        {
            var item = db.s_Company.Count(e => e.CRNo == id && e.Language == lang) > 0;
            return item;
        }
        private s_Company s_CompanyExistsByTkeyNo(string id, long lang)
        {
            try
            {
                var item = db.s_Company.Where(e => e.CRNo == id && e.Language == lang).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("error1:{0}", ex);
                return null;
            }

        }
        private t_CompanyChange t_CompanyChangeExistsByTkeyNo(string id, long? lang, long? Sort)
        {

            try
            {
                var item = db.t_CompanyChange.Where(e => e.CRNo == id && e.Language == lang && e.Sort == Sort).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("error2:{0}", ex);
                return null;
            }
        }

        private bool t_DisqualificationExists(string id)
        {

            return db.t_Disqualification.Count(e => e.ItemNo == id) > 0;
        }

        private t_Disqualification t_DisqualificationByNo(string id)
        {
            try
            {
                return db.t_Disqualification.Where(e => e.ItemNo == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("error3:{0}", ex);
                return null;
            }
        }
    }
}