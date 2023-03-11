using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Data;
using System.Collections.ObjectModel;
using Serilog.Events;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .CreateLogger();
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);



//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


//static void Main(string[] args)
//{
//    Console.WriteLine("ajþfsadasdsads");
//    Log.Logger = new LoggerConfiguration()
//           .MinimumLevel.Information()
//           .WriteTo.MSSqlServer(
//               connectionString: "Server=IRMTPCM;Database=boncuk;User Trusted_Connection = True;",
//               sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" },
//               columnOptions: new ColumnOptions
//               {
//                   AdditionalColumns = new Collection<SqlColumn>
//                   {
//                        new SqlColumn { ColumnName = "MachineName", DataType = SqlDbType.NVarChar, DataLength = 50 },
//                        new SqlColumn { ColumnName = "Logged", DataType = SqlDbType.DateTime },
//                   }

//               })
//           .CreateLogger();

//    Console.WriteLine("irem topcam kodlama ogreniyor");

//    Log.Information("Uygulama baþlatýldý");

//    /////
//    Log.Debug("neyin debugý");

//    Log.Information("Uygulama kapatýldý");
//    Log.CloseAndFlush();
//}











//using Serilog.Sinks.MSSqlServer;
//using Serilog;
//using System.Data;
//using System.Collections.ObjectModel;
//using Serilog.Events;
//using Serilog.Formatting.Compact;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//// Configure Serilog logger
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.MSSqlServer(
//        connectionString: "Server=IRMTPCM;Database=LogDB;Trusted_Connection = True;",
//        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" },
//        columnOptions: new ColumnOptions
//        {
//            AdditionalColumns = new Collection<SqlColumn>
//            {
//                new SqlColumn { ColumnName = "MachineName", DataType = SqlDbType.NVarChar, DataLength = 50 },
//                new SqlColumn { ColumnName = "Logged", DataType = SqlDbType.DateTime },
//            }

//        })
//    .CreateLogger();

//app.UseSerilogRequestLogging();

//app.Run(async (context) =>
//{
//    Log.Information("Handling request {RequestMethod} {RequestPath}", context.Request.Method, context.Request.Path);

//    await context.Response.WriteAsync("Hello World!");
//});

//Log.Information("Starting web host");
//app.Run();

//Log.Information("Stopping web host");
//Log.CloseAndFlush();
