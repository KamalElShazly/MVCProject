namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        Choice = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.Choice })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        CorrectAnswer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 5),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .Index(t => t.CourseCode);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                        LectureDuartion = c.Int(nullable: false),
                        LabDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Capacity = c.Int(nullable: false),
                        ManagerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BirthDate = c.DateTime(nullable: false),
                        IsMarried = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.InstructorCourseDepartments",
                c => new
                    {
                        InstructorId = c.String(nullable: false, maxLength: 128),
                        DepartmentId = c.Int(nullable: false),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                        CourseStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstructorId, t.DepartmentId, t.CourseCode })
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .Index(t => t.InstructorId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseCode);
            
            CreateTable(
                "dbo.OfficialVacations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StudentAttendences",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ArrivalTime = c.DateTime(nullable: false),
                        LeavingTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Date, t.StudentId })
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ExamId = c.Int(nullable: false),
                        ExamGrade = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.ExamId })
                .ForeignKey("dbo.Exam", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.StudentInstructorCourses",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        InstructorId = c.String(nullable: false, maxLength: 128),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                        InstructorEvaluation = c.Int(nullable: false),
                        LabGrade = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.InstructorId, t.CourseCode })
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.InstructorId)
                .Index(t => t.CourseCode);
            
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_Id = c.Int(nullable: false),
                        Course_Code = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.Department_Id, t.Course_Code })
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Code, cascadeDelete: true)
                .Index(t => t.Department_Id)
                .Index(t => t.Course_Code);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.String(nullable: false, maxLength: 128),
                        Course_Code = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Code })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Code, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Code);
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        Exam_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exam_Id, t.Question_Id })
                .ForeignKey("dbo.Exam", t => t.Exam_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Exam_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        GraduationYear = c.DateTime(nullable: false),
                        Qualification = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.Id)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Instructors", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Instructors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentInstructorCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentInstructorCourses", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.StudentInstructorCourses", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.StudentExams", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentExams", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.StudentAttendences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Permission", "StudentId", "dbo.Students");
            DropForeignKey("dbo.InstructorCourseDepartments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourseDepartments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.InstructorCourseDepartments", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ExamQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.ExamQuestions", "Exam_Id", "dbo.Exam");
            DropForeignKey("dbo.Exam", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Departments", "ManagerId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_Code", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.DepartmentCourses", "Course_Code", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Instructors", new[] { "DepartmentId" });
            DropIndex("dbo.Instructors", new[] { "Id" });
            DropIndex("dbo.ExamQuestions", new[] { "Question_Id" });
            DropIndex("dbo.ExamQuestions", new[] { "Exam_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Course_Code" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropIndex("dbo.DepartmentCourses", new[] { "Course_Code" });
            DropIndex("dbo.DepartmentCourses", new[] { "Department_Id" });
            DropIndex("dbo.StudentInstructorCourses", new[] { "CourseCode" });
            DropIndex("dbo.StudentInstructorCourses", new[] { "InstructorId" });
            DropIndex("dbo.StudentInstructorCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentExams", new[] { "ExamId" });
            DropIndex("dbo.StudentExams", new[] { "StudentId" });
            DropIndex("dbo.StudentAttendences", new[] { "StudentId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Permission", new[] { "StudentId" });
            DropIndex("dbo.InstructorCourseDepartments", new[] { "CourseCode" });
            DropIndex("dbo.InstructorCourseDepartments", new[] { "DepartmentId" });
            DropIndex("dbo.InstructorCourseDepartments", new[] { "InstructorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Departments", new[] { "ManagerId" });
            DropIndex("dbo.Exam", new[] { "CourseCode" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.Students");
            DropTable("dbo.Instructors");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.DepartmentCourses");
            DropTable("dbo.StudentInstructorCourses");
            DropTable("dbo.StudentExams");
            DropTable("dbo.StudentAttendences");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Permission");
            DropTable("dbo.OfficialVacations");
            DropTable("dbo.InstructorCourseDepartments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Exam");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
