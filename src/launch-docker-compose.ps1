. ./utilities/cli/Write-Menu.ps1
$menuReturn = Write-Menu -Title "Cowz n' Bullz Dev Areas" -Sort -MultiSelect -Entries @{
    "consumer micro frontend" = "(start-process powershell {cd ./micro-front-ends/consumer | docker-compose up})"
}