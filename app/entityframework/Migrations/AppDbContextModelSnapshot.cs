﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entityframework;

#nullable disable

namespace entityframework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");
                });

            modelBuilder.Entity("domain.Attendance", b =>
                {
                    b.Property<Guid>("SlotTimeTableAtWeekId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FeeDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsAttendance")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SlotTimeTableAtWeekId", "RoomId", "FeeDetailId");

                    b.HasIndex("FeeDetailId");

                    b.HasIndex("RoomId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("domain.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("domain.FeeDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentSemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentSemesterId");

                    b.HasIndex("SubjectId", "StudentSemesterId", "ClassId")
                        .IsUnique()
                        .HasFilter("[ClassId] IS NOT NULL");

                    b.ToTable("FeeDetails");
                });

            modelBuilder.Entity("domain.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MajorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MajorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("domain.MajorSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("MajorId", "SubjectId")
                        .IsUnique();

                    b.ToTable("MajorSubjects");
                });

            modelBuilder.Entity("domain.PaymentTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("BankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankTranNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FeeDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ResponseCode")
                        .HasColumnType("int");

                    b.Property<string>("SecureHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecureHashType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransactionNo")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<string>("TxnRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FeeDetailId")
                        .IsUnique();

                    b.HasIndex("TxnRef")
                        .IsUnique();

                    b.ToTable("PaymentTransactions");
                });

            modelBuilder.Entity("domain.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("domain.Score", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectComponentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectComponentID");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("domain.Semester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EndDay")
                        .HasColumnType("int");

                    b.Property<int>("EndMonth")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PrevSemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SemesterCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartDay")
                        .HasColumnType("int");

                    b.Property<int>("StartMonth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrevSemesterId")
                        .IsUnique()
                        .HasFilter("[PrevSemesterId] IS NOT NULL");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("domain.Slot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("SlotName")
                        .HasColumnType("int");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("domain.SlotTimeTableAtWeek", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimetableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WeekId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SlotId");

                    b.HasIndex("TimetableId");

                    b.HasIndex("WeekId");

                    b.ToTable("SlotTimeTableAtWeeks");
                });

            modelBuilder.Entity("domain.StudentSemester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsNow")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SemesterId", "StudentId")
                        .IsUnique();

                    b.ToTable("StudentSemesters");
                });

            modelBuilder.Entity("domain.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("domain.SubjectComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SubjectID");

                    b.ToTable("SubjectComponents");
                });

            modelBuilder.Entity("domain.Timetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WeekDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("domain.Week", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WeekName")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Weeks");
                });

            modelBuilder.Entity("domain.Student", b =>
                {
                    b.HasBaseType("domain.Account");

                    b.Property<Guid>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("MajorId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("domain.Teacher", b =>
                {
                    b.HasBaseType("domain.Account");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("domain.Attendance", b =>
                {
                    b.HasOne("domain.FeeDetail", "FeeDetail")
                        .WithMany("Attendances")
                        .HasForeignKey("FeeDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Room", "Room")
                        .WithMany("RoomAttendances")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.SlotTimeTableAtWeek", "SlotTimeTableAtWeek")
                        .WithMany("Attendances")
                        .HasForeignKey("SlotTimeTableAtWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeeDetail");

                    b.Navigation("Room");

                    b.Navigation("SlotTimeTableAtWeek");
                });

            modelBuilder.Entity("domain.Class", b =>
                {
                    b.HasOne("domain.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("domain.FeeDetail", b =>
                {
                    b.HasOne("domain.Class", "Class")
                        .WithMany("FeeDetails")
                        .HasForeignKey("ClassId");

                    b.HasOne("domain.StudentSemester", "StudentSemester")
                        .WithMany("FeeDetails")
                        .HasForeignKey("StudentSemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Subject", "Subject")
                        .WithMany("FeeDetails")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("StudentSemester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("domain.MajorSubject", b =>
                {
                    b.HasOne("domain.Major", "Major")
                        .WithMany("MajorSubjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Semester", "Semester")
                        .WithMany("MajorSubjects")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Subject", "Subject")
                        .WithMany("MajorSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("domain.PaymentTransaction", b =>
                {
                    b.HasOne("domain.FeeDetail", "FeeDetail")
                        .WithOne("PaymentTransaction")
                        .HasForeignKey("domain.PaymentTransaction", "FeeDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeeDetail");
                });

            modelBuilder.Entity("domain.Score", b =>
                {
                    b.HasOne("domain.Student", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.SubjectComponent", "SubjectComponent")
                        .WithMany("Scores")
                        .HasForeignKey("SubjectComponentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("SubjectComponent");
                });

            modelBuilder.Entity("domain.Semester", b =>
                {
                    b.HasOne("domain.Semester", "PrevSemester")
                        .WithOne("NextSemester")
                        .HasForeignKey("domain.Semester", "PrevSemesterId");

                    b.Navigation("PrevSemester");
                });

            modelBuilder.Entity("domain.SlotTimeTableAtWeek", b =>
                {
                    b.HasOne("domain.Slot", "Slot")
                        .WithMany("SlotTimeTableAtWeeks")
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Timetable", "Timetable")
                        .WithMany("SlotTimeTableAtWeeks")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Week", "Week")
                        .WithMany("SlotTimeTableAtWeeks")
                        .HasForeignKey("WeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("Timetable");

                    b.Navigation("Week");
                });

            modelBuilder.Entity("domain.StudentSemester", b =>
                {
                    b.HasOne("domain.Semester", "Semester")
                        .WithMany("StudentSemesters")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.Student", "Student")
                        .WithMany("StudentSemesters")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("domain.SubjectComponent", b =>
                {
                    b.HasOne("domain.Subject", "Subject")
                        .WithMany("SubjectComponents")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("domain.Student", b =>
                {
                    b.HasOne("domain.Major", "Major")
                        .WithMany("Students")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("domain.Class", b =>
                {
                    b.Navigation("FeeDetails");
                });

            modelBuilder.Entity("domain.FeeDetail", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("PaymentTransaction")
                        .IsRequired();
                });

            modelBuilder.Entity("domain.Major", b =>
                {
                    b.Navigation("MajorSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("domain.Room", b =>
                {
                    b.Navigation("RoomAttendances");
                });

            modelBuilder.Entity("domain.Semester", b =>
                {
                    b.Navigation("MajorSubjects");

                    b.Navigation("NextSemester");

                    b.Navigation("StudentSemesters");
                });

            modelBuilder.Entity("domain.Slot", b =>
                {
                    b.Navigation("SlotTimeTableAtWeeks");
                });

            modelBuilder.Entity("domain.SlotTimeTableAtWeek", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("domain.StudentSemester", b =>
                {
                    b.Navigation("FeeDetails");
                });

            modelBuilder.Entity("domain.Subject", b =>
                {
                    b.Navigation("FeeDetails");

                    b.Navigation("MajorSubjects");

                    b.Navigation("SubjectComponents");
                });

            modelBuilder.Entity("domain.SubjectComponent", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("domain.Timetable", b =>
                {
                    b.Navigation("SlotTimeTableAtWeeks");
                });

            modelBuilder.Entity("domain.Week", b =>
                {
                    b.Navigation("SlotTimeTableAtWeeks");
                });

            modelBuilder.Entity("domain.Student", b =>
                {
                    b.Navigation("Scores");

                    b.Navigation("StudentSemesters");
                });

            modelBuilder.Entity("domain.Teacher", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
