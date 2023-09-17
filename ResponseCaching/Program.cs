using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding response caching algrithm
builder.Services.AddResponseCompression(option =>
{
    //This enables compression for https by default it is disabled
    option.EnableForHttps = true;

    /*
     * These two compression provider already provided by .NET
     * IF Need we can add custom provider.
     */
    option.Providers.Add<BrotliCompressionProvider>();
    option.Providers.Add<GzipCompressionProvider>();

    //image is not supported in by defualt MIME Types
    option.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new string[] { "image/svg+html" });
});

//There are next options for each provider we can set as per we need.
builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    //Level fastes / No compression / small size / Optimal
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.SmallestSize;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseResponseCompression();

app.Run();
