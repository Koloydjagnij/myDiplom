using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using test.Models;

namespace test.Views.Enrollees
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Group> groupsList,int[] groups ,List<Speciality> specialities, int[] fSpec, int[] cSpec ,List<EducationType> educationTypes, int[] eduType, List<MaritalStatus> maritalStatuses, int? maritalStatus, 
            List<PreemptiveRight> preemptiveRights, int? preemptiveRight, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            //educationTypes.Insert(0, new EducationType { NameEducationType = "Все", IdEducationType = 0 });
            maritalStatuses.Insert(0, new MaritalStatus { NameMaritalStatus = "Все", IdMaritalStatus = 0 });
            preemptiveRights.Insert(0, new PreemptiveRight { NamePreemptiveRight = "Все", IdPreemptiveRight = 0 });


            //
            Groups = new MultiSelectList(groupsList, "IdGroup", "GroupName", groups);
            FirstSpecialities = new MultiSelectList(specialities, "IdSpeciality", "NameSpeciality", fSpec);
            CurrentSpecialities = new MultiSelectList(specialities, "IdSpeciality", "NameSpeciality", cSpec);
            EduTypes = new MultiSelectList(educationTypes, "IdEducationType", "NameEducationType", eduType);
            MaritalStatuses = new SelectList(maritalStatuses, "IdMaritalStatus", "NameMaritalStatus", maritalStatus);
            PreemptiveRights = new SelectList(preemptiveRights, "IdPreemptiveRight", "NamePreemptiveRight", preemptiveRight);


            SelectedGroups = groups;
            SelectedFirstSpecialities = fSpec;
            SelectedCurrentSpecialities = cSpec;
            SelectedEduType = eduType;
            SelectedMaritalStatus = maritalStatus;
            SelectedPreemptiveRight = preemptiveRight;
            SelectedName = name;

            isFiltrated = (SelectedEduType.Length != 0 )|| (SelectedFirstSpecialities.Length !=0 ) 
                || (SelectedCurrentSpecialities.Length != 0)|| (SelectedGroups.Length != 0) 
                || (SelectedMaritalStatus != null && SelectedMaritalStatus != 0) 
                || (SelectedPreemptiveRight != null && SelectedPreemptiveRight != 0) || (!String.IsNullOrEmpty(SelectedName));

        }
        public MultiSelectList Groups { get; private set; } // список групп
        public MultiSelectList CurrentSpecialities { get; private set; } // список специальностей по текущей позиции
        public MultiSelectList FirstSpecialities { get; private set; } // список специальностей по первому приоритету
        public MultiSelectList EduTypes { get; private set; } // список типов образования
        public SelectList MaritalStatuses { get; private set; } // список типов семейного положения
        public SelectList PreemptiveRights { get; private set; } //список преимущественных прав

        public int[] SelectedGroups{ get; private set; } // выбранные Группы
        public int[] SelectedCurrentSpecialities { get; private set; } // выбранные специальности по текущей позиции
        public int[] SelectedFirstSpecialities { get; private set; } // выбранные специальности по первому приоритету
        public int[] SelectedEduType { get; private set; }   // выбранный тип образования
        public int? SelectedMaritalStatus { get; private set; }   // выбранный тип сейменого положения
        public int? SelectedPreemptiveRight { get; private set; }   // выбранное преим право
        public string SelectedName { get; private set; }    // введенное имя

        public bool isFiltrated { get; private set; } //применены ли фильтры 
    
    }
}

