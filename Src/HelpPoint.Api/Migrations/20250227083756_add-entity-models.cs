using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpPoint.Api.Migrations
{
    /// <inheritdoc />
    public partial class addentitymodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Support");

            migrationBuilder.EnsureSchema(
                name: "Ticket");

            migrationBuilder.CreateTable(
                name: "EstadoSolicitudes",
                schema: "Support",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                schema: "Support",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<string>(type: "text", nullable: true),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Support",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketEstados",
                schema: "Ticket",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketEstados", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TicketPrioridades",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                schema: "Support",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                schema: "Support",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    MenuId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => new { x.RoleId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_RoleMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "Support",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                schema: "Support",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    UnidadId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalSchema: "Support",
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
                schema: "Support",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Prioridad = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    EstadoId = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaResolucion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmpleadoId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TokenVerificacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalSchema: "Support",
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SupportRequests_EstadoSolicitudes_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "Support",
                        principalTable: "EstadoSolicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OrdenEnTablero = table.Column<int>(type: "integer", nullable: true),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    EstadoId = table.Column<string>(type: "text", nullable: false),
                    PrioridadId = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SupportRequestId = table.Column<string>(type: "text", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_SupportRequests_SupportRequestId",
                        column: x => x.SupportRequestId,
                        principalSchema: "Support",
                        principalTable: "SupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketEstados_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "Ticket",
                        principalTable: "TicketEstados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketPrioridades_PrioridadId",
                        column: x => x.PrioridadId,
                        principalSchema: "Ticket",
                        principalTable: "TicketPrioridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TicketId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    TipoNotificacion = table.Column<string>(type: "text", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExitoEnvio = table.Column<bool>(type: "boolean", nullable: false),
                    Mensaje = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificaciones_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notificaciones_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Ticket",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketAsignaciones",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TicketId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TiempoEmpleadoMinutos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAsignaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAsignaciones_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Ticket",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketComentarios",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TicketId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Comentario = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketComentarios_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Ticket",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketHistorial",
                schema: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TicketId = table.Column<string>(type: "text", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CampoModificado = table.Column<string>(type: "text", nullable: true),
                    ValorAnterior = table.Column<string>(type: "text", nullable: true),
                    ValorNuevo = table.Column<string>(type: "text", nullable: true),
                    ChangedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketHistorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketHistorial_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Ticket",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTags",
                schema: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "text", nullable: false),
                    TagId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTags", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_TicketTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "Ticket",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketTags_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Ticket",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UnidadId",
                schema: "Support",
                table: "Empleados",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                schema: "Support",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_TicketId",
                schema: "Ticket",
                table: "Notificaciones",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UserId",
                schema: "Ticket",
                table: "Notificaciones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_MenuId",
                schema: "Support",
                table: "RoleMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_EmpleadoId",
                schema: "Support",
                table: "SupportRequests",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_EstadoId",
                schema: "Support",
                table: "SupportRequests",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAsignaciones_TicketId",
                schema: "Ticket",
                table: "TicketAsignaciones",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComentarios_TicketId",
                schema: "Ticket",
                table: "TicketComentarios",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistorial_TicketId",
                schema: "Ticket",
                table: "TicketHistorial",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EstadoId",
                schema: "Ticket",
                table: "Tickets",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PrioridadId",
                schema: "Ticket",
                table: "Tickets",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SupportRequestId",
                schema: "Ticket",
                table: "Tickets",
                column: "SupportRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTags_TagId",
                schema: "Ticket",
                table: "TicketTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "RoleMenus",
                schema: "Support");

            migrationBuilder.DropTable(
                name: "TicketAsignaciones",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketComentarios",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketHistorial",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketTags",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "Support");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "SupportRequests",
                schema: "Support");

            migrationBuilder.DropTable(
                name: "TicketEstados",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketPrioridades",
                schema: "Ticket");

            migrationBuilder.DropTable(
                name: "Empleados",
                schema: "Support");

            migrationBuilder.DropTable(
                name: "EstadoSolicitudes",
                schema: "Support");

            migrationBuilder.DropTable(
                name: "Unidades",
                schema: "Support");
        }
    }
}
