using System;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Console;

namespace Mediator
{
    /// <summary>
    ///
    /// 1. Create an "intermediary" that decouples "senders" from "receivers"
    /// 2. Producers are coupled only to the Mediator
    /// 3. Consumers are coupled only to the Mediator
    /// 4. The Mediator arbitrates the storing and retrieving of messages
    ///
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mediator mb = new Mediator();
            new Producer(mb).Start();
            new Producer(mb).Start();
            new Consumer(mb).Start();
            new Consumer(mb).Start();
            new Consumer(mb).Start();
            new Consumer(mb).Start();
        }
    }

    // 1. The "intermediary"
    internal class Mediator
    {
        // 4. The Mediator arbitrates
        private bool _slotFull;
        private readonly object _producerLock = new object();
        private readonly object _consumerLock = new object();

        private int number;
        private readonly Semaphore _mutex = new Semaphore(1, 1);

        public void StoreMessage(int num)
        {
            // no room for another message
            lock (_producerLock)
            {
                while (_slotFull)
                {
                    Thread.Sleep(1000);
                }
                number = num;
                _slotFull = true;
            }
        }

        public int RetrieveMessage()
        {
            // no message to retrieve
            lock (_consumerLock)
            {
                while (!_slotFull)
                {
                    Thread.Sleep(1000);
                }
                var returnValue = number;
                _slotFull = false;
                return returnValue;
            }
        }
    }

    internal class Producer
    {
        // 2. Producers are coupled only to the Mediator
        private readonly Mediator _med;

        private readonly int _id;
        private static int _num = 1;

        public Producer(Mediator m)
        {
            _med = m;
            _id = _num++;
        }

        public void Run()
        {
            var random = new Random();
            while (true)
            {
                int num;
                _med.StoreMessage(num = (random.Next()));
                WriteLine("p" + _id + "-" + num + "  ");
                Thread.Sleep(1000);
            }
        }

        public void Start()
        {
            new Thread(Run).Start();
        }
    }

    internal class Consumer
    {
        // 3. Consumers are coupled only to the Mediator
        private readonly Mediator _med;

        private readonly int _id;
        private static int num = 1;

        public Consumer(Mediator m)
        {
            _med = m;
            _id = num++;
        }

        public void Run()
        {
            while (true)
            {
                WriteLine("c" + _id + "-" + _med.RetrieveMessage() + "  ");
                Thread.Sleep(1000);
            }
        }

        public void Start()
        {
            new Thread(Run).Start();
        }
    }
}