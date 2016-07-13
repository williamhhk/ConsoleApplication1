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
                    user
                    .SetIfPwdMustChange()
                    .SetIfEnabledChange(userAccessControl)
                    .SetIfPwdNeverExpiresChange(userAccessControl)
                    .SetIfLockOutChange(userAccessControl);
                    user.Save();
                }

            }
        }
    }
}
