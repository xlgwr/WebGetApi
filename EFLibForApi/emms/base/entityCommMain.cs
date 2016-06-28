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
            this.i_Barristers = new List<i_Barristers>();

            this.i_WithCertLawyers = new List<i_WithCertLawyers>();

            this.i_ForeignLawyers = new List<i_ForeignLawyers>();

            this.i_GovPhonebook = new List<i_GovPhonebook>();

            this.i_RegPharmacist = new List<i_RegPharmacist>();

            this.i_InstituteSurveyors = new List<i_InstituteSurveyors>();

            this.i_PsychologicalSociety = new List<i_PsychologicalSociety>();

            this.i_RegArchitect = new List<i_RegArchitect>();

            this.i_RegBuildingCom = new List<i_RegBuildingCom>();

            this.i_Architect = new List<i_Architect>();

            this.i_BuildingCom = new List<i_BuildingCom>();

            this.i_SecurityBureau = new List<i_SecurityBureau>();

            this.i_Secretaries = new List<i_Secretaries>();
        }
        public ICollection<i_Barristers> i_Barristers { get; set; }
        public ICollection<i_WithCertLawyers> i_WithCertLawyers { get; set; }
        public ICollection<i_ForeignLawyers> i_ForeignLawyers { get; set; }

        public ICollection<i_GovPhonebook> i_GovPhonebook { get; set; }
        public ICollection<i_RegPharmacist> i_RegPharmacist { get; set; }
        public ICollection<i_InstituteSurveyors> i_InstituteSurveyors { get; set; }
        public ICollection<i_PsychologicalSociety> i_PsychologicalSociety { get; set; }
        public ICollection<i_RegArchitect> i_RegArchitect { get; set; }
        public ICollection<i_RegBuildingCom> i_RegBuildingCom { get; set; }
        public ICollection<i_Architect> i_Architect { get; set; }
        public ICollection<i_BuildingCom> i_BuildingCom { get; set; }
        public ICollection<i_SecurityBureau> i_SecurityBureau { get; set; }
        public ICollection<i_Secretaries> i_Secretaries { get; set; }

    }
}
