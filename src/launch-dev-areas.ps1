. ./utilities/cli/Write-Menu.ps1

$menuReturn = Write-Menu -Title "Cowz n' Bullz Dev Areas" -Sort -MultiSelect -Entries @{
    "dapr" = "(code ./dapr/)"
    "documentation" = "(code ../)"
    "simulation" = "(code ./simulation)"
    "orchestration (zeebe)" =  "(code ./orchestration/zeebe)"
    "micro front ends (consumer)" =  "(code ./micro-front-ends/consumer)"
}
