﻿using System;
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
    /// 香港心理学会 PsychologistsList
    /// http://www.hkps.org.hk/index.php
    /// </summary>
    [Table("i_PsychologicalSociety")]
    public class i_PsychologicalSociety : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        public long PsychologicalId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string Name_En { get; set; }

        [Index]
        [StringLength(128)]
        public string Name_Cn { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 登记号码
        /// </summary>
        public string RegisteredNo { get; set; }

        /// <summary>
        /// 支部
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        
        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
