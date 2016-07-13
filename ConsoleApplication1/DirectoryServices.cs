using System.DirectoryServices.AccountManagement;

namespace ConsoleApplication1
{
    public class DirectoryServices
    {
        public void UpdateStatus (int userAccessControl)
        {
            using (PrincipalContext ctx  = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "test"))
                {
                    bool enabledChanged         = ((userAccessControl & 0x2) != 0) == user.Enabled;
                    bool pwdNeverExpiresChanged = ((userAccessControl & 0x10000) != 0) == user.PasswordNeverExpires;
                    bool lockedOutChanged       = ((userAccessControl & 0x10) != 0) == user.IsAccountLockedOut();
                    //bool pwdLastSet = ((userAccessControl & 0x2) != 0) == user.Enabled;

                    if (lockedOutChanged)
                        user.UnlockAccount();
                }

            }
        }
    }
}
