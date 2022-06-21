using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace sa3_c3a_groupE.Models
{
    [Table("people")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        [MaxLength(250)]
        public int Age { get; set; }
        [MaxLength(250)]
        public string Gender { get; set; }
        [MaxLength(250)]
        public string InitialHeight { get; set; }
        [MaxLength(250)]
        public string ConvertedHeight { get; set; }
        [MaxLength(250)]
        public string InitialWeight { get; set; }
        [MaxLength(250)]
        public string ConvertedWeight { get; set; }
        [MaxLength(250)]
        public string InitialSalary { get; set; }
        [MaxLength(250)]
        public string ConvertedSalary { get; set; }
        
    }
}
