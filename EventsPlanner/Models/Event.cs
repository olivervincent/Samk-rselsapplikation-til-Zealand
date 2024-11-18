﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace EventsPlanner.Models
{
    [Table("Event")]
    public partial class Event
    {
        public Event()
        {
            Stands = new HashSet<Stand>();
        }

        [Key]
        [Column("Event_No")]
        public int EventNo { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [InverseProperty(nameof(Stand.EventNoNavigation))]
        public virtual ICollection<Stand> Stands { get; set; }
    }
}