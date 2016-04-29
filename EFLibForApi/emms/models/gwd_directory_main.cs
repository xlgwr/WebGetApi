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
    [Table("gwd_directory_main")]
    public class gwd_directory_main : entityMainComm
    {
        public gwd_directory_main()
        {
            this.gwd_directory_items = new List<gwd_directory_items>();
        }
        public ICollection<gwd_directory_items> gwd_directory_items { get; set; }
    }

    [Table("gwd_directory_items")]
    public class gwd_directory_items : entityItems
    {
        [Index]
        [ForeignKey("gwd_directory_main")]
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
        /// 电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        [JsonIgnore]
        public gwd_directory_main gwd_directory_main { get; set; }

    }

}
