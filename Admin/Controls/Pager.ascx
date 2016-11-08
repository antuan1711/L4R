<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="Admin.Controls.Pager" %>
<style type="text/css">
#pagination {
	overflow:hidden;
	/*padding:0 0 15px;*/
	
	clear: both; float:right;

	}

#pagination ul {
	display: block;
	float: left;
	margin: 0px;
	padding: 0px;
	}
	
#pagination li {
	background: none;
	display: inline;
	margin: 0px;
	padding-top: 0px;
	
	padding-bottom: 0px;
	float: left;
	font-family:'MuliRegular', sans-serif;
	font-size:14px;
	}
	
#pagination li a {
	background-color: #E3E3E3;
    color: #999999;
	text-decoration: none;
	border:1px solid #999999;
	min-height: 8px;
    min-width: 8px;
    padding: 1px 6px;
    text-align: center;
	float: left;
	-webkit-transition:all 0.3s ease-in;  
   	-moz-transition:all 0.3s ease-in;  
  	-o-transition:all 0.3s ease-in;  
   	transition:all 0.3s ease-in;
	}
	
#pagination li a.current {
	background-color: #ED8D23;
    color: #FFFFFF;
	text-decoration: none;
	border:1px solid #bc730f;
	min-height: 8px;
    min-width: 8px;
    padding: 1px 6px;
    text-align: center;
	float: left;
	}

#pagination li a:hover {
	background-color: #333333;
    color: #FFFFFF;
	text-decoration: none;
	border:1px solid #3C3C3C;
	min-height: 8px;
    min-width: 8px;
    padding: 1px 6px;
    text-align: center;
	float: left;
	}
	
</style>
<div style="width: 100%; float: left;">
    <div class="pull-left">
        <asp:Label ID="lblCurrentPge" runat="server"></asp:Label>
    </div>
    <div id="pagingDIV" runat="server" class="pull-right">
     
            <ul id="pagination">
                <li>
                    <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click" CssClass="Flag tooltip"
                        ToolTip="Previous">&laquo;</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnk1" runat="server" Text="1" OnClick="lnk1_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnk2" runat="server" Text="2" OnClick="lnk2_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnk3" runat="server" Text="3" OnClick="lnk3_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnk4" runat="server" Text="4" OnClick="lnk4_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnk5" runat="server" Text="5" OnClick="lnk5_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click" CssClass="Flag tooltip"
                        ToolTip="Next">&raquo;</asp:LinkButton></li>
            </ul>
       
    </div>
</div>
<div class="clrblk">
</div>