﻿using PayRollSystem.entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PayRollSystem.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DataJoined { get; set; } = DateTime.UtcNow;
        public string Role { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "NationalInsuranceNo is required"), StringLength(50), Display(Name = "NI No"), RegularExpression(@"^[A - CEGHJ -PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s$")]
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public DateTime DateJoined { get; internal set; }
    }
}
