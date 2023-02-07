Public Interface IShip
    ReadOnly Property X As Double
    ReadOnly Property Y As Double
    ReadOnly Property Faction As IFaction
    Property Heading As Double
    Property Speed As Double
    Property Name As String
End Interface
