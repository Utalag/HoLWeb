using HoLWeb.BusinessLayer;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Interfaces.IThumbImgManagers;
using HoLWeb.BusinessLayer.Managers;
using HoLWeb.BusinessLayer.Managers.ThumbImgManagers;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.BusinessLayer.StateServices;
using HoLWeb.Components;
using HoLWeb.Components.Account;
using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models.IdentityModels;
using HoLWeb.DataLayer.Repositories;
using HoLWeb.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();
;


// Configure FluentEmail
builder.Services.AddFluentEmail("example@test.com")
    .AddRazorRenderer()
    .AddSmtpSender("localhost",25); // Použijte "localhost" a port "25" pro Papercut SMTP

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider,IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<HoLWebDbContext>(options =>
    options.UseSqlServer(connectionString)
    .UseLazyLoadingProxies()
//.ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
);


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add Identity - with custom user and role
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<HoLWebDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// DI
builder.Services.AddScoped<IEmailSender<ApplicationUser>,FluentEmailSender>();
builder.Services.AddScoped<FluentEmailSender>();

//JSInterop
//builder.Services.AddScoped<JsInterop>();

// modely
builder.Services.AddScoped<StateService<WorldDto>>();

// genericRepository
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

// httpclient
//builder.Services.AddHttpClient();

//repository
builder.Services.AddScoped<IRaceRepository,RaceRepository>();
builder.Services.AddScoped<INarrativeRepository,NarrativeRepository>();
builder.Services.AddScoped<IWorldRepository,WorldRepository>();
builder.Services.AddScoped<IProfessionModulRepository,ProfessionModulRepository>();
builder.Services.AddScoped<ICharacterRepository,CharacterRepository>();
builder.Services.AddScoped<IProfessionSkillRepository,ProfessionSkillRepository>();
builder.Services.AddScoped<ISpecificSkillReposotory,SpecificSkillReposotory>();
builder.Services.AddScoped<ICharacterStatRepository,CharacterStatRepository>();
builder.Services.AddScoped<IRaceStatRepository,RaceStatRepository>();

builder.Services.AddScoped<IThumbImgWorldRepository,ThumbImgWorldRepository>();
builder.Services.AddScoped<IThumbImgNarrativeRepository,ThumbImgNarrativeRepository>();
builder.Services.AddScoped<IThumbImgRaceRepository,ThumbImgRaceRepository>();
builder.Services.AddScoped<IThumbImgCharacterRepository,ThumbImgCharacterRepository>();

//manazery

builder.Services.AddScoped<INarrativeManager,NarrativeManager>();
builder.Services.AddScoped<IRaceManager,RaceManager>();
builder.Services.AddScoped<IWorldManager,WorldManager>();
builder.Services.AddScoped<IProfessionManager,ProfessionModulManager>();
builder.Services.AddScoped<ICharacterManager,CharacterManager>();
builder.Services.AddScoped<IProfessionSkillManager,ProfessionSkillManager>();
builder.Services.AddScoped<ISpecificSkillManager,SpecificSkillManager>();
builder.Services.AddScoped<ICharacterStatManager,CharacterStatManager>();
builder.Services.AddScoped<IRaceStatManager,RaceStatManager>();

builder.Services.AddScoped<IThumbImgCharacterManager,ThumbImgCharacterManager>();
builder.Services.AddScoped<IThumbImgNarrativeManager,ThumbImgNarrativeManager>();
builder.Services.AddScoped<IThumbImgRaceManager,ThumbImgRaceManager>();
builder.Services.AddScoped<IThumbImgWorldManager,ThumbImgWorldManager>();



// registrase automapperu
builder.Services.AddAutoMapper(typeof(AutoMapperConfigurationProfile));

//Add authorization policies
Policy.SetPolicies(builder);

// Registrace loggeru
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//add swagger
builder.Services.AddSwaggerGen();


//-----------------------------------------------------------------------------------------------
var app = builder.Build();

// Migration database to last version
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<HoLWebDbContext>();
    dbContext.Database.Migrate();
}

// Seed Roles
SeedRoll.Seed(app);


// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json","HeroesOfLegends API V1"); });
}
else
{
    app.UseExceptionHandler("/Error",createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();


// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

// Controllers endpoints
app.MapControllers();

// 
app.UseAuthorization();


app.Run();

