var osArch = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder
    .AddSqlServer("sqlserver", null, 1433)
    .WithLifetime(ContainerLifetime.Persistent);

if (osArch == System.Runtime.InteropServices.Architecture.Arm64 
    && System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
{
    sqlServer.WithImage("azure-sql-edge");
}

var db = sqlServer.AddDatabase("coalescescratchdb");

var emsServer =
    builder.AddProject<Projects.Scratch_CoalesceScratch_Web>("coalescescratchserver",
            config => config.LaunchProfileName = "Kestrel")
        .WithReference(db).WaitFor(db);

builder.Build().Run();