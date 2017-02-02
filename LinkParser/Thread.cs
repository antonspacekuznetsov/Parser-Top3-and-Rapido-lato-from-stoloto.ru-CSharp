using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
namespace LinkParser
{

    class MyThread
    {
        Proccess2 _proc;
        Thread _rapido, _top3, _sound;
        static bool started;
        public MyThread()
        {
            started = false;
             _proc= new Proccess2();
            
             
             
        }

        public void Start()
        {

            if (Settings.sound == 1)
            {
                _sound = new Thread(new ThreadStart(this.PlaySound));
                _sound.Start();
            }
            if (Settings.rOn == 1)
            {
                _rapido = new Thread(new ThreadStart(_proc.StartRedio));
                _rapido.Start();
                Settings.rThread = true;

            }
            if (Settings.top3On == 1)
            {
                Settings.top3Thread = true;
                _top3 = new Thread(new ThreadStart(_proc.Start));
                _top3.Start();
            }


        }

        public void Stop()
        {
            if (Settings.rOn == 1)
            {

                Settings.rThread = false;

            }
            if (Settings.top3On == 1)
            {
                Settings.top3Thread = false;
                
            }

            if (Settings.sound == 1)
            {
                Settings.soundLoop = -9;
            }

                //_sound.Suspend
        }

        private void PlaySound()
        {
            SoundPlayer simpleSound = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "cartoon010.wav");

            for (; ; )
            {
                if (Settings.soundLoop < 0)
                    return;
                if (Settings.sound == 1 && Settings.soundLoop > 1)
                {
                    simpleSound.Play();
                }
                Thread.Sleep(3000);
            }
        }
    }
}
