using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COREAPP2.Domain.Entities.SpModel
{
    public partial class T_VULN
    {
        [Key]
        public long VULN_SEQ { get; set; }
        public long GROUP_SEQ { get; set; }
        public bool? MANUAL_YN { get; set; }
        public bool? AUTO_YN { get; set; }
        public string MANAGE_ID { get; set; }
        public string CLIENT_STANDARD_ID { get; set; }
        public string VULN_NAME { get; set; }
        public int? SORT_ORDER { get; set; }
        public bool? RULE_YN { get; set; }
        public int? RATE { get; set; }
        public int? SCORE { get; set; }
        public string APPLY_TIME { get; set; }
        public string DETAIL { get; set; }
        public string DETAIL_PATH { get; set; }
        public string JUDGEMENT { get; set; }
        public string EFFECT { get; set; }
        public string REMEDY { get; set; }
        public string REMEDY_PATH { get; set; }
        public string REFRRENCE { get; set; }
        public string PARSER_CONTENTS { get; set; }
        public string ORG_PARSER_CONTENTS { get; set; }
        public string APPLY_TARGET { get; set; }
        public bool? USE_YN { get; set; }
        public string EXCEPT_CD { get; set; }
        public string EXCEPT_TERM_TYPE { get; set; }
        public DateTime? EXCEPT_TERM_FR { get; set; }
        public DateTime? EXCEPT_TERM_TO { get; set; }
        public string EXCEPT_REASON { get; set; }
        public string EXCEPT_USER_ID { get; set; }
        public DateTime? EXCEPT_DT { get; set; }
        public string CREATE_USER_ID { get; set; }
        public DateTime? CREATE_DT { get; set; }
        public string UPDATE_USER_ID { get; set; }
        public DateTime? UPDATE_DT { get; set; }
        public long? VULGROUP { get; set; }
        public string VULNO { get; set; }
        public string REMEDY_DETAIL { get; set; }
        public string OVERVIEW { get; set; }
        public bool? MANAGEMENT_VULN_YN { get; set; }

        public T_VULN_GROUP GROUP_SEQNavigation { get; set; }
    }
}
