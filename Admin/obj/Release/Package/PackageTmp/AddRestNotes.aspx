<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRestNotes.aspx.cs" Inherits="Admin.AddRestNotes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="thickbox/Thickbox.css" type="text/css" media="screen" />
       <script type="text/javascript">
           function updatereviewinfo() {
               var Flag = '<%=flag%>';
               if (Flag == "added") {
                   //self.parent.window.location = "AllOrderLOG.aspx?nav=added"
                   self.parent.tb_remove();
               }
           }
    </script>
</head>
<body  onload="javascript:updatereviewinfo();"  style="font-size:12px; font-family:Verdana;">
    <form id="form1" runat="server">
    <div>
      <table>
            <tr>
                <td >
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Notes<br />
                    <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" Rows="5" Columns="40" ></asp:TextBox>
                </td>
            </tr>
         
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Add Notes" OnClick="btnSubmit_Click" />                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
