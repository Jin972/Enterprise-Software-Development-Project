using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESD_Project.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session) {
            HttpContext.Current.Session["LoginSession"] = session;
        }

        public static UserSession GetSession() {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
                return null;
            else {
                return session as UserSession;
            }
        }
    }
}