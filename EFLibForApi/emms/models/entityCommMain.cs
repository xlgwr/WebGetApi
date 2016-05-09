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
    /// 公共主表
    /// </summary>
    [Table("entityCommMain")]
    public class entityCommMain : entityTID
    {
        public long tLang { get; set; }

        [StringLength(500)]
        public string tname { get; set; }


        [StringLength(300)]
        public string ttype { get; set; }


        [Column(TypeName = "text")]
        public string thtml { get; set; }

        public entityCommMain()
        {
            this.gwd_Barristers_items = new List<gwd_Barristers_items>();

            this.gwd_Lawyers_items = new List<gwd_Lawyers_items>();

            this.gwd_GovernmentPhonebook_items = new List<gwd_GovernmentPhonebook_items>();

            this.gwd_RegisteredPharmacists_items = new List<gwd_RegisteredPharmacists_items>();

            this.gwd_InstituteSurveyors_items = new List<gwd_InstituteSurveyors_items>();

            this.gwd_PsychologistsList_items = new List<gwd_PsychologistsList_items>();

            this.gwd_RegArchitect_items = new List<gwd_RegArchitect_items>();

            this.gwd_RegBuildingCompany_items = new List<gwd_RegBuildingCompany_items>();

            this.gwd_architect_items = new List<gwd_architect_items>();

            this.gwd_ConstructionCompany_items = new List<gwd_ConstructionCompany_items>();

            this.gwd_SecurityBureau_items = new List<gwd_SecurityBureau_items>();

            this.gwd_Secretaries_items = new List<gwd_Secretaries_items>();
        }
        public ICollection<gwd_Barristers_items> gwd_Barristers_items { get; set; }
        public ICollection<gwd_Lawyers_items> gwd_Lawyers_items { get; set; }
        public ICollection<gwd_GovernmentPhonebook_items> gwd_GovernmentPhonebook_items { get; set; }
        public ICollection<gwd_RegisteredPharmacists_items> gwd_RegisteredPharmacists_items { get; set; }
        public ICollection<gwd_InstituteSurveyors_items> gwd_InstituteSurveyors_items { get; set; }
        public ICollection<gwd_PsychologistsList_items> gwd_PsychologistsList_items { get; set; }
        public ICollection<gwd_RegArchitect_items> gwd_RegArchitect_items { get; set; }
        public ICollection<gwd_RegBuildingCompany_items> gwd_RegBuildingCompany_items { get; set; }
        public ICollection<gwd_architect_items> gwd_architect_items { get; set; }
        public ICollection<gwd_ConstructionCompany_items> gwd_ConstructionCompany_items { get; set; }
        public ICollection<gwd_SecurityBureau_items> gwd_SecurityBureau_items { get; set; }
        public ICollection<gwd_Secretaries_items> gwd_Secretaries_items { get; set; }

    }
}
