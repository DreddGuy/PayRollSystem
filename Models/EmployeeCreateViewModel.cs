﻿using PayRollSystem.entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayRollSystem.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Field EmployeeNo is Required")]
        public string EmployeeNo { get; set; }
        [Required(ErrorMessage = "FirstName is Required"), StringLength(50,MinimumLength = 2), Display(Name ="First name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get { return FirstName + " " + MiddleName + " " + LastName; }
        }
        public string Gender { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

    }
}
