using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WCFTicketService.Domains
{
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        [MaxLength(800)]
        public string ShortDescription { get; set; }
        [DataMember]
        [MaxLength]
        public string FullDescription { get; set; }
        [DataMember]
        [Required]
        [MaxLength(400)]
        public string ImagePath { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }
    }
}