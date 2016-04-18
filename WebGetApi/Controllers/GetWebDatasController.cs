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

namespace WebGetApi.Controllers
{

    [RoutePrefix("api/GetWebDatas")]
    public class GetWebDatasController : ApiController
    {
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/GetWebDatas
        public IQueryable<entityGetWebDatas> GetGetWebDatas()
        {
            return db.GetWebDatas;
        }

        // GET: api/GetWebDatas/5
        [ResponseType(typeof(entityGetWebDatas))]
        public async Task<IHttpActionResult> GetGetWebDatas(long id)
        {
            entityGetWebDatas getWebDatas = await db.GetWebDatas.Where(a => a.Tid == id).SingleOrDefaultAsync();
            if (getWebDatas == null)
            {
                return NotFound();
            }
            return Ok(getWebDatas);
        }
        // GET: api/GetWebDatas/name/5
        [ResponseType(typeof(entityGetWebDatas))]
        [Route("name/{name}")]
        public async Task<IHttpActionResult> GetGetWebDatas(string name)
        {
            entityGetWebDatas getWebDatas = await db.GetWebDatas.Where(a => a.tname == name).FirstOrDefaultAsync();

            if (getWebDatas == null)
            {
                return NotFound();
            }
            return Ok(getWebDatas);
        }

        // GET: api/GetWebDatas/GetWebDatasMaxName/{ttype}
        [ResponseType(typeof(string))]
        [Route("GetWebDatasMaxName/{id}")]
        public async Task<IHttpActionResult> GetWebDatasMaxAsync(string id)
        {
            var getWebDatas = await db.GetWebDatas.Where(a => a.ttype == id).MaxAsync(m => m.tname);
            if (getWebDatas == null)
            {
                return NotFound();
            }

            return Ok(getWebDatas);
        }

        // PUT: api/GetWebDatas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGetWebDatas(long id, entityGetWebDatas getWebDatas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != getWebDatas.Tid)
            {
                return BadRequest();
            }

            db.Entry(getWebDatas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetWebDatasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GetWebDatas
        [ResponseType(typeof(entityGetWebDatas))]
        public async Task<IHttpActionResult> PostGetWebDatas(entityGetWebDatas getWebDatas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                getWebDatas.Remark = HttpContext.Current.Request.UserHostAddress;

                entityGetWebDatas tmpexit = await db.GetWebDatas.Where(a => a.tname == getWebDatas.tname).FirstOrDefaultAsync();
                if (tmpexit == null)
                {

                    getWebDatas.UpdateDate = DateTime.Now;
                    getWebDatas.GetWebDatas_ICRIS.UpdateDate = DateTime.Now;


                    var tmpdd = db.GetWebDatas.Add(getWebDatas);


                    if (!string.IsNullOrEmpty(getWebDatas.GetWebDatas_ICRIS.tcomp))
                    {

                        var tmpGetWebDatas_ICRIS = getWebDatas.GetWebDatas_ICRIS;

                        tmpGetWebDatas_ICRIS.GetWebDatas_Tid = tmpdd.Tid;
                        tmpGetWebDatas_ICRIS.GetWebDatas_tname = tmpdd.tname;

                        var tmpicris = db.GetWebDatas_ICRIS.Add(tmpGetWebDatas_ICRIS);
                    }
                    else
                    {
                        getWebDatas.GetWebDatas_ICRIS = null;
                    }




                    //return CreatedAtRoute("DefaultApi", new { id = getWebDatas.Tid }, getWebDatas);
                }
                else
                {
                    tmpexit.tcontent = getWebDatas.tcontent;
                    tmpexit.tGetTable = getWebDatas.tGetTable;
                    tmpexit.thtml = getWebDatas.thtml;
                    tmpexit.ttype = getWebDatas.ttype;
                    tmpexit.tStatus = getWebDatas.tStatus;
                    tmpexit.Remark = getWebDatas.Remark;
                    tmpexit.UpdateDate = DateTime.Now;
                    tmpexit.GetWebDatas_ICRIS = null;

                    gwd_ICRIS_items tmpICRIS = await db.GetWebDatas_ICRIS.Where(a => a.GetWebDatas_Tid == tmpexit.Tid && a.GetWebDatas_tname == tmpexit.tname).FirstOrDefaultAsync();

                    if (getWebDatas.GetWebDatas_ICRIS != null && !string.IsNullOrEmpty(getWebDatas.GetWebDatas_ICRIS.tcomp))
                    {
                        if (tmpICRIS == null)
                        {
                            tmpICRIS = getWebDatas.GetWebDatas_ICRIS;
                            tmpICRIS.GetWebDatas_Tid = tmpexit.Tid;
                            tmpICRIS.GetWebDatas_tname = tmpexit.tname;
                            tmpICRIS.UpdateDate = DateTime.Now;
                            db.GetWebDatas_ICRIS.Add(tmpICRIS);
                        }
                        else
                        {
                            tmpICRIS.Remark = getWebDatas.GetWebDatas_ICRIS.Remark;
                            tmpICRIS.tclass = getWebDatas.GetWebDatas_ICRIS.tclass;
                            tmpICRIS.tCloseDate = getWebDatas.GetWebDatas_ICRIS.tCloseDate;
                            tmpICRIS.tcomp = getWebDatas.GetWebDatas_ICRIS.tcomp;
                            tmpICRIS.tCompStart = getWebDatas.GetWebDatas_ICRIS.tCompStart;
                            tmpICRIS.tCompStartDate = getWebDatas.GetWebDatas_ICRIS.tCompStartDate;
                            tmpICRIS.tImEvens = getWebDatas.GetWebDatas_ICRIS.tImEvens;
                            tmpICRIS.tModel = getWebDatas.GetWebDatas_ICRIS.tModel;
                            tmpICRIS.tNows = getWebDatas.GetWebDatas_ICRIS.tNows;
                            tmpICRIS.tRemarkNow = getWebDatas.GetWebDatas_ICRIS.tRemarkNow;
                            tmpICRIS.tSaveBook = getWebDatas.GetWebDatas_ICRIS.tSaveBook;
                            tmpICRIS.tSearchRes = getWebDatas.GetWebDatas_ICRIS.tSearchRes;
                            tmpICRIS.tStartDate = getWebDatas.GetWebDatas_ICRIS.tStartDate;
                            tmpICRIS.UpdateDate = DateTime.Now;
                        }
                    }

                }
                await db.SaveChangesAsync();
                return Ok();
                //return CreatedAtRoute("DefaultApi", new { id = tmpexit.Tid }, tmpexit);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // POST: api/GetWebDatas
        [HttpPost]
        [Route("Judiciary")]
        [ResponseType(typeof(entityGetWebDatas))]
        public async Task<IHttpActionResult> Judiciary(entityGetWebDatas getWebDatas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                getWebDatas.GetWebDatas_ICRIS = null;
                getWebDatas.Remark = HttpContext.Current.Request.UserHostAddress;

                entityGetWebDatas tmpexit = await db.GetWebDatas.Where(a => a.tname == getWebDatas.tname).FirstOrDefaultAsync();
                if (tmpexit == null)
                {
                    //新增

                    getWebDatas.UpdateDate = DateTime.Now;
                    getWebDatas.GetWebDatas_judiciary.UpdateDate = DateTime.Now;


                    var tmpdd = db.GetWebDatas.Add(getWebDatas);


                    if (!string.IsNullOrEmpty(getWebDatas.GetWebDatas_judiciary.CourtID))
                    {

                        var tmpGetWebDatas_judiciary = getWebDatas.GetWebDatas_judiciary;

                        tmpGetWebDatas_judiciary.GetWebDatas_Tid = tmpdd.Tid;
                        tmpGetWebDatas_judiciary.GetWebDatas_tname = tmpdd.tname;

                        var tmpicris = db.GetWebDatas_judiciary.Add(tmpGetWebDatas_judiciary);
                    }
                    else
                    {
                        getWebDatas.GetWebDatas_judiciary = null;
                    }
                }
                else
                {
                    //修改
                    tmpexit = getWebDatas;
                    tmpexit.UpdateDate = DateTime.Now;
                    tmpexit.GetWebDatas_ICRIS = null;

                    gwd_Judiciary_items tmpjudiciary = await db.GetWebDatas_judiciary.Where(a => a.GetWebDatas_Tid == tmpexit.Tid && a.GetWebDatas_tname == tmpexit.tname).FirstOrDefaultAsync();

                    if (getWebDatas.GetWebDatas_judiciary != null && !string.IsNullOrEmpty(getWebDatas.GetWebDatas_judiciary.CourtID))
                    {
                        if (tmpjudiciary == null)
                        {
                            tmpjudiciary = getWebDatas.GetWebDatas_judiciary;
                            tmpjudiciary.GetWebDatas_Tid = tmpexit.Tid;
                            tmpjudiciary.GetWebDatas_tname = tmpexit.tname;
                            tmpjudiciary.UpdateDate = DateTime.Now;

                            db.GetWebDatas_judiciary.Add(tmpjudiciary);
                        }
                        else
                        {
                            tmpjudiciary = getWebDatas.GetWebDatas_judiciary;
                            tmpjudiciary.GetWebDatas_Tid = tmpexit.Tid;
                            tmpjudiciary.GetWebDatas_tname = tmpexit.tname;
                            tmpjudiciary.UpdateDate = DateTime.Now;
                        }
                    }

                }
                await db.SaveChangesAsync();

                return Ok();
                //return CreatedAtRoute("DefaultApi", new { id = tmpexit.Tid }, tmpexit);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        // DELETE: api/GetWebDatas/5
        [ResponseType(typeof(entityGetWebDatas))]
        public async Task<IHttpActionResult> DeleteGetWebDatas(long id)
        {
            entityGetWebDatas getWebDatas = await db.GetWebDatas.FindAsync(id);
            if (getWebDatas == null)
            {
                return NotFound();
            }

            db.GetWebDatas.Remove(getWebDatas);
            await db.SaveChangesAsync();

            return Ok(getWebDatas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GetWebDatasExists(long id)
        {
            return db.GetWebDatas.Count(e => e.Tid == id) > 0;
        }
    }
}