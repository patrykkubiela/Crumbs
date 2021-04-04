using Crumbs.Core.Broadcasting;
using Moq;
using Xunit;

namespace Crumbs.Core.Tests
{
    public class CrumbTest
    {
        [Fact]
        public void AssignedObserver_IntoCrumb_Broadcast_Call_Receive()
        {
            var observerMock = new Mock<IObserver>();
            observerMock.Setup(o => o.Receive());

            var broadcaster = new Crumb();
            broadcaster.RegisterObserver(observerMock.Object);
            //act
            broadcaster.Broadcast();

            observerMock.Verify(o => o.Receive(), Times.Once);
        }

        [Fact]
        public void Assign_Observer()
        {
            var observerCrumb = new Crumb();
            var broadcaster = new Crumb();

            //act
            Assert.Empty(broadcaster.Observers);
            broadcaster.RegisterObserver(observerCrumb);

            Assert.Single(broadcaster.Observers);
        }

        [Fact]
        public void Unassign_Observer()
        {
            var observerCrumb = new Crumb();
            var broadcaster = new Crumb();
            broadcaster.RegisterObserver(observerCrumb);

            //act
            Assert.Single(broadcaster.Observers);
            broadcaster.UnregisterObserver(observerCrumb);

            Assert.Empty(broadcaster.Observers);
        }
    }
}