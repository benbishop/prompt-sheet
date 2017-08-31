#addin "Cake.Xamarin"
#addin "Cake.FileHelpers"
#tool nunit.consolerunner
#tool gitlink

var target = Argument("target", Argument("t", "package"));
var version = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", "0.0.9999");

Setup(x =>
{    

    DeleteFiles("./*.nupkg");
    DeleteFiles("./output/*.*");

    if (!DirectoryExists("./output"))
        CreateDirectory("./output");
});

Task("build")
    .Does(() =>
{
    NuGetRestore("./Lib.sln");
    DotNetBuild("./Lib.sln", x => x
        .SetConfiguration("Release")
        .SetVerbosity(Verbosity.Minimal)
        .WithProperty("TreatWarningsAsErrors", "false")
    );
});

Task("package")
    .IsDependentOn("build")
    .Does(() =>
{    
    NuGetPack(new FilePath("./prompt-sheet.nuspec"), new NuGetPackSettings() 
    {
        Version = version,
        Verbosity = NuGetVerbosity.Detailed,
    });
    MoveFiles("./*.nupkg", "./output");
});

RunTarget(target);
