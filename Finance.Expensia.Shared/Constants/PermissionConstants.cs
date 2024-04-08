namespace Finance.Expensia.Shared.Constants
{
    public static class PermissionConstants
    {
        public const string TypeCode = "Permission";
        public const string SuperPermission = "Administrator";
        public const string RefreshToken = "RefreshToken";
        public const string MyPermission = "MyPermission";

        public static class OutgoingPayment
        {
            public const string OutgoingPaymentView = "OutgoingPayment.View";
            public const string OutgoingPaymentUpsert = "OutgoingPayment.Upsert";
            public const string OutgoingPaymentDelete = "OutgoingPayment.Delete";
        }

        public static class ApprovalInbox
        {
            public const string ApprovalInboxView = "ApprovalInbox.View";
            public const string ApprovalInboxUpdate = "ApprovalInbox.Update";
            public const string ApprovalInboxDelete = "ApprovalInbox.Delete";
        }

        #region example
        //public static class General
        //{
        //    public const string ViewResourceFile = "General.ViewResourceFile";
        //}

        //public static class UserManagement
        //{
        //    public const string ViewUser = "UserManagement.ViewUser";
        //    public const string UpsertUser = "UserManagement.UpsertUser";
        //    public const string DeleteUser = "UserManagement.DeleteUser";

        //    public const string SaveMember = "UserManagement.SaveMember";
        //    public const string ViewListMember = "UserManagement.ViewListMember";
        //    public const string ViewDetailMember = "UserManagement.ViewDetailMember";
        //    public const string DeleteMember = "UserManagement.DeleteMember";

        //    public const string UpdateProfilePicture = "UserManagement.UpdateProfilePicture";
        //}

        //public static class MasterData
        //{
        //    #region Venue
        //    public const string MasterDataVenueView = "MasterData.Venue.View";
        //    public const string MasterDataVenueUpsert = "MasterData.Venue.Upsert";
        //    public const string MasterDataVenueDelete = "MasterData.Venue.Delete";

        //    public const string MasterDataTournamentView = "MasterData.Tournament.View";
        //    public const string MasterDataTournamentUpsert = "MasterData.Tournament.Upsert";
        //    public const string MasterDataTournamentDelete = "MasterData.Tournament.Delete";
        //    #endregion
        //}
        #endregion
    }
}
