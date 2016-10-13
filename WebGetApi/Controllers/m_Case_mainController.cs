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
using System.Text.RegularExpressions;

namespace WebGetApi.Controllers
{
    [RoutePrefix("api/GWDCase")]
    public class m_Case_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/m_Case_main
        public IQueryable<m_Case_main> Getm_Case_main()
        {
            return db.m_Case_main.Take(10);
        }

        // GET: api/m_Case_main/5
        [ResponseType(typeof(m_Case_main))]
        public async Task<IHttpActionResult> Getm_Case_main(long id)
        {
            m_Case_main m_Case_main = await db.m_Case_main.FindAsync(id);
            if (m_Case_main == null)
            {
                return NotFound();
            }

            return Ok(m_Case_main);
        }
        // POST: api/m_Case_main
        [ResponseType(typeof(m_Case_main))]
        public async Task<IHttpActionResult> Postm_Case_main(m_Case_main m_Case_main)
        {
            logger.DebugFormat("Post");
            if (!ModelState.IsValid)
            {
                try
                {
                    logger.ErrorFormat("BadRequest,Type:{0},Count:{1}", m_Case_main.tname, m_Case_main.m_Case_items.Count);
                }
                catch (Exception)
                {

                }
                return BadRequest(ModelState);
            }

            try
            {
                m_Case_main.updtime = DateTime.Now;
                m_Case_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (m_Case_main.m_Case_items != null)
                {


                    foreach (var item in m_Case_main.m_Case_items)
                    {
                        item.htmlID = m_Case_main.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.updtime = DateTime.Now;
                        if (string.IsNullOrEmpty(item.PlainTiff))
                        {
                            item.PlainTiff = "";
                        }
                        if (string.IsNullOrEmpty(item.Defendant))
                        {
                            item.Defendant = "";
                        }

                        if (string.IsNullOrEmpty(item.Representation))
                        {
                            item.Representation = "";
                        }
                        try
                        {

                            #region
                            //案件日期改为当天
                            item.CourtDay = DateTime.Now.ToString("yyyy-MM-dd");
                            //所有备注取空
                            item.Remark = "";

                            //裁判法院所有案件原告都是香港特别行政区，被告按网上的
                            switch (item.tname)
                            {
                                case "wtnmag":
                                    if (string.IsNullOrEmpty(item.Defendant))
                                    {
                                        item.Defendant = item.PlainTiff;
                                        item.PlainTiff = "Government of HKSAR 香港特别行政区";// 香港特別行政區
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(item.PlainTiff))
                                        {
                                            item.Defendant += "," + item.PlainTiff;
                                        }
                                        item.PlainTiff = "Government of HKSAR 香港特别行政区";// 香港特別行政區
                                    }
                                    break;
                                case "lt":
                                    item.Nature = string.IsNullOrEmpty(item.Nature) ? "Labour Dispute" : item.Nature;
                                    break;
                                default:
                                    break;
                            }
                            //劳资审裁处所有的原因是Labour Dispute（全部都写这个）

                            //初始化，原告及被告
                            var regxRADefendant = @"([D]+[0-9]+:)";//被告
                            var regxRADefendantReg = new Regex(regxRADefendant, RegexOptions.IgnoreCase);

                            var regxRADefendant1 = @"(Defendant[\ ]?\(s\):)";//被告 Defendant(s)
                            var regxRADefendantReg1 = new Regex(regxRADefendant1, RegexOptions.IgnoreCase);

                            var regxRADefendant2 = @"(Respondent[\ ]?\(s\):)";//被告 答辯人Respondent(s)
                            var regxRADefendantReg2 = new Regex(regxRADefendant2, RegexOptions.IgnoreCase);

                            var regxRADefendant3 = @"(付款方[\ ]?PAYING\ PARTY\(s\):)";//被告 付款方PAYING PARTY(s)
                            var regxRADefendantReg3 = new Regex(regxRADefendant3, RegexOptions.IgnoreCase);


                            if (string.IsNullOrEmpty(item.Defendant))
                            {
                                item.Parties = item.PlainTiff;
                                //处理分开原告及被告
                                if (item.PlainTiff.IndexOf("@and@", StringComparison.OrdinalIgnoreCase) > -1)
                                {
                                    item.Defendant = item.PlainTiff.Substring(item.PlainTiff.IndexOf("@and@", StringComparison.OrdinalIgnoreCase) + 5);
                                    item.PlainTiff = item.PlainTiff.Substring(0, item.PlainTiff.IndexOf("@and@", StringComparison.OrdinalIgnoreCase));
                                }
                                else if (item.PlainTiff.IndexOf("v.@", StringComparison.OrdinalIgnoreCase) > -1)
                                {
                                    item.Defendant = item.PlainTiff.Substring(item.PlainTiff.IndexOf("v.@", StringComparison.OrdinalIgnoreCase) + 3);
                                    item.PlainTiff = item.PlainTiff.Substring(0, item.PlainTiff.IndexOf("v.@", StringComparison.OrdinalIgnoreCase));
                                }
                                else if (regxRADefendantReg1.IsMatch(item.PlainTiff))
                                {
                                    var getStr = tRegex(regxRADefendant1, item.PlainTiff, 1, false, false, false);

                                    if (!string.IsNullOrEmpty(getStr))
                                    {
                                        var startIndex = item.PlainTiff.IndexOf(getStr, StringComparison.OrdinalIgnoreCase);
                                        if (startIndex > getStr.Length)
                                        {
                                            item.Defendant = item.PlainTiff.Substring(startIndex + getStr.Length);

                                            item.PlainTiff = item.PlainTiff.Substring(0, startIndex);
                                        }
                                        else
                                        {
                                            item.Defendant = item.PlainTiff;

                                            item.PlainTiff = "";
                                        }

                                    }

                                }
                                else if (regxRADefendantReg2.IsMatch(item.PlainTiff))
                                {
                                    var getStr = tRegex(regxRADefendant2, item.PlainTiff, 1, false, false, false);

                                    if (!string.IsNullOrEmpty(getStr))
                                    {
                                        var startIndex = item.PlainTiff.IndexOf(getStr, StringComparison.OrdinalIgnoreCase);
                                        if (startIndex > getStr.Length)
                                        {
                                            item.Defendant = item.PlainTiff.Substring(startIndex + getStr.Length);

                                            item.PlainTiff = item.PlainTiff.Substring(0, startIndex);
                                        }
                                        else
                                        {
                                            item.Defendant = item.PlainTiff;

                                            item.PlainTiff = "";
                                        }

                                    }

                                }
                                else if (regxRADefendantReg3.IsMatch(item.PlainTiff))
                                {
                                    var getStr = tRegex(regxRADefendant3, item.PlainTiff, 1, false, false, false);

                                    if (!string.IsNullOrEmpty(getStr))
                                    {
                                        var startIndex = item.PlainTiff.IndexOf(getStr, StringComparison.OrdinalIgnoreCase);
                                        if (startIndex > getStr.Length)
                                        {
                                            item.Defendant = item.PlainTiff.Substring(startIndex + getStr.Length);

                                            item.PlainTiff = item.PlainTiff.Substring(0, startIndex);
                                        }
                                        else
                                        {
                                            item.Defendant = item.PlainTiff;

                                            item.PlainTiff = "";
                                        }

                                    }

                                }
                                else if (regxRADefendantReg.IsMatch(item.PlainTiff))
                                {
                                    var getStr = tRegex(regxRADefendant, item.PlainTiff, 1, false, false, false);

                                    if (!string.IsNullOrEmpty(getStr))
                                    {
                                        var startIndex = item.PlainTiff.IndexOf(getStr, StringComparison.OrdinalIgnoreCase);
                                        if (startIndex > getStr.Length)
                                        {
                                            item.Defendant = item.PlainTiff.Substring(startIndex + getStr.Length);

                                            item.PlainTiff = item.PlainTiff.Substring(0, startIndex);
                                        }
                                        else
                                        {
                                            item.Defendant = item.PlainTiff;

                                            item.PlainTiff = "";
                                        }

                                    }

                                }
                                else
                                {
                                    item.Defendant = item.PlainTiff;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(item.PlainTiff))
                                {
                                    item.Parties = item.PlainTiff + " @and@ " + item.Defendant;
                                }
                            }
                            //检测关键字
                            if (item.Parties.Contains(@"*"))
                            {
                                item.Other = @"For defendants/ respondents aged below 16, their names will not be shown on the Daily List. 未滿十六歲之被告人/ 答辯人，其姓名將不會顯示於審訊表內";
                            }
                            else
                            {
                                if (CheckKeyValue(item.Parties))
                                {
                                    item.Other = item.Parties.Replace(@"@", "");
                                }
                            }

                            //多个案件编号取第一个,并放入其它，追加
                            if (!string.IsNullOrEmpty(item.CaseNo))
                            {
                                if (item.CaseNo.IndexOf(',') > 0)
                                {
                                    item.Other += " " + item.CaseNo;
                                    //var dd = item.CaseNo.Split(',');
                                    //item.CaseNo = dd[0];
                                }
                                else
                                {
                                    var arrSplit = item.CaseNo.Split('@');
                                    if (arrSplit.Length > 3)
                                    {
                                        item.Other += " " + item.CaseNo;

                                        //item.CaseNo = arrSplit[0] + "@" + arrSplit[1];
                                        //if (arrSplit[2].IndexOf('#') > 0)
                                        //{
                                        //    item.CaseNo += "@" + arrSplit[2];
                                        //}
                                    }
                                }



                            }
                            if (!string.IsNullOrEmpty(item.Other))
                            {
                                item.Other = item.Other.Trim();
                            }
                            //替换缩写
                            item.PlainTiff = ReplaceShort(item.PlainTiff);
                            item.Defendant = ReplaceShort(item.Defendant);

                            //应讯代表,折分

                            item.Representation = regDoubleSpace(item.Representation);

                            //处理分开原告及被告
                            if (item.Representation.IndexOf("@and@", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                item.Representation_P = item.Representation.Substring(0, item.Representation.IndexOf("@and@", StringComparison.OrdinalIgnoreCase));
                                item.Representation_D = item.Representation.Substring(item.Representation.IndexOf("@and@", StringComparison.OrdinalIgnoreCase) + 5);
                            }
                            else if (item.Representation.IndexOf("v.@", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                item.Representation_P = item.Representation.Substring(0, item.Representation.IndexOf("v.@", StringComparison.OrdinalIgnoreCase));
                                item.Representation_D = item.Representation.Substring(item.Representation.IndexOf("v.@", StringComparison.OrdinalIgnoreCase) + 3);
                            }
                            else if (item.Representation.IndexOf(@"律政司@Department of Justice@", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                var str = "律政司@Department of Justice@";
                                item.Representation_P = "律政司@Department of Justice";
                                item.Representation_D = item.Representation.Substring(str.Length);
                            }
                            else if (item.Representation.IndexOf(@"無律師代表@In Person@", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                var str = "無律師代表@In Person@";
                                item.Representation_P = "無律師代表@In Person";
                                item.Representation_D = item.Representation.Substring(str.Length);
                            }
                            else if (item.Representation.IndexOf(@"@無律師代表@In Person", StringComparison.OrdinalIgnoreCase) > 0)
                            {
                                item.Representation_P = item.Representation.Substring(0, item.Representation.IndexOf(@"@無律師代表@In Person", StringComparison.OrdinalIgnoreCase));
                                item.Representation_D = item.Representation.Substring(item.Representation_P.Length + 1);
                            }
                            else
                            {
                                var reg1 = new Regex(@"^([\u4e00-\u9fa5,，]+@[A-Za-z ,&\.-]+@)", RegexOptions.IgnoreCase);
                                var m1 = reg1.Match(item.Representation);
                                var tmpvalue1 = m1.Groups[0].Value.Trim();

                                if (!string.IsNullOrEmpty(tmpvalue1))
                                {
                                    item.Representation_P = tmpvalue1.Substring(0, tmpvalue1.Length - 1);
                                    item.Representation_D = item.Representation.Substring(tmpvalue1.Length);
                                }
                                else
                                {
                                    item.Representation_P = item.Representation;
                                }

                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            logger.ErrorFormat("84 rows :Case Type:{0},Count:{1},Error{2}", m_Case_main.tname, m_Case_main.m_Case_items.Count, ex);
                        }
                        //
                    }
                    if (m_Case_main.m_Case_items.Count > 0)
                    {
                        var tmpfirst = m_Case_main.m_Case_items.First();

                        var tmpExitItem = m_Case_itemExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in m_Case_main.m_Case_items)
                            {
                                if (!string.IsNullOrEmpty(item.CourtID))
                                {
                                    var getItem = m_Case_itemByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.CaseNo = regDoubleSpace(item.CaseNo);
                                        getItem.CaseType = regDoubleSpace(item.CaseType);
                                        //getItem.Cause = item.Cause;
                                        getItem.ClientIP = item.ClientIP;
                                        getItem.CourtDay = regDoubleSpace(item.CourtDay);
                                        getItem.CourtID = regDoubleSpace(item.CourtID);
                                        getItem.CYear = regDoubleSpace(item.CYear);
                                        getItem.Hearing = regDoubleSpace(item.Hearing);
                                        getItem.Judge = regDoubleSpace(item.Judge);
                                        getItem.Nature = regDoubleSpace(item.Nature);

                                        //关键字处理，放其他
                                        getItem.Parties = regDoubleSpace(item.Parties);
                                        getItem.Other = regDoubleSpace(getItem.Other);

                                        getItem.Defendant = regDoubleSpace(item.Defendant);
                                        getItem.PlainTiff = regDoubleSpace(item.PlainTiff);

                                        getItem.Remark = regDoubleSpace(item.Remark);
                                        getItem.Representation = regDoubleSpace(item.Representation);
                                        getItem.Representation_P = regDoubleSpace(item.Representation_P);
                                        getItem.Representation_D = regDoubleSpace(item.Representation_D);

                                        getItem.SerialNo = item.SerialNo;
                                        getItem.tname = item.tname;
                                        getItem.tStatus = item.tStatus;
                                        getItem.ttype = item.ttype;
                                        getItem.updtime = DateTime.Now;

                                        //getItem.Actiondate = item.Actiondate;
                                        getItem.Currency = item.Currency;
                                        getItem.Amount = item.Amount;
                                        //getItem.CheckField = item.CheckField;



                                    }

                                }
                            }
                            //change main
                            if (tmpHtmlId > 0)
                            {
                                var getMain = m_Case_mainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = m_Case_main.thtml;
                                    getMain.tLang = m_Case_main.tLang;
                                    getMain.ClientIP = m_Case_main.ClientIP;
                                    getMain.Remark = m_Case_main.Remark;
                                    getMain.tname = m_Case_main.tname;
                                    getMain.tStatus = m_Case_main.tStatus;
                                    getMain.ttype = m_Case_main.ttype;
                                    getMain.updtime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.m_Case_main.Add(m_Case_main);
                        }



                    }
                    //end if count

                }
                logger.InfoFormat("Type:{0},Count:{1}", m_Case_main.tname, m_Case_main.m_Case_items.Count);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Type:{0},Count:{1},Error{2}", m_Case_main.tname, m_Case_main.m_Case_items.Count, ex);
            }
            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = m_Case_main.Tid }, m_Case_main);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool m_Case_mainExists(long id)
        {
            return db.m_Case_main.Count(e => e.Tid == id) > 0;
        }
        private m_Case_main m_Case_mainByID(long id)
        {
            return db.m_Case_main.Where(e => e.Tid == id).FirstOrDefault();
        }


        private bool m_Case_itemExists(string id, long lang, long tindex)
        {
            return db.m_Case_items.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private m_Case_items m_Case_itemByNo(string id, long lang, long tindex)
        {
            return db.m_Case_items.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
        }

        private async Task<bool> m_Case_mainExistsAsync(long id)
        {
            return await db.m_Case_main.CountAsync(e => e.Tid == id) > 0;
        }
        public static string regDoubleSpace(string strV)
        {
            var v = strV;
            try
            {
                var reg1 = @"[\f\n\r\t\v]";//去除换行符等
                var reg2 = @"[\u3000\u0020]{2,}";//去空格,两个以上空格改为一个，全角、半角


                v = ReplaceReg(reg1, v, " ");
                v = ReplaceReg(reg2, v, " ");

                return v;
            }
            catch (Exception)
            {
                return v;
            }
        }
        static string ReplaceReg(string patt, string input, string totxt)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return "";
                }
                Regex rgx = new Regex(patt, RegexOptions.IgnoreCase);
                return rgx.Replace(input.ToString(), totxt).Trim();
            }
            catch (Exception ex)
            {

                return input;
            }
        }
        /// <summary>
        /// 测试关键字,
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckKeyValue(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
                //var strKey0 = "*|For defendants/ respondents aged below 16, their names will not be shown on the Daily List. 未滿十六歲之被告人/ 答辯人，其姓名將不會顯示於審訊表內";

                var strKey1 = "前稱|formerly known as|FKA|also known as|AKA|c/o|trading as|T/A" +
                             "|formerly known as|alias|OCCUPIER|Occupant|on behalf of|unauthorized structure" +
                             "|otherwise known as|administrators|a minor |Guardian|by her mother and Next Friend" +
                             "|RECEIVING PARTY|PAYING PARTY|the person appointed to represent the estate of|DECEASED|on behalf of" +
                             "|A1:SINGH NAVROOP|Third Party|known in|Liquidator|Liquidation" +
                             "|法人|曾用名|真名|unknown person|demise charterers|Intended Respondent|IR:" +
                             "|INTENDED PARTY|in counterclaim";

                Regex reg1 = new Regex(@"\u3000");//全角,全转为半角
                Regex reg2 = new Regex(@"[\u3000\u0020]{2,}");//去空格,两个以上空格改为一个，全角、半角

                string strReplace3000 = reg1.Replace(str.ToLower(), " ");
                string strCheck = reg2.Replace(strReplace3000.ToLower(), " ");
                string strKey1SpaceNo = reg2.Replace(strKey1.ToLower(), " ");

                var toArr = strKey1SpaceNo.Split('|');

                foreach (var item in toArr)
                {
                    if (strCheck.Contains(item))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
        /// <summary>
        /// 正则表达式 for CASE No
        ///  @"建築及仲裁訴訟@HCCT 29/2013@[35/30+6]##";
        ///  @"(?prefix>[A-Za-z ]+)(?no\d+)/(?year[\d]+)"--》1---》HCCT
        ///  @"(?zh[\u4e00-\u9fa5]+)@"--》1---》建築及仲裁訴訟
        ///   @"@(?time1\[[\w/\+]+\]#+)";--》1---》[35/30+6]##      
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="input"></param>
        /// <param name="index"></param>
        /// <param name="isnext"></param>
        /// <param name="getMaxOrMin"></param>
        /// <param name="isMaxOrMin">True:最大的，false:最小的</param>
        /// <returns></returns>
        public static string tRegex(string pattern, string input, int index, bool isnext, bool getMaxOrMin, bool isMaxOrMin)
        {
            try
            {
                Regex r1 = new Regex(pattern);
                Match m2 = r1.Match(input);
                var tmpvalue = input;

                if (m2.Success)
                {
                    if (isnext)
                    {
                        tmpvalue = m2.Groups[index].Value.Trim();

                        var isgo = true;
                        while (isgo)
                        {
                            m2 = m2.NextMatch();
                            isgo = m2.Success;
                            if (isgo)
                            {
                                var tmpgetNext = m2.Groups[index].Value.Trim();
                                if (getMaxOrMin)
                                {
                                    double inttmpgetNext = 0;
                                    double inttmpvalue = 0;

                                    double.TryParse(tmpgetNext, out inttmpgetNext);
                                    double.TryParse(tmpvalue, out inttmpvalue);
                                    if (isMaxOrMin)
                                    {
                                        if (inttmpgetNext > inttmpvalue)
                                        {
                                            tmpvalue = tmpgetNext;
                                        }
                                    }
                                    else
                                    {
                                        if (inttmpgetNext < inttmpvalue)
                                        {
                                            tmpvalue = tmpgetNext;
                                        }
                                    }

                                }
                                else
                                {
                                    tmpvalue += "," + tmpgetNext;
                                }

                            }
                        }

                        return tmpvalue;
                    }
                    else
                    {

                        return m2.Groups[index].Value.Trim();
                    }

                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
                //throw;
            }

        }

        public static string ReplaceShort(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return str;
                }

                string shortKeys = @" HKSAR | Government of HKSAR @ HKSAR[\(\（]{1}| Government of HKSAR(@ Co\.[,]? | Company @ Co., | Company @ Ltd[\. ]? | Limited @ & | And @ \+ | Plus @ Pte[.]? | Private ";
                shortKeys += @"";

                Regex reg1 = new Regex(@"\u3000", RegexOptions.IgnoreCase);
                Regex reg2 = new Regex(@"Government of HKSAR", RegexOptions.IgnoreCase);
                Regex reg3 = new Regex(@"[\-]", RegexOptions.IgnoreCase);
                Regex reg4 = new Regex(@"[\u3000\u0020]{2,}", RegexOptions.IgnoreCase);//去空格,两个以上空格改为一个，全角、半角

                string strReplaceu3000 = reg1.Replace(str, " ");
                strReplaceu3000 = reg3.Replace(strReplaceu3000, " ");//原告被告把横杠改为空格
                string strReplace = " " + reg2.Replace(strReplaceu3000, "HKSAR") + " ";

                var shortArr = shortKeys.Split('@');

                foreach (var item in shortArr)
                {
                    try
                    {
                        var tmpArr = item.Split('|');
                        Regex TmpRegex = new Regex(tmpArr[0], RegexOptions.IgnoreCase);
                        var getRegex = TmpRegex.Match(tmpArr[1]);
                        strReplace = TmpRegex.Replace(strReplace, tmpArr[1]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                strReplace = reg4.Replace(strReplace, " ");
                return strReplace.Trim();
            }
            catch (Exception)
            {
                return str;
            }
        }
    }
}