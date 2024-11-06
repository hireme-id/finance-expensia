using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance.Expensia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialEffectiveTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EffectiveTaxCategoryAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NonTaxableIncome = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EffectiveTaxCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectiveTaxCategoryAssignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EffectiveTaxRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveTaxCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IncomeLowerLimit = table.Column<int>(type: "int", nullable: false),
                    IncomeUpperLimit = table.Column<int>(type: "int", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectiveTaxRates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EffectiveTaxCategoryAssignments",
                columns: new[] { "Id", "Created", "CreatedBy", "EffectiveTaxCategory", "Modified", "ModifiedBy", "NonTaxableIncome", "RowStatus" },
                values: new object[,]
                {
                    { new Guid("00637935-bfea-4604-ad8a-843f5b0c8c53"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", null, null, "K3", 0 },
                    { new Guid("3537701a-9ad0-4054-8df6-68c1d899890c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", null, null, "TK0", 0 },
                    { new Guid("47952a3f-5971-4de1-967e-7e3dfff8f2ba"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", null, null, "K0", 0 },
                    { new Guid("62dbf9f5-fef0-4b0e-b0cb-38053f1508ce"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", null, null, "TK2", 0 },
                    { new Guid("80b13c4e-355a-489b-8157-1931e63c15a1"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", null, null, "TK1", 0 },
                    { new Guid("a8f900c0-1a38-4a24-a45b-9f7aa630074a"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", null, null, "K1", 0 },
                    { new Guid("b1d7a3bf-3548-4ba7-8e0b-a98a1d712a29"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", null, null, "K2", 0 },
                    { new Guid("c69d1233-797a-4ddf-8dd7-e56f7b8ad781"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", null, null, "TK3", 0 }
                });

            migrationBuilder.InsertData(
                table: "EffectiveTaxRates",
                columns: new[] { "Id", "Created", "CreatedBy", "EffectiveTaxCategory", "IncomeLowerLimit", "IncomeUpperLimit", "Modified", "ModifiedBy", "RowStatus", "TaxRate" },
                values: new object[,]
                {
                    { new Guid("0079b782-d04b-423f-987a-f9c166f76b79"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 5650001, 5950000, null, null, 0, 0.005m },
                    { new Guid("01e2241c-b5c1-466b-8adc-1a638fd8080c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 56300001, 62200000, null, null, 0, 0.2m },
                    { new Guid("0209d927-ff4c-4bee-998a-523ee064c15d"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 390000001, 463000000, null, null, 0, 0.29m },
                    { new Guid("03d0eca0-4747-4f87-980c-83b71d1d3b7e"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 32600001, 35400000, null, null, 0, 0.13m },
                    { new Guid("04412963-8395-4651-be06-2b956f10e83e"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 53800001, 58500000, null, null, 0, 0.19m },
                    { new Guid("08ff3cf4-495e-47f8-8aeb-1bedf7e3c677"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 463000001, 561000000, null, null, 0, 0.3m },
                    { new Guid("0993e2d3-4067-4259-80c4-bd269da09697"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 51400001, 56300000, null, null, 0, 0.19m },
                    { new Guid("0e0a7c16-c179-4afb-b354-9acb69b0a144"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 39100001, 43850000, null, null, 0, 0.16m },
                    { new Guid("13a07dd1-eb15-4fef-bcf1-19282325ae0d"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 9800001, 10950000, null, null, 0, 0.015m },
                    { new Guid("14211ff7-93e3-494e-b6a2-d8da7884a21c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 28000001, 30050000, null, null, 0, 0.12m },
                    { new Guid("146e19f4-42d1-4754-93e9-00a6e30b632c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 6300001, 6750000, null, null, 0, 0.01m },
                    { new Guid("178eef98-5e48-4386-851e-0d9a8871011c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 11600001, 12600000, null, null, 0, 0.03m },
                    { new Guid("197bef48-37df-41a8-a190-3995fa9d5397"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 80000001, 93000000, null, null, 0, 0.23m },
                    { new Guid("1a9f2ffe-ca60-46d8-b009-8b10d825f0fe"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 47400001, 51200000, null, null, 0, 0.17m },
                    { new Guid("206549f1-76a0-4fd7-b770-26caa55daf70"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 13750001, 15100000, null, null, 0, 0.06m },
                    { new Guid("208c8c9f-4a77-42cb-9b33-1de79ef9fee2"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 11050001, 11600000, null, null, 0, 0.035m },
                    { new Guid("2503adcd-0960-4eb4-83a3-31c9395ad3fb"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 26450001, 28000000, null, null, 0, 0.11m },
                    { new Guid("26c3d878-97c7-4b1e-a74d-a98b2ec819fa"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 1419000001, null, null, null, 0, 0.34m },
                    { new Guid("29480d23-200e-41b4-aaac-4b08f54b30c1"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 6750001, 7500000, null, null, 0, 0.0125m },
                    { new Guid("2b18b2c5-6698-4338-89b4-c73747bb2731"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 12500001, 13750000, null, null, 0, 0.05m },
                    { new Guid("2b5314a2-8986-4a5c-966b-6d72e6f0b871"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 17050001, 19500000, null, null, 0, 0.07m },
                    { new Guid("2bb7ffd1-bb25-4117-9df4-56c445cefe38"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 709000001, 965000000, null, null, 0, 0.32m },
                    { new Guid("2cae93af-b547-461d-8351-a42b6e78e622"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 7500001, 8550000, null, null, 0, 0.015m },
                    { new Guid("2da04a6c-d36a-4e73-80d8-604a17fafaa3"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 35400001, 39100000, null, null, 0, 0.15m },
                    { new Guid("30c118dd-d177-4339-a5c5-4ad082e57233"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 83200001, 95600000, null, null, 0, 0.23m },
                    { new Guid("33935b86-ff47-488a-a76e-145a8c043167"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 157000001, 206000000, null, null, 0, 0.27m },
                    { new Guid("33d957b6-3c3e-4fed-8aa0-3b01d8f22104"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 74500001, 83200000, null, null, 0, 0.22m },
                    { new Guid("348aa49c-d912-445d-ab07-86aadf3a65e4"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 35400001, 38900000, null, null, 0, 0.14m },
                    { new Guid("354c0cf4-e764-4aaf-b3b7-a97a8eb9df82"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 125000001, 157000000, null, null, 0, 0.26m },
                    { new Guid("35522292-c01f-4ac5-8f6f-f77fb7cf2cbc"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 6850001, 7300000, null, null, 0, 0.0075m },
                    { new Guid("35dce34c-3928-46ee-bd2a-8dc75a4da6db"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 5950001, 6300000, null, null, 0, 0.0075m },
                    { new Guid("3724ddc1-21b4-4c71-bf41-060edae98c8f"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 37100001, 41100000, null, null, 0, 0.15m },
                    { new Guid("38fb6c63-7525-4d32-8d0c-01148c91fa06"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 109000001, 129000000, null, null, 0, 0.25m },
                    { new Guid("3bf4a3b2-99cb-4041-b1e2-e06981ec9de2"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 33950001, 37100000, null, null, 0, 0.14m },
                    { new Guid("3c2a22cb-a19f-499d-ae4f-7bd0d11cef3d"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 19500001, 22700000, null, null, 0, 0.08m },
                    { new Guid("3c466ecf-4512-4098-aaa2-247818bf2a11"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 60400001, 66700000, null, null, 0, 0.2m },
                    { new Guid("3f20976f-7b85-4a05-9788-957032516a74"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 206000001, 337000000, null, null, 0, 0.28m },
                    { new Guid("42fde7f8-d4ac-46fe-9a7b-0c59b236f195"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 27700001, 29350000, null, null, 0, 0.11m },
                    { new Guid("4631f638-1759-448d-a3e1-d63ff7e0fe9e"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 21850001, 26000000, null, null, 0, 0.09m },
                    { new Guid("4bb95595-92d6-441a-bcc4-38a3f9f17ff5"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 695000001, 910000000, null, null, 0, 0.32m },
                    { new Guid("4dd81af6-28ec-4ce4-8f4a-18adafcc4830"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 0, 5400000, null, null, 0, 0m },
                    { new Guid("547c341a-fbb2-4620-87d1-6f89023d0252"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 374000001, 459000000, null, null, 0, 0.29m },
                    { new Guid("55d3ccdb-bcf5-4694-aedc-688151719a0b"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 28100001, 30100000, null, null, 0, 0.11m },
                    { new Guid("568172b7-703f-4dbb-8011-fdd66c8b83b4"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 129000001, 163000000, null, null, 0, 0.26m },
                    { new Guid("57a295df-f56c-452d-9142-0e331df6dc63"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 43850001, 47800000, null, null, 0, 0.17m },
                    { new Guid("59cba89b-8b5b-4f8e-bea0-171e4185e25c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 10700001, 11050000, null, null, 0, 0.03m },
                    { new Guid("614ceed4-84d8-48d2-9b5d-1c76870a4d9d"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 68600001, 77500000, null, null, 0, 0.22m },
                    { new Guid("6171f2d7-fda5-4579-bc53-1d604e4daf9b"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 12050001, 12950000, null, null, 0, 0.03m },
                    { new Guid("6433283d-275a-4a51-842e-30a86b963c17"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 11600001, 12500000, null, null, 0, 0.04m },
                    { new Guid("65b0f9ef-facd-459b-9b3d-e5aeba0bf111"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 15100001, 16950000, null, null, 0, 0.07m },
                    { new Guid("686d7f85-233d-44bc-9fc8-102a480d2fa2"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 6950001, 7350000, null, null, 0, 0.005m },
                    { new Guid("697410da-416a-4534-b810-28a8dd58c8ab"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 51200001, 55800000, null, null, 0, 0.18m },
                    { new Guid("6aef5edd-26b2-4824-ae40-07c0038916a3"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 555000001, 704000000, null, null, 0, 0.31m },
                    { new Guid("6c4a7548-20d0-4aea-90fb-527525e860ab"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 0, 6200000, null, null, 0, 0m },
                    { new Guid("6c74fe15-4445-400a-b55c-df1aca09e563"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 6600001, 6950000, null, null, 0, 0.0025m },
                    { new Guid("6d58f395-e4ab-4774-ad38-ec68917de953"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 7800001, 8850000, null, null, 0, 0.01m },
                    { new Guid("6e77954f-bfe5-4fe6-8494-82becbcf85b4"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 62200001, 68600000, null, null, 0, 0.21m },
                    { new Guid("6e97174d-3424-42c4-a11f-5408318255ab"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 71000001, 80000000, null, null, 0, 0.22m },
                    { new Guid("6fed1fcf-8a01-456f-98fa-7fad7cda3383"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 89000001, 103000000, null, null, 0, 0.24m },
                    { new Guid("7230f4eb-5464-4b2d-8ac0-cde954716673"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 103000001, 125000000, null, null, 0, 0.25m },
                    { new Guid("73bde91e-61a9-4280-9ae3-4fdc89a6a624"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 22700001, 26600000, null, null, 0, 0.09m },
                    { new Guid("76eecd0d-8195-48c7-a16e-42aad098e324"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 221000001, 390000000, null, null, 0, 0.28m },
                    { new Guid("785e70e8-2cce-4ae3-a877-2232a5c7ff10"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 13600001, 14950000, null, null, 0, 0.05m },
                    { new Guid("7a08a7ac-2089-48a6-a705-fc8b0d1c83b3"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 910000001, 1400000000, null, null, 0, 0.33m },
                    { new Guid("7a27b02d-a889-44d5-ad5a-638de8855430"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 1400000001, null, null, null, 0, 0.34m },
                    { new Guid("7c64f95a-a0d9-49bc-bd32-8970006cd016"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 550000001, 695000000, null, null, 0, 0.31m },
                    { new Guid("825f0261-12c3-4ddc-a52b-b856498f6910"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 7350001, 7800000, null, null, 0, 0.0075m },
                    { new Guid("83bc523e-f25c-4db5-95bb-40b184714eba"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 12950001, 14150000, null, null, 0, 0.04m },
                    { new Guid("864cb2ad-ff49-42ab-8c20-4e075ecd4f6d"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 49500001, 53800000, null, null, 0, 0.18m },
                    { new Guid("8696108b-4682-4e1f-ad58-defba130d064"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 110000001, 134000000, null, null, 0, 0.25m },
                    { new Guid("87c1e21a-8ccf-48d5-9254-36869d0f854f"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 7300001, 9200000, null, null, 0, 0.01m },
                    { new Guid("8c10e32d-e829-4b38-a71c-d21f202bd176"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 11200001, 12050000, null, null, 0, 0.02m },
                    { new Guid("8f449f3b-60ff-423a-aec6-654581a7e4c8"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 66700001, 74500000, null, null, 0, 0.21m },
                    { new Guid("8fb92b88-af52-4618-903f-70aaaf4ffa46"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 32400001, 35400000, null, null, 0, 0.14m },
                    { new Guid("9081c458-ebb7-4bdf-b97a-01197b0366b6"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 5400001, 5650000, null, null, 0, 0.0025m },
                    { new Guid("908f0a9a-be80-4553-aa23-66252201f2f4"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 0, 6600000, null, null, 0, 0m },
                    { new Guid("913b7804-dbb9-40f1-a2d7-54e5e98e3efe"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 454000001, 550000000, null, null, 0, 0.3m },
                    { new Guid("92f284c9-0edd-472e-84ea-6e7555657594"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 8850001, 9800000, null, null, 0, 0.0125m },
                    { new Guid("935d8ce0-d1b8-4d59-9e32-d73623874ac7"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 10050001, 10350000, null, null, 0, 0.0225m },
                    { new Guid("94362f09-45e2-4374-89a2-175f04bdb1cc"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 6200001, 6500000, null, null, 0, 0.0025m },
                    { new Guid("957d9fed-945f-468d-bd3b-ba68cf1286f4"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 134000001, 169000000, null, null, 0, 0.26m },
                    { new Guid("99f6bde6-22f6-4f5f-98b9-27a05e93d2a7"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 459000001, 555000000, null, null, 0, 0.3m },
                    { new Guid("9f152339-7b0e-4f66-8d5d-dfe8e41fcfa1"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 16400001, 18450000, null, null, 0, 0.07m },
                    { new Guid("a076b02e-edbe-435d-aa6d-caae28708056"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 47800001, 51400000, null, null, 0, 0.18m },
                    { new Guid("a1388566-9b2d-42a1-97e3-2174a352de0b"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 41100001, 45800000, null, null, 0, 0.16m },
                    { new Guid("a3e03674-0ebd-4687-aaf7-46de245502a1"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 24150001, 26450000, null, null, 0, 0.1m },
                    { new Guid("a3e80c93-a10f-4b91-89bd-60f2bd134341"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 19750001, 24150000, null, null, 0, 0.09m },
                    { new Guid("a48d5b72-c3ca-46f8-8233-a6379f488410"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 31450001, 33950000, null, null, 0, 0.13m },
                    { new Guid("a908593d-7b51-4517-a84a-f131e7cfff77"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 26000001, 27700000, null, null, 0, 0.1m },
                    { new Guid("ad1caa2b-7479-4d72-a63a-5f5d5288d642"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 957000001, 1405000000, null, null, 0, 0.33m },
                    { new Guid("b0a0a4c5-41f9-42a0-ae88-93f43f748cd1"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 77500001, 89000000, null, null, 0, 0.23m },
                    { new Guid("b439ac29-05a0-4bd8-9749-745d1b71aeea"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 6500001, 6850000, null, null, 0, 0.005m },
                    { new Guid("c50977a8-a33a-4483-97a3-2dd6f597ec4f"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 11250001, 11600000, null, null, 0, 0.025m },
                    { new Guid("c620898f-b773-4c67-a7c1-070c33fe6ff4"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 16950001, 19750000, null, null, 0, 0.08m },
                    { new Guid("c6ec0c71-f0b2-49bc-b784-155b388995b7"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 30050001, 32400000, null, null, 0, 0.13m },
                    { new Guid("c761f5aa-b330-41da-a842-b822016c2c86"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 337000001, 454000000, null, null, 0, 0.29m },
                    { new Guid("c84231c9-70fe-46e6-ba03-fe748c3c54c0"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 93000001, 109000000, null, null, 0, 0.24m },
                    { new Guid("c894ff12-ceb3-4822-a4fa-0709d6d0eeb3"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 9200001, 10750000, null, null, 0, 0.015m },
                    { new Guid("ca167f5c-50c8-4340-a182-7c57bcc2814c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 38900001, 43000000, null, null, 0, 0.15m },
                    { new Guid("ca200ad4-ee16-4c74-a59e-4a3f0de96eac"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 64000001, 71000000, null, null, 0, 0.21m },
                    { new Guid("cb620770-919c-4807-bb79-e097991c5fdb"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 43000001, 47400000, null, null, 0, 0.16m },
                    { new Guid("cd051e24-ad97-4f48-ac5b-af29be1d46c8"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 55800001, 60400000, null, null, 0, 0.19m },
                    { new Guid("cd4a3f4c-17ae-4b34-a287-c9ec323be42b"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 12600001, 13600000, null, null, 0, 0.04m },
                    { new Guid("cd88fd37-c74b-4f63-9c0d-21a2621c1264"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 45800001, 49500000, null, null, 0, 0.17m },
                    { new Guid("d2359741-0197-4eb3-8239-3380ee73644a"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 29350001, 31450000, null, null, 0, 0.12m },
                    { new Guid("d44f36eb-b452-4643-8492-42564e071cfc"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 30100001, 32600000, null, null, 0, 0.12m },
                    { new Guid("d728406e-3170-4bbd-822e-4b02fd885b33"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 95600001, 110000000, null, null, 0, 0.24m },
                    { new Guid("d885fc6d-bcbd-4929-83f9-c29339d1b793"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 10950001, 11200000, null, null, 0, 0.0175m },
                    { new Guid("de8b3504-b285-43f1-b2c6-027b20588479"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 704000001, 957000000, null, null, 0, 0.32m },
                    { new Guid("dfef87f2-aaf1-4488-8284-11e2c798f3ba"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 169000001, 221000000, null, null, 0, 0.27m },
                    { new Guid("e492628e-63ba-45af-ac5f-26e870ec4cd3"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 9650001, 10050000, null, null, 0, 0.02m },
                    { new Guid("e4cf9a0a-50d4-487c-9787-175413731d9c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 163000001, 211000000, null, null, 0, 0.27m },
                    { new Guid("e5a904a9-41e0-40f6-b41e-c79b07b2d952"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 561000001, 709000000, null, null, 0, 0.31m },
                    { new Guid("e9b80adc-40ad-4d75-b7ee-5cc638b08ce9"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 8550001, 9650000, null, null, 0, 0.0175m },
                    { new Guid("ea3130eb-af54-42f0-a27c-3ca1f418675a"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 18450001, 21850000, null, null, 0, 0.08m },
                    { new Guid("ead9ad92-7886-4880-8f60-36662573ab68"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 26600001, 28100000, null, null, 0, 0.1m },
                    { new Guid("ee110b6e-f743-44ca-b823-7a3f35a5cc4f"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 15550001, 17050000, null, null, 0, 0.06m },
                    { new Guid("f55acbbb-3d9c-4196-a077-b5905184bd3b"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 58500001, 64000000, null, null, 0, 0.2m },
                    { new Guid("f569c607-b7af-412b-925a-e044a2238891"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 14950001, 16400000, null, null, 0, 0.06m },
                    { new Guid("f589b3ea-1ddc-4849-8f69-59e60a1c34f6"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 10750001, 11250000, null, null, 0, 0.02m },
                    { new Guid("f64ac1d0-0cf2-471a-8482-6651e87ec8f2"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 211000001, 374000000, null, null, 0, 0.28m },
                    { new Guid("f696f9ce-9e35-4c99-b952-f7b0146f4162"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "A", 10350001, 10700000, null, null, 0, 0.025m },
                    { new Guid("f9077b2c-c828-4a76-85cb-03425a6baa5c"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "B", 1405000001, null, null, null, 0, 0.34m },
                    { new Guid("fafe1fb1-7c06-422e-8935-25e205a8ef79"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 965000001, 1419000000, null, null, 0, 0.33m },
                    { new Guid("fb919d64-99e6-40a3-8c3e-bb5fd27687fa"), new DateTime(2024, 11, 6, 9, 33, 0, 0, DateTimeKind.Utc), "", "C", 14150001, 15550000, null, null, 0, 0.05m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EffectiveTaxCategoryAssignments_NonTaxableIncome_EffectiveTaxCategory",
                table: "EffectiveTaxCategoryAssignments",
                columns: new[] { "NonTaxableIncome", "EffectiveTaxCategory" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EffectiveTaxCategoryAssignments");

            migrationBuilder.DropTable(
                name: "EffectiveTaxRates");
        }
    }
}
