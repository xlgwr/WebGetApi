﻿using System;
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
    [RoutePrefix("api/iWithCertLawyers")]
    public class i_WithCertLawyersController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/entityMainComm
        public IQueryable<entityCommMain> Get()
        {
            return db.entityCommMain.Take(10);
        }

        // POST: api/entityMainComm
        [ResponseType(typeof(entityCommMain))]
        public async Task<IHttpActionResult> Post(entityCommMain entityMainComm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                entityMainComm.updtime = DateTime.Now;
                entityMainComm.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (entityMainComm.i_WithCertLawyers != null)
                {
                    foreach (var item in entityMainComm.i_WithCertLawyers)
                    {
                        item.htmlID = entityMainComm.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.updtime = DateTime.Now;
                    }

                    if (entityMainComm.i_WithCertLawyers.Count > 0)
                    {
                        var tmpfirst = entityMainComm.i_WithCertLawyers.First();

                        var tmpExitItem = gwd_Lawyers_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in entityMainComm.i_WithCertLawyers)
                            {
                                if (!string.IsNullOrEmpty(item.LawyerNameEn) || !string.IsNullOrEmpty(item.LawyerNameCn))
                                {
                                    var getItem = gwd_Lawyers_itemsByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.ApproveCountry = item.ApproveCountry;
                                        getItem.ApproveDate = item.ApproveDate;
                                        getItem.BeforeName = item.BeforeName;
                                        getItem.ClientIP = item.ClientIP;
                                        getItem.ComAddressCn = item.ComAddressCn;
                                        getItem.LawyerCompanyCn = item.LawyerCompanyCn;
                                        getItem.LawyerNameCn = item.LawyerNameCn;
                                        getItem.ComAddressEn = item.ComAddressEn;
                                        getItem.ComEmail = item.ComEmail;
                                        getItem.ComFax = item.ComFax;
                                        getItem.ComTel = item.ComTel;
                                        getItem.DxNO = item.DxNO;
                                        getItem.Remark = item.Remark;
                                        getItem.LawyerCompanyEn = item.LawyerCompanyEn;
                                        getItem.LawyerEmail = item.LawyerEmail;
                                        getItem.LawyerNameEn = item.LawyerNameEn;
                                        getItem.OtherDate = item.OtherDate;
                                        getItem.Title = item.Title;

                                        getItem.tname = item.tname;
                                        getItem.tStatus = item.tStatus;
                                        getItem.ttype = item.ttype;
                                        getItem.updtime = DateTime.Now;
                                    }

                                }
                            }
                            //change main
                            if (tmpHtmlId > 0)
                            {
                                var getMain = entityMainCommByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = entityMainComm.thtml;
                                    getMain.tLang = entityMainComm.tLang;
                                    getMain.ClientIP = entityMainComm.ClientIP;
                                    getMain.Remark = entityMainComm.Remark;
                                    getMain.tname = entityMainComm.tname;
                                    getMain.tStatus = entityMainComm.tStatus;
                                    getMain.ttype = entityMainComm.ttype;
                                    getMain.updtime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.entityCommMain.Add(entityMainComm);
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
            //return CreatedAtRoute("DefaultApi", new { id = entityMainComm.Tid }, entityMainComm);

        }
        private bool gwtMainExistsAsync(long id)
        {
            return db.entityCommMain.Count(e => e.Tid == id) > 0;
        }
        private entityCommMain entityMainCommByID(long id)
        {
            return db.entityCommMain.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool gwd_Lawyers_itemsExists(string id, long lang, long tindex)
        {
            return db.i_WithCertLawyers.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private i_WithCertLawyers gwd_Lawyers_itemsByNo(string id, long lang, long tindex)
        {
            return db.i_WithCertLawyers.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
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
