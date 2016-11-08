<%@ Control Language="c#" AutoEventWireup="True" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"
    CodeBehind="_MenuNew.ascx.cs" Inherits="Admin.Controls.__MenuNew" %>
<%--

    This user control creates a menu for left-hand navigation of the
    product catalog pages.

--%>
<div id="column-left">
    <div id="admin-menu" class="left-menu left-blk">
        <%--<ul id="nav" class="dropdown dropdown-vertical">
            <li class="dir" id="liRestaurants" runat="server"><a href="javascript:void(0);">Restaurants</a>
             <ul>
                    <li><a href="ManageRestaurants.aspx"">Manage Restaurants</a></li>
                    <li><a href="SendInvoice.aspx">Send Invoice</a></li>
                </ul>
            </li>
            <li class="dir" id="liLogs" runat="server"><a href="javascript:void(0);">Purchases Log</a>
                <ul>
                    <li><a href="AllOrderLog.aspx">Pay Restaurants</a></li>
                    <li><a href="DinersPaymentLog.aspx">Diner Payment Log</a></li>
                    <li><a href="viewCatOrders.aspx">Catering</a></li>
                    <li><a href="RestMenuLog.aspx">Takeout</a></li>
                    <li><a href="GiftCardOrders.aspx">Gift Certificates Sold</a></li>
                     <li><a href="L4RGiftCertificateLog.aspx">L4R Gift Cerificate Log</a></li>
                    <li><a href="adminInventoryManage.aspx">Auction</a></li>
                    <li><a href="LocOrderLog.aspx">Party Reservations</a></li>
                    <li><a href="CouponLog.aspx">Coupons</a></li>
                </ul>
            </li>
            <li class="dir" id="liMember" runat="server"><a href="javascript:void(0);">Members</a>
                <ul>
                    <li><a href="Member_search.aspx">Member Search</a></li>
                    <li><a href="SearchMailinglist.aspx">Send Emails</a></li>
                    <li><a href="allrewards.aspx">Customers' Rewards</a></li>
                    
                </ul>
            </li>
              <li class="dir" id="liEvents" runat="server"><a href="javascript:void(0);">Manage Events</a>
                <ul>
                    <li><a href="Calendar.aspx">View Events</a></li>
                    <li><a href="AddEvent.aspx">Add Events</a></li>
                    <li><a href="ManageActivities.aspx">Managae Event Category</a></li>
                   </ul>
            </li>
             <li class="dir" id="reviewmenu" runat="server" visible="true"><a href="../UserReviews.aspx"
                id="liReview" runat="server">Manage Reviews</a>
                
            </li>
            <li id="liCalender" runat="server"><a href="Calendar.aspx">Manage Calendar</a></li>
            <li id="liCategory" runat="server"><a href="javascript:void(0);">Categories</a>
                <ul>
                    <li><a href="Advt.aspx?mid=2">Jobs</a></li>
                    <li><a href="Advt.aspx?mid=3">Service Provider</a></li>
                    <li><a href="Advt.aspx?mid=1">Equipment for Sale</a></li>
                    <li><a href="ManageActivities.aspx">Activities</a></li>
                    <li><a href="ManageCuisine.aspx">Type of Food</a></li>
                </ul>
            </li>
            <li class="dir" id="liClassified" runat="server"><a href="javascript:void(0);">CLassifieds</a>
                <ul>
                    <li><a href="freeClassifiedCategoryDetais.aspx">Restaurants Jobs</a></li>
                    <li><a href="ClassifiedUserDetails.aspx">Service/Advertising</a></li>
                     <li><a href="PostedResumes.aspx">job Seekers</a></li>

                </ul>
            </li>
            <li class="dir" id="liCities" runat="server"><a href="ManageCities.aspx">Mansage Cities</a></li>
             <li class="dir" id="liGiftCertificate" runat="server"><a href="SetupGiftCertificates.aspx">Manage Gift Certificate</a></li>
            <li class="dir" id="liServices" runat="server"><a href="ManageService.aspx">Manage Services</a></li>
            <li class="dir" id="liPhrase" runat="server"><a href="AddPhrase.aspx">Add Phrase</a></li>
             <li class="dir" id="liFinePrints" runat="server"><a href="L4RCertificateFinePrints.aspx">L4RCertificate Fine Print</a></li>
            <li class="dir" id="liAdmin" runat="server"><a href="javascript:void(0);">Administrators</a>
                <ul>
                    <li><a href="Administrators.aspx">Add Users</a></li>
                    <li><a href="Password.aspx">Change Admin Passwords</a></li>
                </ul>
            </li>
            <li><a href="Logoff.aspx">Logout</a></li>
            <div class="clr-blk">
            </div>
        </ul>--%>
        <ul id="nav" class="dropdown dropdown-vertical">
            <li class="dir" id="liRestaurants" runat="server"><a href="javascript:void(0);">Restaurants</a>
             <ul>
                 <li><a href="AllOrderLog.aspx">Pay Restaurants</a></li>
                 <li><a href="SendInvoice.aspx">Send Invoice</a></li>
                    <li><a href="ManageRestaurants.aspx"">Restaurants</a></li>                    
                </ul>
            </li>
            <li class="dir" id="liLogs" runat="server"><a href="javascript:void(0);">Reports</a>
                <ul>
                    <li><a href="AllOrderLog.aspx">All</a></li>
                    <%--<li><a href="AllOrderLog.aspx">Pay Restaurants</a></li>--%>
                    <%--<li><a href="DinersPaymentLog.aspx">Dining (rewards)</a></li>--%>
                    <li><a href="viewCatOrders.aspx">Catering</a></li>
                    <li><a href="RestMenuLog.aspx">Takeout</a></li>
                    <li><a href="GiftCardOrders.aspx">Gift Certificate</a></li>
                     <li><a href="L4RGiftCertificateLog.aspx">L4R Gift Cerificates</a></li>
                    <%--<li><a href="adminInventoryManage.aspx">Auction</a></li>--%>
                    <li><a href="LocOrderLog.aspx">Private Parties</a></li>
                    <li><a href="CouponLog.aspx">Coupons</a></li>
                </ul>
            </li>
            <li class="dir" id="liMember" runat="server"><a href="javascript:void(0);">Members</a>
                <ul>
                    <li><a href="Member_search.aspx">Member Search</a></li>
                   <%-- <li><a href="SearchMailinglist.aspx">Send Emails</a></li>--%>
                    <%--<li><a href="allrewards.aspx">Customers' Rewards</a></li>--%>                    
                </ul>
            </li>
            <li class="dir" id="liCustomerReward" runat="server"><a href="javascript:void(0);">Customers' Rewards</a>
                <ul>
                    <li><a href="allrewards.aspx">Search Rewards</a></li>
                    <%--<li><a href="SearchMailinglist.aspx">Send Emails</a></li>--%>
                    <%--<li><a href="allrewards.aspx">Customers' Rewards</a></li>--%>                    
                </ul>
            </li>
            <li class="dir" id="liClassified" runat="server"><a href="javascript:void(0);">CLassifieds</a>
                <ul>
                    <li><a href="freeClassifiedCategoryDetais.aspx">Restaurants Jobs</a></li>
                    <li><a href="Classifieds_Categories.aspx?type=s">Vendors & Services</a></li>
                    <li><a href="Classifieds_Categories.aspx?type=a">Equipment for Sale</a></li>
                     <li><a href="PostedResumes.aspx">job Seekers</a></li>

                </ul>
            </li>
            <li class="dir" id="liSetting" runat="server"><a href="javascript:void(0);">Setting</a>
                <ul>    
             <li id="liFinePrints" runat="server"><a href="L4RCertificateFinePrints.aspx">L4RCertificate Fine Print</a></li>       
             <li id="liCities" runat="server"><a href="ManageCities.aspx">Cities</a></li>
             <li id="liPhrase" runat="server"><a href="AddPhrase.aspx">Phrases</a></li>                
             <li><a href="ManageService.aspx">Fees (Services)</a></li>             
                </ul>
            </li>
            <li id="liCategory" runat="server"><a href="javascript:void(0);">Categories Setup</a>
                <ul>
                    <li><a href="Advt.aspx?mid=2">Jobs</a></li>
                    <li><a href="Advt.aspx?mid=3">Service Provider</a></li>
                    <li><a href="Advt.aspx?mid=1">Equipment for Sale</a></li>
                    <li><a href="ManageActivities.aspx">Activities</a></li>
                    <li><a href="ManageCuisine.aspx">Type of Food</a></li>
                </ul>
            </li>
              <li class="dir" id="liServices" runat="server"><a href="javascript:void(0);">Manage Services</a>
                <ul>    
             <li id="reviewmenu" runat="server" visible="true"><a href="../UserReviews.aspx" id="liReview" runat="server">Reviews</a></li>       
            <li id="liCalender" runat="server"><a href="Calendar.aspx">Calendar</a></li>
                    <li id="liGiftCertificate" runat="server"><a href="SetupGiftCertificates.aspx">Manage Gift Certificate</a></li>
                     <li class="dir" id="Li1" runat="server" visible="true">
                         <a href="../ManageActivities.aspx" id="A1" runat="server">Activities</a>
                             <%--<ul>
                                 <li><a href="ManageActivities.aspx">View Activities</a></li>
                                 <li><a href="AddEvent.aspx">Add Activity</a></li>
                                 <li><a href="ManageActivities.aspx">Categories</a></li>
                             </ul>--%>
                    </li>
                    <%--<li><a href="AddEvent.aspx">Add Events</a></li>
                    <li><a href="ManageActivities.aspx">Managae Event Category</a></li>--%>
                   </ul>
            </li>
            <li class="dir" id="liAdmin" runat="server"><a href="javascript:void(0);">Admin</a>
                <ul>
                    <li><a href="Administrators.aspx">Add Users</a></li>
                    <li><a href="Password.aspx">Change Admin Passwords</a></li>
                </ul>
            </li>
   <%--         <li><a href="Logoff.aspx">Logout</a></li>--%>
            <div class="clr-blk">
            </div>
        </ul>
        <div class="clr-blk">
        </div>
    </div>
    <!--left-menu-->
  
    <div class="clr-blk">
    </div>
</div>
