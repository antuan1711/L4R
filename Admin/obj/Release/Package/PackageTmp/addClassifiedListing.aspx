<%@ Register TagPrefix="uc1" TagName="Menu" Src="Controls/A_Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Page language="c#" Codebehind="addClassifiedListing.aspx.cs" AutoEventWireup="True" Inherits="Admin.addClassifiedListing" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>777Restaurants.com--Admin</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">BODY { MARGIN: 0px }
	.textbox { BORDER-RIGHT: #c2c2c2 1px solid; BORDER-TOP: #c2c2c2 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #c2c2c2 1px solid; BORDER-BOTTOM: #c2c2c2 1px solid; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
		</style>
		<LINK href="Default.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Addclassified" method="post" runat="server">
			<DIV>
				<table style="WIDTH: 100%; HEIGHT: 100%" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td colSpan="2" height="60"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="10%">
							<uc1:Menu id="Menu2" runat="server"></uc1:Menu></td>
						<td vAlign="top" width="90%">
							<table cellSpacing="1" cellPadding="5" width="100%" bgColor="#cccccc" border="0">
								<tr>
									<td><strong>Add / Edit classified</strong></td>
								</tr>
								<tr>
									<td><form method="post" name="form1">
											<P>
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD style="WIDTH: 421px"><asp:validationsummary id="ValidationSummary1" runat="server" HeaderText="Please enter following details"
																DisplayMode="List" Width="240px"></asp:validationsummary><asp:label id="lblerror" runat="server" ForeColor="Red" Visible="False"></asp:label></TD>
														<TD>
															<P align="center">
																<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="Advt.aspx" Font-Bold="True">View All Classifieds</asp:HyperLink>&nbsp;
															</P>
														</TD>
													</TR>
												</TABLE>
											</P>
											<table border="0" style="WIDTH: 454px; HEIGHT: 80px">
												<TR>
													<TD class="classifiedLabel" vAlign="top" width="149">New Classified :</TD>
													<TD><asp:textbox id="txtCategory" Width="160px" Height="20px" Runat="server" CssClass="textbox" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategory" ErrorMessage="classified Name">*</asp:requiredfieldvalidator>&nbsp;</TD>
												</TR>
												<tr align="left">
													<td class="classifiedLabel" vAlign="top" width="149" height="19" style="HEIGHT: 19px">
														Claddified &nbsp;Listing&nbsp;:</td>
													<td height="19" valign="top" style="HEIGHT: 19px">
														<P><asp:textbox id="txtListing" Width="160px" Height="20px" Runat="server" CssClass="textbox" EnableViewState="False"></asp:textbox></P>
													</td>
												</tr>
												<tr align="left">
													<td class="classifiedLabel" width="149" height="7">Category Active:</td>
													<td vAlign="top" height="7"><nobr><SELECT id="SelectActive" name="selectActive" runat="server">
																<OPTION value="1" selected>Active</OPTION>
																<OPTION value="0">Inactive</OPTION>
																<OPTION value=""></OPTION>
															</SELECT></nobr></td>
												</tr>
												<TR>
													<TD width="149"></TD>
													<TD align="left" colSpan="3">
														<P align="right">
															<asp:ImageButton id="Submitclassified" runat="server" ImageUrl="Images/button-save.gif"></asp:ImageButton></P>
													</TD>
												</TR>
											</table>
											<p align="center">
										</form>
										&nbsp;</P></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</DIV>
		</form>
	</body>
</HTML>
