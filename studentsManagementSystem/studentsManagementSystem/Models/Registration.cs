//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace studentsManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string NIC { get; set; }
        public Nullable<int> cource_id { get; set; }
        public Nullable<int> batch_id { get; set; }
        public Nullable<int> phone { get; set; }
    
        public virtual batch batch { get; set; }
        public virtual Cource Cource { get; set; }
    }
}
