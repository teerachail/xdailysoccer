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
    
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentScore { get; set; }
        public int CurrentPredictionPoints { get; set; }
        public string ReferenceTeamId { get; set; }
    }
}
