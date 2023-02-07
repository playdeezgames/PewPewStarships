Friend Class Ship
    Implements IShip
    Private ReadOnly _scenarioData As ScenarioData
    Private ReadOnly _shipIdentifier As Guid
    Sub New(scenarioData As ScenarioData, shipIdentifier As Guid)
        _scenarioData = scenarioData
        _shipIdentifier = shipIdentifier
    End Sub
    Private ReadOnly Property Data As ShipData
        Get
            Return _scenarioData.Ships(_shipIdentifier)
        End Get
    End Property

    Public Property X As Double Implements IShip.X
        Get
            Return Data.X
        End Get
        Set(value As Double)
            Data.X = value
        End Set
    End Property

    Public Property Y As Double Implements IShip.Y
        Get
            Return Data.Y
        End Get
        Set(value As Double)
            Data.Y = value
        End Set
    End Property

    Public ReadOnly Property Faction As IFaction Implements IShip.Faction
        Get
            Return New Faction(_scenarioData, Data.FactionIndex)
        End Get
    End Property

    Public ReadOnly Property Heading As Double Implements IShip.Heading
        Get
            Return 0.0
        End Get
    End Property

    Public ReadOnly Property Speed As Double Implements IShip.Speed
        Get
            Return 1.0
        End Get
    End Property
End Class
