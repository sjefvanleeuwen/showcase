. ./utilities/cli/Write-Menu.ps1
$menuReturn = Write-Menu -Title "Cowz n' Bullz Docker-Compose Areas" -Sort -MultiSelect -Entries @{
    "zeebe orchestration (with operator)" = "(start-process powershell {cd ./orchestration/zeebe/operate-simple-monitor | docker compose up})"
    "consumer micro frontend" = "(start-process powershell {cd ./micro-front-ends/consumer | docker compose up})"
}