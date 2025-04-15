using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrganicBasketsV2.Models;

public partial class OrganicBasketsContext : DbContext
{
    public OrganicBasketsContext()
    {
    }

    public OrganicBasketsContext(DbContextOptions<OrganicBasketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Alarm> Alarms { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<DietPlan> DietPlans { get; set; }

    public virtual DbSet<HealthDataToTrain> HealthDataToTrains { get; set; }

    public virtual DbSet<HealthInfo> HealthInfos { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MarketBasketAnalysis> MarketBasketAnalyses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Prediction> Predictions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDiet> ProductDiets { get; set; }

    public virtual DbSet<SupportTicket> SupportTickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VISHWANI;Database=OrganicBaskets;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2A1B14DA3522");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressLine1).HasMaxLength(255);
            entity.Property(e => e.AddressLine2).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LocationType).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.UserNameOrVendorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Alarm>(entity =>
        {
            entity.HasKey(e => e.AlarmId).HasName("PK__Alarms__43E5EB15D6B90A72");

            entity.Property(e => e.AlarmId).HasColumnName("AlarmID");
            entity.Property(e => e.AlarmDays).HasMaxLength(50);
            entity.Property(e => e.DietId).HasColumnName("DietID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7978A6453F7");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DietPlan>(entity =>
        {
            entity.HasKey(e => e.DietId).HasName("PK__DietPlan__AB42F6BE3FA94761");

            entity.Property(e => e.DietId).HasColumnName("DietID");
            entity.Property(e => e.DietName).HasMaxLength(100);
        });

        modelBuilder.Entity<HealthDataToTrain>(entity =>
        {
            entity.HasKey(e => e.DataId).HasName("PK_DataID");

            entity.ToTable("HealthDataToTrain");

            entity.Property(e => e.DataId).HasColumnName("DataID");
            entity.Property(e => e.AdherenceToDietPlan)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Adherence_to_Diet_Plan");
            entity.Property(e => e.Allergies)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BloodPressureMmHg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Blood_Pressure_mmHg");
            entity.Property(e => e.Bmi)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("BMI");
            entity.Property(e => e.CholesterolMgDL).HasColumnName("Cholesterol_mg_dL");
            entity.Property(e => e.DailyCaloricIntake).HasColumnName("Daily_Caloric_Intake");
            entity.Property(e => e.DietRecommendation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Diet_Recommendation");
            entity.Property(e => e.DietaryNutrientImbalanceScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Dietary_Nutrient_Imbalance_Score");
            entity.Property(e => e.DietaryRestrictions)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dietary_Restrictions");
            entity.Property(e => e.DiseaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Disease_Type");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GlucoseMgDL).HasColumnName("Glucose_mg_dL");
            entity.Property(e => e.HeightCm).HasColumnName("Height_cm");
            entity.Property(e => e.PhysicalActivityLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Physical_Activity_Level");
            entity.Property(e => e.PreferredCuisine)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preferred_Cuisine");
            entity.Property(e => e.Severity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WeeklyExerciseHours)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Weekly_Exercise_Hours");
            entity.Property(e => e.WeightKg)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Weight_kg");
        });

        modelBuilder.Entity<HealthInfo>(entity =>
        {
            entity.HasKey(e => e.HealthDataId).HasName("PK_HealthDataID");

            entity.ToTable("HealthInfo");

            entity.Property(e => e.HealthDataId).HasColumnName("HealthDataID");
            entity.Property(e => e.AdherenceToDietPlan)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Adherence_to_Diet_Plan");
            entity.Property(e => e.Allergies)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AnyDeficiency)
                .HasMaxLength(1500)
                .IsUnicode(false)
                .HasColumnName("AnyDeficiency?");
            entity.Property(e => e.BloodPressureMmHg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Blood_Pressure_mmHg");
            entity.Property(e => e.Bmi)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("BMI");
            entity.Property(e => e.CholesterolMgDL).HasColumnName("Cholesterol_mg_dL");
            entity.Property(e => e.DailyCaloricIntake).HasColumnName("Daily_Caloric_Intake");
            entity.Property(e => e.DietRecommendation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Diet_Recommendation");
            entity.Property(e => e.DietaryNutrientImbalanceScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Dietary_Nutrient_Imbalance_Score");
            entity.Property(e => e.DietaryRestrictions)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dietary_Restrictions");
            entity.Property(e => e.DiseaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Disease_Type");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GlucoseMgDL).HasColumnName("Glucose_mg_dL");
            entity.Property(e => e.HaveNutAllergy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("HaveNutAllergy?");
            entity.Property(e => e.HeightCm).HasColumnName("Height_cm");
            entity.Property(e => e.PhysicalActivityLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Physical_Activity_Level");
            entity.Property(e => e.PreferredCuisine)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preferred_Cuisine");
            entity.Property(e => e.Severity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WeeklyExerciseHours)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Weekly_Exercise_Hours");
            entity.Property(e => e.WeightKg)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Weight_kg");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__Login__4DDA2818A9F09EE1");

            entity.ToTable("Login");

            entity.Property(e => e.LoginTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        modelBuilder.Entity<MarketBasketAnalysis>(entity =>
        {
            entity.HasKey(e => e.RuleId).HasName("PK__MarketBa__110458C2A0FAEB14");

            entity.ToTable("MarketBasketAnalysis");

            entity.Property(e => e.RuleId).HasColumnName("RuleID");
            entity.Property(e => e.Confidence).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Support).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFB26F473C");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.OrderededAt).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C73F53B05");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<Prediction>(entity =>
        {
            entity.HasKey(e => e.PredictionId).HasName("PK__Predicti__BAE4C140CBC99450");

            entity.Property(e => e.PredictionId).HasColumnName("PredictionID");
            entity.Property(e => e.PredictedDiet).HasMaxLength(255);
            entity.Property(e => e.PredictionPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED9A3CE434");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.IsGlutenFree)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IsGlutenFree?");
            entity.Property(e => e.IsVegan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IsVegan?");
            entity.Property(e => e.PackagingUnit)
                .HasMaxLength(50)
                .HasColumnName("Packaging_Unit");
            entity.Property(e => e.PartOfDiet)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductImage).HasMaxLength(500);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.RichInHealthBenefits)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<ProductDiet>(entity =>
        {
            entity.HasKey(e => e.ProductDietId).HasName("PK__ProductD__DBDD888D015EC438");

            entity.ToTable("ProductDiet");

            entity.Property(e => e.ProductDietId).HasColumnName("ProductDietID");
            entity.Property(e => e.PartOfDiet)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SupportTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__SupportT__712CC627DC0DF0FE");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TicketStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Open");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC157004C4");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsVendor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__FC8618D35F310450");

            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
