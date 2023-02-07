Public Interface IShip
    Property X As Double
    Property Y As Double
    ReadOnly Property Faction As IFaction
    ReadOnly Property Heading As Double
    ReadOnly Property Speed As Double
End Interface
