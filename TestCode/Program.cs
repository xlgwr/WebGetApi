using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test2();
            var tname = "吳歐陽律師事務所@Ng, Au-Yeung   & Partners@聶柏仁律師行@Littlewoods";
            var tname2 = "a吳歐陽律師事務所@Ng, Au-Yeung   & Partners@聶柏仁律師行@Littlewoods";
            var reg1 = new Regex(@"^([\u4e00-\u9fa5]+@[A-Za-z ,&\.-]+)", RegexOptions.IgnoreCase);
            var m1 = reg1.Match(tname);
            var m2 = reg1.Match(tname2);
            var tmpvalue1 = m1.Groups[0].Value.Trim();
            var tmpvalue2 = m2.Groups[0].Value.Trim();
            Console.ReadKey();
        }
        static void Test1()
        {
            var strAll = "dfbdd前稱|a formerly 　known  as  dfd |a FKA　 bd|d also known as fdf|c/o|df trading   as dfdf" +
                        "|adf formerly known as bd|bd   alias df dfdf |OCCUPIER|Occupant|acb   on   behalf of|unauthorized   structure dfdf " +
                        "|otherwise  known   as|administrators|a   minor, by|Guardian|by   her mother and Next Friend f  dfdf" +
                        "|RECEIVING  PARTY|PAYING  PARTY|the  person appointed  to   represent    the estate   of|DECEASED|on behalf of adfa" +
                        "|bbA1:SINGH   NAVROOP|Third   Party|known  in|Liquidator |Liquidation" +
                        "|aa法人dd|bb曾用名|aa真名bb|dd unknown    person dfd|adf demise  charterers df|d Intended     Respondent|zzz IR:ddff" +
                        "|INTENDED PARTY";
            var toCheckArr = strAll.Split('|');

            foreach (var item in toCheckArr)
            {
                var checkFlag = CheckKeyValue(item);
                Console.WriteLine(checkFlag.ToString() + ":\t CheckStr:" + item);
            }
        }
        static void Test2()
        {
            var toTest = @"add HKSAR(ddd) |add HKSAR（ddd）|adf aHKSAR |aff HKSARb |abb HKSAR  |adf Government of HKSAR dfa|adf Government of HKSAR（dd) dfa|" +
                         "|af Co |afd aCo |dfd Cob" +
                         "|adf Co. adf|adf aCo. adf| Co.b" +
                         "|adf Co., | aCo., adf|adf Co.,b" +
                         "|adf Ltd adf| aLtd | Ltdb" +
                         "|adf Ltd. adf| aLtd. | Ltd.b" +
                         "|adf Pte adf| aPte | Pteb" +
                         "|adf Pte. adf| aPte. | Pte.b" +
                         "|adf & adf| a& | &b" +
                         "|adf a+ adf| +b adf| + adf";
            var arrTest = toTest.Split('|');
            foreach (var item in arrTest)
            {
                var strRep = ReplaceShort(item);
                Console.WriteLine(item + ":\t" + strRep);
            }
        }

        public static string ReplaceShort(string str)
        {
            string shortKeys = @" HKSAR | Government of HKSAR @ HKSAR[\(\（]{1}| Government of HKSAR(@ Co\.?(,)? | Company @ Ltd[\. ]? | Limited @ & | And @ \+ | Plus @ Pte[.]? | Private ";

            Regex reg1 = new Regex(@"\u3000", RegexOptions.IgnoreCase);
            Regex reg2 = new Regex(@"Government of HKSAR", RegexOptions.IgnoreCase);
            string strReplaceu3000 = reg1.Replace(str, " ") ;
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
            return strReplace;
        }
        /// <summary>
        /// 测试关键字,
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckKeyValue(string str)
        {
            //var strKey0 = "*|For defendants/ respondents aged below 16, their names will not be shown on the Daily List. 未滿十六歲之被告人/ 答辯人，其姓名將不會顯示於審訊表內";

            var strKey1 = "前稱|formerly known as|FKA|also known as|c/o|trading as" +
                         "|formerly known as|alias|OCCUPIER|Occupant|on behalf of|unauthorized structure" +
                         "|otherwise known as|administrators|a minor, by|Guardian|by her mother and Next Friend" +
                         "|RECEIVING PARTY|PAYING PARTY|the person appointed to represent the estate of|DECEASED|on behalf of" +
                         "|A1:SINGH NAVROOP|Third Party|known in|Liquidator|Liquidation" +
                         "|法人|曾用名|真名|unknown person|demise charterers|Intended Respondent|IR:" +
                         "|INTENDED PARTY";

            Regex reg1 = new Regex(@"\u3000");//全角,全转为半角
            Regex reg2 = new Regex(@"[\u3000\u0020]{2,}");//去空格,两个以上空格改为一个，全角、半角

            string strReplace3000 = reg1.Replace(str.ToLower(), " ");
            string strCheck = reg2.Replace(strReplace3000, " ");
            string strKey1SpaceNo = reg2.Replace(strKey1.ToLower(), " ");

            var toArr = strKey1SpaceNo.Split('|');

            foreach (var item in toArr)
            {
                if (strCheck.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
