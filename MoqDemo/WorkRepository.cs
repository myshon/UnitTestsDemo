using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MoqDemo
{
    public class WorkRepository : IWorkRepository
    {
        public void Save(Work entity)
        {
            // save
        }

        public Work Get(int id)
        {
            // get
            return new Work();
        }
    }
}
