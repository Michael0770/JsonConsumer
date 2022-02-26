using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonConsumer.Models
{
    public class CatsListModel
    {
        public IList<string> MaleOwnerCats { get; set; }
        public IList<string> FemaleOwnerCats { get; set; }

        public CatsListModel()
        {
            this.MaleOwnerCats = new List<string>();
            this.FemaleOwnerCats = new List<string>();
        }
    }
}
