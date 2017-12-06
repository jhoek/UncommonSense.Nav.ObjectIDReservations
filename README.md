# UncommonSense.Nav.ObjectIDReservations

## Index

| Command | Synopsis |
| ------- | -------- |
| [Get-NAVObjectIDReservation](#Get-NAVObjectIDReservation) |  |
| [New-NavObjectIDReservation](#New-NavObjectIDReservation) |  |
| [Remove-NavObjectIDReservation](#Remove-NavObjectIDReservation) |  |

<a name="Get-NAVObjectIDReservation"></a>
## Get-NAVObjectIDReservation
### Synopsis

### Description
Retrieves all NAV object ID reservations

### Syntax
```powershell
Get-NAVObjectIDReservation -DataFilePath <string> [-BeforeLoad <scriptblock>] [-AfterSave <scriptblock>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.Nav.ObjectIDReservations.Reservation

### Parameters
#### DataFilePath &lt;string&gt;
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### BeforeLoad &lt;ScriptBlock&gt;
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### AfterSave &lt;ScriptBlock&gt;
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
<a name="New-NavObjectIDReservation"></a>
## New-NavObjectIDReservation
### Synopsis

### Description
Creates a new NAV object ID reservation

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
    
    Required?                    false
    Position?                    named
    Default value                False
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### DataFilePath &lt;string&gt;
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### BeforeLoad &lt;ScriptBlock&gt;
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### AfterSave &lt;ScriptBlock&gt;
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
<a name="Remove-NavObjectIDReservation"></a>
## Remove-NavObjectIDReservation
### Synopsis

### Description
Removes an existing NAV object ID reservation

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
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### BeforeLoad &lt;ScriptBlock&gt;
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### AfterSave &lt;ScriptBlock&gt;
    
    Required?                    false
    Position?                    named
    Default value                {}
    Accept pipeline input?       false
    Accept wildcard characters?  false
<div style='font-size:small; color: #ccc'>Generated 06-12-2017 12:04</div>
