namespace Crumbs.Core
{
    public class Crumb
    {
        public string Name { get; private set; }

        public Crumb(string name)
        {
            Name = name;
        }
    }
}