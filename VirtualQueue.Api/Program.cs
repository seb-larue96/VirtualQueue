using VirtualQueue.Api.Extensions;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureApplicationBuilder();

var app = builder
    .Build()
    .ConfigureApplication();

try
{
    app.Run();
}
catch (Exception ex)
{

}
finally
{

}