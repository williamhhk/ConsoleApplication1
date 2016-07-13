using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class UserPrincipalEx
    {
        public static UserPrincipal SetIfEnabledChange(this UserPrincipal user, int userAccessControl)
        {
            bool enabledChanged = ((userAccessControl & 0x2) != 0) == user.Enabled;
            if (!enabledChanged)
                user.Enabled = ((userAccessControl & 0x2) != 0);
            return user;
        }
        public static UserPrincipal SetIfPwdNeverExpiresChange(this UserPrincipal user, int userAccessControl)
        {
            bool pwdNeverExpiresChanged = ((userAccessControl & 0x10000) != 0) == user.PasswordNeverExpires;
            if (!pwdNeverExpiresChanged)
                user.PasswordNeverExpires = ((userAccessControl & 0x10000) != 0);
            return user;
        }

        public static UserPrincipal SetIfPwdMustChange(this UserPrincipal user)
        {
            bool pwdMustChanged = DateTime.FromFileTimeUtc(0) == user.LastPasswordSet;
            if (!pwdMustChanged)
                user.ExpirePasswordNow();
            return user;
        }

        public static UserPrincipal SetIfLockOutChange(this UserPrincipal user, int userAccessControl)
        {
            bool enabledChanged = ((userAccessControl & 0x10) != 0) == user.IsAccountLockedOut();
            if (!enabledChanged)
                user.Enabled = ((userAccessControl & 0x10) != 0);
            return user;
        }
    }
}
