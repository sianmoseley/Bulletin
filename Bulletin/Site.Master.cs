using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggedInUser"] == null)
                {
                    this.Page.Master.FindControl("MyAccount").Visible = false;
                    this.Page.Master.FindControl("Boards").Visible = false;
                    this.Page.Master.FindControl("Admin").Visible = false;
                    this.Page.Master.FindControl("Logout").Visible = false;
                   
                }
                else
                {
                   
                    this.Page.Master.FindControl("Home").Visible = false;
                    this.Page.Master.FindControl("Boards").Visible = true;
                    this.Page.Master.FindControl("Logout").Visible = true;
                    if (((User)Session["loggedInUser"]).UserType == "ADMIN")
                        this.Page.Master.FindControl("Admin").Visible = true;
                    else
                        this.Page.Master.FindControl("Admin").Visible = false;
                }
            }
        }
    }
}