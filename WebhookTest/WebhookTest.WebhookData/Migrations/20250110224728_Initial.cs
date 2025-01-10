using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebhookTest.WebhookData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Event_Seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "EventData_Seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "EventGroup_Seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Webhook_Seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "WebhookHeader_Seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "WebhookState_Seq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Schema = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    SampleData = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "EventGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    WebhookStateId = table.Column<int>(type: "integer", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDatas_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Webhooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    MethodType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webhooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webhooks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebhookHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    WebhookId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    Value = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebhookHeaders_Webhooks_WebhookId",
                        column: x => x.WebhookId,
                        principalTable: "Webhooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebhookStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DeliveryStatus = table.Column<int>(type: "integer", nullable: false),
                    EventDataId = table.Column<int>(type: "integer", nullable: false),
                    WebhookId = table.Column<int>(type: "integer", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebhookStates_EventDatas_EventDataId",
                        column: x => x.EventDataId,
                        principalTable: "EventDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebhookStates_Webhooks_WebhookId",
                        column: x => x.WebhookId,
                        principalTable: "Webhooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDatas_EventId",
                table: "EventDatas",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_GroupId",
                table: "Events",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WebhookHeaders_WebhookId",
                table: "WebhookHeaders",
                column: "WebhookId");

            migrationBuilder.CreateIndex(
                name: "IX_Webhooks_EventId",
                table: "Webhooks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_WebhookStates_EventDataId",
                table: "WebhookStates",
                column: "EventDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebhookStates_WebhookId",
                table: "WebhookStates",
                column: "WebhookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebhookHeaders");

            migrationBuilder.DropTable(
                name: "WebhookStates");

            migrationBuilder.DropTable(
                name: "EventDatas");

            migrationBuilder.DropTable(
                name: "Webhooks");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventGroups");

            migrationBuilder.DropSequence(
                name: "Event_Seq");

            migrationBuilder.DropSequence(
                name: "EventData_Seq");

            migrationBuilder.DropSequence(
                name: "EventGroup_Seq");

            migrationBuilder.DropSequence(
                name: "Webhook_Seq");

            migrationBuilder.DropSequence(
                name: "WebhookHeader_Seq");

            migrationBuilder.DropSequence(
                name: "WebhookState_Seq");
        }
    }
}
