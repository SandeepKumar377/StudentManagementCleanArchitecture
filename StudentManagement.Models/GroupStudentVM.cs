using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class GroupStudentVM
    {
        public int GroupId { get; set; }
        public List<CheckBoxTable>? CheckBoxTables { get; set; }
    }
}
