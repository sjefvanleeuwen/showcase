. ./utilities/cli/Write-Menu.ps1

$menuReturn = Write-Menu -Title "Cowz n' Bullz Debug Areas" -Sort -MultiSelect -Entries @{
    "debug micro front ends (consumer)" =  "cd ./micro-front-ends | ./micro-front-ends/debug-consumer.ps1"
}
