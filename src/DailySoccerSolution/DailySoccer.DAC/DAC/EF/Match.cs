//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DailySoccer.DAC.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Match()
        {
            this.GuessMatches = new HashSet<GuessMatch>();
            this.TeamHome = new Team();
            this.TeamAway = new Team();
        }
    
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public System.DateTime BeginDate { get; set; }
        public Nullable<System.DateTime> StartedDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public string Status { get; set; }
    
        public Team TeamHome { get; set; }
        public Team TeamAway { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuessMatch> GuessMatches { get; set; }
    }
}
