﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API_DEMO.Models
{
    [Table("EMPLOYEEAPI")]
    public class Employee
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public long phone { get; set; }
        public string? address { get; set; }

    }
}