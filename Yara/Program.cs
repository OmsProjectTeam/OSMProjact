
using static Infarstuructre.BL.IIExchangeRate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MasterDbcontext>(options => {
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("MasterConnection"));
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredUniqueChars = 0;
	options.Password.RequiredLength = 5;
	options.Password.RequireNonAlphanumeric = false;
	options.User.RequireUniqueEmail = true;
	//options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MasterDbcontext>();
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Admin/Accounts/Login";
	options.AccessDeniedPath = "/Admin/Home/Denied";
	options.Cookie.Name = "Cookie";
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
	options.SlidingExpiration = true;
});


builder.Services.AddScoped<IIUserInformation, CLSUserInformation>();
builder.Services.AddScoped<IIRolsInformation, CLSRolsInformation>();
builder.Services.AddScoped<IITypesCompanies, CLSTBTypesCompanies>();
builder.Services.AddScoped<IIInformationCompanies, CLSTBInformationCompanies>();
builder.Services.AddScoped<IICity, CLSCity>();
builder.Services.AddScoped<IITypeSystem, CLSTBTypeSystem>();
builder.Services.AddScoped<IICurrenciesExchangeRates, CLSTBCurrenciesExchangeRates>();
builder.Services.AddScoped<IIExchangeRate, CLSTBExchangeRate>();
builder.Services.AddScoped<IITransaction, CLSTBTransaction>();
builder.Services.AddScoped<IIShippingPrice, CLSTBShippingPrice>();
builder.Services.AddScoped<IIArea, CLSArea>();
builder.Services.AddScoped<IICityDeliveryTariffs, CLSTBCityDeliveryTariffs>();
builder.Services.AddScoped<IIAreaDeliveryTariffs, CLSTBAreaDeliveryTariffs>();
builder.Services.AddScoped<IICustomer, CLSCustomer>();
builder.Services.AddScoped<IIMerchant, CLSMerchant>();



// Controlers for APIs
builder.Services.AddControllers();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();





var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.UseSession();

app.MapControllerRoute(
	name: "areas",
	   pattern: "{area:exists}/{controller=Accounts}/{action=Login}/{id?}"
	);
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
