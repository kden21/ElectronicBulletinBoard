using ElectronicBoard.Registrar.Registrars.StartupRegistrars;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();