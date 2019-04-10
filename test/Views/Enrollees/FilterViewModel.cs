using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace test.Views.Enrollees
{
    public class FilterViewModel
    {
        public FilterViewModel(List<EducationType> educationTypes, int? eduType, List<MaritalStatus> maritalStatuses, int? maritalStatus, 
            List<PreemptiveRight> preemptiveRights, int? preemptiveRight, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            educationTypes.Insert(0, new EducationType { NameEducationType = "Все", IdEducationType = 0 });
            maritalStatuses.Insert(0, new MaritalStatus { NameMaritalStatus = "Все", IdMaritalStatus = 0 });
            preemptiveRights.Insert(0, new PreemptiveRight { NamePreemptiveRight = "Все", IdPreemptiveRight = 0 });


            //
            EduTypes = new SelectList(educationTypes, "IdEducationType", "NameEducationType", eduType);
            MaritalStatuses = new SelectList(maritalStatuses, "IdMaritalStatus", "NameMaritalStatus", maritalStatus);
            PreemptiveRights = new SelectList(preemptiveRights, "IdPreemptiveRight", "NamePreemptiveRight", preemptiveRight);


            SelectedEduType = eduType;
            SelectedMaritalStatus = maritalStatus;
            SelectedPreemptiveRight = preemptiveRight;
            SelectedName = name;

            isFiltrated = (SelectedEduType != null && SelectedEduType != 0) || (SelectedMaritalStatus != null && SelectedMaritalStatus != 0) || (SelectedPreemptiveRight != null && SelectedPreemptiveRight != 0) || (!String.IsNullOrEmpty(SelectedName));

        }
        public SelectList EduTypes { get; private set; } // список типов образования
        public SelectList MaritalStatuses { get; private set; } // список типов семейного положения
        public SelectList PreemptiveRights { get; private set; } //список преимущественных прав

        public int? SelectedEduType { get; private set; }   // выбранный тип образования
        public int? SelectedMaritalStatus { get; private set; }   // выбранный тип сейменого положения
        public int? SelectedPreemptiveRight { get; private set; }   // выбранное преим право
        public string SelectedName { get; private set; }    // введенное имя

        public bool isFiltrated { get; private set; } //применены ли фильтры 
    
    }
}

