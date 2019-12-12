Create a local db named TindyrDb

??You may need to install the dotnet ef feature for console??

Run these commands (After you access Tools > Command Line > Developer Command Prompt)

cd Persistence //gets you in the Persistence project folder

dotnet ef migrations add TindyrDbTestReady -s ..\Tindyr\Tindyr.csproj --context TindyrDbContext //adds a migration in the Persistence project for TindyrDbContext
dotnet ef database update -s ..\Tindyr\Tindyr.csproj --context TindyrDbContext//runs the migration from Persistence into Tindyr project, thus updating/creating all tables needed for TindyrDbContext

do the same for AppChat

run cd .. to step back from Persistence

then

cd AppChat
dotnet ef migrations add ChatDbTestReady -s ..\Tindyr\Tindyr.csproj --context ChatDbContext
dotnet ef database update -s ..\Tindyr\Tindyr.csproj --context ChatDbContext
