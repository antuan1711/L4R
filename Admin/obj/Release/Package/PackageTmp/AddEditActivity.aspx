<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditActivity.aspx.cs" Inherits="Admin.AddEditActivity" %>

<%@ Register TagPrefix="ucMenu" TagName="Menu" Src="Controls/_MenuNew.ascx" %>
<%@ Register TagPrefix="ucHeader1" TagName="Header" Src="Controls/HeaderNew.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>777Restaurants.com--Admin</title>
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="css/design.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/forms.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/jquery.coolfieldset.css" />

    <script language="javascript" type="text/javascript" src="js/jquery.js"></script>

    <script language="javascript" type="text/javascript" src="js/jquery.coolfieldset.js"></script>

    <link href="dropdown/vertical.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]>
<script type="text/javascript" src="dropdown/jquery.js"></script>
<script type="text/javascript" src="dropdown/jquery-dropdown.js"></script>
<![endif]-->
    <!-- / dropdown end -->
    <!--[if IE 7]>
	<link rel="stylesheet" type="text/css" href="css/ie7.css">
<![endif]-->
</head>

<body ms_positioning="FlowLayout">
   <form id="Form1" method="post" runat="server">
    <div id="background">
        <div id="page">
            <ucHeader1:Header ID="Header2" runat="server"></ucHeader1:Header>
            <!--menu-->
            <div id="main">
                <ucMenu:Menu ID="Menu1" runat="server"></ucMenu:Menu>
                <div id="column-right">
                    <div id="content">
                        <div id="content-top">
                           <h3> Add/Edit Activity</h3>
                        </div>
                        <!--content-top-->
                        <div id="content-mid" class="col-md-12">
                            
                            <div id="page-title">
                                <h3>
                                   <asp:Label ID="lblAddError" runat="server" ForeColor="Red" Visible="True" Font-Size="12px"></asp:Label></h3>
                            </div>
                            <div class="form" id="edit-resto">
                                <div id="form-fieldset-basic" class="def-fieldsets">
                                    <ul id="resto-basic">
                                       
                                        <li>
                                            <label>
                                                Activity Name:</label>
                                            <div class="field-input">
                                                 <asp:TextBox ID="txtActivity" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="clr-blk">
                                            </div>
                                        </li>
                                        <li >
                                            <label>
                                                Activity Status:</label>
                                            <div class="field-input">
                                            <asp:DropDownList ID="ddlActivityStatus" runat="server">
                                               <asp:ListItem Value="-1" Text="Select" ></asp:ListItem>
                                               <asp:ListItem Value="1" Text="Active" ></asp:ListItem>
                                               <asp:ListItem Value="0" Text="InActive" ></asp:ListItem>
                                               </asp:DropDownList>
                                            </div>
                                            <div class="clr-blk">
                                            </div>
                                        </li>
                                        
                                       
                                         
                                        <div class="clr-blk">
                                        </div>
                                    </ul>
                                </div>
                               
                                <ul style="margin-top:10px;">
                                    <li>
                                        <label>
                                        </label>
                                        <div class="field-input">
                                          <asp:Button ID="btnAdd"  runat="server" CssClass="btn btn-success" Text="Add" Font-Bold="true"
                                                    OnClick="btnAdd_Click"></asp:Button>&nbsp;&nbsp;
                                                <asp:Button ID="btnAddCancel"  runat="server" CssClass="btn btn-default" Text="Cancel" Font-Bold="true"
                                                    CausesValidation="False" OnClick="btnAddCancel_Click"></asp:Button>
                                        </div>
                                        <div class="clr-blk">
                                        </div>
                                    </li>
                                </ul>
                            </div>

                            <script>
                                $('#fieldset-contact, #fieldset-activities, #fieldset-restotype, #fieldset-schedule, #fieldset-price').coolfieldset({ animation: false });
                            </script>

                        </div>
                        <!--content-mid-->
                        <div id="content-bot">
                            &nbsp;
                        </div>
                        <!--
                    <!--content-->
                        <div class="clr-blk">
                        </div>
                    </div>
                    <!--column-right-->
                    <div class="clr-blk">
                    </div>
                </div>
                <!--main-->

                <div class="clr-blk">
                </div>
            </div>
            <!--page-->
            <div class="clr-blk">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
