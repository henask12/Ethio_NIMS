namespace eProcurement.UnitTest
{
    public class Approval
    {
        public ApprovalStatus ApprovalStatus { get; set; }
        public User MadeBy { get; set; }
        public bool CanBeCancelledBy(User user)
        {
            return user.IsAdmin;
        }       

        public bool CanCancelBy(User user) 
        {
            if (user.IsAdmin)
                return true;

            if (user == MadeBy)
                return true;

            return false;
        }
    }

    public enum ApprovalStatus
    {
        Approved = 1,
        Cancelled,
        Pending
    }
}
