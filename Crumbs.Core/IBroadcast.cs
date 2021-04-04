namespace Crumbs.Core
{
    public interface IBroadcast
    {
        void RegisterObserver(IObserve observer);
        void UnregisterObserver(IObserve observer);
        void Broadcast();
    }
}