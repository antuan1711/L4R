<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderNew.ascx.cs" Inherits="Admin.Controls.HeaderNew" %>

<%@ Import Namespace="LoveForRestaurants.BizLayer" %>

<link href="<%=ConfigHelper.RootUrl %>css/bootstrap.min.css" rel="stylesheet" />
<script src="<%=ConfigHelper.RootUrl %>scripts/jquery-1.11.1.min.js"></script>
<link href="<%=ConfigHelper.RootUrl %>thickbox/thickbox.css" rel="stylesheet" />
<link href="<%=ConfigHelper.RootUrl %>css/uploadify.css" rel="stylesheet" />


<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>thickbox/thickbox.js"></script>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>js/jquery-ui.js"></script>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>scripts/ModalPopups.js"></script>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl%>scripts/bootstrap.min.js"></script>
<link href="<%=ConfigHelper.RootUrl %>css/jquery.ui.css" rel="stylesheet" type="text/css" />

<%-- COLUMN RESIZEABLE START--%>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>scripts/colResizable-1.6.js"></script>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>scripts/jquery.uploadify.js"></script>
<script type="text/javascript">
    $(function () {
        $("table.resizeable").colResizable({
            liveDrag: true,
            gripInnerHtml: "<div class='grip'></div>",
            draggingClass: "dragging",
            resizeMode: 'fit'
        });
    });



    var RootUrl = "<%=ConfigHelper.RootUrl%>";
    function ShowOrderDetail(orderType, orderID) {
        if (orderID != "") {
            $.ajax({
                url: RootUrl + "ShowOrderDetails.aspx?OT=" + orderType + "&OI=" + orderID + "&t=" + Math.random(),
                success: function (data) {
                    var _startIndex = data.indexOf("#START#") + 7;
                    var _endIndex = data.indexOf("#END#");
                    document.getElementById("dvOrderDetail").innerHTML = data.substring(_startIndex, _endIndex);
                    $("#dvOrderDetail").modal('show');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                }
            });
        }
    }
</script>

<%-- END --%>


<%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>scripts/jquery.searchabledropdown-1.0.8.min.js"></script>
<script type="text/javascript" src="<%=ConfigHelper.RootUrl %>scripts/jquery.dd.min.js"></script>
<script type="text/javascript">
    var jqNew = jQuery.noConflict();
    jqNew(document).ready(function (e) {
        try {
            jqNew("select").searchable();
            jqNew("#ddlAction").msDropDown();
        } catch (e) {
            alert(e.message);
        }
    });
</script>--%>
<script type="text/javascript">
    $(document).ready(function () {
        SearchText();
    });
    
    $(document).ready(function () {
        $('.file_upload').uploadify({
            'swf': 'scripts/uploadify.swf',
            //        'uploader': 'http://localhost/admin.l4r.templateplanet.net/Handler/Uploadify.ashx',
            'uploader': 'Handler/Uploadify.ashx',
            'cancelImg': '../Images/uploadify-cancel.png',
            'buttonText': 'Select Files',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
            'multi': true,
            'auto': false,
            'onQueueComplete': function (queueData) {                
                CallServerSideFunction();
            }
        });

        $('#btnUpload').click(function () {
            //alert($('.uploadify').attr('id'));
            $("#" + $('.uploadify').attr('id')).uploadify('upload', '*');

        });
    });

    function SearchText() {

        $(".rest-autocomplete").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "actionpages/AjaxActions.aspx/GetRestaurants",
                    //data: "{'filter':'" + document.getElementById('txtRestNameLeftSearch').value + "','isActive':'false'}",
                    data: "{'filter':'" + $(".rest-autocomplete").val() + "','isActive':'false'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("No Match");
                    }
                });
            }
        });
    }

</script>


<link href='<%=ConfigHelper.RootUrl %>fancybox/jquery.fancybox-1.3.4.css' rel='stylesheet' />
<script src="<%=ConfigHelper.RootUrl %>fancybox/jquery.fancybox-1.3.4.js" type='text/javascript'></script>

<script>
    $(function () {
        $(".datepicker").datepicker();
    });
</script>
<div id="header">
    <div id="header-logo">
        <a href="javascript:void(0);">
            <img src="images/logonew.png" alt="L4R" /></a>
    </div>
    <div id="header-l4r">
        <a href="javascript:void(0);">
            <img src="images/l4r-logo.png" width="51" height="50" /></a>
    </div>
    <div class="clr-blk">
    </div>
</div>
<div id="menu">
    <ul>
        <li><a href="AllOrderLog.aspx">Home</a></li>
        <li><a href="Logoff.aspx">Logout</a></li>
        <%--<li><a href="javascript:void(0);">Tips</a></li>
        <li>
            <a href="javascript:void(0);">Services</a></li>--%>
    </ul>
    <div class="clr-blk">
    </div>
</div>
<div class="modal fade" id="dvOrderDetail">
</div>
