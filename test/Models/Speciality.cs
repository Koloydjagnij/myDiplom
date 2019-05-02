using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Speciality
    {
        public Speciality()
        {
            ExamForSpeciality = new HashSet<ExamForSpeciality>();
        }

        public int IdSpeciality { get; set; }
        [Required(ErrorMessage ="Не указано название специальности")]
        [Display(Name = "Специальность")]
        public string NameSpeciality { get; set; }
        [Required(ErrorMessage = "Не указано количество мест на специальности")]
        [Display(Name = "Количество мест на специальности")]
        public int CountAbiturToSpeciality { get; set; }

        public ICollection<ExamForSpeciality> ExamForSpeciality { get; set; }
        public ICollection<Enrollee> EnrolleesFirst { get; set; }
        public ICollection<Enrollee> EnrolleesSecond { get; set; }
        public ICollection<Enrollee> EnrolleesThird { get; set; }
        public ICollection<Enrollee> EnrolleesCurrent { get; set; }
        public ICollection<Enrollee> EnrolleesReserve { get; set; }
    }
}
