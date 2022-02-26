using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonConsumer.Json
{
    public class PetModel
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class OwnerModel
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<PetModel> pets { get; set; }
    }

}
