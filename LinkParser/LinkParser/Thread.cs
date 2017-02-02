using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LinkParser
{

    class MyThread
    {
        Proccess2 _proc;
        Thread _rapido, _top3;
        public MyThread()
        {
             _proc= new Proccess2();
        }

        public void Start()
        {
            if (Settings.rOn == 1)
            {
                _rapido = new Thread(new ThreadStart(_proc.StartRedio));
                _rapido.Start();

            }
            if (Settings.top3On == 1)
            {
                _top3 = new Thread(new ThreadStart(_proc.Start));
                _top3.Start();
            }


        }

        public void Stop()
        {
            if (_rapido != null)
                _rapido.Abort();

            if (_top3 != null)
                _top3.Abort();
        }
    }
}
