<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="USASchedulerASPWEB.Login" %>

<html>
  <head>
  <title></title>
  <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <style>
        body#LoginForm{ background-image:url("https://hdwallsource.com/img/2014/9/blur-26347-27038-hd-wallpapers.jpg"); background-repeat:no-repeat; background-position:center; background-size:cover; padding:10px;}

        .form-heading { color:#fff; font-size:23px;}
        .panel h2{ color:#444444; font-size:18px; margin:0 0 8px 0;}
        .panel p { color:#777777; font-size:14px; margin-bottom:30px; line-height:24px;}
        .login-form .form-control {
          background: #f7f7f7 none repeat scroll 0 0;
          border: 1px solid #d4d4d4;
          border-radius: 4px;
          font-size: 14px;
          height: 50px;
          line-height: 50px;
        }
        .main-div {
          background: #ffffff none repeat scroll 0 0;
          border-radius: 2px;
          margin: 10px auto 30px;
          max-width: 38%;
          padding: 50px 70px 70px 71px;
        }

        .login-form .form-group {
          margin-bottom:10px;
        }
        .login-form{ text-align:center;}
        .forgot a {
          color: #777777;
          font-size: 14px;
          text-decoration: underline;
        }
        .login-form  .btn.btn-primary {
          background: #f0ad4e none repeat scroll 0 0;
          border-color: #f0ad4e;
          color: #ffffff;
          font-size: 14px;
          width: 100%;
          height: 50px;
          line-height: 50px;
          padding: 0;
        }
        .forgot {
          text-align: left; margin-bottom:30px;
        }
        .botto-text {
          color: #ffffff;
          font-size: 14px;
          margin: auto;
        }
        .login-form .btn.btn-primary.reset {
          background: #ff9900 none repeat scroll 0 0;
        }
        .back { text-align: left; margin-top:10px;}
        .back a {color: #444444; font-size: 13px;text-decoration: none;}

    </style>
  </head>
<body id="LoginForm">
<div class="container">
<h1 class="form-heading">login Form</h1>
<div class="login-form">
<div class="main-div">
    <div class="panel">
   <h2>Login</h2>
   <p>Please enter your School Id, password, and select your school</p>
   </div>
    <form id="Login" runat="server">

        <div class="form-group">
            <input type="text" class="form-control" id="inputEmail"  value="983" runat="server" placeholder="Email Address">
            <%--<input type="email" class="form-control" id="Email1"  value="983" runat="server" placeholder="Email Address">--%>
        </div>

        <div class="form-group">

            <input type="password" class="form-control" id="inputPassword" runat="server" placeholder="Password" value="rockware">


        <div class="form-group">
            <asp:Label ID="lblddlSchools" Text="Select School" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlSchools" CssClass="form-control" DataValueField="school_id" DataTextField="school_name" runat="server"></asp:DropDownList>            
        </div>
        </div>
        <div class="forgot">
        <%--<a href="PasswordReset.aspx">Forgot password?</a>--%>
</div>
<%--        <button type="button" id="cmdLogin" runat="server" onserverclick="cmdLogin_ServerClick" class="btn btn-primary">Login</button> --%>
        
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_click"  />

    </form>
    </div>

</div>
</div>
</body>
</html>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>
           <font face="Verdana">Logon Page</font>
        </h3>
        <table>
           <tr>
              <td>Email:</td>
              <td><input id="txtUserName" type="text" runat="server"/></td>
              <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName"
                   Display="Static" ErrorMessage="*" runat="server" 
                   ID="vUserName" /></td>
           </tr>
           <tr>
              <td>Password:</td>
              <td><input id="txtUserPass" type="password" runat="server"/></td>
              <td><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
                  Display="Static" ErrorMessage="*" runat="server" 
                  ID="vUserPass" />
              </td>
           </tr>
           <tr>
              <td>Persistent Cookie:</td>
              <td><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
              <td></td>
           </tr>
        </table>
        <input type="submit" Value="Logon" runat="server" ID="cmdLogin"/><p></p>
        <asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
    </form>
</body>
</html>--%>
