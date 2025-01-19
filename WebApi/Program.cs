using DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccess();
var app = builder.Build();


app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];
        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
    }
    else 
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});
app.Run();
