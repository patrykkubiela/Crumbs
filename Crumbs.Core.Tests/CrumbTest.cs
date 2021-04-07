using System.Linq;
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
            var observerMock = new Mock<ICrumb>();
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

        [Fact]
        public void GetBranch_OK_WithNoRoot_OnlyFirstLineInheriting()
        {
            var crumbRoot = new Crumb();
            //A
            var crumbA = new Crumb();
            var crumbA_A = new Crumb();
            var crumbA_B = new Crumb();
            //C
            var crumbC = new Crumb();
            
            crumbRoot.RegisterObserver(crumbA);
            crumbRoot.RegisterObserver(crumbC);
            
            crumbA.RegisterObserver(crumbA_A);
            crumbA.RegisterObserver(crumbA_B);
            
            //act
            var crumbABranch = crumbA.GetBranch().ToArray();
            var crumbCBranch = crumbC.GetBranch().ToArray();
            
            Assert.Equal(3, crumbABranch.Length);
            Assert.Contains(crumbA, crumbABranch);
            Assert.Contains(crumbA_A, crumbABranch);
            Assert.Contains(crumbA_B, crumbABranch);
            
            Assert.Single(crumbCBranch);
            Assert.Contains(crumbC, crumbCBranch);
        }
        
        [Fact]
        public void GetBranch_OK_WithNoRoot_AlsoSecondLineInheriting()
        {
            var crumbRoot = new Crumb();
            //B
            var crumbB = new Crumb();
            var crumbB_A = new Crumb();
            var crumbB_B = new Crumb();
            var crumbB_C = new Crumb();
            var crumbB_C_A = new Crumb();
            //C
            var crumbC = new Crumb();
            
            crumbRoot.RegisterObserver(crumbB);
            crumbRoot.RegisterObserver(crumbC);
            
            crumbB.RegisterObserver(crumbB_A);
            crumbB.RegisterObserver(crumbB_B);
            
            crumbB_C.RegisterObserver(crumbB_C_A);
            crumbB.RegisterObserver(crumbB_C);

            //act
            var crumbBBranch = crumbB.GetBranch().ToArray();
            var crumbCBranch = crumbC.GetBranch().ToArray();
            
            Assert.Equal(5, crumbBBranch.Length);
            Assert.Contains(crumbB, crumbBBranch);
            Assert.Contains(crumbB_A, crumbBBranch);
            Assert.Contains(crumbB_B, crumbBBranch);
            Assert.Contains(crumbB_C, crumbBBranch);
            Assert.Contains(crumbB_C_A, crumbBBranch);

            Assert.Single(crumbCBranch);
            Assert.Contains(crumbC, crumbCBranch);
        }
    }
}