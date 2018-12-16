using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COREAPP2.Domain.Entities.EfModel
{
    public partial class T_COMMON_CODE : BaseEntity
    {
        [Key]
        public string CODE_TYPE { get; set; }
        public string CODE_TYPE_NAME { get; set; }
        [Key]
        public string CODE_ID { get; set; }
        public string CODE_NAME { get; set; }
        public int? CODE_VAL { get; set; }
        public int? SORT_ORDER { get; set; }
        public bool? USE_YN { get; set; }
        public string CODE_COMMENT { get; set; }
        public string CREATE_USER_ID { get; set; }
        public DateTime? CREATE_DT { get; set; }
    }
}
