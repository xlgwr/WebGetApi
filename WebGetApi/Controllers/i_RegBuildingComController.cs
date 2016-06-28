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
using EFLibForApi.emms;
using EFLibForApi.emms.models;
using System.Web;
using System.Reflection;
using Common.Logging;

namespace WebGetApi.Controllers
{
    /// <summary>
    /// Registered Pharmacists
    /// </summary>
    [RoutePrefix("api/GWDRegBuildingCompany")]
    public class gwd_RegBuildingCompany_itemsController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/entityCommMain
        public IQueryable<entityCommMain> Get()
        {
            return db.entityCommMain.Take(10);
        }

        // POST: api/entityCommMain
        [ResponseType(typeof(entityCommMain))]
        public async Task<IHttpActionResult> Post(entityCommMain entityCommMain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tmpMain = new entityCommMain();

                entityCommMain.updtime = DateTime.Now;
                entityCommMain.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (entityCommMain.i_RegBuildingCom != null)
                {
                    foreach (var item in entityCommMain.i_RegBuildingCom)
                    {
                        item.htmlID = entityCommMain.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.updtime = DateTime.Now;
                    }

                    if (entityCommMain.i_RegBuildingCom.Count > 0)
                    {
                        var tmpfirst = entityCommMain.i_RegBuildingCom.First();

                        var tmpExitItem = gwd_RegBuildingCompany_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in entityCommMain.i_RegBuildingCom)
                            {
                                if (!string.IsNullOrEmpty(item.CompanyName))
                                {
                                    var getItem = gwd_RegBuildingCompany_itemsByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.tIndex = item.tIndex;
                                        getItem.CompanyName = item.CompanyName;
                                        getItem.Type = item.Type;
                                        getItem.AuthorizedSignatory = item.AuthorizedSignatory;
                                        getItem.classType = item.classType;
                                        getItem.BuildingSafety = item.BuildingSafety;
                                        getItem.ExpiryDate = item.ExpiryDate;
                                        getItem.Tel = item.Tel;
                                        getItem.RegBuildingComId = item.RegBuildingComId;
                                        getItem.Districtarea = item.Districtarea;
                                        getItem.Emailaddress = item.Emailaddress;
                                        getItem.Faxno = item.Faxno;

                                        getItem.ClientIP = item.ClientIP;
                                        getItem.Remark = item.Remark;

                                        getItem.tname = item.tname;
                                        getItem.tStatus = item.tStatus;
                                        getItem.ttype = item.ttype;
                                        getItem.updtime = DateTime.Now;
                                    }
                                    else
                                    {
                                        tmpMain.i_RegBuildingCom.Add(getItem);
                                    }

                                }
                            }
                            //change main
                            if (tmpHtmlId > 0)
                            {
                                var getMain = entityCommMainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = entityCommMain.thtml;
                                    getMain.tLang = entityCommMain.tLang;
                                    getMain.ClientIP = entityCommMain.ClientIP;
                                    getMain.Remark = entityCommMain.Remark;
                                    getMain.tname = entityCommMain.tname;
                                    getMain.tStatus = entityCommMain.tStatus;
                                    getMain.ttype = entityCommMain.ttype;
                                    getMain.updtime = DateTime.Now;
                                }
                            }

                            //add is not exit
                            if (tmpMain.i_PsychologicalSociety.Count > 0)
                            {
                                tmpMain.thtml = entityCommMain.thtml;
                                tmpMain.tLang = entityCommMain.tLang;
                                tmpMain.ClientIP = entityCommMain.ClientIP;
                                tmpMain.Remark = entityCommMain.Remark;
                                tmpMain.tname = entityCommMain.tname;
                                tmpMain.tStatus = entityCommMain.tStatus;
                                tmpMain.ttype = entityCommMain.ttype;
                                tmpMain.updtime = DateTime.Now;

                                db.entityCommMain.Add(tmpMain);
                            }
                        }
                        else
                        {
                            db.entityCommMain.Add(entityCommMain);
                        }



                    }
                    //end if count

                }
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = entityCommMain.Tid }, entityCommMain);

        }
        private bool gwtMainExistsAsync(long id)
        {
            return db.entityCommMain.Count(e => e.Tid == id) > 0;
        }
        private entityCommMain entityCommMainByID(long id)
        {
            return db.entityCommMain.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool gwd_RegBuildingCompany_itemsExists(string id, long lang, long tindex)
        {
            return db.i_RegBuildingCom.Count(e => e.tkeyNo == id && e.tLang == lang) > 0;
        }
        private i_RegBuildingCom gwd_RegBuildingCompany_itemsByNo(string id, long lang, long tindex)
        {
            return db.i_RegBuildingCom.Where(e => e.tkeyNo == id && e.tLang == lang).FirstOrDefault();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
