using System;
using System.Web;
using System.Collections.Generic;
//using System.Web;
namespace MODELS
{
    [Serializable()]
    public class SessionValues : ResponseMessageModel
    {
        // private constructor
        public SessionValues()
        {
        }
       
        // Gets the current session.
        public static SessionValues Current
        {
            get
            {
                SessionValues session;
                if (HttpContext.Current == null)
                {
                    session = new SessionValues();
                    if (HttpContext.Current != null) HttpContext.Current.Session["MySession"] = session;
                    return session;
                }
                session = (SessionValues)HttpContext.Current.Session["MySession"];
                if (session == null)
                {
                    session = new SessionValues();
                    HttpContext.Current.Session["MySession"] = session;
                }
                return session;
            }
        }
        
        public LoginInSession Login { get; set; }
    }

    [Serializable]
    public class LoginInSession
    {
        public string UserEcn { get; set; }
        public string UserName { get; set; }
        public string UserEmailID { get; set; }
        public string UserPassword { get; set; }
        public string Roles { get; set; }
    }

}