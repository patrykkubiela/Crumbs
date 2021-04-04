using Moq;
using Xunit;

namespace Crumbs.Core.Tests
{
    public class ObserverTests
    {
        [Fact]
        public void AssignedObserver_React()
        {
            var observerMock = new Mock<IObserve>();
            observerMock.Setup(o => o.Receive());
            
            var broadcaster = new Broadcaster();
            broadcaster.RegisterObserver(observerMock.Object);
            
            broadcaster.Broadcast();
            
            observerMock.Verify(o => o.Receive(), Times.Once);
        }

        [Fact]
        public void Assign_Observer()
        {
            var observerMock = new Mock<IObserve>();
            var broadcaster = new Broadcaster();
            //act
            broadcaster.RegisterObserver(observerMock.Object);

            Assert.Equal(1, broadcaster.Observers.Count);
        }

        [Fact]
        public void Unassign_Observer()
        {
            var observerMock = new Mock<IObserve>();
            var broadcaster = new Broadcaster();
            broadcaster.RegisterObserver(observerMock.Object);
            //act
            broadcaster.UnregisterObserver(observerMock.Object);
            
            Assert.Equal(0, broadcaster.Observers.Count);
        }
    }
}