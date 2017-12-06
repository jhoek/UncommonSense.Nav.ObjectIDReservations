Get-Module UncommonSense.Nav.ObjectIDReservations -ListAvailable | Import-Module -Force

Get-Command -Module UncommonSense.Nav.ObjectIDReservations |
    Sort-Object -Property Noun, Verb |
    Get-HelpAsMarkDown -Title UncommonSense.Nav.ObjectIDReservations -Description 'PowerShell module for managing Microsoft Dynamics NAV object ID reservations' |
    Out-File ./README.md -Encoding utf8