param(
    [Parameter(Mandatory = $true)][string]$migrationName
)

Set-Location -Path ..\src

dotnet ef migrations add $migrationName --project "kangoeroes.infrastructure" --startup-project "kangoeroes.webUI"

Set-Location -Path ..\scripts #Return to initial location for less confusion