<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Admin.Controls.Login" %>


<asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Size="10px"></asp:Label>

<div class="form-group">
    <div class="col-xs-12">
        <label>
            Username:
        </label>
        <asp:TextBox ID="txtUsername" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="red"
            SetFocusOnError="true" ControlToValidate="txtUsername" ErrorMessage="*"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="form-group">
    <div class="col-xs-12">
        <label>
            Password:
        </label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
            SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
    </div>
</div>
<asp:LinkButton ID="lnksubmit" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-warning btn-lg btn-block text-uppercase waves-effect waves-light">
                                    Login</asp:LinkButton>


<%--<a href="javascript:void(0);" class="btn btn-default btn-lg btn-block text-uppercase waves-effect waves-light">Register</a>--%>

<div class="form-group ">
    <div class="col-md-12 col-xs-12">
        <div class="checkbox checkbox-primary">
            <asp:CheckBox ID="SavePassword" runat="server" Text="Save password for this System"></asp:CheckBox>
        </div>
    </div>
</div>
