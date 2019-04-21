namespace HMS.Infrastructure
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affiliated_With",
                c => new
                    {
                        Physician = c.Int(nullable: false),
                        Department = c.Int(nullable: false),
                        PrimaryAffiliation = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.Physician, t.Department })
                .ForeignKey("dbo.Department", t => t.Department)
                .ForeignKey("dbo.Physician", t => t.Physician)
                .Index(t => t.Physician)
                .Index(t => t.Department);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Head = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Physician", t => t.Head)
                .Index(t => t.Head);
            
            CreateTable(
                "dbo.Physician",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        SSN = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false),
                        Patient = c.Int(nullable: false),
                        PrepNurse = c.Int(),
                        Physician = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        EndDateDate = c.DateTime(nullable: false),
                        ExaminationRoom = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Nurse", t => t.PrepNurse)
                .ForeignKey("dbo.Patient", t => t.Patient)
                .ForeignKey("dbo.Physician", t => t.Physician)
                .Index(t => t.Patient)
                .Index(t => t.PrepNurse)
                .Index(t => t.Physician);
            
            CreateTable(
                "dbo.Nurse",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        Registered = c.Boolean(nullable: false),
                        SSN = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Undergoes",
                c => new
                    {
                        Patient = c.Int(nullable: false),
                        Procedure = c.Int(nullable: false),
                        Stay = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Physician = c.Int(nullable: false),
                        AssistingNurse = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.Patient, t.Procedure, t.Stay, t.Date })
                .ForeignKey("dbo.Stay", t => t.Stay)
                .ForeignKey("dbo.Patient", t => t.Patient)
                .ForeignKey("dbo.Procedure", t => t.Procedure)
                .ForeignKey("dbo.Nurse", t => t.AssistingNurse)
                .ForeignKey("dbo.Physician", t => t.Physician)
                .Index(t => t.Patient)
                .Index(t => t.Procedure)
                .Index(t => t.Stay)
                .Index(t => t.Physician)
                .Index(t => t.AssistingNurse);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        SSN = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        InsuranceId = c.Int(nullable: false),
                        PCP = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.SSN)
                .ForeignKey("dbo.Physician", t => t.PCP)
                .Index(t => t.PCP);
            
            CreateTable(
                "dbo.Prescribes",
                c => new
                    {
                        Physician = c.Int(nullable: false),
                        Patient = c.Int(nullable: false),
                        Medication = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Appointment = c.Int(),
                        Dose = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.Physician, t.Patient, t.Medication, t.Date })
                .ForeignKey("dbo.Medication", t => t.Medication)
                .ForeignKey("dbo.Patient", t => t.Patient)
                .ForeignKey("dbo.Appointment", t => t.Appointment)
                .ForeignKey("dbo.Physician", t => t.Physician)
                .Index(t => t.Physician)
                .Index(t => t.Patient)
                .Index(t => t.Medication)
                .Index(t => t.Appointment);
            
            CreateTable(
                "dbo.Medication",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Stay",
                c => new
                    {
                        StayId = c.Int(nullable: false),
                        Patient = c.Int(nullable: false),
                        Room = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        EndDateDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.StayId)
                .ForeignKey("dbo.Room", t => t.Room)
                .ForeignKey("dbo.Patient", t => t.Patient)
                .Index(t => t.Patient)
                .Index(t => t.Room);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Number = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        BlockFloor = c.Int(nullable: false),
                        BlockCode = c.Int(nullable: false),
                        Unavailable = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Number);
            
            CreateTable(
                "dbo.Procedure",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Cost = c.Single(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Trained_In",
                c => new
                    {
                        Physician = c.Int(nullable: false),
                        Treatment = c.Int(nullable: false),
                        CertificationDate = c.DateTime(nullable: false),
                        CertificationExpires = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.Physician, t.Treatment })
                .ForeignKey("dbo.Procedure", t => t.Treatment)
                .ForeignKey("dbo.Physician", t => t.Physician)
                .Index(t => t.Physician)
                .Index(t => t.Treatment);
            
            CreateTable(
                "dbo.Block",
                c => new
                    {
                        Floor = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.Floor, t.Code });
            
            CreateTable(
                "dbo.On_Call",
                c => new
                    {
                        Nurse = c.Int(nullable: false),
                        BlockFloor = c.Int(nullable: false),
                        BlockCode = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.Nurse, t.BlockFloor, t.BlockCode, t.Start, t.End });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Undergoes", "Physician", "dbo.Physician");
            DropForeignKey("dbo.Trained_In", "Physician", "dbo.Physician");
            DropForeignKey("dbo.Prescribes", "Physician", "dbo.Physician");
            DropForeignKey("dbo.Patient", "PCP", "dbo.Physician");
            DropForeignKey("dbo.Department", "Head", "dbo.Physician");
            DropForeignKey("dbo.Appointment", "Physician", "dbo.Physician");
            DropForeignKey("dbo.Prescribes", "Appointment", "dbo.Appointment");
            DropForeignKey("dbo.Undergoes", "AssistingNurse", "dbo.Nurse");
            DropForeignKey("dbo.Undergoes", "Procedure", "dbo.Procedure");
            DropForeignKey("dbo.Trained_In", "Treatment", "dbo.Procedure");
            DropForeignKey("dbo.Undergoes", "Patient", "dbo.Patient");
            DropForeignKey("dbo.Stay", "Patient", "dbo.Patient");
            DropForeignKey("dbo.Undergoes", "Stay", "dbo.Stay");
            DropForeignKey("dbo.Stay", "Room", "dbo.Room");
            DropForeignKey("dbo.Prescribes", "Patient", "dbo.Patient");
            DropForeignKey("dbo.Prescribes", "Medication", "dbo.Medication");
            DropForeignKey("dbo.Appointment", "Patient", "dbo.Patient");
            DropForeignKey("dbo.Appointment", "PrepNurse", "dbo.Nurse");
            DropForeignKey("dbo.Affiliated_With", "Physician", "dbo.Physician");
            DropForeignKey("dbo.Affiliated_With", "Department", "dbo.Department");
            DropIndex("dbo.Trained_In", new[] { "Treatment" });
            DropIndex("dbo.Trained_In", new[] { "Physician" });
            DropIndex("dbo.Stay", new[] { "Room" });
            DropIndex("dbo.Stay", new[] { "Patient" });
            DropIndex("dbo.Prescribes", new[] { "Appointment" });
            DropIndex("dbo.Prescribes", new[] { "Medication" });
            DropIndex("dbo.Prescribes", new[] { "Patient" });
            DropIndex("dbo.Prescribes", new[] { "Physician" });
            DropIndex("dbo.Patient", new[] { "PCP" });
            DropIndex("dbo.Undergoes", new[] { "AssistingNurse" });
            DropIndex("dbo.Undergoes", new[] { "Physician" });
            DropIndex("dbo.Undergoes", new[] { "Stay" });
            DropIndex("dbo.Undergoes", new[] { "Procedure" });
            DropIndex("dbo.Undergoes", new[] { "Patient" });
            DropIndex("dbo.Appointment", new[] { "Physician" });
            DropIndex("dbo.Appointment", new[] { "PrepNurse" });
            DropIndex("dbo.Appointment", new[] { "Patient" });
            DropIndex("dbo.Department", new[] { "Head" });
            DropIndex("dbo.Affiliated_With", new[] { "Department" });
            DropIndex("dbo.Affiliated_With", new[] { "Physician" });
            DropTable("dbo.On_Call");
            DropTable("dbo.Block");
            DropTable("dbo.Trained_In");
            DropTable("dbo.Procedure");
            DropTable("dbo.Room");
            DropTable("dbo.Stay");
            DropTable("dbo.Medication");
            DropTable("dbo.Prescribes");
            DropTable("dbo.Patient");
            DropTable("dbo.Undergoes");
            DropTable("dbo.Nurse");
            DropTable("dbo.Appointment");
            DropTable("dbo.Physician");
            DropTable("dbo.Department");
            DropTable("dbo.Affiliated_With");
        }
    }
}
