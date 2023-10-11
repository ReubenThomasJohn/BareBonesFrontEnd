using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BareBonesFrontEnd.Models.ViewModels
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public string StateName { get; set; }
    }
}