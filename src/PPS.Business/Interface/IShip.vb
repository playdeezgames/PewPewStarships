Public Interface IShip
    ReadOnly Property X As Double
    ReadOnly Property Y As Double
    ReadOnly Property Faction As IFaction
    Property Heading As Double
    Property Speed As Double
    Property Name As String
    ReadOnly Property Identifier As Integer
    Function Scan() As IEnumerable(Of IShip)
    ReadOnly Property ScanRange As Double
    Function DistanceFrom(other As IShip) As Double
    Function HeadingTo(other As IShip) As Double
    Sub Update()
    Function AddTorpedoTube() As ITorpedoTube
    ReadOnly Property TorpedoTubes As IEnumerable(Of ITorpedoTube)
    Property Torpedos As Integer
End Interface
