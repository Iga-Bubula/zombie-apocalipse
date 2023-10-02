using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZombieApocalipse
{
    internal class BareHands: Wepon
    {
        private int demage;
        public BareHands() { demage = base.GetDemage(); }

        public int Demage() { return -demage / 10;  }

        public new int GetDemage() { return demage; }

        public override string ToString()
        {
            return "BareHands";
        }
    }
}
