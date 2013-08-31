using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PartialAssociationRules.Domain.Gui.Web;
using System.Web;
using System.Web.Profile;

namespace PartialAssociationRules.Domain
{
    public static class SettingsManager
    {
#if WEB
        public static PARProfile Settings
        {
            get
            {
                return (PARProfile)HttpContext.Current.Profile ;
            }
        }
#else
        public static ApplicationSettings Settings
        {
            get
            {
                return ApplicationSettings.Default;
            }
        }
#endif
    }
}
