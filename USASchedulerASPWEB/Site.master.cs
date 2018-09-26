using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace USASchedulerASPWEB {
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        //AutoSeparatorMode CurrentAutoSeparatorMode
        //{
        //    get
        //    {
        //        return (AutoSeparatorMode)Enum.Parse(typeof(AutoSeparatorMode),
        //            ddlAutoSeparators.SelectedItem.Value.ToString());
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            //DemoHelper.Instance.ControlAreaMaxWidth = Unit.Pixel(600);
            //DemoHelper.Instance.PrepareControlOptions(OptionsFormLayout, new ControlOptionsSettings
            //{
            //    ColumnMinWidth = 300,
            //    RightBlockWidth = 332,
            //    ColumnCountMode = RecalculateColumnCountMode.ChildGroups
            //});

            //mMain.AllowSelectItem = cbAllowSelectItem.Checked;
            //mMain.AutoPostBack = cbAutoPostBack.Checked;
            //mMain.EnableAnimation = cbEnableAnimation.Checked;
            //mMain.EnableHotTrack = cbEnableHotTrack.Checked;
            //mMain.AutoSeparators = CurrentAutoSeparatorMode;

            //mMain.AppearAfter = int.Parse(tbAppearAfter.Text);
            //mMain.DisappearAfter = int.Parse(tbDisappearAfter.Text);
            //mMain.MaximumDisplayLevels = int.Parse(tbMaximumDisplayLevels.Text);
            //mMain.Opacity = int.Parse(tbOpacity.Text);
        }
    }
    }