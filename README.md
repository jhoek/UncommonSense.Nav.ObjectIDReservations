# UncommonSense.Nav.ObjectIDReservations

PowerShell module for managing Microsoft Dynamics NAV object ID reservations

## Index

| Command | Synopsis |
| ------- | -------- |
| [Get-NAVObjectIDReservation](#Get-NAVObjectIDReservation) | Retrieves all NAV object ID reservations |
| [New-NavObjectIDReservation](#New-NavObjectIDReservation) | Creates one or more new NAV object ID reservations |
| [Remove-NavObjectIDReservation](#Remove-NavObjectIDReservation) | Removes one or more existing NAV object ID reservations |

<a name="Get-NAVObjectIDReservation"></a>
## Get-NAVObjectIDReservation
### Synopsis
Retrieves all NAV object ID reservations
### Syntax
```powershell
Get-NAVObjectIDReservation -DataFilePath <string> [-Comment <string>] [-UserName <string>] [-ObjectType <ObjectType[]>] [-BeforeLoad <scriptblock>] [-AfterSave <scriptblock>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.Nav.ObjectIDReservations.Reservation

### Parameters
#### Comment &lt;string&gt;
    Filters reservations by specified comment text.
    
    Required?                    false
    Position?                    named
    Default value                *
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### UserName &lt;string&gt;
    Filters reservations by specified user name.
    
    Required?                    false
    Position?                    named
    Default value                *
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### ObjectType &lt;ObjectType[]&gt;
    Filters reservations by specified object type.
    
    Required?                    false
    Position?                    named
    Default value                Table, Page, Report, Codeunit, XmlPort, Query, MenuSuite
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### DataFilePath &lt;string&gt;
    The path to your local reservations data file
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### BeforeLoad &lt;ScriptBlock&gt;
    The scriptblock to invoke before loading your local data file
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### AfterSave &lt;ScriptBlock&gt;
    The scriptblock to invoke after saving your local data file
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
<a name="New-NavObjectIDReservation"></a>
## New-NavObjectIDReservation
### Synopsis
Creates one or more new NAV object ID reservations
### Syntax
```powershell
New-NavObjectIDReservation [-ObjectType] <ObjectType> [-ObjectID] <int[]> [[-Comment] <string>] -DataFilePath <string> [-Force] [-BeforeLoad <scriptblock>] [-AfterSave <scriptblock>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.Nav.ObjectIDReservations.Reservation

### Parameters
#### ObjectType &lt;ObjectType&gt;
    The type of object to reserve
    
    Possible values: Table, Page, Report, Codeunit, XmlPort, Query, MenuSuite
    
    Required?                    true
    Position?                    1
    Default value                Table
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Accept wildcard characters?  false
#### ObjectID &lt;int[]&gt;
    One or more object IDs to reserve
    
    Required?                    true
    Position?                    2
    Default value                
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Accept wildcard characters?  false
#### Comment &lt;string&gt;
    Optional comment for the reservation
    
    Required?                    false
    Position?                    3
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### Force &lt;SwitchParameter&gt;
    If present, allows overwriting of other users&#39; reservations
    
    Required?                    false
    Position?                    named
    Default value                False
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### DataFilePath &lt;string&gt;
    The path to your local reservations data file
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### BeforeLoad &lt;ScriptBlock&gt;
    The scriptblock to invoke before loading your local data file
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### AfterSave &lt;ScriptBlock&gt;
    The scriptblock to invoke after saving your local data file
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
<a name="Remove-NavObjectIDReservation"></a>
## Remove-NavObjectIDReservation
### Synopsis
Removes one or more existing NAV object ID reservations
### Syntax
```powershell
Remove-NavObjectIDReservation [-ObjectType] <ObjectType> [-ObjectID] <int[]> -DataFilePath <string> [-Force] [-BeforeLoad <scriptblock>] [-AfterSave <scriptblock>] [<CommonParameters>]
```
### Parameters
#### ObjectType &lt;ObjectType&gt;
    The type of the reserved object
    
    Possible values: Table, Page, Report, Codeunit, XmlPort, Query, MenuSuite
    
    Required?                    true
    Position?                    1
    Default value                Table
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Accept wildcard characters?  false
#### ObjectID &lt;int[]&gt;
    The ID of the reserved object
    
    Required?                    true
    Position?                    2
    Default value                
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Accept wildcard characters?  false
#### Force &lt;SwitchParameter&gt;
    If present, allows removal of other users&#39; reservations
    
    Required?                    false
    Position?                    named
    Default value                False
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### DataFilePath &lt;string&gt;
    The path to your local reservations data file
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### BeforeLoad &lt;ScriptBlock&gt;
    The scriptblock to invoke before loading your local data file
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### AfterSave &lt;ScriptBlock&gt;
    The scriptblock to invoke after saving your local data file
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
<div style='font-size:small; color: #ccc'>Generated 06-03-2018 08:45</div>
