// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuoteFinal.Models;

namespace QuoteFinal.Migrations
{
    [DbContext(typeof(QuoteDBContext))]
    partial class QuoteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("QuoteFinal.Models.Quote", b =>
                {
                    b.Property<int>("QuoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Citation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<string>("aQuote")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuoteID");

                    b.ToTable("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
