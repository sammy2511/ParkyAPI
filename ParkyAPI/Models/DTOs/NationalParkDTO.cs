using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models.DTOs
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class NationalParkDTO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        [Key]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public int Id { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        [Required]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string Name { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        [Required]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string State { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public DateTime Created { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public DateTime Established { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member


    }
}
