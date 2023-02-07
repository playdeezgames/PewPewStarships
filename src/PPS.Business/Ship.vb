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

    Public Property Heading As Double Implements IShip.Heading
        Get
            Return Data.Heading
        End Get
        Set(value As Double)
            Data.Heading = value
        End Set
    End Property

    Public Property Speed As Double Implements IShip.Speed
        Get
            Return Data.Speed
        End Get
        Set(value As Double)
            Data.Speed = Math.Clamp(value, 0.0, 1.0)
        End Set
    End Property

    Public Property Name As String Implements IShip.Name
        Get
            Return Data.Name
        End Get
        Set(value As String)
            Data.Name = value
        End Set
    End Property
End Class
