namespace Finance.Expensia.Shared.Constants
{
    public static class PermissionConstants
    {
        //Use for JWT Token Key Value
        public const string TypeCode = "Permission";

        public const string SuperPermission = "Administrator";
        public const string RefreshToken = "RefreshToken";
        public const string MyPermission = "MyPermission";

        public static class OutgoingPayment
        {
            public const string OutgoingPaymentViewMyDocument = "OutgoingPayment.View.MyDocument";
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

        public static class MasterData
        {
            public const string CompanyView = "MasterData.Company.View";
			public const string CoaView = "MasterData.CoA.View";
            public const string TransactionTypeView = "MasterData.TransactionType.View";

            public static class Partner
            {
                public const string PartnerView = "MasterData.Partner.View";
                public const string PartnerUpsert = "MasterData.Partner.Upsert";
                public const string PartnerDelete = "MasterData.Partner.Delete";
            }

            public static class BankAlias
            {
                public const string BankAliasView = "MasterData.BankAlias.View";
                public const string BankAliasUpsert = "MasterData.BankAlias.Upsert";
                public const string BankAliasDelete = "MasterData.BankAlias.Delete";
            }

            public static class CostCenter
            {
                public const string CostCenterView = "MasterData.CostCenter.View";
                public const string CostCenterUpsert = "MasterData.CostCenter.Upsert";
                public const string CostCenterDelete = "MasterData.CostCenter.Delete";
            }
        }

        public static class Storage
        {
            public const string StorageUpload = "Storage.Upload";
			public const string StorageDownload = "Storage.Download";
		}

        public static class WorkflowHistory
        {
            public const string WorkflowHistoryView = "WorkflowHistory.View";
        }
    }
}
