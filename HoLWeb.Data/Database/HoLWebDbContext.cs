using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Models.GeneralAttributes;
using HoLWeb.DataLayer.Models.IdentityModels;
using HoLWeb.DataLayer.Models.SkillsModels;
using HoLWeb.DataLayer.Models.ThumbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace HoLWeb.DataLayer.Database
{
    public class HoLWebDbContext(DbContextOptions<HoLWebDbContext> options) : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>(options)
    {

        public DbSet<Race>? Races { get; set; }
        public DbSet<Narrative>? Naratives { get; set; }
        public DbSet<World>? Worlds { get; set; }
        public DbSet<ProfessionModul>? Professions { get; set; }
        public DbSet<Character>? Characters { get; set; }
        public DbSet<ProfessionSkill>? ProfessionSkill { get; set; }
        public DbSet<BaseSpecificSkill>? SpecificSkill { get; set; }
        public DbSet<GeneralAttribut>? AttributeStats { get; set; }
        public DbSet<ThumbnailImage>? ThumbnailImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YourConnectionString")
                              .EnableSensitiveDataLogging();
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            // ----------------- 1:N -----------------
            Configure_BaseSpecificSkill(builder);
            Configure_AttributeStats(builder);
            // ----------------- 1:N One-way -----------------
            Configure_Character(builder);
            Configure_Race(builder);
            Configure_World(builder);

            // -----------------M:N One-way -----------------
            Configure_Profession(builder);
            Confiure_ApplicationUser(builder);
            // ----------------- 1:1 -----------------
            Configure_ThumbnailImage(builder);
            // ----------------- INIT -----------------
            InitializeData(builder);
            base.OnModelCreating(builder);
        }
        private void Configure_ThumbnailImage(ModelBuilder builder)
        {
            builder.Entity<ThumbnailImage>()
                .HasDiscriminator<string>("class")
                .HasValue<ThumbImgCharacter>("ThumbCharacter")
                .HasValue<ThumbImgNarrative>("ThumbNarrative")
                .HasValue<ThumbImgRace>("ThumbRace")
                .HasValue<ThumbImgWorld>("ThumbWorld");


            builder.Entity<ThumbImgCharacter>()
                .HasOne(c => c.Character)
                .WithOne(c => c.ThumbnailImage)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ThumbImgNarrative>()
                .HasOne(n => n.Narrative)
                .WithOne(n => n.ThumbnailImage)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ThumbImgRace>()
                .HasOne(n => n.Race)
                .WithOne(n => n.ThumbnailImage)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ThumbImgWorld>()
                .HasOne(n => n.World)
                .WithOne(n => n.ThumbnailImage)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
        private void Configure_AttributeStats(ModelBuilder builder)
        {
            builder.Entity<GeneralAttribut>()
                .HasDiscriminator<string>("class")
                .HasValue<RaceStat>("race")
                .HasValue<CharacterStat>("character");
        }
        private void Configure_Character(ModelBuilder builder)
        {
            builder.Entity<Character>()
                .HasOne(c => c.NavForStrengthStat)
                .WithMany()
                .HasForeignKey(c => c.StrengthStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Strength_Character");

            builder.Entity<Character>()
                .HasOne(c => c.NavForAgilityStat)
                .WithMany()
                .HasForeignKey(c => c.AgilityStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Agility_Character");

            builder.Entity<Character>()
                .HasOne(c => c.NavForConstitutionStat)
                .WithMany()
                .HasForeignKey(c => c.ConstitutionStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Constitution_Character");

            builder.Entity<Character>()
                .HasOne(c => c.NavForIntelligenceStat)
                .WithMany()
                .HasForeignKey(c => c.IntelligenceStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Intelligence_Character");

            builder.Entity<Character>()
                .HasOne(c => c.NavForCharismaStat)
                .WithMany()
                .HasForeignKey(c => c.CharismaStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Charisma");
        }
        private void Configure_Profession(ModelBuilder builder)
        {
            //One - way M: N
            builder.Entity<ProfessionModul>()
                .HasMany(p => p.BeginnerSkills)
                .WithMany()
                .UsingEntity(t => t.ToTable("BindTable_Beginner_ProfessionSkill"));
            //One - way M: N
            builder.Entity<ProfessionModul>()
                .HasMany(p => p.AdvancedSkills)
                .WithMany()
                .UsingEntity(t => t.ToTable("BindTable_Advanced_ProfessionSkill"));
            //One - way M: N
            builder.Entity<ProfessionModul>()
                .HasMany(p => p.ExpertSkills)
                .WithMany()
                .UsingEntity(t => t.ToTable("BindTable_Expert_ProfessionSkill"));
        }
        private void Configure_BaseSpecificSkill(ModelBuilder builder)
        {
            builder.Entity<BaseSpecificSkill>()
                .HasDiscriminator<string>("Skill_type")
                .HasValue<MultipleAttack>("multiple_attack")
                .HasValue<Healing>("healing");
        }
        private void Configure_Race(ModelBuilder builder)
        {
            builder.Entity<Race>()
            .HasOne(c => c.StrengthStat)
            .WithMany()
            .HasForeignKey(c => c.StrengthStatId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Strength_Race");

            builder.Entity<Race>()
                .HasOne(c => c.AgilityStat)
                .WithMany()
                .HasForeignKey(c => c.AgilityStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Agility_Race");

            builder.Entity<Race>()
                .HasOne(c => c.ConstitutionStat)
                .WithMany()
                .HasForeignKey(c => c.ConstitutionStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Constitution_Race");

            builder.Entity<Race>()
                .HasOne(c => c.IntelligenceStat)
                .WithMany()
                .HasForeignKey(c => c.IntelligenceStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Intelligence_Race");

            builder.Entity<Race>()
                .HasOne(c => c.CharismaStat)
                .WithMany()
                .HasForeignKey(c => c.CharismaStatId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Charisma_Race");

            //builder.Entity<Race>()
            //      .HasMany(m=>m.Narratives)
            //      .WithMany(m=>m.Races)
            //      .UsingEntity(mg=>mg.ToTable(nameof(World)));
        }
        private void InitializeData(ModelBuilder builder)
        {
            int baseSpecificSkillId = 1;
            int stat = 1;

            builder.Entity<World>().HasData(new World().Initial());
            builder.Entity<Narrative>().HasData(new Narrative().Initial());
            builder.Entity<ProfessionModul>().HasData(new ProfessionModul().ProfessionModulInit());
            builder.Entity<ProfessionSkill>().HasData(new ProfessionSkill().Initial(1));
            //Skills
            baseSpecificSkillId = Increment_Id_BaseSpecificSkill<Healing>(baseSpecificSkillId,builder);
            baseSpecificSkillId = Increment_Id_BaseSpecificSkill<MultipleAttack>(baseSpecificSkillId,builder);
            stat = Increment_Id_CharacterStats<RaceStat>(stat,builder);
            stat = Increment_Id_CharacterStats<CharacterStat>(stat,builder);
            builder.Entity<Race>().HasData(new Race().Initial());
            builder.Entity<Character>().HasData(new Character().Initial());
        }
        private void Confiure_ApplicationUser(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Worlds)
                .WithMany(w => w.Players)
                .UsingEntity(j => j.ToTable("Worlds_Players"));
                
        }
        private void Configure_World(ModelBuilder builder)
        {
            builder.Entity<World>()
                .HasOne(w => w.GameMaster)
                .WithMany()
                .HasForeignKey(w => w.GameMasterId)
                .HasConstraintName("FK_GameMaster_World");
        }
        private int Increment_Id_BaseSpecificSkill<T>(int firstId,ModelBuilder builder) where T : BaseSpecificSkill, new()
        {
            var skills = new T().Initial(firstId);
            builder.Entity<T>().HasData(skills);
            return firstId + skills.Length;
        }
        private int Increment_Id_CharacterStats<T>(int firstId,ModelBuilder builder) where T : GeneralAttribut, new()
        {
            var stats = new T().Initial(firstId);
            builder.Entity<T>().HasData(stats);
            return firstId + stats.Length;
        }


    }

}
