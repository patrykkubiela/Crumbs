using System;
using Akka.Actor;

namespace Crumbs.Core
{
    public class CrumbActor : ReceiveActor
    {
        public CrumbActor()
        {
            Receive<Crumb>(crumb =>
            {
                Console.WriteLine($"Name of crumb: {crumb.Name}");
            });
        }
    }
}