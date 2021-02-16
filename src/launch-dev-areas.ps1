. ./utilities/cli/Write-Menu.ps1

$menuReturn = Write-Menu -Title "Cowz n' Bullz Dev Areas" -Sort -MultiSelect -Entries "dapr","piral","pilets","documentation","simulation"

foreach ($i in $menuReturn){
    Write-Host 'launching area' $i
    switch($i) {
        # Micro services area
        "dapr" {code ./dapr/}
        # Piral portal area
        "piral" {code ./piral/}
        # Pilets area (web assembly micro front ends)
        "pilets" {code ./blazor/}
        # Documentation area
        "documentation" {code ./}
        # Simulation area
        "simulation" {code ./simulation}
    }
}
