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
    
    public partial class ApprovalRequest
    {
        public System.Guid Id { get; set; }
        public System.Guid Editor_Id { get; set; }
        public string Editor_Name { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public Nullable<System.Guid> ApprovalProcess_Id { get; set; }
    
        public virtual ApprovalProcess ApprovalProcess { get; set; }
    }
}
