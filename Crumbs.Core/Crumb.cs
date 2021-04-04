using System;

namespace Crumbs.Core
{
    public class Crumb : CrumbBase
    {
        public override void Receive()
        {
            Console.Write("this is message from within crumb");
        }
    }
}