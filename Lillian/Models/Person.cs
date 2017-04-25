//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lillian.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.SalesOrders = new HashSet<SalesOrder>();
        }
    
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public int PersonTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int SuburbId { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual PersonType PersonType { get; set; }
        public virtual SuburbType SuburbType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}