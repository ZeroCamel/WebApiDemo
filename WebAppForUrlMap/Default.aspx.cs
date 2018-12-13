using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace WebAppForUrlMap
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private EmployeeRepository repository;

        public EmployeeRepository Repository
        {
            get { return repository ?? (repository = new EmployeeRepository()); }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }
            string employeeId = this.RouteData.Values["id"] as string;
            if (employeeId=="*"||string.IsNullOrEmpty(employeeId))
            {
                this.GridViewEmployees.DataSource = this.Repository.GetEmployees();
                this.GridViewEmployees.DataBind();
                this.DetailViewEmployee.Visible = false;
            }
            else
            {
                var employees = this.Repository.GetEmployees(employeeId);
                this.DetailViewEmployee.DataSource = employees;
                this.DetailViewEmployee.DataBind();
                this.GridViewEmployees.Visible = false;
            }
        }
    }
}