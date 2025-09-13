using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class DoctorEntity:UserBase
    {  
        public required string Specialization { get; set; }

        public uint OfficeNumber { get; set; }
        public bool Status { get; set; } = true;  
    }
}
