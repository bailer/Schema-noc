using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Linq;
using Schedule.Models;
using System.Xml;
namespace Schedule
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Today;
        }

        public void excelParser()
        {

        }


        public IQueryable<Worker> getWorkers()
        {

            var _db = new Schedule.Models.WorkContext();
            IQueryable<Worker> query = _db.workers;
            return query;
        }

        public IQueryable<Shift> GetShifts()
        {
            var _db = new Schedule.Models.WorkContext();
            IQueryable<Shift> query = _db.shifts;
            return query;
        }


        public IQueryable<ShiftWorker> GetShiftworkers()
        {
            var _db = new Schedule.Models.WorkContext();
            IQueryable<ShiftWorker> query = _db.shiftworkers;
            return query;
        }
        


        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        
        protected void Calendar1_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        {
            
            // define a new Style for the current date
            Style todayStyle = new Style();
            todayStyle.BackColor = System.Drawing.Color.Black;
            todayStyle.ForeColor = System.Drawing.Color.White;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var _db = new Schedule.Models.WorkContext();
            var parser = new Schedule.Models.Excelparser();
            parser.excelParser(_db);
        }
    }
}