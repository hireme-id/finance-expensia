﻿namespace Finance.Expensia.Shared.Constants
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
            public const string ApprovalEditInformation = "ApprovalInbox.EditInformation"; // Edit Expected Transfer, Scheduled Date, From Bank Alias, Bank Payment Type
            public const string ApprovalEditCoA = "ApprovalInbox.EditCoA"; //Edit CoA & Cost Center
        }

        public static class MasterData
        {
            public const string CompanyView = "MasterData.Company.View";
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

            public static class Coa
            {
                public const string CoaView = "MasterData.Coa.View";
                public const string CoaUpsert = "MasterData.Coa.Upsert";
                public const string CoaDelete = "MasterData.Coa.Delete";
            }

            public static class Tax
            {
                public const string EffectiveTaxView = "MasterData.EffectiveTax.View";
                public const string EffectiveTaxUpdate = "MasterData.EffectiveTax.Update";
            }

            public static class CostComponent
            {
                public const string CostComponentView = "MasterData.CostComponent.View";
                public const string CostComponentUpsert = "MasterData.CostComponent.Upsert";
            }

            public static class Recruiter
            {
                public const string RecruiterView = "MasterData.Recruiter.View";
                public const string RecruiterUpsert = "MasterData.Recruiter.Upsert";
            }
        }

        public static class Rule
        {
            public const string ApprovalRuleView = "ApprovalRule.View";
            public const string ApprovalRuleUpsert = "ApprovalRule.Upsert";
            public const string ApprovalRuleDelete = "ApprovalRule.Delete";
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

        public static class UserManagement
        {
            public static class ManageRole
            {
                public const string RoleView = "UserManagement.Role.View";
                public const string RoleUpdate = "UserManagement.Role.Update";
            }

            public static class ManageUser
            {
				public const string ManageUserView = "UserManagement.ManageUser.View";
				public const string ManageUserUpdate = "UserManagement.ManageUser.Update";
			}
        }

        public static class Employee
        {
            public const string EmployeeView = "Employee:View";

            public static class EmployeeCost
            {
                public const string EmployeeCostCreate = "Employee:Cost:Create";
				public const string EmployeeCostUpdate = "Employee:Cost:Update";
				public const string EmployeeCostDelete = "Employee:Cost:Delete";
				public const string EmployeeCostView = "Employee:Cost:View";
			}
        }
    }
}
