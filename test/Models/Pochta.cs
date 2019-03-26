using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace test.Models
{
    public class Pochta
    {
        public int Id { get; set; }

        [Display(Name = "Почтовый индекс")]
        public string Index { get; set; }

        [Display(Name = "Наименование объекта почтовой связи")]
        public string OPSName { get; set; }

        [Display(Name = "Тип объекта почтовой связи")]
        public string OPSType   { get; set; }
    
        [Display(Name = "Индекс вышестоящего по иерархии подчиненности объекта почтовой связи")]
        public string OPSSubm{ get; set; }

        [Display(Name = "Наименование области, края, республики, в которой находится объект почтовой связи")]
        public string Region { get; set; } 

        [Display(Name = "Наименование автономной области, в которой находится объект почтовой связи")]
        public string Autonom  { get; set; }

        [Display(Name = "Наименование района, в котором находится объект почтовой связи")]
        public string Area { get; set; } 

        [Display(Name = "Наименование населенного пункта, в котором находится объект почтовой связи")]
        public string City { get; set; }

        [Display(Name = "Наименование подчиненного населенного пункта, в котором находится объект почтовой связи")]
        public string City1 { get; set; }   

        [Display(Name = "Дата актуализации информации об объекте почтовой связи")]
        public string ActDate { get; set; }

        [Display(Name = "Старый индекс")]
        public string IndexOld { get; set; }
    }
}

