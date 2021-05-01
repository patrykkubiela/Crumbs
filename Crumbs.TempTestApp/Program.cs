using System;
using Akka.Actor;
using Crumbs.Core;

namespace Crumbs.TempTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorSystem");
            var crumbActor = system.ActorOf<CrumbActor>("crumb");
            crumbActor.Tell(new Crumb());

            Console.Read();
        }
    }
}