<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="CourseManager.aspx.cs" Inherits="USASchedulerASPWEB.CourseManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<%--<dx:ASPxGridView ID="ASPxGridView1" runat="server"  OnRowUpdating="ASPxGridView1_RowUpdating" Width="588px"
            OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting"
    AutoGenerateColumns="False" KeyFieldName="ID" >
     <Columns>
          <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="0" />
          <dx:GridViewDataTextColumn FieldName="RosterID" VisibleIndex="2">
          </dx:GridViewDataTextColumn>
          <dx:GridViewDataSpinEditColumn FieldName="CourseCode" VisibleIndex="3">
          </dx:GridViewDataSpinEditColumn>
          <dx:GridViewDataSpinEditColumn FieldName="CourseName" VisibleIndex="4">
          </dx:GridViewDataSpinEditColumn>
          <dx:GridViewDataSpinEditColumn FieldName="TermOptions" VisibleIndex="5">
          </dx:GridViewDataSpinEditColumn>
          <dx:GridViewDataSpinEditColumn FieldName="CourseCode" VisibleIndex="6">
          </dx:GridViewDataSpinEditColumn>
     </Columns>
</dx:ASPxGridView>--%>


    <%--<form id="form1" runat="server">--%>
    <div></div>
      <%--  </form>--%>
<%--        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            KeyFieldName="ID" OnRowUpdating="ASPxGridView1_RowUpdating" Width="588px"
            OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" ShowNewButton="True"/>
                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RosterId" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CourseName" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CourseCode" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TermOptions" VisibleIndex="5">
                </dx:GridViewDataTextColumn>

            </Columns>
            <SettingsDetail ShowDetailRow="True" />
            <Templates>
                <DetailRow>
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        KeyFieldName="ID" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect"
                        OnRowUpdating="ASPxGridView1_RowUpdating" Width="100%">
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
                            <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RosterId" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CourseName" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CourseCode" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="TermOptions" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </DetailRow>
            </Templates>
        </dx:ASPxGridView>
    --%>
    <%--</div>--%>


</asp:Content>