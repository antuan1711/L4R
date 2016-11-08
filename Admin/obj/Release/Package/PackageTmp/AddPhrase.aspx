<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhrase.aspx.cs" Inherits="Admin.AddPhrase" %>

<%@ Register TagPrefix="ucMenu" TagName="Menu" Src="Controls/_MenuNew.ascx" %>
<%@ Register TagPrefix="ucHeader1" TagName="Header" Src="Controls/HeaderNew.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>777Restaurants.com--Admin</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="css/design.css" rel="stylesheet" type="text/css" />
   
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    
    <link href="dropdown/vertical.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="script.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="background">
        <div id="page">
            <ucHeader1:Header ID="Header2" runat="server"></ucHeader1:Header>
            <!--menu-->
            <div id="main">
                <ucMenu:Menu ID="Menu1" runat="server"></ucMenu:Menu>
                <div id="column-right">
                    <div id="content">
                        <div id="content-top">
                           <h3>
                                Add Phrase
                                <a  href="EditPharse.aspx?keepThis=false&amp;TB_iframe=true&amp;height=130&amp;width=400&amp;title=Add Pharse" class="thickbox btn btn-link pull-right" title="Add Pharse">Add New</a>
                                </h3>
                        </div>
                        <!--content-top-->
                        <div id="content-mid" class="col-md-12">
                           
                                <asp:Label ID="lblerror" runat="server" Visible="False" ForeColor="Red"  Font-Size="12px"></asp:Label>
                           
                          
                                
                                <div class="scroll">
                                    <asp:DataGrid ID="dgGiftCertificatePhares" runat="server" AllowPaging="True" AllowSorting="True"
                                        OnPageIndexChanged="dgGiftCertificatePhares_PageIndexChanged" OnItemCommand="dgGiftCertificatePhares_ItemCommand"
                                        CellSpacing="0" CellPadding="0" AutoGenerateColumns="False" GridLines="None" CssClass="resizeable table table-bordered table-striped table-hover"
                                        OnSortCommand="dgGiftCertificatePhares_SortCommand" Width="100%" PageSize="10">
                                      
                                        <Columns>
                                            <asp:TemplateColumn SortExpression="Pharse" HeaderText="Pharse" >
                                              
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPharse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pharse")%>'>
                                                        <asp:HiddenField ID="hdnPharseID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"PhrasesID")%>' />
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="View/Delete"  >
                                              
                                                <ItemTemplate>
                                                    <a class="thickbox" href="EditPharse.aspx?PharseID=<%#DataBinder.Eval(Container.DataItem,"PhrasesID")%>&keepThis=false&amp;TB_iframe=true&amp;height=130&amp;width=300&amp;title=Edit Pharse" title="Edit Pharse" style="margin-right:3px;">
                                                        Edit </a>/<asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteOrder" style="margin-left:3px;"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PhrasesID")%>' OnClientClick="javascript:return confirm('Do you want to delete this pharse'); "></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle NextPageText="Next &amp;gt;&amp;gt;" PrevPageText="&amp;lt;&amp;lt; Prev" 
                                            HorizontalAlign="Center"></PagerStyle>
                                    </asp:DataGrid>
                                </div>
                                <!--.table-container--->
                           
                        </div>
                        <!--content-mid-->
                        <div id="content-bot">
                            &nbsp;
                        </div>
                        <!--content-bot-->
                        <div class="clr-blk">
                        </div>
                    </div>
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
    </form>
</body>
</html>
