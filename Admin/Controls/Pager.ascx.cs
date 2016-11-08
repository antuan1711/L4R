using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Controls
{
    public delegate void LoadData(Int32 currentPageNo);
    public delegate void ChangeOtherPager();
    //public delegate void ChangePagerPageSize(Int32 pageSize);
    public partial class Pager : System.Web.UI.UserControl
    {
        #region member declaration
        public LoadData loadData = null;
        public ChangeOtherPager changeOtherPager = null;
        private int _pageSize;
        private int _totalPages;
        private int _totalRecord;
        private bool _isChanged = false;
        private string _buttonType = String.Empty;
        #endregion

        #region [ Public Property ]
        public int PageSize
        {
            get
            {
                if (ViewState["m_intPageSize"] == null)
                {
                    return _pageSize;
                }
                else
                {
                    return Convert.ToInt32(ViewState["m_intPageSize"]);
                }
            }
            set
            {
                _pageSize = value;
                ViewState["m_intPageSize"] = value;
            }
        }

        public int PageNo
        {
            get
            {
                if (ViewState["m_intCurrentPage"] == null)
                {
                    ViewState["m_intCurrentPage"] = 1;
                }
                return Convert.ToInt32(ViewState["m_intCurrentPage"]);
            }
            set
            {
                ViewState["m_intCurrentPage"] = value;
            }
        }

        private int TotalPages
        {
            get
            {
                if (ViewState["m_intTotalPageSize"] == null)
                {
                    return _pageSize;
                }
                else
                {
                    return Convert.ToInt32(ViewState["m_intTotalPageSize"]);
                }
            }
            set
            {
                _totalPages = value;
                ViewState["m_intTotalPageSize"] = value;
            }
        }

        public int TotalRecord
        {
            get
            {
                return _totalRecord;
            }
            set
            {
                _totalRecord = value;
            }
        }

        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }

        public String ButtonType
        {
            get
            {
                if (_buttonType == String.Empty)
                    return null;
                else
                    return _buttonType;
            }
            set
            {
                _buttonType = value;
                ViewState["btnType"] = value;
            }
        }

        #endregion

        #region "Paging Events"
        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = PageNo - 1;
            if (PageNo % 5 == 0)
            {
                loadData(PageNo);
            }
            else
            {
                loadData(PageNo);
            }

            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        protected void lnkNext_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = PageNo + 1;
            if (PageNo % 5 == 0)
            {
                loadData(PageNo);
            }
            else
            {
                loadData(PageNo);
            }

            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        protected void lnk1_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = Convert.ToInt32(lnk1.Text);

            loadData(PageNo);
            if (PageNo == 1)
            {
                lnkPrevious.Enabled = false;
            }
            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        protected void lnk2_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = Convert.ToInt32(lnk2.Text);
            loadData(PageNo);
            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        protected void lnk3_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = Convert.ToInt32(lnk3.Text);
            loadData(PageNo);
            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        protected void lnk4_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = Convert.ToInt32(lnk4.Text);
            loadData(PageNo);
            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        protected void lnk5_Click(object sender, EventArgs e)
        {
            IsChanged = true;
            PageNo = Convert.ToInt32(lnk5.Text);
            loadData(PageNo);
            if (changeOtherPager != null)
            {
                changeOtherPager();
            }
        }
        #endregion
        /// <summary>
        /// Set Intial paging elements
        /// </summary>
        private void EnablePaging()
        {
            lnkPrevious.CssClass = "pagingactive";
            lnkNext.CssClass = "pagingactive";
            pagingDIV.Style["display"] = "block";
            pagingDIV.Visible = true;
            lblCurrentPge.Text = "Page " + PageNo.ToString() + " of " + TotalPages.ToString();
            if (PageNo > 1 && PageNo < TotalPages)
            {
                lnkPrevious.Enabled = true;
                lnkNext.Enabled = true;
            }
            else
            {
                if (PageNo == TotalPages)
                {
                    lnkNext.Enabled = false;
                    lnkPrevious.Enabled = true;
                }

                if (PageNo == 1)
                {
                    lnkPrevious.Enabled = false;
                    lnkNext.Enabled = true;
                }
            }

            lnk1.OnClientClick = "javascript:return true;";
            lnk2.OnClientClick = "javascript:return true;";
            lnk3.OnClientClick = "javascript:return true;";
            lnk4.OnClientClick = "javascript:return true;";
            lnk5.OnClientClick = "javascript:return true;";
            lnk1.CssClass = "";
            lnk2.CssClass = "";
            lnk3.CssClass = "";
            lnk4.CssClass = "";
            lnk5.CssClass = "";
            switch ((PageNo - 1) % 5)
            {
                case 0:

                    lnk1.OnClientClick = "javascript:return false;";
                    lnk1.CssClass = "current";
                    break;
                case 1:
                    //lnk2.CssClass = "pagingactive";
                    lnk2.OnClientClick = "javascript:return false;";
                    lnk2.CssClass = "current";
                    break;
                case 2:
                    //lnk3.CssClass = "pagingactive";
                    lnk3.OnClientClick = "javascript:return false;";
                    lnk3.CssClass = "current";
                    break;
                case 3:
                    //lnk4.CssClass = "pagingactive";
                    lnk4.OnClientClick = "javascript:return false;";
                    lnk4.CssClass = "current";
                    break;
                case 4:
                    //lnk5.CssClass = "pagingactive";
                    lnk5.OnClientClick = "javascript:return false;";
                    lnk5.CssClass = "current";
                    break;
            }

            lnk1.Visible = false;
            lnk2.Visible = false;
            lnk3.Visible = false;
            lnk4.Visible = false;
            lnk5.Visible = false;
            Int32 firstPageNo = Convert.ToInt32(Convert.ToString(Math.Floor((PageNo - 1) / 5.0) * 5 + 1));
            Int32 RemainingPage = TotalPages - firstPageNo + 1;

            if (RemainingPage >= 5)
            {
                lnk1.Visible = true;
                lnk2.Visible = true;
                lnk3.Visible = true;
                lnk4.Visible = true;
                lnk5.Visible = true;
                lnk1.Text = Convert.ToString(firstPageNo);
                lnk2.Text = Convert.ToString(firstPageNo + 1);
                lnk3.Text = Convert.ToString(firstPageNo + 2);
                lnk4.Text = Convert.ToString(firstPageNo + 3);
                lnk5.Text = Convert.ToString(firstPageNo + 4);
            }
            else if (RemainingPage == 4)
            {
                lnk1.Visible = true;
                lnk2.Visible = true;
                lnk3.Visible = true;
                lnk4.Visible = true;
                lnk1.Text = Convert.ToString(firstPageNo);
                lnk2.Text = Convert.ToString(firstPageNo + 1);
                lnk3.Text = Convert.ToString(firstPageNo + 2);
                lnk4.Text = Convert.ToString(firstPageNo + 3);
            }
            else if (RemainingPage == 3)
            {
                lnk1.Visible = true;
                lnk2.Visible = true;
                lnk3.Visible = true;
                lnk1.Text = Convert.ToString(firstPageNo);
                lnk2.Text = Convert.ToString(firstPageNo + 1);
                lnk3.Text = Convert.ToString(firstPageNo + 2);
            }
            else if (RemainingPage == 2)
            {

                lnk1.Visible = true;
                lnk2.Visible = true;
                lnk1.Text = Convert.ToString(firstPageNo);
                lnk2.Text = Convert.ToString(firstPageNo + 1);

            }
            else if (RemainingPage == 1)
            {
                lnk1.Visible = true;
                lnk1.Text = Convert.ToString(firstPageNo);
            }
        }
        #region "SetPagerLoadSetting"
        /// <summary>
        /// This methods is used to setup paging from main page
        /// </summary>
        public void SetPagerLoadSetting()
        {
            TotalPages = (int)Math.Ceiling((double)TotalRecord / PageSize);
            if (TotalPages <= 1)
            {
                pagingDIV.Visible = false;
                lblCurrentPge.Visible = false;
                return;
            }
            else
            {
                EnablePaging();
                pagingDIV.Visible = true;
                lblCurrentPge.Visible = true;
            }
        }
        #endregion

        #region SetPager
        /// <summary>
        /// Change pager on the base of other page
        /// </summary>
        /// <param name="otherPager"></param>
        public void SetPager(Pager otherPager)
        {
            this.PageNo = otherPager.PageNo;
            this.ButtonType = otherPager.ButtonType;
            this.lnk1.Text = otherPager.lnk1.Text;
            this.lnk2.Text = otherPager.lnk2.Text;
            this.lnk3.Text = otherPager.lnk3.Text;
            this.lnk4.Text = otherPager.lnk4.Text;
            this.lnk5.Text = otherPager.lnk5.Text;

            this.lnk1.Visible = otherPager.lnk1.Visible;
            this.lnk2.Visible = otherPager.lnk2.Visible;
            this.lnk3.Visible = otherPager.lnk3.Visible;
            this.lnk4.Visible = otherPager.lnk4.Visible;
            this.lnk5.Visible = otherPager.lnk5.Visible;
            this.lnkPrevious.Visible = otherPager.lnkPrevious.Visible;
            this.lnkNext.Visible = otherPager.lnkNext.Visible;
            this.lnk1.CssClass = otherPager.lnk1.CssClass;
            this.lnk2.CssClass = otherPager.lnk2.CssClass;
            this.lnk3.CssClass = otherPager.lnk3.CssClass;
            this.lnk4.CssClass = otherPager.lnk4.CssClass;
            this.lnk5.CssClass = otherPager.lnk5.CssClass;
            this.lnk1.OnClientClick = otherPager.lnk1.OnClientClick;
            this.lnk2.OnClientClick = otherPager.lnk2.OnClientClick;
            this.lnk3.OnClientClick = otherPager.lnk3.OnClientClick;
            this.lnk4.OnClientClick = otherPager.lnk4.OnClientClick;
            this.lnk5.OnClientClick = otherPager.lnk5.OnClientClick;
            EnablePaging();
        }
        #endregion
        //protected void ChangePageSize(object sender, EventArgs e)
        //{
        //    changePagerPageSize(Convert.ToInt32(ddlPageSize.SelectedValue));
        //}
    }
}