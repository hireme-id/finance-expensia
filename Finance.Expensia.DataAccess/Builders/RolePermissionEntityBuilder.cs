using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Expensia.DataAccess.Builders
{
    public class RolePermissionEntityBuilder : EntityBaseBuilder<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);

            SeedingDataUser(builder);
            SeedingDataManager(builder);
            SeedingDataAccounting(builder);
            SeedingDataFinance(builder);
            SeedingDataApproval(builder);
            SeedingDataReleaser(builder);
            SeedingDataAdministrator(builder);
            SeedingDataRecruitment(builder);
            SeedingDataSales(builder);
            SeedingDataRecruitmentManager(builder);
        }

        private static void SeedingDataUser(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
            #region General
                    new RolePermission { Id = new Guid("0cf91c77-4a12-4547-bac2-695d0f14741a"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Master Data

            #region TransactionType
                    new RolePermission { Id = new Guid("cfdceb82-2708-4dcc-a4e4-90aa76db8ea7"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Company
                    new RolePermission { Id = new Guid("28fd8b9d-5c08-44ae-8afe-86b894338d48"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Partner
                    new RolePermission { Id = new Guid("1a940a3b-6a70-4b13-b7d1-30e381a20f41"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4b83a9eb-37ab-473a-8d3e-bd98d9935572"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("62b1ca6b-c264-4235-ba2e-a6573616ac55"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Bank Alias
                    new RolePermission { Id = new Guid("0788ad85-8bdb-41be-9f24-7aeada28ad48"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("2fc8ca59-f51a-4b84-b765-2018f4aadfe9"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("31e9150e-32b2-4008-b7ac-a4e21c172299"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Chart Of Account
                    new RolePermission { Id = new Guid("eca833e4-41c9-45df-be6e-c35deb4158ee"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Cost Center
                    new RolePermission { Id = new Guid("f7012478-4ad2-4c44-acfc-a10b7751f4cb"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("c5c9fd01-d6b2-45cf-bfc2-de6c3a670d56"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("540ccc89-364d-433a-b669-df92739a043c"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #endregion

            #region Outgoing Payment
                    new RolePermission { Id = new Guid("410300c9-e850-4e89-91ed-5784634c89c5"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f5de4a8f-3b4d-4269-869e-65d72e52acec"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("f51b33c8-66bf-4c47-aa88-37d3d0cf6e49"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("d705f02b-0722-4f20-82a7-4809dadc057c"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Storage
                    new RolePermission { Id = new Guid("f411eb8c-444d-42e9-8ca2-5bc435d57c22"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4f0844ea-07c7-458f-b8c1-b8335f088d47"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Workflow History
                    new RolePermission { Id = new Guid("ff38217b-2065-4681-a15e-e73c2168b45c"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
            #endregion
                );
        }

        private static void SeedingDataManager(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
            #region General
                    new RolePermission { Id = new Guid("0784623d-32be-4e31-828a-8327e4c1a9d5"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Master Data

            #region TransactionType
                    new RolePermission { Id = new Guid("06c8b43c-382e-4950-9402-24f318ff7c3b"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Company
                    new RolePermission { Id = new Guid("a4c5f7be-493d-41eb-b536-a41007dae586"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Partner
                    new RolePermission { Id = new Guid("58452848-e5a4-4046-85b5-db805cd5301f"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("ddfeae68-52f4-407c-8d69-29a797bbfef2"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("84269b73-fe6a-4415-a283-c61303aa8745"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Bank Alias
                    new RolePermission { Id = new Guid("b8b7ed16-2352-46c7-a2ab-500da10b5b58"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("6696ab3f-4bab-4d6c-a98a-036e141330da"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("736f8b24-0134-4542-a9b4-d5a60493fa8d"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Chart Of Account
                    new RolePermission { Id = new Guid("ca647ad1-c420-4751-9f76-aec5c17b84c4"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("6faadf01-b008-46ef-9717-aed9095c9fa2"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("43dd2d57-4ffe-481d-a3e9-63c5904b7b3a"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Cost Center
                    new RolePermission { Id = new Guid("d7187a9f-276c-4c3f-9317-cf8b3ac827d1"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("ad98ff8b-9937-4fe6-ab8e-006395fbc7c5"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("f96c2402-b849-4f58-9402-ad7152e5bcca"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #endregion

            #region Outgoing Payment
                    new RolePermission { Id = new Guid("77c8ad48-2e04-4c9d-a4af-79782938e524"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4886a602-3fe9-4800-9fcb-da58ef1e6809"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("cb3e65b5-8fba-441e-bca1-d6330b9e7f4f"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Approval Inbox
                    new RolePermission { Id = new Guid("86ae2438-2903-48ea-9a8a-43e9ea4bce02"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("5a55ebe6-846c-4016-ba06-d2e1dc1699d5"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("aca28653-eafe-4c21-8cbf-0737ae5e70d4"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Storage
                    new RolePermission { Id = new Guid("4bab6c42-a6f3-4772-91c0-23f5d7042799"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("01f894b4-d51f-4f03-a3bb-ee3161b98fc5"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Workflow History
                    new RolePermission { Id = new Guid("ff38217b-2065-4681-a15e-e73c2168b46c"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region User Management
                    new RolePermission { Id = new Guid("2907a99d-506a-488e-9c9a-78b227f48fb3"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
            #endregion
                );
        }

        private static void SeedingDataAccounting(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
            #region General
                    new RolePermission { Id = new Guid("be5729aa-1d7b-47af-9a49-8f908d019f93"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Master Data

            #region TransactionType
                    new RolePermission { Id = new Guid("16b2ba35-01fe-487a-8243-5aecb2c5191a"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Company
                    new RolePermission { Id = new Guid("362dced2-80e4-49a0-afdd-aa8d1b98796d"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Partner
                    new RolePermission { Id = new Guid("fbacdf5d-910c-4fcc-a5e7-77cf5da52bfb"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("9daa4329-5f35-445f-8253-2db8cb51ebd1"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("13c7aac7-ed97-46fe-8f8e-1f8e077dadef"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Bank Alias
                    new RolePermission { Id = new Guid("f79f5dfd-d136-47d4-a93e-f2683c8f2c9f"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4a0c33b8-8f21-4812-81a1-94e5bd980701"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("1e20220b-1dea-430f-8205-000f9c655df8"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Chart Of Account
                    new RolePermission { Id = new Guid("3d7f85b4-8ae0-45c0-b84f-ca8fd2540468"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("d77179f3-92d1-43a0-bb94-208413d6f4dc"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("6d9ba54f-9d4f-4212-a3bb-9bfe46fb509d"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Cost Center
                    new RolePermission { Id = new Guid("1112bef2-ec1a-437f-8fc9-b199998dc306"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("bce391a4-9e1f-4483-9499-1d1610de46ea"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("aa7d6bf4-54b1-4d25-ab18-b67f183bc84a"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #endregion

            #region Outgoing Payment
                    new RolePermission { Id = new Guid("54ba733c-8ad4-45f2-a552-f77e820b9333"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4a6d4c12-b870-4cd0-83d0-34997b992c5e"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("006469b5-1d6e-4ea2-ab2b-d09e87dedf7f"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Approval Inbox
                    new RolePermission { Id = new Guid("c2b544db-ae0c-49bf-b7aa-683f606355a9"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("7afd64c0-9b7f-4b70-a693-ab961fd7baa2"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("0671eba2-0fe3-4630-93ad-3fd9cdef88e7"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("bb588f4c-0862-4dcf-899a-ababc1c0010f"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("42cd2108-f0b2-46eb-8f0b-ff66948bc1e8"), Created = new DateTime(2024, 2, 10, 9, 39, 0, DateTimeKind.Utc) },
			#endregion

			#region Storage
					new RolePermission { Id = new Guid("e8645142-335a-49e3-a9c0-07df4bc6bf29"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("fa007a00-75d1-4621-bbca-5429f169d1bd"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Workflow History
                    new RolePermission { Id = new Guid("ff38217b-2065-4681-a15e-e73c2168b47c"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region User Management
                    new RolePermission { Id = new Guid("bf1b0281-2b32-444a-b794-80b5627a06f2"), RoleId = new Guid("a0ae025a-9d3a-405a-beb2-8e643078d5db"), PermissionId = new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
            #endregion
                );
        }

        private static void SeedingDataFinance(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
            #region General
                    new RolePermission { Id = new Guid("7244da8f-9cbe-4f69-94ef-2dfc81842448"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Master Data

            #region TransactionType
                    new RolePermission { Id = new Guid("a0761254-0ef5-48ad-9575-46c29883df81"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Company
                    new RolePermission { Id = new Guid("6257d112-274e-4d18-9f82-3c10475ffa5e"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Partner
                    new RolePermission { Id = new Guid("bc3cb899-7151-414a-b8ea-5c8150085872"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4f2e85c1-ed67-4db6-af99-31a9bbefff29"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("940bcf24-e6f9-42a6-9634-98ff2187ab63"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Bank Alias
                    new RolePermission { Id = new Guid("371fd68e-c05b-4e57-805c-96229450a876"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("cb999462-5e27-44df-816c-16ebe223a452"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("d3b25116-11c8-40c4-b616-5b7fc31bcc90"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Chart Of Account
                    new RolePermission { Id = new Guid("dcf19f3f-88d4-404b-b375-40c473c34262"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("1dfbb99d-2d48-4b09-a483-a2e9dd3636af"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("2821544e-5374-4599-b2a3-304510cf0881"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Cost Center
                    new RolePermission { Id = new Guid("137039ee-f533-4c24-aef8-95b36b6c288f"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("1ff0b99a-5815-4dfe-bd74-e3985818574c"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("1a66749f-6307-42bb-9aaf-33ef174f61a1"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #endregion

            #region Outgoing Payment
                    new RolePermission { Id = new Guid("aa698e3b-cb12-41f7-9e24-662061271fac"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("b723c0dd-35e3-4de0-87c4-372a5961c6d9"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("4313462a-9fd1-4505-b4b2-1d780f663944"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Approval Inbox
                    new RolePermission { Id = new Guid("4cbd8aea-22e7-40b1-b97b-5f202532ff33"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("3adb7b0d-840d-4c6f-941e-a74c5bfb92ac"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("3568bf3c-4f11-405f-8528-e587631ebcf0"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    // Tambahkan mapping permission untuk role Finance dan permission ApprovalEditInformation
                    new RolePermission { Id = new Guid("5ddb81a5-aad2-4c3b-b6a7-d7ab90f1f6b6"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("b7eafb34-d9e7-4cba-9378-8c54c0786dbf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Storage
                    new RolePermission { Id = new Guid("7ad32223-2898-4279-bd17-9391059eaa5a"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("b3c112bd-7623-4ce4-a2f4-c4ce82c179f2"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Workflow History
                    new RolePermission { Id = new Guid("ff38217b-2065-4681-a15e-e73c2168b48c"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region User Management
                    new RolePermission { Id = new Guid("e2479cc8-6a54-49b9-abb7-163edaf4107e"), RoleId = new Guid("9624f22a-c9a7-4603-b8d6-97aa22d285c6"), PermissionId = new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
            #endregion
                );
        }

        private static void SeedingDataApproval(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
            #region General
                    new RolePermission { Id = new Guid("70388a71-84d9-4e18-8400-ba4ca380e248"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Master Data

            #region TransactionType
                    new RolePermission { Id = new Guid("d1bc210b-6bdc-4b48-bdab-3d666154cb93"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Company
                    new RolePermission { Id = new Guid("547b5e24-de21-4038-a533-6ded0903ffd4"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Partner
                    new RolePermission { Id = new Guid("2b1ea671-b27a-4045-99da-1fe308b34bb8"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("8a587ca8-71b8-4ca9-9273-dde4a5c4233e"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("521a3605-d0dd-4a61-8d33-597abf74a020"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Bank Alias
                    new RolePermission { Id = new Guid("7a9744a0-af8e-40e7-a46d-eb6037a660b0"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("e27a289c-82bb-48ab-b4dd-11037a6fa81a"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("3bf40b59-4e8c-4cc9-ada6-a86f3a147d7b"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Chart Of Account
                    new RolePermission { Id = new Guid("0981bbec-4ccc-493d-b8d7-cec43a60052d"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("3e93125c-ff1d-4a27-83af-16cac3b9c3e3"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("152e0338-bc11-45c4-a425-908a35a5312f"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Cost Center
                    new RolePermission { Id = new Guid("87474c8e-b0cf-4cdb-8a08-9d999745456f"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("e4ac8a44-55da-41b8-9322-de69cc46e4ff"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("621c4acd-73a5-450b-bd4b-c4683a1288ca"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #endregion

            #region Outgoing Payment
                    new RolePermission { Id = new Guid("9c3f2c37-6370-4715-8d41-e5400179abc9"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("c47d55bf-76cf-4322-881c-5681b99e98ad"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("19a9aaaa-1d13-44fd-bca9-4d0f6fbb5ce7"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Approval Inbox
                    new RolePermission { Id = new Guid("6ac36468-5c20-4b30-afcf-c06bf03e82fb"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("f587b052-119d-4724-a73b-5221494188f3"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("04db5205-3241-4462-a6b7-811c54dd87e1"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Storage
                    new RolePermission { Id = new Guid("e70bb298-de35-4ca9-8685-3f4c5da03b70"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("db8e122a-9b5d-42fd-ad48-6dfbf5146e31"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Workflow History
                    new RolePermission { Id = new Guid("ff38217b-2065-4681-a15e-e73c2168b52c"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region User Management
                    new RolePermission { Id = new Guid("b5667fa6-102c-4d0e-94f8-58d330462dfa"), RoleId = new Guid("9844f544-63b9-402e-8916-40df21fefd7a"), PermissionId = new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
            #endregion
                );
        }

        private static void SeedingDataReleaser(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
            #region General
                    new RolePermission { Id = new Guid("28acf85a-a4b3-4ff5-af76-ec7d1ff6c930"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Master Data

            #region TransactionType
                    new RolePermission { Id = new Guid("9be46290-7e25-4163-89c0-4793d680e93c"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Company
                    new RolePermission { Id = new Guid("ae8d3e6c-34d4-4b31-9536-a3e7e0ab309d"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Partner
                    new RolePermission { Id = new Guid("28613711-95c9-490b-a604-7c3c6acb275d"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("c3e863ae-e737-4329-9847-c51cd2ce3c86"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("478abe04-1b12-47a0-acd9-885b15964923"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("7ca0d65c-e499-4435-83ff-0d7fd757276b"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("a250f1ad-ba83-4af4-a25e-fe5875e343aa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Bank Alias
                    new RolePermission { Id = new Guid("1229aeb9-ef23-4ef9-8e35-35b0f3ef725a"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("654a9db9-092d-49a0-8644-b7840afd2a39"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("217cf590-a6f7-4cc0-a8e0-530ecf36608a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("7f10467a-0246-4699-870b-2449fe366cb5"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("04cb64dd-0d9f-4471-9d3e-a57f6ede261d"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Chart Of Account
                    new RolePermission { Id = new Guid("9ae070fc-4bfa-4552-b823-87e24fb779d5"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("26a2442b-585d-4d36-9dfa-fbde38c0ead2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("71657cef-30c8-419b-a2ca-67c5e3ed8d66"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("5c3a6cd7-3d8c-48f8-b10b-0435379fd643"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("03e70ba0-1194-4246-8b1f-b848af304a37"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("6b73945c-6fa7-49ee-8c2c-8490b08236f9"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Cost Center
                    new RolePermission { Id = new Guid("d32a6742-7683-48d9-9511-a3c340da2536"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("6b410e73-fa1a-494e-8374-03cb4c2d82ae"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("7b50fa6f-5b76-4349-bbcc-86f9c974a4a8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("7a1cae33-3079-422d-8c69-c1244d0c62b0"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("e768a0ab-5210-4418-accd-d841f8283c7f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #endregion

            #region Outgoing Payment
                    new RolePermission { Id = new Guid("fe5104d3-1da2-4113-8dbc-af1f15fe4ee2"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("02add777-717e-4010-95a0-10dd046b2d89"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("f8ae3609-3b7d-4036-9f41-282ffd047dd3"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Approval Inbox
                    new RolePermission { Id = new Guid("a5a9df0a-1ba7-484a-9734-8db323cb89b0"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("29123cbb-0247-4899-98d8-c6e5d56f95c1"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("2a477cb3-90af-4011-b89e-392bdf2d5339"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Storage
                    new RolePermission { Id = new Guid("57a75c58-6938-470b-b3a4-90c57cee28b7"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("dbc7096e-dded-474b-b481-48d896a3e256"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region Workflow History
                    new RolePermission { Id = new Guid("ff38217b-2065-4681-a15e-e73c2168b53c"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("24c5e9ff-ebab-477f-8177-02a65fcc00fd"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
            #endregion

            #region User Management
                    new RolePermission { Id = new Guid("5af2ec99-2f5b-4551-9782-f206a8dfc2d7"), RoleId = new Guid("68d3a412-0b70-4144-ab7d-556bff726b83"), PermissionId = new Guid("31410ff2-6c2a-457d-bb50-a926d5f90396"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
            #endregion
                );
        }

        private static void SeedingDataAdministrator(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
					new RolePermission { Id = new Guid("b0093f1a-86c1-41af-978d-f33865390b51"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("a830d1d8-07af-46a7-bb51-ea157fe4f421"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("108aaa5e-c79d-4429-b140-fce72e1382e2"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("ed9a3de5-d557-46b1-9509-78fced8ad5c0"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
				);

            builder
                .HasData(
                    new RolePermission { Id = new Guid("20c92fe2-9927-4e30-a73a-fce6953bbf8b"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), Created = new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("47cdff05-a686-4af6-be30-7159a2a01c1c"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("f2c5ead1-3ea7-4206-b2dc-7790af360d75"), Created = new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910) }
                );

            builder
                .HasData(
                    new RolePermission { Id = new Guid("fe224692-bdc8-4f35-8c72-8744f22b4692"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("bf1d72af-698e-43fa-af9f-5fabd42743f2"), Created = new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("9a99df65-693d-4ff7-99f4-0976e764d0d6"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("dc97d84b-c194-4493-98c6-897f440e67a2"), Created = new DateTime(2024, 11, 6, 13, 58, 0, 0, DateTimeKind.Utc).AddTicks(3910) }
                );

			builder
				.HasData(
					new RolePermission { Id = new Guid("d4493d80-f8e7-4286-95d7-a4671bc49b53"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), Created = new DateTime(2025, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("ffb7bd5e-2918-4428-8cba-dc3a610159d9"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), Created = new DateTime(2024, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("38fde7bc-67c5-4caf-9603-9d261fefcf8a"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), Created = new DateTime(2025, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("031f512a-4e23-4cad-968d-5a541aab2f2d"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), Created = new DateTime(2024, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("8574ce80-16e8-4658-b3a1-3f2c34fe76a6"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), Created = new DateTime(2025, 1, 3, 15, 54, 0, 0, DateTimeKind.Utc).AddTicks(3910) }
				);

			builder
				.HasData(
					new RolePermission { Id = new Guid("fea959df-d33b-44c4-9bfd-2526c2221af2"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("5df851bf-17a7-42b8-b0eb-6517ab3a74d7"), Created = new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("64249430-e111-4eef-aaf2-2d7bbb0835fe"), RoleId = new Guid("9ffa21e8-f911-48ce-9c68-0ec6ba882302"), PermissionId = new Guid("909948bc-8af6-4a01-a3ce-307fd8a68bca"), Created = new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910) }
				);
		}

        private static void SeedingDataRecruitment(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
                    new RolePermission { Id = new Guid("bc182dae-181d-4336-849e-7d616dedba40"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("55b1508f-8035-4525-b583-6c6205a47e4a"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("06fde6cb-f28c-4ba8-b20f-583058f5971f"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("482a7b2c-84c7-463b-bdcc-af34f578e8dc"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("fffe808c-a842-4bee-b1d3-b4d8a0a7682d"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("6a29a4bb-6c1a-4f5e-a9da-6b5483f52a87"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("12d8ea62-e936-42ae-81c1-fe33182f2175"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("d2e14bb7-9fa7-49d9-9aed-5c8c8f7aae3d"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("26f9dfc3-6e9e-4730-aa64-c770a73df603"), RoleId = new Guid("e07eb061-6a5d-4360-b6d6-c5dbeb82f074"), PermissionId = new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) }
				);
        }

        private static void SeedingDataSales(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasData(
                    new RolePermission { Id = new Guid("f242f6d1-a140-4368-8cd2-7d0940f1daf8"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("b621b344-7a61-4ae9-898f-7c060cf17641"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("fd3da1d3-eff8-4084-a95a-1f0cfde74dd9"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("69e719a7-fb8b-4593-8983-81a9b328814d"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("7b42a768-2c00-4811-897e-a2de728b10b2"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("2d86e5ba-4862-482c-a5aa-57f854d9d146"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("3a229f69-00ad-4b9d-af75-13a0dd248a76"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("4bea6378-af27-43a8-bf6d-1881b25c71c1"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
                    new RolePermission { Id = new Guid("47f44eeb-d741-4a4f-b6cb-2421b8931fb0"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("a9901d48-f80f-492d-bd21-fd3414f855b1"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("b33ca67e-b746-400f-b096-990e824867b0"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("012fcaa6-e54f-49ed-9bce-2a3ced131b31"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("ae8812b7-6490-4a13-aa05-62a57af0dc16"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) },
					new RolePermission { Id = new Guid("a9280e1c-9f6a-4fd4-9849-eb2e2d3f19f5"), RoleId = new Guid("2a0b91c6-7242-4fbb-a7a4-60e5bc9bd9cf"), PermissionId = new Guid("923d83d4-cd5d-4049-8371-a6313a101094"), Created = new DateTime(2025, 1, 9, 11, 02, 0, 0, DateTimeKind.Utc) }
				);
        }

        private static void SeedingDataRecruitmentManager(EntityTypeBuilder<RolePermission> builder)
        {
			builder
				.HasData(
					new RolePermission { Id = new Guid("c817996b-3756-4252-a18d-1e44375f06d9"), RoleId = new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"), PermissionId = new Guid("5df851bf-17a7-42b8-b0eb-6517ab3a74d7"), Created = new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("f0b1feb7-bf6b-4f08-ac01-d692ca2edfdc"), RoleId = new Guid("319302b3-3935-4355-97b0-8c1cd2d7798d"), PermissionId = new Guid("909948bc-8af6-4a01-a3ce-307fd8a68bca"), Created = new DateTime(2025, 2, 10, 15, 37, 0, 0, DateTimeKind.Utc).AddTicks(3910) }
				);
		}

	}
}
