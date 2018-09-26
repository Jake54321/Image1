using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using USASchedulerASPWEB;
using System.Web;

namespace USASchedulerASPWEB
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                DataTable schools = Config.SelectSchools();
                
                ddlSchools.DataSource = schools;
                ddlSchools.DataBind();
            }
        }



        private bool ValidateUser(string userName, string passWord)
        {
            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {
                DataTable ActiveUser = Config.LoginUser(userName, passWord,ddlSchools.SelectedValue);

                if (ActiveUser != null && ActiveUser.Rows.Count > 0)
                {
                    Session["g_LoginId"] = Config.ReturnDataColumns(ActiveUser.Rows[0], "LoginId");
                    Session["g_IsStudent"] = Config.ReturnDataColumns(ActiveUser.Rows[0], "IsStudent");
                    Session["g_SchoolId"] = Config.ReturnDataColumns(ActiveUser.Rows[0], "SchoolId");
                    Session["g_RosterId"] = Config.ReturnDataColumns(ActiveUser.Rows[0], "RosterId");

                    return true;
                }
                else
                {
                return false;
                }
            }
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                return false;
            }


        }

        protected void btnLogin_click(object sender, System.EventArgs e)
        {

            bool persitCookie = false;

            if (ValidateUser(inputEmail.Value, inputPassword.Value))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;

            tkt = new FormsAuthenticationTicket(1, inputEmail.Value, DateTime.Now,
            DateTime.Now.AddMinutes(30), persitCookie, "your custom data");

            cookiestr = FormsAuthentication.Encrypt(tkt);

            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);

            if (persitCookie)
                ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;

            Response.Cookies.Add(ck);

            string strRedirect;
            strRedirect = Request["ReturnUrl"];

            if (strRedirect == null)
                strRedirect = "Default.aspx";

            Response.Redirect(strRedirect, true);
            }
            else
            Response.Redirect("Login.aspx", true);
        }

    }
}