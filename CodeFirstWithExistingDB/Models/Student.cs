namespace CodeFirstWithExistingDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int StudentID { get; set; }

        [Required]
        public string StudentName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
