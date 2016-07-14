using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;

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
                    .SetIfLockOutChange(userAccessControl)
                    .Save();
                }

            }
        }

        public IEnumerable<DomainController> GetControllers()
        {
            return Domain.GetCurrentDomain().DomainControllers.OfType<DomainController>().Select(controller => controller);
        }
    }
}
