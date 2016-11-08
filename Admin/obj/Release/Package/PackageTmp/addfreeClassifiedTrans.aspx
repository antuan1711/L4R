<%@ Register TagPrefix="ucMenu" TagName="Menu" Src="Controls/_MenuNew.ascx" %>
<%@ Register TagPrefix="ucHeader1" TagName="Header" Src="Controls/HeaderNew.ascx" %>

<%@ Page Language="c#" CodeBehind="addfreeClassifiedTrans.aspx.cs" ValidateRequest="false"
    AutoEventWireup="True" Inherits="Admin.addfreeClassifiedTrans" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>777Restaurants.com--Admin</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="css/design.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />


    <script language="javascript" type="text/javascript" src="js/jquery.js"></script>


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
<body>
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
                                <h3>Edit Employment Posting
                                <asp:HyperLink ID="hlink" runat="server" class="btn btn-link pull-right">View All Posting</asp:HyperLink></h3>
                            </div>

                            <div id="content-mid" class="col-md-12">

                                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>

                                <div class="row">

                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Title:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="text-field"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                                            ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                            </div>
                                            <div id="trFlatFees" runat="server" class="col-md-12 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Cls. Status:</label>
                                                    <div class="col-md-9">
                                                        <select id="selectStatus" name="selectStatus" runat="server">
                                                            <option value="ACTIVE" selected>ACTIVE</option>
                                                            <option value="INACTIVE">INACTIVE</option>
                                                        </select>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Posted&nbsp;Date:</label>
                                                    <div class="col-md-9">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <select id="selectMonth" name="li_start_dt_month" runat="server">
                                                                    <option value="1">Jan</option>
                                                                    <option value="2">Feb</option>
                                                                    <option value="3">Mar</option>
                                                                    <option value="4">Apr</option>
                                                                    <option value="5" selected>May</option>
                                                                    <option value="6">Jun</option>
                                                                    <option value="7">Jul</option>
                                                                    <option value="8">Aug</option>
                                                                    <option value="9">Sep</option>
                                                                    <option value="10">Oct</option>
                                                                    <option value="11">Nov</option>
                                                                    <option value="12">Dec</option>
                                                                </select>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <select id="SelectDate" name="li_start_dt_day" runat="server">
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6" selected>6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                    <option value="11">11</option>
                                                                    <option value="12">12</option>
                                                                    <option value="13">13</option>
                                                                    <option value="14">14</option>
                                                                    <option value="15">15</option>
                                                                    <option value="16">16</option>
                                                                    <option value="17">17</option>
                                                                    <option value="18">18</option>
                                                                    <option value="19">19</option>
                                                                    <option value="20">20</option>
                                                                    <option value="21">21</option>
                                                                    <option value="22">22</option>
                                                                    <option value="23">23</option>
                                                                    <option value="24">24</option>
                                                                    <option value="25">25</option>
                                                                    <option value="26">26</option>
                                                                    <option value="27">27</option>
                                                                    <option value="28">28</option>
                                                                    <option value="29">29</option>
                                                                    <option value="30">30</option>
                                                                    <option value="31">31</option>
                                                                </select>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <select id="SelectYear" name="li_start_dt_year" runat="server">
                                                                    <option value="2005" selected>2005</option>
                                                                    <option value="2006">2006</option>
                                                                    <option value="2007">2007</option>
                                                                    <option value="2008">2008</option>
                                                                    <option value="2009">2009</option>
                                                                    <option value="2010">2010</option>
                                                                    <option value="2011">2011</option>
                                                                    <option value="2012">2012</option>
                                                                    <option value="2013">2013</option>
                                                                    <option value="2014">2014</option>
                                                                    <option value="2015">2015</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Salary Details:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="text-field"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Expiry Date :</label>
                                                    <div class="col-md-9">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <select id="SelectEMONTH" name="li_start_dt_month" runat="server">
                                                                    <option value="1">Jan</option>
                                                                    <option value="2">Feb</option>
                                                                    <option value="3">Mar</option>
                                                                    <option value="4">Apr</option>
                                                                    <option value="5" selected>May</option>
                                                                    <option value="6">Jun</option>
                                                                    <option value="7">Jul</option>
                                                                    <option value="8">Aug</option>
                                                                    <option value="9">Sep</option>
                                                                    <option value="10">Oct</option>
                                                                    <option value="11">Nov</option>
                                                                    <option value="12">Dec</option>
                                                                </select>
                                                            </div>

                                                            <div class="col-md-4">
                                                                <select id="SelectEDay" name="li_start_dt_day" runat="server">
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6" selected>6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                    <option value="11">11</option>
                                                                    <option value="12">12</option>
                                                                    <option value="13">13</option>
                                                                    <option value="14">14</option>
                                                                    <option value="15">15</option>
                                                                    <option value="16">16</option>
                                                                    <option value="17">17</option>
                                                                    <option value="18">18</option>
                                                                    <option value="19">19</option>
                                                                    <option value="20">20</option>
                                                                    <option value="21">21</option>
                                                                    <option value="22">22</option>
                                                                    <option value="23">23</option>
                                                                    <option value="24">24</option>
                                                                    <option value="25">25</option>
                                                                    <option value="26">26</option>
                                                                    <option value="27">27</option>
                                                                    <option value="28">28</option>
                                                                    <option value="29">29</option>
                                                                    <option value="30">30</option>
                                                                    <option value="31">31</option>
                                                                </select>
                                                            </div>

                                                            <div class="col-md-4">
                                                                <select id="SelectEYear" name="li_start_dt_year" runat="server">
                                                                    <option value="2005" selected>2005</option>
                                                                    <option value="2006">2006</option>
                                                                    <option value="2007">2007</option>
                                                                    <option value="2008">2008</option>
                                                                    <option value="2009">2009</option>
                                                                    <option value="2010">2010</option>
                                                                    <option value="2011">2011</option>
                                                                    <option value="2012">2012</option>
                                                                    <option value="2013">2013</option>
                                                                    <option value="2014">2014</option>
                                                                    <option value="2015">2015</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Contact Email:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                        Description:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" Height="200px"
                                                            TextMode="MultiLine" Rows="7" Columns="77"></asp:TextBox><asp:RequiredFieldValidator
                                                                ID="Requiredfieldvalidator2" runat="server" ControlToValidate="txtDesc" ErrorMessage="*"
                                                                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                            </div>
                                           
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                     <div class="col-md-6 margin-top-10">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">
                                                       </label>
                                                    <span class="col-md-9">

                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Add Classified"
                                                            OnClick="btnSubmit_Click"></asp:Button>
                                                    </span>
                                                </div>
                                            </div>
                                </div>



                            </div>


                        </div>

                    </div>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
