using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COREAPP2.Domain.Entities.SpModel
{
    public partial class T_VULN_GROUP
    {
        public T_VULN_GROUP()
        {
            T_VULN = new HashSet<T_VULN>();
        }

        [Key]
        public long GROUP_SEQ { get; set; }
        public long UPPER_SEQ { get; set; }
        public int LEVEL { get; set; }
        public string GROUP_TYPE { get; set; }
        public long COMP_SEQ { get; set; }
        public string DIAG_KIND { get; set; }
        public string DIAG_TERM { get; set; }
        public string GROUP_ID { get; set; }
        public string GROUP_NAME { get; set; }
        public string DIAG_TOOL { get; set; }
        public int? SORT_ORDER { get; set; }
        public string CREATE_USER_ID { get; set; }
        public DateTime? CREATE_DT { get; set; }
        public string UPDATE_USER_ID { get; set; }
        public DateTime? UPDATE_DT { get; set; }

        public T_COMP_INFO COMP_SEQNavigation { get; set; }
        public ICollection<T_VULN> T_VULN { get; set; }
    }
}
