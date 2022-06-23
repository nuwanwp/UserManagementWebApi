using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModule.Domain.model
{
    public class Administrator : Person
    {
        public string Privilege { get; set; }
    }
}
