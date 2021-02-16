. ./utilities/cli/Write-Menu.ps1

$menuReturn = Write-Menu -Title "Cowz n' Bullz Dev Spaces" -Sort -MultiSelect -Entries "dapr","piral","pilets","documentation"
Write-Host $menuReturn

foreach ($i in $menuReturn){
    Write-Host $i
    switch($i) {
        # Micro services area
        "dapr" {code ./dapr/}
        # Piral portal area
        "piral" {code ./piral/}
        # Pilets area (web assembly micro front ends)
        "pilets" {code ./blazor/}
        # Documentation area
        "documentation" {code ./}
    }
}
