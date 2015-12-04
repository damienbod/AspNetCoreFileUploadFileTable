using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataAccess;

namespace DataAccess.Migrations
{
    [DbContext(typeof(FileContext))]
    partial class FileContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Model.FileDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("CreatedTimestamp");

                    b.Property<string>("Description");

                    b.Property<string>("FileName");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("Id");
                });
        }
    }
}
