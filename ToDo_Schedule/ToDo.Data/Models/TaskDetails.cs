using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ToDo.Data.Models
{

    public class TaskDetails
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusType Status { get; set; }
        public PriorityType Priority { get; set; }
        [DataType(dataType: DataType.Date)]
        public System.DateTime DueDate { get; set; }
    }
}
