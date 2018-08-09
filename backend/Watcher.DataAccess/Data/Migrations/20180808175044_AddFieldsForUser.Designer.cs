﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Watcher.DataAccess.Data;

namespace Watcher.DataAccess.Data.Migrations
{
    [DbContext(typeof(WatcherDbContext))]
    [Migration("20180808175044_AddFieldsForUser")]
    partial class AddFieldsForUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Watcher.DataAccess.Entities.Chart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DashboardId");

                    b.Property<string>("MostLoaded");

                    b.Property<string>("ShowCommon");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<int>("Threshold");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OrganizationId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OrganizationId")
                        .IsUnique()
                        .HasFilter("[OrganizationId] IS NOT NULL");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Dashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("InstanceId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("InstanceId");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("ResponseId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Instance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("OrganizationId");

                    b.Property<string>("Platform")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Instances");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.Property<bool>("WasRead");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("NotificationSettingId");

                    b.Property<int?>("OrganizationId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NotificationSettingId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.NotificationSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDisable");

                    b.Property<bool>("IsMute");

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("NotificationSettings");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ThemeId");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("FeedbackId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SampleField");

                    b.HasKey("Id");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundColor");

                    b.Property<string>("FontFamily");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Bio");

                    b.Property<int>("ChhosedOrganizationId");

                    b.Property<int?>("ChoosedOrganizationId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("NickName");

                    b.Property<int>("RoleId");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("ChoosedOrganizationId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.UserOrganization", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("OrganizationId");

                    b.HasKey("UserId", "OrganizationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("UserOrganizations");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Chart", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Dashboard", "Dashboard")
                        .WithMany("Charts")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Chat", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.User", "CreatedBy")
                        .WithMany("CreatedChats")
                        .HasForeignKey("CreatedById");

                    b.HasOne("Watcher.DataAccess.Entities.Organization", "Organization")
                        .WithOne("Chat")
                        .HasForeignKey("Watcher.DataAccess.Entities.Chat", "OrganizationId");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Dashboard", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Instance", "Instance")
                        .WithMany("Dashboards")
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Feedback", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Instance", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Organization", "Organization")
                        .WithMany("Instances")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Message", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Watcher.DataAccess.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Notification", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.NotificationSetting", "NotificationSetting")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationSettingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Watcher.DataAccess.Entities.Organization", "Organization")
                        .WithMany("Notifications")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Watcher.DataAccess.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.NotificationSetting", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.User", "User")
                        .WithMany("NotificationSettings")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Organization", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Theme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.Response", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Feedback", "Feedback")
                        .WithOne("Response")
                        .HasForeignKey("Watcher.DataAccess.Entities.Response", "FeedbackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Watcher.DataAccess.Entities.User", "User")
                        .WithMany("Responses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.User", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Organization", "ChoosedOrganization")
                        .WithMany()
                        .HasForeignKey("ChoosedOrganizationId");

                    b.HasOne("Watcher.DataAccess.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.UserOrganization", b =>
                {
                    b.HasOne("Watcher.DataAccess.Entities.Organization", "Organization")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Watcher.DataAccess.Entities.User", "User")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}