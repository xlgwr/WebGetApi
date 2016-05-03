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
    //[Table("gwd_GovernmentPhonebook_main")]
    //public class gwd_GovernmentPhonebook_main : entityCommMain
    //{
    //    public gwd_GovernmentPhonebook_main()
    //    {
    //        this.gwd_GovernmentPhonebook_items = new List<gwd_GovernmentPhonebook_items>();
    //    }
    //    public ICollection<gwd_GovernmentPhonebook_items> gwd_GovernmentPhonebook_items { get; set; }
    //}

    [Table("gwd_GovernmentPhonebook_items")]
    public class gwd_GovernmentPhonebook_items : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
