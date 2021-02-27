. ./utilities/cli/Write-Menu.ps1

$menuReturn = Write-Menu -Title "Cowz n' Bullz Dev Areas" -Sort -MultiSelect -Entries "dapr","documentation","simulation","micro front ends (consumer)"

foreach ($i in $menuReturn){
    Write-Host 'launching area' $i
    switch($i) {
        # Micro services area
        "dapr" {code ./dapr/}
        # Documentation area
        "documentation" {code ../}
        # Simulation area
        "simulation" {code ./simulation}
        # Micro Front Ends area
        "micro front ends (consumer)" {code ./micro-front-ends/consumer}
    }
}
