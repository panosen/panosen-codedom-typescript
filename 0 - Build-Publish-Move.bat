@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Typescript\bin\Release\Panosen.CodeDom.Typescript.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Typescript.Engine\bin\Release\Panosen.CodeDom.Typescript.Engine.*.nupkg D:\LocalSavoryNuget\

pause