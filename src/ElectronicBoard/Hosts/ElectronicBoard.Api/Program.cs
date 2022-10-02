using ElectronicBoard.Registrar.Registrars.StartupRegistrars;

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();