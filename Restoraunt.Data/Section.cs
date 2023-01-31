using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoraunt.Data
{
    public class Section
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public List<Type> Types { get; set; }
    }
}
