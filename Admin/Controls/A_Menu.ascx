<%@ Control Language="c#" AutoEventWireup="True" Inherits="Admin.Controls.A_Menu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" CodeBehind="A_Menu.ascx.cs" %>
<%--

    This user control creates a menu for left-hand navigation.

--%> 
 
 <script language="JavaScript" type="text/javascript">
<!--
if(window.event + "" == "undefined") event = null;
function HM_f_PopUp(){return false};
function HM_f_PopDown(){return false};
popUp = HM_f_PopUp;
popDown = HM_f_PopDown;

HM_PG_MenuWidth = 250;
HM_PG_FontFamily = "verdana";
HM_PG_FontSize = 8;
HM_PG_FontBold = 1;
HM_PG_FontItalic = 0;
HM_PG_FontColor = "#000000";
HM_PG_FontColorOver = "white";
HM_PG_BGColor = "white";
HM_PG_BGColorOver = "#8C5034";
HM_PG_ItemPadding = 3;
HM_PG_BorderWidth = 1;
HM_PG_BorderColor = "#8C5034";
HM_PG_BorderStyle = "solid";
HM_PG_SeparatorSize = 1;
HM_PG_SeparatorColor = "#8C5034";
HM_PG_ImageSrc = "images/triangle.gif";
HM_PG_ImageSrcLeft = "images/triangle.gif";
HM_PG_ImageSrcOver = "images/triangle.gif";
HM_PG_ImageSrcLeftOver = "images/triangle.gif";
HM_PG_ImageSize = 5;
HM_PG_ImageHorizSpace = .5;
HM_PG_ImageVertSpace = 5;
HM_PG_KeepHilite = true; 
HM_PG_ClickStart = 0;
HM_PG_ClickKill = false;
HM_PG_ChildOverlap = 0;
HM_PG_ChildOffset = 0;
HM_PG_ChildPerCentOver = null;
HM_PG_TopSecondsVisible = .0;
HM_PG_StatusDisplayBuild =0;
HM_PG_StatusDisplayLink = 0;
HM_PG_UponDisplay = null;
HM_PG_UponHide = null;
HM_PG_RightToLeft = 0;
HM_PG_CreateTopOnly = 0;
HM_PG_ShowLinkCursor = 1;
HM_PG_NSFontOver = true>-->
//HM_a_TreesToBuild = []
</script>
<script language="JavaScript1.2" src="../HM_Loader.js" type='text/javascript'></script>
<script type="text/javascript">
with(milonic=new menuname("Main Menu")){
alwaysvisible=1;
left=10;
orientation="vertical";
position="relative";
style=menuStyle;
top=0;  
aI("text=Restaurants;url=ManageRestaurants.aspx"); 
aI("showmenu=TrackPurchases;text=Track Purchases;"); 
aI("showmenu=ManageMembers;text=Members;"); 
aI("text=Manage Calendar;url=Calendar.aspx"); 
aI("showmenu=ManageCategories;text=Categories;"); 
aI("showmenu=ManageClassifieds;text=Classifieds;");
aI("text=Manage Cities;url=ManageCities.aspx");
aI("text=Manage Services;url=ManageService.aspx"); 
aI("text=Add Phrase;url=AddPhrase.aspx");
aI("showmenu=Administrators;text=Administrators;"); 
aI("text=Log off;url=logOff.aspx");
}
drawMenus();
</script> 
 
	<!--		<table  >
				<tr id="trAdmin" runat="server">
					<TD  ><A href="Administrators.aspx">Administrators</A>
					</TD>
				</tr></table>-->
				 
			 
 
	 
