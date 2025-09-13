using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Medical_Service>("api");
builder.AddExecutable(name: "meddb",
    command: "docker-compose",
    workingDirectory: "..\\..\\DataBase", 
    ["up", "-d"])
    .ExcludeFromManifest();


builder.Build().Run();
