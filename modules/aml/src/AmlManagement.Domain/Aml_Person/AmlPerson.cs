using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using static MsDemo.Shared.Enums.Enums;

namespace AmlManagement.Aml_Person
{
    public class AmlPerson : FullAuditedAggregateRoot<Guid>
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        public AmlPerson(Guid id, string firstName,string lastName,string fatherName, string motherName )
        {
            Id = id;
            FirstName= firstName;
            FatherName= fatherName;
            LastName= lastName;
            MotherName= motherName;
        }

    }
}



