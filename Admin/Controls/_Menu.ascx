<%@ OutputCache Duration="3600" VaryByParam="selection" %>
<%@ Control Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%--

    This user control creates a menu for left-hand navigation of the
    product catalog pages.

--%>
<link href="../Default.css" type="text/css" rel="stylesheet">
<style type="text/css">
    <!
    -- .menu
    {
        font-family: Arial;
        font-weight: bold;
    }
    .menu a
    {
        text-decoration: none;
        color: black;
    }
    -- ></style>

<script language="javascript">
<!--

function movein(which)
{
	which.style.background='#dcdcdc'
}

function moveout(which)
{
	which.style.background=''
}

//-->
</script>

<br>
<table cellspacing="0" cellpadding="0" width="153" border="0" style="width: 153px;
    height: 432px">
    <tr valign="top">
        <td colspan="2" style="height: 346px">
            <table border="0" bordercolor="#f1f1f1" cellpadding="2" cellspacing="0" style="background-image: none;
                width: 142px; height: 320px; background-color: transparent" bgcolor="#f1f1f1"
                background="images/table.GIF" width="142" align="center">
                <tr style="height: 2px">
                </tr>
                <tr>
                    <td class="menu" style="cursor: hand" bordercolor="#000000">
                        <img src="Images/logo.jpg" style="width: 152px; height: 40px" height="40" width="152">
                    </td>
                </tr>
                <tr>
                    <td class="menu" id="choice1" onmouseover="movein(this)" style="cursor: hand; height: 34px"
                        onmouseout="moveout(this)" bordercolor="black">
                        &nbsp;<a href="Calendar.aspx">Manage Calendar </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" id="choice2" onmouseover="movein(this)" style="cursor: hand; height: 31px"
                        onmouseout="moveout(this)" bordercolor="black">
                        &nbsp;<a href="AddResturantsPhoto.aspx">Manage&nbsp;Gallery </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" id="choice3" onmouseover="movein(this)" style="cursor: hand; height: 30px"
                        onmouseout="moveout(this)" bordercolor="black">
                        &nbsp;<a href="Coupan.aspx">Manage&nbsp; Coupan </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" id="choice6" onmouseover="movein(this)" style="cursor: hand; height: 32px"
                        onmouseout="moveout(this)" bordercolor="black">
                        &nbsp;<a href="Menu.aspx">Manage&nbsp; Menu </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" id="choice4" onmouseover="movein(this)" style="cursor: hand; height: 30px"
                        onmouseout="moveout(this)" bordercolor="black">
                        &nbsp;<a href="MemberSerch.aspx">Send Email </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" id="choice5" onmouseover="movein(this)" style="cursor: hand; height: 29px"
                        onmouseout="moveout(this)" bordercolor="black">
                        &nbsp;<a href='AddRestaurantDetails.aspx'>Edit Your Details </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" style="cursor: hand; height: 30px" bordercolor="#000000">
                        &nbsp;<a href="ChangePassword.aspx">Change Password</a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" style="cursor: hand" bordercolor="#000000">
                        &nbsp;<a href="ManageService.aspx">Manage Services </a>
                    </td>
                </tr>
                <tr>
                    <td class="menu" style="cursor: hand" bordercolor="#000000">
                        &nbsp;<a href="logoff.aspx">Log Off</a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
