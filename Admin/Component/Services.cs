using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Admin.Component
{
    public enum ServiceType
    {
        Profile = 1,
        OpenPosition = 2,
        Events = 3,
        Catering = 4,
        GiftCertificate = 5,
        Email = 6,
        Coupons = 7,
        ReservationsNewTable = 8,
        Location = 9,
        DinersRewardsLog = 10,
        UseL4R = 11,
        Classifieds = 12,
        Auction = 13,
        ReservationsOpenTable = 14,
        Reviews = 15
    }

    /// <summary>
    /// Summary description for Services.
    /// </summary>
    public class Services
    {
        #region Variable declaration
        private Int32 _restaurantID;
        private Boolean _isProfileActive;
        private Boolean _isOpenPositionActive;
        private Boolean _isEventsActive;
        private Boolean _isCateringActive;
        private Boolean _isGiftCertificateActive;
        private Boolean _isEmailActive;
        private Boolean _isCouponsActive;
        private Boolean _isReservationsNewUserActive;
        private Boolean _isReservationsOpenTableActive;
        private Boolean _isLocationActive;
        private Boolean _isDinersRewardsLogActive;
        private Boolean _isUseL4RActive;
        private Boolean _isClassifiedActive;
        private Boolean _isAuctionActive;
        private Boolean _isReviewsActive;

        #endregion

        #region Properties
        public Int32 RestaurantID
        {
            get
            {
                return _restaurantID;
            }
            set
            {
                _restaurantID = value;
            }
        }

        public Boolean IsProfileActive
        {
            get
            {
                return _isProfileActive;
            }
            set
            {
                _isProfileActive = value;
            }
        }
        public Boolean IsOpenPositionActive
        {
            get
            {
                return _isOpenPositionActive;
            }
            set
            {
                _isOpenPositionActive = value;
            }
        }
        public Boolean IsEventsActive
        {
            get
            {
                return _isEventsActive;
            }
            set
            {
                _isEventsActive = value;
            }
        }

        public Boolean IsCateringActive
        {
            get
            {
                return _isCateringActive;
            }
            set
            {
                _isCateringActive = value;
            }
        }
        public Boolean IsGiftCertificateActive
        {
            get
            {
                return _isGiftCertificateActive;
            }
            set
            {
                _isGiftCertificateActive = value;
            }
        }
        public Boolean IsEmailActive
        {
            get
            {
                return _isEmailActive;
            }
            set
            {
                _isEmailActive = value;
            }
        }
        public Boolean IsCouponsActive
        {
            get
            {
                return _isCouponsActive;
            }
            set
            {
                _isCouponsActive = value;
            }
        }
        public Boolean IsReservationsNewUserActive
        {
            get
            {
                return _isReservationsNewUserActive;
            }
            set
            {
                _isReservationsNewUserActive = value;
            }
        }

        public Boolean IsReservationsOpenTableActive
        {
            get
            {
                return _isReservationsOpenTableActive;
            }
            set
            {
                _isReservationsOpenTableActive = value;
            }
        }


        public Boolean IsLocationActive
        {
            get
            {
                return _isLocationActive;
            }
            set
            {
                _isLocationActive = value;
            }
        }
        public Boolean IsDinersRewardsLogActive
        {
            get
            {
                return _isDinersRewardsLogActive;
            }
            set
            {
                _isDinersRewardsLogActive = value;
            }
        }
        public Boolean IsUseL4RActive
        {
            get
            {
                return _isUseL4RActive;
            }
            set
            {
                _isUseL4RActive = value;
            }
        }

        public Boolean IsClassifiedActive
        {
            get
            {
                return _isClassifiedActive;
            }
            set
            {
                _isClassifiedActive = value;
            }
        }

        public Boolean IsAuctionActive
        {
            get
            {
                return _isAuctionActive;
            }
            set
            {
                _isAuctionActive = value;
            }
        }

        public Boolean IsReviewsActive
        {
            get
            {
                return _isReviewsActive;
            }
            set
            {
                _isReviewsActive = value;
            }
        }
        #endregion

        #region Constructor
        public Services()
        {
            _restaurantID = 0;
            _isProfileActive = false;
            _isOpenPositionActive = false;
            _isEventsActive = false;
            _isCateringActive = false;
            _isGiftCertificateActive = false;
            _isEmailActive = false;
            _isCouponsActive = false;
            _isLocationActive = false;
            _isDinersRewardsLogActive = false;
            _isUseL4RActive = false;
            _isClassifiedActive = false;
            _isAuctionActive = false;
            _isReviewsActive = false;
        }
        #endregion

        #region LoadServiceSetting
        public void LoadServiceSetting()
        {
            if (RestaurantID > 0)
            {
                DataSet dsService = RestaurantDB.GetAllServicesByRestID(RestaurantID);
                if (dsService.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drService in dsService.Tables[1].Rows)
                    {
                        switch ((ServiceType)Convert.ToInt32(drService["ServiceID"]))
                        {
                            case ServiceType.Profile:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsProfileActive = true;
                                }
                                else
                                {
                                    IsProfileActive = false;
                                }
                                break;
                            case ServiceType.OpenPosition:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsOpenPositionActive = true;
                                }
                                else
                                {
                                    IsOpenPositionActive = false;
                                }
                                break;
                            case ServiceType.Events:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsEventsActive = true;
                                }
                                else
                                {
                                    IsEventsActive = false;
                                }
                                break;
                            case ServiceType.Catering:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsCateringActive = true;
                                }
                                else
                                {
                                    IsCateringActive = false;
                                }
                                break;
                            case ServiceType.GiftCertificate:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsGiftCertificateActive = true;
                                }
                                else
                                {
                                    IsGiftCertificateActive = false;
                                }
                                break;
                            case ServiceType.Email:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsEmailActive = true;
                                }
                                else
                                {
                                    IsEmailActive = false;
                                }
                                break;
                            case ServiceType.Coupons:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsCouponsActive = true;
                                }
                                else
                                {
                                    IsCouponsActive = false;
                                }
                                break;
                            case ServiceType.ReservationsNewTable:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsReservationsNewUserActive = true;
                                }
                                else
                                {
                                    IsReservationsNewUserActive = false;
                                }
                                break;
                            case ServiceType.ReservationsOpenTable:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsReservationsOpenTableActive = true;
                                }
                                else
                                {
                                    IsReservationsOpenTableActive = false;
                                }
                                break;
                            case ServiceType.Location:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsLocationActive = true;
                                }
                                else
                                {
                                    IsLocationActive = false;
                                }
                                break;
                            case ServiceType.DinersRewardsLog:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsDinersRewardsLogActive = true;
                                }
                                else
                                {
                                    IsDinersRewardsLogActive = false;
                                }
                                break;
                            case ServiceType.UseL4R:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsUseL4RActive = true;
                                }
                                else
                                {
                                    IsUseL4RActive = false;
                                }
                                break;
                            case ServiceType.Classifieds:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsClassifiedActive = true;
                                }
                                else
                                {
                                    IsClassifiedActive = false;
                                }
                                break;
                            case ServiceType.Auction:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsAuctionActive = true;
                                }
                                else
                                {
                                    IsAuctionActive = false;
                                }
                                break;
                            case ServiceType.Reviews:
                                if (Convert.ToInt32(drService["Status"]) == 1 && Convert.ToInt32(drService["PaymentStatus"]) == 2)
                                {
                                    IsReviewsActive = true;
                                }
                                else
                                {
                                    IsReviewsActive = false;
                                }
                                break;
                            default:
                                //nothing to do
                                break;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Please set resaurant id");
            }
        }
        #endregion
    }
}
