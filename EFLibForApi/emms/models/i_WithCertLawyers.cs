using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EFLibForApi.emms.models
{
    /// <summary>
    /// 律师界名录表
    /// </summary>
    [Table("i_WithCertLawyers")]
    public class i_WithCertLawyers : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public long LawyerId { get; set; }

        /// <summary>
        /// 姓名（英文）
        /// </summary>
        public string LawyerNameEn { get; set; }

        /// <summary>
        /// 姓名（中文）
        /// </summary>
        public string LawyerNameCn { get; set; }

        /// <summary>
        /// 前称（中文）
        /// </summary>
        public string BeforeName { get; set; }

        /// <summary>
        /// 在香港认许日期
        /// </summary>
        public string ApproveDate { get; set; }

        /// <summary>
        /// 其他认许国家
        /// </summary>
        public string ApproveCountry { get; set; }

        /// <summary>
        /// 其他国家认许日期
        /// </summary>
        public string OtherDate { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        public string LawyerEmail { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 律师行/公司（英文）
        /// </summary>
        public string LawyerCompanyEn { get; set; }

        /// <summary>
        /// 律师行/公司（中文）
        /// </summary>
        public string LawyerCompanyCn { get; set; }

        /// <summary>
        /// 地址（英文）
        /// </summary>
        public string ComAddressEn { get; set; }

        /// <summary>
        /// 地址（中文）
        /// </summary>
        public string ComAddressCn { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string ComTel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string ComFax { get; set; }

        /// <summary>
        /// DX号码
        /// </summary>
        public string DxNO { get; set; }
        /// <summary>
        /// 律师行邮箱
        /// </summary>
        public string ComEmail { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }
    }

}
