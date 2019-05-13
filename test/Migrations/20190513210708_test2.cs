using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_test_type_id_test_type",
                table: "test_type",
                column: "id_test_type");

            migrationBuilder.CreateIndex(
                name: "IX_subject_mark_id_subject_mark",
                table: "subject_mark",
                column: "id_subject_mark");

            migrationBuilder.CreateIndex(
                name: "IX_subject_id_subject",
                table: "subject",
                column: "id_subject");

            migrationBuilder.CreateIndex(
                name: "IX_speciality_id_speciality",
                table: "speciality",
                column: "id_speciality");

            migrationBuilder.CreateIndex(
                name: "IX_social_status_id_social_status",
                table: "social_status",
                column: "id_social_status");

            migrationBuilder.CreateIndex(
                name: "IX_social_background_id_social_background",
                table: "social_background",
                column: "id_social_background");

            migrationBuilder.CreateIndex(
                name: "IX_region_id_region",
                table: "region",
                column: "id_region");

            migrationBuilder.CreateIndex(
                name: "IX_reason_for_deduction_id_reason_for_deduction",
                table: "reason_for_deduction",
                column: "id_reason_for_deduction");

            migrationBuilder.CreateIndex(
                name: "IX_preemptive_right_id_preemptive_right",
                table: "preemptive_right",
                column: "id_preemptive_right");

            migrationBuilder.CreateIndex(
                name: "IX_parent_type_id_parent_type",
                table: "parent_type",
                column: "id_parent_type");

            migrationBuilder.CreateIndex(
                name: "IX_parent_id_parent",
                table: "parent",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "IX_nationality_id_nationality",
                table: "nationality",
                column: "id_nationality");

            migrationBuilder.CreateIndex(
                name: "IX_military_unit_id_military_unit",
                table: "military_unit",
                column: "id_military_unit");

            migrationBuilder.CreateIndex(
                name: "IX_military_service_category_id_category_ms",
                table: "military_service_category",
                column: "id_category_ms");

            migrationBuilder.CreateIndex(
                name: "IX_military_rank_id_military_rank",
                table: "military_rank",
                column: "id_military_rank");

            migrationBuilder.CreateIndex(
                name: "IX_military_office_id_military_office",
                table: "military_office",
                column: "id_military_office");

            migrationBuilder.CreateIndex(
                name: "IX_military_district_id_military_district",
                table: "military_district",
                column: "id_military_district");

            migrationBuilder.CreateIndex(
                name: "IX_marital_status_id_marital_status",
                table: "marital_status",
                column: "id_marital_status");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_id_group",
                table: "Groups",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_family_type_id_family_type",
                table: "family_type",
                column: "id_family_type");

            migrationBuilder.CreateIndex(
                name: "IX_family_IdFamily",
                table: "family",
                column: "IdFamily");

            migrationBuilder.CreateIndex(
                name: "IX_fact_of_prosecution_id_fact_of_prosecution",
                table: "fact_of_prosecution",
                column: "id_fact_of_prosecution");

            migrationBuilder.CreateIndex(
                name: "IX_exam_for_speciality_IdExamForSpeciality",
                table: "exam_for_speciality",
                column: "IdExamForSpeciality");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_exams_id_entrance_exam",
                table: "entrance_exams",
                column: "id_entrance_exam");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_documents_IdEnrolleeDocument",
                table: "enrollee_documents",
                column: "IdEnrolleeDocument");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_achievement_IdEnrolleeAchievement",
                table: "enrollee_achievement",
                column: "IdEnrolleeAchievement");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_arrival_date",
                table: "enrollee",
                column: "arrival_date");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_date_of_birth",
                table: "enrollee",
                column: "date_of_birth");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_date_of_deduction",
                table: "enrollee",
                column: "date_of_deduction");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_grade_point_AVG",
                table: "enrollee",
                column: "grade_point_AVG");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_enrollee",
                table: "enrollee",
                column: "id_enrollee");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_num_of_personal_file",
                table: "enrollee",
                column: "num_of_personal_file");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_surname",
                table: "enrollee",
                column: "surname");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_year_of_ending_education",
                table: "enrollee",
                column: "year_of_ending_education");

            migrationBuilder.CreateIndex(
                name: "IX_educational_institution_id_educational_institution",
                table: "educational_institution",
                column: "id_educational_institution");

            migrationBuilder.CreateIndex(
                name: "IX_education_type_id_education_type",
                table: "education_type",
                column: "id_education_type");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFile_id",
                table: "DocumentFile",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_document_id_document",
                table: "document",
                column: "id_document");

            migrationBuilder.CreateIndex(
                name: "IX_city_id_town",
                table: "city",
                column: "id_town");

            migrationBuilder.CreateIndex(
                name: "IX_change_history_id_change_history",
                table: "change_history",
                column: "id_change_history");

            migrationBuilder.CreateIndex(
                name: "IX_area_id_area",
                table: "area",
                column: "id_area");

            migrationBuilder.CreateIndex(
                name: "IX_application_to_speciality_IdApplicationToSpeciality",
                table: "application_to_speciality",
                column: "IdApplicationToSpeciality");

            migrationBuilder.CreateIndex(
                name: "IX_achievement_id_achievement",
                table: "achievement",
                column: "id_achievement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_test_type_id_test_type",
                table: "test_type");

            migrationBuilder.DropIndex(
                name: "IX_subject_mark_id_subject_mark",
                table: "subject_mark");

            migrationBuilder.DropIndex(
                name: "IX_subject_id_subject",
                table: "subject");

            migrationBuilder.DropIndex(
                name: "IX_speciality_id_speciality",
                table: "speciality");

            migrationBuilder.DropIndex(
                name: "IX_social_status_id_social_status",
                table: "social_status");

            migrationBuilder.DropIndex(
                name: "IX_social_background_id_social_background",
                table: "social_background");

            migrationBuilder.DropIndex(
                name: "IX_region_id_region",
                table: "region");

            migrationBuilder.DropIndex(
                name: "IX_reason_for_deduction_id_reason_for_deduction",
                table: "reason_for_deduction");

            migrationBuilder.DropIndex(
                name: "IX_preemptive_right_id_preemptive_right",
                table: "preemptive_right");

            migrationBuilder.DropIndex(
                name: "IX_parent_type_id_parent_type",
                table: "parent_type");

            migrationBuilder.DropIndex(
                name: "IX_parent_id_parent",
                table: "parent");

            migrationBuilder.DropIndex(
                name: "IX_nationality_id_nationality",
                table: "nationality");

            migrationBuilder.DropIndex(
                name: "IX_military_unit_id_military_unit",
                table: "military_unit");

            migrationBuilder.DropIndex(
                name: "IX_military_service_category_id_category_ms",
                table: "military_service_category");

            migrationBuilder.DropIndex(
                name: "IX_military_rank_id_military_rank",
                table: "military_rank");

            migrationBuilder.DropIndex(
                name: "IX_military_office_id_military_office",
                table: "military_office");

            migrationBuilder.DropIndex(
                name: "IX_military_district_id_military_district",
                table: "military_district");

            migrationBuilder.DropIndex(
                name: "IX_marital_status_id_marital_status",
                table: "marital_status");

            migrationBuilder.DropIndex(
                name: "IX_Groups_id_group",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_family_type_id_family_type",
                table: "family_type");

            migrationBuilder.DropIndex(
                name: "IX_family_IdFamily",
                table: "family");

            migrationBuilder.DropIndex(
                name: "IX_fact_of_prosecution_id_fact_of_prosecution",
                table: "fact_of_prosecution");

            migrationBuilder.DropIndex(
                name: "IX_exam_for_speciality_IdExamForSpeciality",
                table: "exam_for_speciality");

            migrationBuilder.DropIndex(
                name: "IX_entrance_exams_id_entrance_exam",
                table: "entrance_exams");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_documents_IdEnrolleeDocument",
                table: "enrollee_documents");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_achievement_IdEnrolleeAchievement",
                table: "enrollee_achievement");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_arrival_date",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_date_of_birth",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_date_of_deduction",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_grade_point_AVG",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_enrollee",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_num_of_personal_file",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_surname",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_year_of_ending_education",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_educational_institution_id_educational_institution",
                table: "educational_institution");

            migrationBuilder.DropIndex(
                name: "IX_education_type_id_education_type",
                table: "education_type");

            migrationBuilder.DropIndex(
                name: "IX_DocumentFile_id",
                table: "DocumentFile");

            migrationBuilder.DropIndex(
                name: "IX_document_id_document",
                table: "document");

            migrationBuilder.DropIndex(
                name: "IX_city_id_town",
                table: "city");

            migrationBuilder.DropIndex(
                name: "IX_change_history_id_change_history",
                table: "change_history");

            migrationBuilder.DropIndex(
                name: "IX_area_id_area",
                table: "area");

            migrationBuilder.DropIndex(
                name: "IX_application_to_speciality_IdApplicationToSpeciality",
                table: "application_to_speciality");

            migrationBuilder.DropIndex(
                name: "IX_achievement_id_achievement",
                table: "achievement");
        }
    }
}
