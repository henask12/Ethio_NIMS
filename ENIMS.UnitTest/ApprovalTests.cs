using NUnit.Framework;

namespace eProcurement.UnitTest
{
    public class ApprovalTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var approval = new Approval();

            //Act 
            var result = approval.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
            //Assert.Pass();
        }

        [Test]
        public void CanCancelBy_SameUserCancellingTheApproval_ReturnTrue()
        {
            //Arrange
            var approval = new Approval
            {
                MadeBy = new User { IsAdmin = true }
            };
            //Act 
            var result = approval.CanBeCancelledBy(approval.MadeBy);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
