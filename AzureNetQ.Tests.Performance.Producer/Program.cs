﻿using System;
using System.Threading;

namespace AzureNetQ.Tests.Performance.Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var publishInterval = 0;
            var messageSize = 1000;

            if (args.Length > 0)
            {
                publishInterval = int.Parse(args[0]);
            }
            if (args.Length > 1)
            {
                messageSize = int.Parse(args[1]);
            }

            Console.Out.WriteLine("publishInterval = {0}", publishInterval);
            Console.Out.WriteLine("messageSize = {0}", messageSize);

            throw new NotImplementedException();
            
            //var bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true;timeout=10;heartbeat=5;" + 
            //    "product=producer",
            //    x => x.Register<IAzureNetQLogger>(_ => new NoDebugLogger()));

            //var messageCount = 0;
            //var messageRateTimer = new Timer(state =>
            //{
            //    Console.Out.WriteLine("messages per second = {0}", messageCount);
            //    Interlocked.Exchange(ref messageCount, 0);
            //}, null, 1000, 1000);

            //var cancelled = false;
            //var publishThread = new Thread(state =>
            //{
            //    while (!cancelled)
            //    {
            //        var text = new string('#', messageSize);
            //        var message = new TestPerformanceMessage { Text = text };

            //        try
            //        {
            //            bus.PublishAsync(message).ContinueWith(task =>
            //                {
            //                    if (task.IsCompleted)
            //                    {
            //                        Interlocked.Increment(ref messageCount);
            //                    }
            //                    if (task.IsFaulted)
            //                    {
            //                        Console.WriteLine(task.Exception);
            //                    }
            //                });
            //        }
            //        catch (AzureNetQException easyNetQException)
            //        {
            //            Console.Out.WriteLine(easyNetQException.Message);
            //            Thread.Sleep(1000);
            //        }
            //    }
            //});
            //publishThread.Start();

            //Console.Out.WriteLine("Timer running, ctrl-C to end");

            //Console.CancelKeyPress += (source, cancelKeyPressArgs) =>
            //{
            //    Console.Out.WriteLine("Shutting down");
                
            //    cancelled = true;
            //    publishThread.Join();
            //    messageRateTimer.Dispose();
            //    bus.Dispose();
            //    Console.WriteLine("Shut down complete");
            //};

            //Thread.Sleep(Timeout.Infinite);
        }
    }

    public class NoDebugLogger : IAzureNetQLogger
    {
        public void DebugWrite(string format, params object[] args)
        {
            
        }

        public void InfoWrite(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void ErrorWrite(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void ErrorWrite(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}