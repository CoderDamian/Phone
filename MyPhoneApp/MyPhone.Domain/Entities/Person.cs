﻿using MyPhone.Domain.Seedwork;

namespace MyPhone.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public ICollection<Phone> Phones { get; set; }

        public Person()
        {
            Phones = new HashSet<Phone>();
        }
    }
}
