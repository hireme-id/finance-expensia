using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.DataAccess.Builders
{
    public class RolePermissionEntityBuilder : EntityBaseBuilder<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<RolePermission> builder)
        {
            //Initial Db
            builder
                .HasData(
                    new RolePermission { Id = new Guid("0cf91c77-4a12-4547-bac2-695d0f14741a"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("cfdceb82-2708-4dcc-a4e4-90aa76db8ea7"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("0af7a0a4-18a6-47a3-be87-d7cc4271e562"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("ce03fb46-2d4d-41d9-aa2a-7da429670bab"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("a2ffc228-87b1-4e14-a665-818e32c2996e"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("6659f17a-c52e-4ec3-847b-46866a3b2abf"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
                );

            //Untuk Role Requestor ea2fbce1-631a-4ea3-8076-f32933588f9f
            builder
                .HasData(
                    new RolePermission { Id = new Guid("aa8194b4-0d26-44ea-8815-b0c85d417484"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("ee541861-a2ff-444e-91bd-29d8c161259c"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("ff5cc455-3d81-4e75-98f5-a4f410b64b0d"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("fb802f18-ae08-43ab-9335-50fc2a1fb290"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("a47218fe-31af-4b4b-87db-ea1068b088df"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f9200a65-df2c-41da-bc81-e73987370c42"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("c419a69a-c778-4e75-913d-a369657fe572"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("7ca4f40d-b1d9-472f-9a91-0c7ec96422e0"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("93bb9a1f-4bff-4dd7-8707-13e9ed5d5dde"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("185db5f6-9fa7-48c6-97df-c2bf1d0709bc"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("6169bee2-f5cb-4a40-b4e5-b85c0b7861c1"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("d2ad9345-8d2a-4147-99e1-6cb714429d33"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("5df9b7c1-3bab-4390-afd8-603c53a06607"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("64518cb1-3dd4-49bb-8077-b0c2b64a6481"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("7dde3578-ef9d-4f05-8717-b1b035517a53"), RoleId = new Guid("ea2fbce1-631a-4ea3-8076-f32933588f9f"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
                );

            //Untuk Role Approval 87312c58-9961-4578-bd05-8e0f96aaeb7f
            builder
                .HasData(
                    new RolePermission { Id = new Guid("65ba5cdf-3cd2-485b-ad7c-79ce544212aa"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("15987858-8d59-49bc-b7ad-dec1e9dd3c83"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("b6e98a31-52ce-487a-9780-f0429ee627b1"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("106ebebf-7ed9-489c-ad28-eeeb49cf71a2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("8e799e9b-6170-4571-8250-3cd3db045f30"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("feceb717-e88d-41bf-86e9-4f3a3cad5cc8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("32b8bfee-7a97-4c23-a789-c97596b0d2cd"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("aaad754e-00d1-4ffe-a530-bce354eba9ed"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("88980ec1-7561-4aff-b105-65f7c29c391a"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("69a24b35-8eab-47a4-96e7-64e18bb2920a"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("bf8e70f8-1410-469d-a110-ac5e7ea7f870"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("92aec8f2-6899-4ad7-9d59-ee7a305b7032"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("f7e00cdd-64a2-43d1-8692-c22c72088e9e"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("9ff1a3b0-e198-4cb0-9f43-c52c22f04da2"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("3b322886-a0a5-4d4d-987a-747ddeadbe93"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("2705dd75-804e-4589-a895-7cabe2e3c6df"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("d5152d60-c9d7-4502-a71e-e0ccc9351df1"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("f601f0dc-ec56-4088-a637-95eea2372daa"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
					new RolePermission { Id = new Guid("ffbf7b43-7175-4d25-abb5-98fb5a7bce00"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("f0300010-c0df-4366-a9c3-994f3a3ad47f"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) },
                    new RolePermission { Id = new Guid("bb81ea29-c146-4eb1-b1ae-4c3e2f1f11b9"), RoleId = new Guid("87312c58-9961-4578-bd05-8e0f96aaeb7f"), PermissionId = new Guid("25de2280-2402-4b9a-ba71-d47174d85ff8"), Created = new DateTime(2024, 2, 25, 15, 15, 29, 23, DateTimeKind.Utc).AddTicks(3910) }
                );
        }
    }
}
