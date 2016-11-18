using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCreate {
    class Program {
        static void Main(string[] args) {
            new DBTestManager().CreateDB();
            new DBTestManager().CreateTestDB();
        }
    }
}
