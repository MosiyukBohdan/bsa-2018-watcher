﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Watcher.DataAccess.Data;

namespace Watcher.DataAccess.Data.Migrations
{
    [DbContext(typeof(WatcherDbContext))]
    partial class WatcherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new { Id = 101, DashboardId = 92, MostLoaded = "MostLoaded3", ShowCommon = "Common3", Source = "Source2", Threshold = 93, Type = 0 },
                        new { Id = 102, DashboardId = 100, MostLoaded = "MostLoaded1", ShowCommon = "Common2", Source = "Source2", Threshold = 15, Type = 1 },
                        new { Id = 103, DashboardId = 95, MostLoaded = "MostLoaded1", ShowCommon = "Common1", Source = "Source3", Threshold = 50, Type = 2 },
                        new { Id = 104, DashboardId = 93, MostLoaded = "MostLoaded2", ShowCommon = "Common1", Source = "Source1", Threshold = 3, Type = 2 },
                        new { Id = 105, DashboardId = 96, MostLoaded = "MostLoaded3", ShowCommon = "Common3", Source = "Source1", Threshold = 16, Type = 1 },
                        new { Id = 106, DashboardId = 93, MostLoaded = "MostLoaded1", ShowCommon = "Common2", Source = "Source3", Threshold = 5, Type = 1 },
                        new { Id = 107, DashboardId = 100, MostLoaded = "MostLoaded3", ShowCommon = "Common3", Source = "Source1", Threshold = 77, Type = 1 },
                        new { Id = 108, DashboardId = 99, MostLoaded = "MostLoaded3", ShowCommon = "Common2", Source = "Source1", Threshold = 34, Type = 1 },
                        new { Id = 109, DashboardId = 98, MostLoaded = "MostLoaded1", ShowCommon = "Common3", Source = "Source1", Threshold = 19, Type = 2 },
                        new { Id = 110, DashboardId = 95, MostLoaded = "MostLoaded3", ShowCommon = "Common1", Source = "Source3", Threshold = 61, Type = 1 }
                    );
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

                    b.HasData(
                        new { Id = 21, CreatedById = "04db4214-f5bb-4449-a4eb-cc485c03244f", Name = "illum", Type = 0 },
                        new { Id = 22, CreatedById = "a257c7de-ea3b-4c26-ace2-68b0d490577b", Name = "totam", Type = 0 },
                        new { Id = 23, CreatedById = "87f77ff4-670d-4715-9831-a703e38d52ca", Name = "aut", Type = 0 },
                        new { Id = 24, CreatedById = "8e70d16d-c344-43d2-a917-0a0e087c8b5a", Name = "officia", Type = 0 },
                        new { Id = 25, CreatedById = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd", Name = "est", Type = 0 },
                        new { Id = 26, CreatedById = "a257c7de-ea3b-4c26-ace2-68b0d490577b", Name = "voluptas", Type = 0 },
                        new { Id = 27, CreatedById = "87f77ff4-670d-4715-9831-a703e38d52ca", Name = "illum", Type = 0 },
                        new { Id = 28, CreatedById = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0", Name = "et", Type = 0 },
                        new { Id = 29, CreatedById = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd", Name = "consectetur", Type = 0 },
                        new { Id = 30, CreatedById = "8e70d16d-c344-43d2-a917-0a0e087c8b5a", Name = "nemo", Type = 0 }
                    );
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

                    b.HasData(
                        new { Id = 91, CreatedAt = new DateTime(2018, 8, 8, 2, 1, 38, 260, DateTimeKind.Local), InstanceId = 90, Title = "Title467" },
                        new { Id = 92, CreatedAt = new DateTime(2018, 8, 8, 6, 12, 15, 765, DateTimeKind.Local), InstanceId = 87, Title = "Title215" },
                        new { Id = 93, CreatedAt = new DateTime(2018, 8, 8, 7, 44, 4, 222, DateTimeKind.Local), InstanceId = 81, Title = "Title639" },
                        new { Id = 94, CreatedAt = new DateTime(2018, 8, 8, 6, 34, 19, 700, DateTimeKind.Local), InstanceId = 86, Title = "Title549" },
                        new { Id = 95, CreatedAt = new DateTime(2018, 8, 8, 14, 25, 6, 498, DateTimeKind.Local), InstanceId = 88, Title = "Title430" },
                        new { Id = 96, CreatedAt = new DateTime(2018, 8, 7, 22, 49, 8, 122, DateTimeKind.Local), InstanceId = 83, Title = "Title52" },
                        new { Id = 97, CreatedAt = new DateTime(2018, 8, 8, 4, 42, 50, 405, DateTimeKind.Local), InstanceId = 85, Title = "Title867" },
                        new { Id = 98, CreatedAt = new DateTime(2018, 8, 8, 11, 52, 46, 275, DateTimeKind.Local), InstanceId = 86, Title = "Title759" },
                        new { Id = 99, CreatedAt = new DateTime(2018, 8, 8, 8, 55, 33, 516, DateTimeKind.Local), InstanceId = 90, Title = "Title136" },
                        new { Id = 100, CreatedAt = new DateTime(2018, 8, 7, 22, 24, 1, 236, DateTimeKind.Local), InstanceId = 82, Title = "Title601" }
                    );
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

                    b.HasData(
                        new { Id = 41, CreatedAt = new DateTime(2018, 8, 8, 5, 33, 1, 298, DateTimeKind.Local), Text = "Voluptatibus voluptate repellat voluptates aliquid quaerat facilis cupiditate iusto accusamus.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd" },
                        new { Id = 42, CreatedAt = new DateTime(2018, 8, 8, 5, 10, 14, 614, DateTimeKind.Local), Text = "Quis quo consectetur rerum tenetur eaque ad id inventore labore.", UserId = "8e70d16d-c344-43d2-a917-0a0e087c8b5a" },
                        new { Id = 43, CreatedAt = new DateTime(2018, 8, 8, 15, 48, 46, 720, DateTimeKind.Local), Text = "Non eum quisquam eos porro saepe rerum eos.", UserId = "8e70d16d-c344-43d2-a917-0a0e087c8b5a" },
                        new { Id = 44, CreatedAt = new DateTime(2018, 8, 8, 12, 13, 30, 475, DateTimeKind.Local), Text = "Velit incidunt sed consequatur quia exercitationem numquam dolor dolores.", UserId = "28d9560d-e2f2-409e-bc0e-8864ea939882" },
                        new { Id = 45, CreatedAt = new DateTime(2018, 8, 8, 14, 7, 30, 856, DateTimeKind.Local), Text = "Et sed qui est repellat sed molestiae.", UserId = "28d9560d-e2f2-409e-bc0e-8864ea939882" },
                        new { Id = 46, CreatedAt = new DateTime(2018, 8, 7, 20, 58, 6, 500, DateTimeKind.Local), Text = "Facilis quae vel aut sunt sequi harum consectetur odit amet.", UserId = "de8f0970-c1bc-4072-9c76-a5e598e3d6e4" },
                        new { Id = 47, CreatedAt = new DateTime(2018, 8, 7, 23, 54, 44, 720, DateTimeKind.Local), Text = "Quisquam fugiat laudantium velit.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd" },
                        new { Id = 48, CreatedAt = new DateTime(2018, 8, 8, 2, 22, 30, 313, DateTimeKind.Local), Text = "Dolores praesentium repellendus modi deleniti quod saepe quia rerum.", UserId = "87f77ff4-670d-4715-9831-a703e38d52ca" },
                        new { Id = 49, CreatedAt = new DateTime(2018, 8, 8, 10, 49, 39, 119, DateTimeKind.Local), Text = "Iure dolores officia nesciunt asperiores occaecati quisquam inventore ratione.", UserId = "87f77ff4-670d-4715-9831-a703e38d52ca" },
                        new { Id = 50, CreatedAt = new DateTime(2018, 8, 7, 19, 39, 30, 851, DateTimeKind.Local), Text = "Quisquam saepe necessitatibus aut.", UserId = "04db4214-f5bb-4449-a4eb-cc485c03244f" }
                    );
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

                    b.HasData(
                        new { Id = 81, Address = "e1:a0:23:c5:bb:f7", OrganizationId = 80, Platform = "Linux" },
                        new { Id = 82, Address = "f0:84:8d:89:10:d1", OrganizationId = 73, Platform = "Linux" },
                        new { Id = 83, Address = "1a:df:7e:6b:a1:3f", OrganizationId = 76, Platform = "Windows" },
                        new { Id = 84, Address = "ea:09:b0:f5:8e:ec", OrganizationId = 77, Platform = "Linux" },
                        new { Id = 85, Address = "0d:94:12:18:0e:a7", OrganizationId = 72, Platform = "Windows" },
                        new { Id = 86, Address = "68:e0:2c:92:82:72", OrganizationId = 73, Platform = "Linux" },
                        new { Id = 87, Address = "f9:57:02:26:72:6a", OrganizationId = 71, Platform = "Windows" },
                        new { Id = 88, Address = "18:81:da:b2:46:fa", OrganizationId = 71, Platform = "Linux" },
                        new { Id = 89, Address = "dd:74:7b:7c:be:1b", OrganizationId = 72, Platform = "Windows" },
                        new { Id = 90, Address = "b0:af:03:c1:12:f5", OrganizationId = 72, Platform = "Windows" }
                    );
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

                    b.HasData(
                        new { Id = 31, ChatId = 25, CreatedAt = new DateTime(2018, 8, 8, 10, 2, 36, 403, DateTimeKind.Local), Text = "Deleniti quo blanditiis sunt.", UserId = "a257c7de-ea3b-4c26-ace2-68b0d490577b", WasRead = false },
                        new { Id = 32, ChatId = 28, CreatedAt = new DateTime(2018, 8, 8, 11, 13, 5, 258, DateTimeKind.Local), Text = "Adipisci adipisci quo quis iure ipsum et iure aut.", UserId = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0", WasRead = true },
                        new { Id = 33, ChatId = 21, CreatedAt = new DateTime(2018, 8, 7, 20, 15, 3, 172, DateTimeKind.Local), Text = "Ratione explicabo fugit similique assumenda reprehenderit.", UserId = "8e70d16d-c344-43d2-a917-0a0e087c8b5a", WasRead = true },
                        new { Id = 34, ChatId = 29, CreatedAt = new DateTime(2018, 8, 7, 23, 0, 23, 633, DateTimeKind.Local), Text = "Suscipit aut aut sequi sit vero sunt.", UserId = "3008686f-a95c-4e25-b0f7-1ac58ccccefe", WasRead = false },
                        new { Id = 35, ChatId = 27, CreatedAt = new DateTime(2018, 8, 8, 16, 14, 17, 433, DateTimeKind.Local), Text = "Non dolor ducimus ut aut.", UserId = "28d9560d-e2f2-409e-bc0e-8864ea939882", WasRead = false },
                        new { Id = 36, ChatId = 30, CreatedAt = new DateTime(2018, 8, 8, 13, 48, 0, 876, DateTimeKind.Local), Text = "Ipsam nemo repellat non est qui pariatur voluptatum.", UserId = "3008686f-a95c-4e25-b0f7-1ac58ccccefe", WasRead = true },
                        new { Id = 37, ChatId = 23, CreatedAt = new DateTime(2018, 8, 8, 9, 21, 26, 18, DateTimeKind.Local), Text = "Commodi incidunt incidunt.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd", WasRead = false },
                        new { Id = 38, ChatId = 27, CreatedAt = new DateTime(2018, 8, 8, 14, 36, 22, 130, DateTimeKind.Local), Text = "Sed et est officia temporibus voluptatem at error molestiae molestiae.", UserId = "28d9560d-e2f2-409e-bc0e-8864ea939882", WasRead = true },
                        new { Id = 39, ChatId = 28, CreatedAt = new DateTime(2018, 8, 7, 21, 48, 3, 998, DateTimeKind.Local), Text = "Nesciunt et vitae commodi voluptas quia qui laudantium.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd", WasRead = true },
                        new { Id = 40, ChatId = 29, CreatedAt = new DateTime(2018, 8, 7, 23, 36, 22, 505, DateTimeKind.Local), Text = "Sunt eius quo dignissimos et.", UserId = "a257c7de-ea3b-4c26-ace2-68b0d490577b", WasRead = false }
                    );
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

                    b.HasData(
                        new { Id = 111, CreatedAt = new DateTime(2018, 8, 8, 14, 41, 6, 217, DateTimeKind.Local), NotificationSettingId = 9, Text = "Totam incidunt cum tempora.", UserId = "8e70d16d-c344-43d2-a917-0a0e087c8b5a" },
                        new { Id = 112, CreatedAt = new DateTime(2018, 8, 7, 19, 21, 31, 714, DateTimeKind.Local), NotificationSettingId = 10, Text = "Dolorem vel ab dignissimos aliquid ut iusto dolor quis quam.", UserId = "a257c7de-ea3b-4c26-ace2-68b0d490577b" },
                        new { Id = 113, CreatedAt = new DateTime(2018, 8, 8, 12, 9, 47, 989, DateTimeKind.Local), NotificationSettingId = 6, Text = "Non quas minus iste et enim aut sit sint.", UserId = "04db4214-f5bb-4449-a4eb-cc485c03244f" },
                        new { Id = 114, CreatedAt = new DateTime(2018, 8, 8, 2, 7, 30, 988, DateTimeKind.Local), NotificationSettingId = 8, Text = "Est qui vel.", UserId = "28d9560d-e2f2-409e-bc0e-8864ea939882" },
                        new { Id = 115, CreatedAt = new DateTime(2018, 8, 8, 1, 57, 43, 99, DateTimeKind.Local), NotificationSettingId = 3, Text = "Atque quas aut placeat non modi ipsam unde harum sit.", UserId = "a257c7de-ea3b-4c26-ace2-68b0d490577b" },
                        new { Id = 116, CreatedAt = new DateTime(2018, 8, 8, 6, 20, 7, 50, DateTimeKind.Local), NotificationSettingId = 8, Text = "Cumque quia dolores deserunt libero unde ut.", UserId = "5282bfd7-5a16-4bc0-92d2-354a14217853" },
                        new { Id = 117, CreatedAt = new DateTime(2018, 8, 8, 17, 36, 3, 729, DateTimeKind.Local), NotificationSettingId = 10, Text = "Eum quos maxime velit et placeat cupiditate iusto sit quis.", UserId = "04db4214-f5bb-4449-a4eb-cc485c03244f" },
                        new { Id = 118, CreatedAt = new DateTime(2018, 8, 8, 1, 26, 38, 335, DateTimeKind.Local), NotificationSettingId = 6, Text = "Sit repellat laudantium.", UserId = "de8f0970-c1bc-4072-9c76-a5e598e3d6e4" },
                        new { Id = 119, CreatedAt = new DateTime(2018, 8, 8, 16, 20, 47, 373, DateTimeKind.Local), NotificationSettingId = 3, Text = "Ut odio maiores voluptate aut.", UserId = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0" },
                        new { Id = 120, CreatedAt = new DateTime(2018, 8, 7, 22, 13, 31, 533, DateTimeKind.Local), NotificationSettingId = 8, Text = "Doloribus rerum dolor.", UserId = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0" }
                    );
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

                    b.HasData(
                        new { Id = 1, IsDisable = true, IsMute = true, Type = 0, UserId = 0 },
                        new { Id = 2, IsDisable = false, IsMute = false, Type = 1, UserId = 0 },
                        new { Id = 3, IsDisable = false, IsMute = true, Type = 0, UserId = 0 },
                        new { Id = 4, IsDisable = true, IsMute = true, Type = 0, UserId = 0 },
                        new { Id = 5, IsDisable = false, IsMute = false, Type = 0, UserId = 0 },
                        new { Id = 6, IsDisable = true, IsMute = false, Type = 0, UserId = 0 },
                        new { Id = 7, IsDisable = true, IsMute = true, Type = 0, UserId = 0 },
                        new { Id = 8, IsDisable = true, IsMute = true, Type = 0, UserId = 0 },
                        new { Id = 9, IsDisable = true, IsMute = true, Type = 0, UserId = 0 },
                        new { Id = 10, IsDisable = false, IsMute = true, Type = 1, UserId = 0 }
                    );
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

                    b.HasData(
                        new { Id = 71, Name = "Company899", ThemeId = 66 },
                        new { Id = 72, Name = "Company134", ThemeId = 61 },
                        new { Id = 73, Name = "Company678", ThemeId = 69 },
                        new { Id = 74, Name = "Company233", ThemeId = 68 },
                        new { Id = 75, Name = "Company192", ThemeId = 70 },
                        new { Id = 76, Name = "Company773", ThemeId = 65 },
                        new { Id = 77, Name = "Company115", ThemeId = 61 },
                        new { Id = 78, Name = "Company984", ThemeId = 69 },
                        new { Id = 79, Name = "Company177", ThemeId = 62 },
                        new { Id = 80, Name = "Company25", ThemeId = 69 }
                    );
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

                    b.HasData(
                        new { Id = 51, CreatedAt = new DateTime(2018, 8, 8, 12, 0, 49, 912, DateTimeKind.Local), FeedbackId = 44, Text = "Neque ratione eligendi quam amet voluptatem deserunt voluptas fugiat.", UserId = "04db4214-f5bb-4449-a4eb-cc485c03244f" },
                        new { Id = 52, CreatedAt = new DateTime(2018, 8, 8, 6, 54, 18, 315, DateTimeKind.Local), FeedbackId = 41, Text = "Aut aut a minus dolores tempore.", UserId = "5282bfd7-5a16-4bc0-92d2-354a14217853" },
                        new { Id = 53, CreatedAt = new DateTime(2018, 8, 7, 21, 21, 13, 322, DateTimeKind.Local), FeedbackId = 47, Text = "Et amet enim ut et qui pariatur autem sit aliquid.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd" },
                        new { Id = 54, CreatedAt = new DateTime(2018, 8, 8, 18, 6, 30, 282, DateTimeKind.Local), FeedbackId = 43, Text = "Architecto in eveniet ea adipisci necessitatibus et quidem.", UserId = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0" },
                        new { Id = 55, CreatedAt = new DateTime(2018, 8, 8, 13, 50, 12, 153, DateTimeKind.Local), FeedbackId = 43, Text = "Recusandae nesciunt ut ut veritatis eveniet sed.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd" },
                        new { Id = 56, CreatedAt = new DateTime(2018, 8, 8, 7, 0, 55, 633, DateTimeKind.Local), FeedbackId = 47, Text = "Quisquam sunt quod voluptatibus totam voluptas hic in repellat.", UserId = "a257c7de-ea3b-4c26-ace2-68b0d490577b" },
                        new { Id = 57, CreatedAt = new DateTime(2018, 8, 8, 10, 50, 41, 893, DateTimeKind.Local), FeedbackId = 47, Text = "Omnis quasi optio sequi neque reiciendis sit laborum.", UserId = "5282bfd7-5a16-4bc0-92d2-354a14217853" },
                        new { Id = 58, CreatedAt = new DateTime(2018, 8, 8, 5, 34, 14, 607, DateTimeKind.Local), FeedbackId = 44, Text = "Qui sint nostrum ut saepe qui fuga voluptas.", UserId = "87f77ff4-670d-4715-9831-a703e38d52ca" },
                        new { Id = 59, CreatedAt = new DateTime(2018, 8, 8, 14, 36, 39, 998, DateTimeKind.Local), FeedbackId = 45, Text = "Et suscipit enim illo consequuntur labore.", UserId = "3008686f-a95c-4e25-b0f7-1ac58ccccefe" },
                        new { Id = 60, CreatedAt = new DateTime(2018, 8, 8, 17, 44, 25, 390, DateTimeKind.Local), FeedbackId = 41, Text = "Corrupti doloribus velit delectus.", UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd" }
                    );
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

                    b.HasData(
                        new { Id = 1, Name = "Admin" },
                        new { Id = 2, Name = "User" }
                    );
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

                    b.HasData(
                        new { Id = 61, BackgroundColor = "White", FontFamily = "Helvetica", Name = "Theme261" },
                        new { Id = 62, BackgroundColor = "Gray", FontFamily = "Frutiger", Name = "Theme287" },
                        new { Id = 63, BackgroundColor = "White", FontFamily = "Frutiger", Name = "Theme603" },
                        new { Id = 64, BackgroundColor = "Gray", FontFamily = "Trade", Name = "Theme818" },
                        new { Id = 65, BackgroundColor = "Yellow", FontFamily = "Frutiger", Name = "Theme245" },
                        new { Id = 66, BackgroundColor = "White", FontFamily = "Frutiger", Name = "Theme129" },
                        new { Id = 67, BackgroundColor = "Gray", FontFamily = "Univers", Name = "Theme975" },
                        new { Id = 68, BackgroundColor = "Yellow", FontFamily = "Univers", Name = "Theme299" },
                        new { Id = 69, BackgroundColor = "White", FontFamily = "Trade", Name = "Theme527" },
                        new { Id = 70, BackgroundColor = "Gray", FontFamily = "Frutiger", Name = "Theme105" }
                    );
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<int>("RoleId");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd", CreatedAt = new DateTime(2018, 8, 8, 16, 54, 26, 920, DateTimeKind.Local), DisplayName = "Jaylen", Email = "Kyla95@gmail.com", FirstName = "Jarrod", IsActive = true, RoleId = 1, SecondName = "Stehr" },
                        new { Id = "87f77ff4-670d-4715-9831-a703e38d52ca", CreatedAt = new DateTime(2018, 8, 8, 7, 57, 12, 296, DateTimeKind.Local), DisplayName = "Sylvan", Email = "Leonor.Graham9@gmail.com", FirstName = "Rowland", IsActive = false, RoleId = 1, SecondName = "Nader" },
                        new { Id = "a257c7de-ea3b-4c26-ace2-68b0d490577b", CreatedAt = new DateTime(2018, 8, 7, 23, 9, 49, 597, DateTimeKind.Local), DisplayName = "Sigrid", Email = "Kurt58@hotmail.com", FirstName = "Ross", IsActive = true, RoleId = 1, SecondName = "Herzog" },
                        new { Id = "de8f0970-c1bc-4072-9c76-a5e598e3d6e4", CreatedAt = new DateTime(2018, 8, 8, 9, 41, 47, 297, DateTimeKind.Local), DisplayName = "Micah", Email = "Gerson62@hotmail.com", FirstName = "Keaton", IsActive = false, RoleId = 1, SecondName = "Hilpert" },
                        new { Id = "28d9560d-e2f2-409e-bc0e-8864ea939882", CreatedAt = new DateTime(2018, 8, 8, 17, 3, 45, 697, DateTimeKind.Local), DisplayName = "Ethelyn", Email = "Rhiannon_Breitenberg38@gmail.com", FirstName = "Jan", IsActive = true, RoleId = 2, SecondName = "Rau" },
                        new { Id = "04db4214-f5bb-4449-a4eb-cc485c03244f", CreatedAt = new DateTime(2018, 8, 8, 16, 51, 25, 653, DateTimeKind.Local), DisplayName = "Maude", Email = "Lorenz47@hotmail.com", FirstName = "Lora", IsActive = true, RoleId = 1, SecondName = "Quitzon" },
                        new { Id = "3008686f-a95c-4e25-b0f7-1ac58ccccefe", CreatedAt = new DateTime(2018, 8, 7, 22, 5, 14, 166, DateTimeKind.Local), DisplayName = "Spencer", Email = "Else.Kunde73@yahoo.com", FirstName = "Federico", IsActive = false, RoleId = 2, SecondName = "Tromp" },
                        new { Id = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0", CreatedAt = new DateTime(2018, 8, 8, 5, 58, 59, 864, DateTimeKind.Local), DisplayName = "Gideon", Email = "Ardith.Torp@yahoo.com", FirstName = "Chadd", IsActive = true, RoleId = 2, SecondName = "Kessler" },
                        new { Id = "5282bfd7-5a16-4bc0-92d2-354a14217853", CreatedAt = new DateTime(2018, 8, 8, 8, 21, 32, 799, DateTimeKind.Local), DisplayName = "Mateo", Email = "Lorena_Blanda@hotmail.com", FirstName = "Armani", IsActive = false, RoleId = 1, SecondName = "Doyle" },
                        new { Id = "8e70d16d-c344-43d2-a917-0a0e087c8b5a", CreatedAt = new DateTime(2018, 8, 7, 21, 37, 36, 351, DateTimeKind.Local), DisplayName = "Tommie", Email = "Gerson.Dare@hotmail.com", FirstName = "Woodrow", IsActive = true, RoleId = 2, SecondName = "Grimes" }
                    );
                });

            modelBuilder.Entity("Watcher.DataAccess.Entities.UserOrganization", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("OrganizationId");

                    b.HasKey("UserId", "OrganizationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("UserOrganizations");

                    b.HasData(
                        new { UserId = "59cd0d8c-07ba-4e60-943f-7a06a967cdfd", OrganizationId = 76 },
                        new { UserId = "87f77ff4-670d-4715-9831-a703e38d52ca", OrganizationId = 74 },
                        new { UserId = "a257c7de-ea3b-4c26-ace2-68b0d490577b", OrganizationId = 77 },
                        new { UserId = "de8f0970-c1bc-4072-9c76-a5e598e3d6e4", OrganizationId = 74 },
                        new { UserId = "28d9560d-e2f2-409e-bc0e-8864ea939882", OrganizationId = 72 },
                        new { UserId = "04db4214-f5bb-4449-a4eb-cc485c03244f", OrganizationId = 77 },
                        new { UserId = "3008686f-a95c-4e25-b0f7-1ac58ccccefe", OrganizationId = 73 },
                        new { UserId = "18d3bc15-1982-43a9-a7e0-ef2226ed89e0", OrganizationId = 73 },
                        new { UserId = "5282bfd7-5a16-4bc0-92d2-354a14217853", OrganizationId = 77 },
                        new { UserId = "8e70d16d-c344-43d2-a917-0a0e087c8b5a", OrganizationId = 76 }
                    );
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
