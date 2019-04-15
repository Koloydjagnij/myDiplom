using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static test.Controllers.EnrolleeControl.EnrolleesController;

namespace test.Views.Enrollees
{
    public class SortViewModel
    {
        public SortState SurnameSort { get; set; } // значение для сортировки по имени
        public SortState ProfNumSort { get; set; }    // значение для сортировки по возрасту
        public SortState NameSort { get; set; }   // значение для сортировки по компании
        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            SurnameSort = SortState.SurnameDesc;
            ProfNumSort = SortState.ProfNumDesc;
            NameSort = SortState.NameDesc;
            Up = true;

            if (sortOrder == SortState.ProfNumDesc || sortOrder == SortState.SurnameDesc
                || sortOrder == SortState.NameDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortState.SurnameDesc:
                    Current = SurnameSort = SortState.SurnameAsc;
                    break;
                case SortState.ProfNumAsc:
                    Current = ProfNumSort = SortState.ProfNumDesc;
                    break;
                case SortState.ProfNumDesc:
                    Current = ProfNumSort = SortState.ProfNumAsc;
                    break;
                case SortState.NameAsc:
                    Current = NameSort = SortState.NameDesc;
                    break;
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                default:
                    Current = SurnameSort = SortState.SurnameDesc;
                    break;
            }
        }
        
    }
}
