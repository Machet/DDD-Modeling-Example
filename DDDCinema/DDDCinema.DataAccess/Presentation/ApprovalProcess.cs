//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDDCinema.DataAccess.Presentation
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApprovalProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApprovalProcess()
        {
            this.ApprovalRequests = new HashSet<ApprovalRequest>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid PromotionId { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
    }
}