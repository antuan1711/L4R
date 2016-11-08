<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="Admin.Calendar.AddEvent" ValidateRequest="false" EnableViewStateMac="false" ViewStateEncryptionMode="Never" %>

<%@ Register TagPrefix="ucMenu" TagName="Menu" Src="Controls/_MenuNew.ascx" %>
<%@ Register TagPrefix="ucHeader1" TagName="Header" Src="Controls/HeaderNew.ascx" %>
<%@ Register Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" TagPrefix="CuteWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>777Restaurants.com--Admin</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/design.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
   <link href='fancybox/jquery.fancybox-1.3.4.css' rel='stylesheet' />

    <script src="js/jquery.min.js" type="text/javascript"></script>
 
    <link href="dropdown/vertical.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]>
<script type="text/javascript" src="dropdown/jquery.js"></script>
<script type="text/javascript" src="dropdown/jquery-dropdown.js"></script>
<![endif]-->
    <!-- / dropdown end -->
    <!--[if IE 7]>
	<div class="col-md-12"nk rel="stylesheet" type="text/css" href="css/ie7.css">
<![endif]-->

    <style type="text/css">
        .fileUploadQueueItem {
            display: none;
        }

        .fileUploadQueue {
            height: 0px;
        }

        .AjaxUploaderQueueTableRow {
            background: none repeat scroll 0 0 rgba(144, 144, 144, 0.15) !important;
            border-bottom: 1px solid #ffffff !important;
            padding-bottom: 3px !important;
        }

        .AjaxUploaderCancelAllButton {
            display: none;
        }

        .AjaxUploaderAttachmentsTable {
            border-bottom: 1px solid #ffffff !important;
            padding-bottom: 3px !important;
            display: block;
        }

        .AjaxUploaderAttachmentsTableRow {
            background: none repeat scroll 0 0 rgba(144, 144, 144, 0.15) !important;
            border-bottom: 1px solid #ffffff !important;
            padding-bottom: 3px !important;
        }

            .AjaxUploaderAttachmentsTableRow td {
                padding-left: 10px;
                padding-right: 10px;
            }
    </style>
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
                                <h3>Add / Edit Activity
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Calendar.aspx" CssClass="btn btn-link pull-right">View Events</asp:HyperLink></h3>
                            </div>
                            <!--content-top-->
                            <div id="content-mid" class="col-md-12">

                                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="hide col-md-12">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Event Photo:</label>
                                                    <div class="col-md-9">
                                                        <input name="eventphoto" type="file" /><br>
                                                        <input name="eventphotodisplay" type="image" src="images/eventpic.jpg" /><br>
                                                        <input name="upload" type="button" value="Upload" class="button" />
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="hide col-md-12">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Event Name:</label>
                                                    <div class="col-md-9">
                                                        <input name="txtname1" type="text" id="txtname" class=" form-control" />
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Event Type:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlActivities" runat="server" CssClass="textbox">
                                                        </asp:DropDownList>
                                                        <div style="display: none; text-align: left; float: right; position: relative; margin-right: 40px;"
                                                            id="dvCity" runat="server">
                                                            <asp:TextBox ID="txtname" CssClass="text-field" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Description:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtdesc" CssClass="form-control" runat="server" cols="35" Rows="5"
                                                            TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Organizer:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtOrganizer" CssClass="text-field" runat="server"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12" id="liOrganizeType" runat="server" visible="false">

                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Organizer Type:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddEvents" runat="server" CssClass="text-field">
                                                            <asp:ListItem Value="Love4Restaurants" Text="Love4Restaurants"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Contact No:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="text-field" onkeyPress="javascript:return ValidIntegerText(event);"
                                                            MaxLength="10"></asp:TextBox>
                                                        <asp:Label ID="lblPhError" runat="server" Text="*" ForeColor="Red" Style="display: none;"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Guests Limit:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtGuestLimit" runat="server" CssClass="text-field" onkeyPress="javascript:return ValidIntegerText(event);"
                                                            Style="float: left; position: relative;" MaxLength="10"></asp:TextBox>
                                                        &nbsp;&nbsp;
                                                <asp:CheckBox ID="chkNoLimit" runat="server" Text="No Limit" Style="float: left; position: relative; margin-left: 10px; text-align: left;"
                                                    CssClass="catcheckbox" />
                                                        <asp:Label ID="lblGuestLimitError" runat="server" Text="*" ForeColor="Red" Style="display: none;"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Restaurant Name:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlRestaurants" runat="server" Visible="true" OnSelectedIndexChanged="ddlRestaurants_SelectedIndexChanged"
                                                            AutoPostBack="true" CssClass="text-field">
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Address:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" onblur="javascript:ResumeText(this);"
                                                            onfocus="javascript:ClearText(this);" TextMode="MultiLine" Text="Enter place name and its complete address"></asp:TextBox>
                                                        <asp:Label ID="lblAddress" runat="server" ForeColor="#f67524" Font-Size="12px" Text=""></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        State:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="select_State" runat="server" CssClass="text-field" AutoPostBack="True"
                                                            OnSelectedIndexChanged="select_State_SelectedIndexChanged">
                                                            <asp:ListItem Value="0" Text="Select State"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblStateError" runat="server" Text="*" ForeColor="Red" Style="display: none;"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        City:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="select_City" runat="server" CssClass="text-field">
                                                            <asp:ListItem Value="0" Text="Select City"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblCityError" runat="server" Text="*" ForeColor="Red" Style="display: none;"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Zip:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtZipCode" CssClass="text-field" runat="server" onkeyPress="javascript:return ValidIntegerText(event);"
                                                            MaxLength="10"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Recurring:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlRecurrType" runat="server" onchange="javascript:ShowWeekDays();"
                                                            CssClass="text-field">
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                            <asp:ListItem Value="Weekly">Weekly</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Start Date:</label>
                                                    <div class="col-md-9">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <select id="selectMonth" class="text-field" name="li_start_dt_month" runat="server">
                                                                    <option selected value="1">January</option>
                                                                    <option value="2">February</option>
                                                                    <option value="3">March</option>
                                                                    <option value="4">April</option>
                                                                    <option value="5">May</option>
                                                                    <option value="6">June</option>
                                                                    <option value="7">July</option>
                                                                    <option value="8">August</option>
                                                                    <option value="9">Sepember</option>
                                                                    <option value="10">October</option>
                                                                    <option value="11">November</option>
                                                                    <option value="12">December</option>
                                                                </select>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <select id="SelectDate" class="text-field" name="li_start_dt_day" runat="server">
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option selected value="6">6</option>
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
                                                                <select id="SelectYear" class="text-field" name="li_start_dt_year" runat="server">
                                                                </select>
                                                            </div>
                                                            <asp:Label ID="lblETError" runat="server" Text="*" ForeColor="Red" Style="display: none;"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10" id="liEndDate" runat="server">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        End Date:</label>
                                                    <div class="col-md-9">
                                                        <div class="row">
                                                            <div id="spanDate" class="note" runat="Server">
                                                                <div class="col-md-4">
                                                                    <select id="selectMon" class="text-field" name="li_start_dt_month" runat="server">
                                                                        <option selected value="1">January</option>
                                                                        <option value="2">February</option>
                                                                        <option value="3">March</option>
                                                                        <option value="4">April</option>
                                                                        <option value="5">May</option>
                                                                        <option value="6">June</option>
                                                                        <option value="7">July</option>
                                                                        <option value="8">August</option>
                                                                        <option value="9">Sepember</option>
                                                                        <option value="10">October</option>
                                                                        <option value="11">November</option>
                                                                        <option value="12">December</option>
                                                                    </select>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <select id="selectDt" class="text-field" name="li_start_dt_day" runat="server">
                                                                        <option value="1" selected>1</option>
                                                                        <option value="2">2</option>
                                                                        <option value="3">3</option>
                                                                        <option value="4">4</option>
                                                                        <option value="5">5</option>
                                                                        <option value="6">6</option>
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
                                                                    <select id="SelectYr" class="text-field" name="li_start_dt_year" runat="server">
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Start Time:</label>
                                                    <div class="col-md-9">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <select id="SelectHH" class="text-field" name="li_start_time_hour" runat="server">
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5" selected="selected">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                    <option value="11">11</option>

                                                                </select>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <select id="SelectMM" class="text-field" name="li_start_time_minute" runat="server">
                                                                    <option selected="selected" value="0">00</option>
                                                                    <option value="1">01</option>
                                                                    <option value="2">02</option>
                                                                    <option value="3">03</option>
                                                                    <option value="4">04</option>
                                                                    <option value="5">05</option>
                                                                    <option value="6">06</option>
                                                                    <option value="7">07</option>
                                                                    <option value="8">08</option>
                                                                    <option value="9">09</option>
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
                                                                    <option value="32">32</option>
                                                                    <option value="33">33</option>
                                                                    <option value="34">34</option>
                                                                    <option value="35">35</option>
                                                                    <option value="36">36</option>
                                                                    <option value="37">37</option>
                                                                    <option value="38">38</option>
                                                                    <option value="39">39</option>
                                                                    <option value="40">40</option>
                                                                    <option value="41">41</option>
                                                                    <option value="42">42</option>
                                                                    <option value="43">43</option>
                                                                    <option value="44">44</option>
                                                                    <option value="45">45</option>
                                                                    <option value="46">46</option>
                                                                    <option value="47">47</option>
                                                                    <option value="48">48</option>
                                                                    <option value="49">49</option>
                                                                    <option value="50">50</option>
                                                                    <option value="51">51</option>
                                                                    <option value="52">52</option>
                                                                    <option value="53">53</option>
                                                                    <option value="54">54</option>
                                                                    <option value="55">55</option>
                                                                    <option value="56">56</option>
                                                                    <option value="57">57</option>
                                                                    <option value="58">58</option>
                                                                    <option value="59">59</option>
                                                                </select>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <select id="SelectPP" class="text-field" name="ls_start_time_half" runat="server">
                                                                    <option selected value="PM">PM</option>
                                                                    <option value="AM">AM</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        End Time:</label>
                                                    <div class="col-md-9">
                                                        <div id="dvEndTime" runat="server">
                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <select id="SelectEHH" class="text-field" name="li_end_time_hour" runat="server">
                                                                        <option value="1">1</option>
                                                                        <option value="2">2</option>
                                                                        <option value="3">3</option>
                                                                        <option value="4">4</option>
                                                                        <option value="5">5</option>
                                                                        <option value="6">6</option>
                                                                        <option value="7">7</option>
                                                                        <option value="8">8</option>
                                                                        <option value="9">9</option>
                                                                        <option value="10">10</option>
                                                                        <option value="11" selected="selected">11</option>

                                                                    </select>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <select id="SelectEMM" class="text-field" name="li_end_time_minute" runat="server">
                                                                        <option selected="selected" value="0">00</option>
                                                                        <option value="1">01</option>
                                                                        <option value="2">02</option>
                                                                        <option value="3">03</option>
                                                                        <option value="4">04</option>
                                                                        <option value="5">05</option>
                                                                        <option value="6">06</option>
                                                                        <option value="7">07</option>
                                                                        <option value="8">08</option>
                                                                        <option value="9">09</option>
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
                                                                        <option value="32">32</option>
                                                                        <option value="33">33</option>
                                                                        <option value="34">34</option>
                                                                        <option value="35">35</option>
                                                                        <option value="36">36</option>
                                                                        <option value="37">37</option>
                                                                        <option value="38">38</option>
                                                                        <option value="39">39</option>
                                                                        <option value="40">40</option>
                                                                        <option value="41">41</option>
                                                                        <option value="42">42</option>
                                                                        <option value="43">43</option>
                                                                        <option value="44">44</option>
                                                                        <option value="45">45</option>
                                                                        <option value="46">46</option>
                                                                        <option value="47">47</option>
                                                                        <option value="48">48</option>
                                                                        <option value="49">49</option>
                                                                        <option value="50">50</option>
                                                                        <option value="51">51</option>
                                                                        <option value="52">52</option>
                                                                        <option value="53">53</option>
                                                                        <option value="54">54</option>
                                                                        <option value="55">55</option>
                                                                        <option value="56">56</option>
                                                                        <option value="57">57</option>
                                                                        <option value="58">58</option>
                                                                        <option value="59">59</option>
                                                                    </select>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <select id="SelectEPP" class="text-field" name="ls_end_time_half" runat="server">
                                                                        <option selected="selected" value="PM">PM</option>
                                                                        <option value="AM">AM</option>
                                                                    </select>
                                                                </div>
                                                                <div class="col-md-12">
                                                                    <asp:CheckBox ID="chkPassNight" runat="server" Text=" Pass Midnight"></asp:CheckBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10" id="SpanWeek" runat="Server" style="display: none;">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Recurring Days:</label>
                                                    <div class="col-md-9">


                                                        <asp:CheckBox ID="chkMon" runat="server" Text="Monday"></asp:CheckBox>

                                                        <asp:CheckBox ID="chkTue" runat="server" Text="Tuesday"></asp:CheckBox>

                                                        <asp:CheckBox ID="chkWed" runat="server" Text="Wednesday"></asp:CheckBox>

                                                        <asp:CheckBox ID="chkThur" runat="server" Text="Thursday"></asp:CheckBox>

                                                        <asp:CheckBox ID="chkFri" runat="server" Text="Friday"></asp:CheckBox>

                                                        <asp:CheckBox ID="chkSat" runat="server" Text="Saturday"></asp:CheckBox>

                                                        <asp:CheckBox ID="chkSun" runat="server" Text="Sunday"></asp:CheckBox>


                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Event Price:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPrice" CssClass="text-field" runat="server" MaxLength="6" onkeyPress="javascript:return ValidIntegerText(event);"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10" id="trrestCoupons" runat="server">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Will you accept Coupons?</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlEventCoupons" runat="server" CssClass="text-field">
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10" id="liRsvp" runat="server" visible="false">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                    </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlRsvp" runat="server" CssClass="text-field">
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10" id="EventPrivacy" runat="server" visible="false">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Publish Event to:</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="rdEventRadioList" runat="server">
                                                            <asp:ListItem Text="Favorite Friends " Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Network" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Singles" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Restaurants" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Business" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Public" Value="6" Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Upload Event Photos:</label>
                                                    <div class="col-md-9">
                                                        <CuteWebUI:UploadAttachments runat="server" ManualStartUpload="true" ID="Uploader1"
                                                            InsertText="Browse Files (Max 1M)" OnAttachmentAdded="Uploader_FileUploaded"
                                                            MultipleFilesUpload="true" AttachmentTableStyle="background-color:#ffffff; margin-top:10px;"
                                                            ProgressTextTemplate="Uploading %F%..%P% Completed">
                                                            <ValidateOption MaxSizeKB="1024" AllowedFileExtensions="jpeg,jpg,gif,png" />
                                                        </CuteWebUI:UploadAttachments>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12 margin-top-10" id="LiOldEventPhoto" runat="server">
                                                <div class="row">
                                                    <label class="col-md-3">
                                                        Event Uploaded Photos</label>
                                                    <div class="col-md-9" id="dvOldEventPhoto" runat="server">
                                                        <table cellspacing="1" cellpadding="2" class="AjaxUploaderQueueTable table table-bordered table-striped table-hover">
                                                            <asp:Repeater ID="rptEventPhotos" runat="server" OnItemDataBound="rptEventPhotos_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tbody>
                                                                        <tr class="AjaxUploaderQueueTableRow" style="background-color: rgb(255, 255, 255);"
                                                                            id="trPhotoname" runat="server">
                                                                            <td style="white-space: nowrap;">
                                                                                <img width="16" height="16" src="Images/attachment.png" title="" />
                                                                            </td>
                                                                            <td style="width: 316px;">
                                                                                <asp:Label ID="lblEventPhoto" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="white-space: nowrap;" id="tdAction" runat="server">
                                                                                <img width="16" height="16" src="Images/RemoveFile.png" title="Remove" style="cursor: pointer;"
                                                                                    id="ImgDelPhoto" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </div>
                                                </div>

                                            </div>



                                            <div class="clearfix"></div>


                                            <div class="col-md-12 margin-top-10">
                                                <label class="col-md-3">
                                                </label>
                                                <div class="col-md-9">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Upload Activity"
                                                        OnClick="btnSubmit_Click" Font-Bold="true"></asp:Button>
                                                    <input type="button" class="btn btn-success" onclick="javascript: EventUpdtAlert();" id="btnSubmit1"
                                                        runat="server" style="display: none;">
                                                    <asp:Button ID="btnDone" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnDone_Click"
                                                        Font-Bold="true" Style="display: inline;"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

        </div>

        <div style="display: none;" onunload="javascript:refreshParent();">
            <div id="divEventUpdtAlert" style="background: #E8EDEF; color: #333; border-radius: 5px 5px 5px 5px; padding: 20px; padding-bottom: 15px; padding-top: 5px; -webkit-border-radius: 5px 5px 5px 5px; float: left; width: 250px; -moz-border-radius: 5px 5px 5px 5px; border: 3px solid white; z-index: 100;">
                <div class="inner_section">
                    Foodies already invited friends to this event, are you sure you want to change or
                delete this event?
                <div class="clear">
                </div>
                    <asp:Button ID="Button1" runat="server" OnClientClick="javascript:$('#btnSubmit').click();"
                        Style="margin-left: 50px;" TabIndex="90" CssClass="reserverbtnpopup" Text="Yes" />
                    <asp:Button ID="btnClose" runat="server" OnClientClick="javascript:$.fancybox.close();"
                        Style="margin-left: 10px;" TabIndex="90" CssClass="reserverbtnpopup" Text="No" />
                </div>
            </div>
        </div>
    </form>
</body>

<script type="text/javascript">
    $(function () {
        if ($("#ddlRecurrType").val() == "Weekly") {
            $("#selectMon").prop("disabled", false);
            $("#selectDt").prop("disabled", false);
            $("#SelectYr").prop("disabled", false);
        } else {
            $("#selectMon").prop("disabled", true);
            $("#selectDt").prop("disabled", true);
            $("#SelectYr").prop("disabled", true);
        }
    });
    $(document).ready(function () {
        $('#ddlRecurrType').change(function () {
            if ($("#ddlRecurrType").val() == "Weekly") {
                $("#selectMon").prop("disabled", false);
                $("#selectDt").prop("disabled", false);
                $("#SelectYr").prop("disabled", false);
            } else {
                $("#selectMon").prop("disabled", true);
                $("#selectDt").prop("disabled", true);
                $("#SelectYr").prop("disabled", true);
            }
        });
        $('#chkPassNight').change(function () {
            if ($("#chkPassNight").is(":checked")) {
                $("#SelectEHH").prop("disabled", true);
                $("#SelectEMM").prop("disabled", true);
                $("#SelectEPP").prop("disabled", true);

            } else {
                $("#SelectEHH").prop("disabled", false);
                $("#SelectEMM").prop("disabled", false);
                $("#SelectEPP").prop("disabled", false);
            }
        });
        $(".fancybox").fancybox({
            openEffect: 'none',
            closeEffect: 'none'

        });
    });

    function EventUpdtAlert() {
        $.fancybox({
            'showCloseButton': true,
            'scrolling': 'no',
            'autoScale': true,
            'href': '#divEventUpdtAlert',
            'zoomOpacity': true,
            'overlayShow': true,
            'transitionIn': 'elastic',
            'transitionOut': 'elastic',
            'zoomSpeedIn': 500,
            'zoomSpeedOut': 500,
            'modal': true
        });
    }

    function ClearText(obj) {
        if (obj.value == "Enter place name and its complete address") {
            obj.value = "";
        }
    }

    function ResumeText(obj) {
        if (obj.value == "") {
            obj.value = "Enter place name and its complete address";
        }
    }

    function ShowWeekDays() {
        if (document.getElementById("ddlRecurrType").options[document.getElementById("ddlRecurrType").selectedIndex].value.toUpperCase() == "WEEKLY") {
            document.getElementById("SpanWeek").style.display = "block";
        } else {
            document.getElementById("SpanWeek").style.display = "none";
        }
    }

    function ValidIntegerText(e) {
        var e = window.event || e;
        keyEntry = e.keyCode || e.charCode;
        if (keyEntry == 8 || keyEntry == 9 || keyEntry == 27 || keyEntry == 13 ||
            (keyEntry >= 35 && keyEntry <= 39)) {
            // let it happen, don't do anything
            return true;
        }
        if ((keyEntry >= 48) && (keyEntry <= 57)) {
            return true;
        } else {
            return false;
        }
    }

    function submitbutton_click() {
        try {
            if (IsValidPage()) {
                btnUploadPhotoID = '<%=btnSubmit.ClientID%>';
                var submitbutton = document.getElementById('<%=btnSubmit.ClientID %>');
                var uploadobj = document.getElementById('<%=Uploader1.ClientID %>');
                if (!window.filesuploaded) {
                    if (uploadobj.getqueuecount() > 0) {
                        uploadobj.startupload();
                    } else {
                        var uploadedcount = parseInt(submitbutton.getAttribute("itemcount")) || 0;
                        if (uploadedcount > 0) {
                            return true;
                        }
                        return true;
                    }
                    return false;
                }
                window.filesuploaded = false;
                return true;
            } else {
                return false;
            }
        } catch (ex) {
            alert(ex);
        }
    }

    function IsValidPage() {
        var eventStartDate;
        var eventEndDate;
        var eventStartHour;
        var eventEndHour;
        $("#<%=lblerror.ClientID%>").text('');
        if ($("#txtPhone").val() == "") {
            $("#<%=lblerror.ClientID%>").text("Enter contact number");
            $("#<%=lblPhError.ClientID%>").css("display", "inline-block");
            $("#<%=lblPhError.ClientID%>").show();
            $("#txtPhone").focus();
            return false;
        }
        if ($("#<%=txtGuestLimit.ClientID%>").val() == "" && $("#chkNoLimit").is(':checked') == false) {
            $("#<%=lblerror.ClientID%>").text("Please choose guest limit");
            $("#<%=txtGuestLimit.ClientID%>").focus();
            $("#<%=lblGuestLimitError.ClientID%>").css("display", "inline-block");
            $("#<%=lblGuestLimitError.ClientID%>").show();
            return false;
        }

        if ($("#<%=txtAddress.ClientID%>").val() == "" || $("#<%=txtAddress.ClientID%>").val() == "Enter place name and its complete address") {
            $("#<%=lblAddress.ClientID%>").text("Please enter address");
            return false;
        }
        if ($("#select_State").val() == "0") {
            $("#<%=lblerror.ClientID%>").text("Select State");
            $("#<%=lblerror.ClientID%>").show();
            $("#select_State").focus();
            $("#<%=lblStateError.ClientID%>").css("display", "inline-block");
            $("#<%=lblStateError.ClientID%>").show();
            return false;
        }
        if ($("#select_City").val() == "0") {
            $("#<%=lblerror.ClientID%>").text("Select State");
            $("#<%=lblerror.ClientID%>").show();
            $("#select_City").focus();
            $("#<%=lblCityError.ClientID%>").css("display", "inline-block");
            $("#<%=lblCityError.ClientID%>").show();
            return false;
        }
        if ($("#SelectPP").val() == "PM") {
            eventStartHour = parseInt($("#SelectHH").val()) + 12;
        } else {
            eventStartHour = parseInt($("#SelectHH").val());
        }
        if ($("#SelectEPP").val() == "PM") {
            eventEndHour = parseInt($("#SelectEHH").val()) + 12;
        } else {
            eventEndHour = parseInt($("#SelectEHH").val());
        }
        var today = new Date();
        eventStartDate = new Date(parseInt($("#SelectYear").val()), parseInt($("#selectMonth").val()) - 1, parseInt($("#SelectDate").val()), eventStartHour, $("#SelectMM").val(), "00", "00");
        if ($('#chkPassNight').is(":checked")) {
            eventEndDate = new Date(parseInt($("#SelectYr").val()), parseInt($("#selectMon").val()) - 1, parseInt($("#selectDt").val()), "23", "59", "00", "00");
        } else {
            eventEndDate = new Date(parseInt($("#SelectYr").val()), parseInt($("#selectMon").val()) - 1, parseInt($("#selectDt").val()), eventEndHour, $("#SelectEMM").val(), "00", "00");
        }

        var querystring = location.search.replace('?', '').split('&');
        var queryObj = {};

        for (var i = 0; i < querystring.length; i++) {
            var name = querystring[i].split('=')[0];
            var value = querystring[i].split('=')[1];
            queryObj[name] = value;
        }
        if ($("#ddlRecurrType").val() != "0") {
            if (eventStartDate >= eventEndDate) {
                $("#<%=lblETError.ClientID%>").css("display", "inline-block");
                $("#<%=lblETError.ClientID%>").show();
                $("#<%=lblerror.ClientID%>").text("Invalid event timing");
                $("#SelectYear").focus();
                return false;
            }
        }
        else if (eventStartDate <= today) {
            $("#<%=lblerror.ClientID%>").text("Invalid event timing");
            $("#<%=lblETError.ClientID%>").css("display", "inline-block");
            $("#<%=lblETError.ClientID%>").show();
            $("#SelectYear").focus();
            return false;
        }
    return true;

}

function CuteWebUI_AjaxUploader_OnPostback() {
    try {

        window.filesuploaded = true;
        var btnUploadPhotoID = '<%=btnSubmit.ClientID%>';
        var submitbutton = document.getElementById(btnUploadPhotoID);
        // submitbutton.click();
        $("#" + btnUploadPhotoID).click();
        return false;
    } catch (ex) {
        alert(ex);
    }
}

function DeleteEventPhoto(eventID, eventPhotoName, rowID, cellID) {
    $("#" + cellID).empty().html("<img src='Images/loader.gif' />");
    $.ajax({
        type: "POST",
        url: "actionpages/AjaxActions.aspx/DeleteEventPhoto",
        data: "{'EventID':'" + eventID + "','EventPhotoName':'" + eventPhotoName + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == "ok") {
                $("#" + rowID).css("display", "none");
                $("#" + rowID).hide();
            }
        },
        errro: function () {
            $("#" + cellID).empty().html("<img src='Images/RemoveFile.png' />");
        }
    });
}
</script>

</html>
