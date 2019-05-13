using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static test.Controllers.EnrolleeControl.EnrolleesController;

namespace test.Views.Enrollees
{
    public class SortViewModel
    {
        public SortState PatrSort { get; set; }
        public SortState SurnameSort { get; set; } // значение для сортировки по имени
        public SortState ProfNumSort { get; set; }    // значение для сортировки по возрасту
        public SortState NameSort { get; set; }   // значение для сортировки по компании
        public SortState EduYearSort { get; set; }
        public SortState DateOfBirthSort { get; set; }
        public SortState DateArrivedSort { get; set; }
        public SortState DateDeducSort { get; set; }
        public SortState gpAVGSort { get; set; }
        public SortState GroupSort { get; set; }
        public SortState EduTypeSort { get; set; }
        public SortState fSpecSort { get; set; }
        public SortState cSpecSort { get; set; }

        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            PatrSort = SortState.PatrDesc;
            SurnameSort = SortState.SurnameDesc;
            ProfNumSort = SortState.ProfNumDesc;
            NameSort = SortState.NameDesc;
            EduYearSort = SortState.EduYearDesc;
            DateOfBirthSort = SortState.DateOfBirthDesc;
            DateArrivedSort = SortState.DateArrivedDesc;
            DateDeducSort = SortState.DateDeducDesc;
            gpAVGSort = SortState.gpAVG_Desc;
            GroupSort = SortState.GroupDesc;
            EduTypeSort = SortState.EduTypeDesc;
            fSpecSort = SortState.fSpecDesc;
            cSpecSort = SortState.cSpecDesc;

            Up = true;

            if (sortOrder == SortState.ProfNumDesc || sortOrder == SortState.SurnameDesc
                || sortOrder == SortState.NameDesc || sortOrder == SortState.PatrDesc
                || sortOrder == SortState.DateArrivedDesc || sortOrder == SortState.DateDeducDesc
                || sortOrder == SortState.DateOfBirthDesc || sortOrder == SortState.EduYearDesc
                || sortOrder == SortState.gpAVG_Desc || sortOrder == SortState.GroupDesc
                || sortOrder == SortState.EduTypeDesc || sortOrder == SortState.fSpecDesc
                || sortOrder == SortState.cSpecDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortState.fSpecAsc:
                    Current = fSpecSort = SortState.fSpecAsc;
                    break;
                case SortState.fSpecDesc:
                    Current = fSpecSort = SortState.fSpecDesc;
                    break;

                case SortState.cSpecAsc:
                    Current = cSpecSort = SortState.cSpecAsc;
                    break;
                case SortState.cSpecDesc:
                    Current = cSpecSort = SortState.cSpecDesc;
                    break;

                case SortState.EduTypeAsc:
                    Current = EduTypeSort = SortState.EduTypeAsc;
                    break;
                case SortState.EduTypeDesc:
                    Current = EduTypeSort = SortState.EduTypeDesc;
                    break;

                case SortState.GroupAsc:
                    Current = GroupSort = SortState.GroupAsc;
                    break;
                case SortState.GroupDesc:
                    Current = GroupSort = SortState.GroupDesc;
                    break;
                case SortState.PatrAsc:
                    Current = PatrSort = SortState.PatrAsc;
                    break;
                case SortState.PatrDesc:
                    Current = PatrSort = SortState.PatrDesc;
                    break;

                case SortState.EduYearAsc:
                    Current = EduYearSort = SortState.EduYearAsc;
                    break;
                case SortState.EduYearDesc:
                    Current = EduYearSort = SortState.EduYearDesc;
                    break;

                case SortState.DateArrivedAsc:
                    Current = DateArrivedSort = SortState.DateArrivedAsc;
                    break;
                case SortState.DateArrivedDesc:
                    Current = DateArrivedSort = SortState.DateArrivedDesc;
                    break;

                case SortState.DateDeducAsc:
                    Current = DateDeducSort = SortState.DateDeducAsc;
                    break;
                case SortState.DateDeducDesc:
                    Current = DateDeducSort = SortState.DateDeducDesc;
                    break;

                case SortState.DateOfBirthAsc:
                    Current = DateOfBirthSort = SortState.DateOfBirthAsc;
                    break;
                case SortState.DateOfBirthDesc:
                    Current = DateOfBirthSort = SortState.DateOfBirthDesc;
                    break;

                case SortState.gpAVG_Asc:
                    Current = gpAVGSort = SortState.gpAVG_Asc;
                    break;
                case SortState.gpAVG_Desc:
                    Current = gpAVGSort = SortState.gpAVG_Desc;
                    break;


                case SortState.SurnameDesc:
                    Current = SurnameSort = SortState.SurnameDesc;
                    break;
                case SortState.ProfNumAsc:
                    Current = ProfNumSort = SortState.ProfNumAsc;
                    break;
                case SortState.ProfNumDesc:
                    Current = ProfNumSort = SortState.ProfNumDesc;
                    break;
                case SortState.NameAsc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameDesc;
                    break;
                default:
                    Current = SurnameSort = SortState.SurnameAsc;
                    break;
            }
        }
        
    }
}
