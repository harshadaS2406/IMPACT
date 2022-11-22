using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class patientserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AllergyDetails",
            //    columns: table => new
            //    {
            //        AllergyDetailsId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AllergyId = table.Column<string>(nullable: true),
            //        AllergyType = table.Column<string>(nullable: true),
            //        AllergyName = table.Column<string>(nullable: true),
            //        AllergyDescription = table.Column<string>(nullable: true),
            //        AllergyClinicalInformation = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AllergyDetails", x => x.AllergyDetailsId);
            //    });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    VisitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitTitle = table.Column<string>(nullable: true),
                    VisitDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.VisitId);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisDetails",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisCode = table.Column<string>(nullable: true),
                    DiagnosisDescription = table.Column<string>(nullable: true),
                    DiagnosisIsDepricated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisDetails", x => x.DiagnosisId);
                });

            migrationBuilder.CreateTable(
                name: "DrugDataDetails",
                columns: table => new
                {
                    DrugId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(nullable: true),
                    DrugGenericName = table.Column<string>(nullable: true),
                    DrugManufactureName = table.Column<string>(nullable: true),
                    DrugForm = table.Column<string>(nullable: true),
                    DrugStrength = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDataDetails", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "PatientEmergencyContacts",
                columns: table => new
                {
                    PatientEmergencyContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Contact = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    created_by = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEmergencyContacts", x => x.PatientEmergencyContactId);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureDetails",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureCode = table.Column<string>(nullable: true),
                    ProcedureDescription = table.Column<string>(nullable: true),
                    ProcedureIsDepricated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureDetails", x => x.ProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergyDetails",
                columns: table => new
                {
                    PatientAllergyDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    Allergyid = table.Column<int>(nullable: false),
                    Is_Allergy_Fatal = table.Column<bool>(nullable: false),
                    Allergy_Clinical_Information = table.Column<string>(nullable: true),
                    created_by = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergyDetails", x => x.PatientAllergyDetailsId);
                    table.ForeignKey(
                        name: "FK_PatientAllergyDetails_AllergyDetails_Allergyid",
                        column: x => x.Allergyid,
                        principalTable: "AllergyDetails",
                        principalColumn: "AllergyDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientVitals",
                columns: table => new
                {
                    VisitVitalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    BloodPressure = table.Column<string>(nullable: true),
                    BodyTemperature = table.Column<string>(nullable: true),
                    RespirationRate = table.Column<string>(nullable: true),
                    createdby = table.Column<int>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedby = table.Column<int>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVitals", x => x.VisitVitalId);
                    table.ForeignKey(
                        name: "FK_PatientVitals_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiagnosis",
                columns: table => new
                {
                    PatientDiagnosisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    createdby = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiagnosis", x => x.PatientDiagnosisId);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_DiagnosisDetails_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosisDetails",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedication",
                columns: table => new
                {
                    PatientMedicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    DrugId = table.Column<int>(nullable: false),
                    Dosage = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    createdby = table.Column<int>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedby = table.Column<int>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedication", x => x.PatientMedicationId);
                    table.ForeignKey(
                        name: "FK_PatientMedication_DrugDataDetails_DrugId",
                        column: x => x.DrugId,
                        principalTable: "DrugDataDetails",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedication_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientProcedures",
                columns: table => new
                {
                    PatientProceduresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    ProcedureId = table.Column<int>(nullable: false),
                    createdby = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProcedures", x => x.PatientProceduresId);
                    table.ForeignKey(
                        name: "FK_PatientProcedures_ProcedureDetails_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "ProcedureDetails",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProcedures_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergyDetails_Allergyid",
                table: "PatientAllergyDetails",
                column: "Allergyid");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_DiagnosisId",
                table: "PatientDiagnosis",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_VisitId",
                table: "PatientDiagnosis",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedication_DrugId",
                table: "PatientMedication",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedication_VisitId",
                table: "PatientMedication",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcedures_ProcedureId",
                table: "PatientProcedures",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcedures_VisitId",
                table: "PatientProcedures",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVitals_VisitId",
                table: "PatientVitals",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAllergyDetails");

            migrationBuilder.DropTable(
                name: "PatientDiagnosis");

            migrationBuilder.DropTable(
                name: "PatientEmergencyContacts");

            migrationBuilder.DropTable(
                name: "PatientMedication");

            migrationBuilder.DropTable(
                name: "PatientProcedures");

            migrationBuilder.DropTable(
                name: "PatientVitals");

            migrationBuilder.DropTable(
                name: "AllergyDetails");

            migrationBuilder.DropTable(
                name: "DiagnosisDetails");

            migrationBuilder.DropTable(
                name: "DrugDataDetails");

            migrationBuilder.DropTable(
                name: "ProcedureDetails");

            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
