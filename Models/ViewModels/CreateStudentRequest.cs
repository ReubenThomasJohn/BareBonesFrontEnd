using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BareBonesFrontEnd.Models.ViewModels
{
    public class CreateStudentRequest
    {
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}