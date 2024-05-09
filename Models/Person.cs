﻿namespace AspCore_Api_2.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + ' ' + FirstName;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}