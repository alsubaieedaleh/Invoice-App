using Microsoft.EntityFrameworkCore;
using invoiceApp.Data;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InvoiceDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

var cultureInfo = new CultureInfo("ar-SA");
cultureInfo.NumberFormat.CurrencySymbol = "\u20C1";
cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
cultureInfo.DateTimeFormat.Calendar = new GregorianCalendar();
cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
if (!app.Environment.IsDevelopment())
{
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();
