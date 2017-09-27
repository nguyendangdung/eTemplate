
using System;
using System.Web.UI;
using System.Web;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

//using SM.eTemplate.CacheManager;
//using SM.eTemplate.SharedComponent.Entities;
//using SM.eTemplate.SharedComponent.Constants;
//using SM.eTemplate.WebUtils;

namespace SM.eTemplate.UI.MasterPages.Common
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void sptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
        }

        #region protected application to avoid: Cross site request forgery (CSRF), Cross site scripting (XSS)
        // http://software-security.sans.org/developer-how-to/developer-guide-csrf
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        protected void Page_Init(object sender, EventArgs e)
        {
            // First, check for the existence of the Anti-XSS cookie 
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            // If the CSRF cookie is found, parse the token from the cookie. Then, set the global page variable and view state user key.
            // The global variable will be used to validate that it matches in the view state method
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                //Set the global token variable so the cookie value can be validated against the value in the view state form field in the Page.PreLoad method.
                _antiXsrfTokenValue = requestCookie.Value;
                //Set the view state user key, which will be validated by the framework during each request 
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else //If the CSRF cookie is not found, then this is a new session.
            {
                //Generate a new Anti-XSRF token             
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

                //Set the view state user key, which will be validated by the framework during each request
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                //Create the non-persistent CSRF cookie             
                var responseCookie = new System.Web.HttpCookie(AntiXsrfTokenKey)
                {
                    //Set the HttpOnly property to prevent the cookie from being accessed by client side script                 
                    HttpOnly = true,
                    //Add the Anti-XSRF token to the cookie value                 
                    Value = _antiXsrfTokenValue
                };

                //If we are using SSL, the cookie should be set to secure to prevent it from being sent over HTTP connections 
                if (System.Web.Security.FormsAuthentication.RequireSSL && Request.IsSecureConnection) responseCookie.Secure = true;

                //Add the CSRF cookie to the response             
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += new EventHandler(Page_PreLoad);
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            //During the initial page load, add the Anti-XSRF token and user name to the ViewState 
            if (!IsPostBack)
            {
                //Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                //If a user name is assigned, set the user name
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            //During all subsequent post backs to the page, the token value from             
            //the cookie should be validated against the token in the view state             
            //form field. Additionally user name should be compared to the authenticated users name 
            else
            {
                //Validate the Anti-XSRF token 
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
                    (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
        #endregion
    }
}