using System;

namespace EFBasics_3_Fluent.Entities
{
    public class Audit
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
