using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace USASchedulerASPWEB
{
    public partial class CourseManager : System.Web.UI.Page
    {


        private DataTable dataTable;

        private DataTable SelectCourses()
        {
            DataTable dt = new DataTable();
            string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[SelectCourseManager]", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = null;

            string LoginId = (string)Session["g_LoginId"];
            string IsStudent = (string)(Session["g_IsStudent"]);
            string SchoolId = (string)Session["g_SchoolId"];
            string RosterId = (string)Session["g_RosterId"];

            conn.Open();

                SqlParameter param = new SqlParameter();


                param.ParameterName = "@LoginId";
                param.Value = LoginId;
                param.Size = 50;

                param.ParameterName = "@SchoolId";
                param.Value = SchoolId;                
                param.Size = 10;

                param.ParameterName = "@RosterId";
                param.Value = RosterId;
                param.Size = 10;

                //param.Direction = parameters[i].Direction;
                da.SelectCommand.Parameters.Add(param);
      
            try
            {
                ds = new DataSet();
                da.Fill(ds);
            }
            catch
            {
            }

            conn.Close();
            conn.Dispose();

            return ds.Tables[0];
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateGrid();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {    
                       
        }

        private DataTable CustomDataSourse
        {
            get
            {
                if (dataTable != null)
                    return dataTable;

                dataTable = ViewState["CustomTable"] as DataTable;

                if (dataTable != null)
                    return dataTable;


                //dataTable = new DataTable("CustomDTable");

                //dataTable.Columns.Add("ID", typeof(Int32));
                //dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };

                //dataTable.Columns.Add("Data", typeof(string));

                ////dataTable.Rows.Add(0, "Data1");
                ////dataTable.Rows.Add(1, "Data2");
                ////dataTable.Rows.Add(2, "Data3");
                ////dataTable.Rows.Add(3, "Data4");
                ////dataTable.Rows.Add(4, "Data5");



                dataTable = SelectCourses();

                //dataTable.Columns.Add("ID", typeof(Int32));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };

                ViewState["CustomTable"] = dataTable;

                return SelectCourses();
            }
        }
        protected void grid_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = CustomDataSourse;
        }
        protected void grid_DataBound(object sender, EventArgs e)
        {
            ASPxGridView g = sender as ASPxGridView;
            for (int i = 0; i < g.Columns.Count; i++)
            {
                GridViewDataTextColumn c = g.Columns[i] as GridViewDataTextColumn;
                if (c == null)
                    continue;

                c.PropertiesTextEdit.ValidationSettings.RequiredField.IsRequired = true;
            }
        }

        protected void grid_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            int id = (int)e.Keys[0];
            DataRow dr = CustomDataSourse.Rows.Find(id);
            dataTable.Rows.Remove(dr);

            ASPxGridView g = sender as ASPxGridView;
            UpdateData(g);
            e.Cancel = true;
        }
        protected void grid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            int id = (int)e.OldValues["ID"];
            DataRow dr = CustomDataSourse.Rows.Find(id);
            dr[0] = e.NewValues["ID"];
            dr[1] = e.NewValues["RosterId"];
            dr[2] = e.NewValues["CourseCode"];
            dr[3] = e.NewValues["CourseName"];
            dr[4] = e.NewValues["TermOptions"];

            ASPxGridView g = sender as ASPxGridView;
            UpdateData(g);
            g.CancelEdit();
            e.Cancel = true;
        }
        protected void grid_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            CustomDataSourse.Rows.Add(e.NewValues["ID"], e.NewValues["RosterId"], e.NewValues["CourseCode"], e.NewValues["CourseName"], e.NewValues["TermOptions"]);

            ASPxGridView g = sender as ASPxGridView;
            UpdateData(g);
            g.CancelEdit();
            e.Cancel = true;
        }

        private void CreateGrid()
        {
            ASPxGridView grid = new ASPxGridView();
            grid.ID = "grid";

            Unit GridWidth;
            GridWidth = 1025;
            grid.Width = GridWidth;
            grid.Theme = "Office2010Blue";

            this.Form.Controls.Add(grid);

            grid.EnableCallBacks = false;
            grid.KeyFieldName = "ID";
            grid.SettingsSearchPanel.Visible = true;
            //grid.SettingsSearchPanel.ShowClearButton = true;
            //grid.SettingsSearchPanel.ShowApplyButton = true;

            //grid.SettingsCommandButton.ApplyFilterButton.RenderMode = GridCommandButtonRenderMode.Button;
            //grid.SettingsCommandButton.ClearFilterButton.RenderMode = GridCommandButtonRenderMode.Button;

            grid.DataBinding += grid_DataBinding;
            grid.RowDeleting += grid_RowDeleting;
            grid.RowUpdating += grid_RowUpdating;
            grid.RowInserting += grid_RowInserting;
            grid.DataBound += grid_DataBound;
            grid.RowValidating += new ASPxDataValidationEventHandler(grid_RowValidating);
            grid.DataBind();
            if (!this.IsPostBack)
            {
                GridViewCommandColumn c = new GridViewCommandColumn();

                //c.ButtonType = DevExpress.Web.GridCommandButtonRenderMode.Button;
                c.ButtonRenderMode = GridCommandButtonRenderMode.Button;

                grid.Columns.Add(c);
                c.ShowEditButton = true;
                c.ShowUpdateButton = true;
                c.ShowDeleteButton = true;
                
                c.ShowNewButtonInHeader = true;
            }

            GridViewDataTextColumn col = grid.Columns["ID"] as GridViewDataTextColumn;
            col.PropertiesTextEdit.ValidationSettings.RegularExpression.ValidationExpression = "\\d{1,9}";
        }

        void grid_RowValidating(object sender, ASPxDataValidationEventArgs e)
        {
            int id = (int)e.NewValues["ID"];
            if ((!e.OldValues.Contains("ID") || ((int)e.OldValues["ID"] != id))
                && (CustomDataSourse.Rows.Find(id) != null))
            {
                ASPxGridView grid = sender as ASPxGridView;
                e.Errors[grid.Columns["ID"]] = String.Format("Column 'ID' is constrained to be unique.  Value '{0}' is already present.", id);
            }
        }
        private void UpdateData(ASPxGridView g)
        {
            ViewState["CustomTable"] = dataTable;
            g.DataBind();
        }

        //DataSet ds = null;
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    if (!IsPostBack || (Session["CourseManagerData"] == null))
        //    {

        //        ds = SelectCourses();

        //        //DataTable masterTable = new DataTable();
        //        //masterTable.Columns.Add("ID", typeof(int));
        //        //masterTable.Columns.Add("RosterId", typeof(string));
        //        //masterTable.Columns.Add("CourseName", typeof(string));
        //        //masterTable.Columns.Add("CourseCode", typeof(string));
        //        //masterTable.Columns.Add("TermOptions", typeof(string));
        //        //masterTable.PrimaryKey = new DataColumn[] { masterTable.Columns["ID"] };

        //        //DataTable detailTable = new DataTable();
        //        //detailTable.Columns.Add("ID", typeof(int));
        //        //detailTable.Columns.Add("RosterId", typeof(string));
        //        //detailTable.Columns.Add("CourseName", typeof(string));
        //        //detailTable.Columns.Add("CourseCode", typeof(string));
        //        //detailTable.Columns.Add("TermOptions", typeof(string));
        //        //detailTable.PrimaryKey = new DataColumn[] { detailTable.Columns["ID"] };
        //        //int index = 0;
        //        //for (int i = 0; i < 20; i++)
        //        //{
        //        //    masterTable.Rows.Add(new object[] { i, "Master Row " + i });
        //        //    for (int j = 0; j < 5; j++)
        //        //        detailTable.Rows.Add(new object[] { index++, i, "Detail Row " + j });
        //        //}
        //        //ds.Tables.AddRange(new DataTable[] { masterTable, detailTable });
        //        Session["CourseManagerData"] = ds;
        //    }
        //    else
        //        ds = (DataSet)Session["CourseManagerData"];

        //    ASPxGridView1.DataSource = ds.Tables[0];
        //    ASPxGridView1.DataBind();
        //}
        //protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        //{
        //    ds = (DataSet)Session["CourseManagerData"];
        //    DataTable detailTable = ds.Tables[1];
        //    DataView dv = new DataView(detailTable);
        //    ASPxGridView detailGridView = (ASPxGridView)sender;
        //    dv.RowFilter = "MasterID = " + detailGridView.GetMasterRowKeyValue();
        //    detailGridView.DataSource = dv;
        //}
        //protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        //{
        //    ds = (DataSet)Session["CourseManagerData"];
        //    ASPxGridView gridView = (ASPxGridView)sender;
        //    DataTable dataTable = gridView.GetMasterRowKeyValue() != null ? ds.Tables[1] : ds.Tables[0];
        //    DataRow row = dataTable.Rows.Find(e.Keys[0]);
        //    IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
        //    enumerator.Reset();
        //    while (enumerator.MoveNext())
        //        row[enumerator.Key.ToString()] = enumerator.Value;
        //    gridView.CancelEdit();
        //    e.Cancel = true;
        //}
        //protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        //{
        //    ds = (DataSet)Session["CourseManagerData"];
        //    ASPxGridView gridView = (ASPxGridView)sender;
        //    DataTable dataTable = gridView.GetMasterRowKeyValue() != null ? ds.Tables[1] : ds.Tables[0];
        //    DataRow row = dataTable.NewRow();
        //    e.NewValues["ID"] = GetNewId();
        //    IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
        //    enumerator.Reset();
        //    while (enumerator.MoveNext())
        //        if (enumerator.Key.ToString() != "Count")
        //            row[enumerator.Key.ToString()] = enumerator.Value;
        //    gridView.CancelEdit();
        //    e.Cancel = true;
        //    dataTable.Rows.Add(row);
        //}

        //protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        //{
        //    int i = ASPxGridView1.FindVisibleIndexByKeyValue(e.Keys[ASPxGridView1.KeyFieldName]);
        //    Control c = ASPxGridView1.FindDetailRowTemplateControl(i, "ASPxGridView2");
        //    e.Cancel = true;
        //    ds = (DataSet)Session["CourseManagerData"];
        //    ds.Tables[0].Rows.Remove(ds.Tables[0].Rows.Find(e.Keys[ASPxGridView1.KeyFieldName]));

        //}

        private int GetNewId()
        {
            DataSet ds = (DataSet)Session["CustomTable"];
            DataTable table = ds.Tables[0];

            if (table.Rows.Count == 0) return 0;
            int max = Convert.ToInt32(table.Rows[0]["ID"]);
            for (int i = 1; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["ID"]) > max)
                    max = Convert.ToInt32(table.Rows[i]["ID"]);
            }
            return max + 1;
        }


    }
}