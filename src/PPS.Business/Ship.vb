Friend Class Ship
    Implements IShip
    Private _scenarioData As ScenarioData
    Private _shipIdentifier As Guid
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
End Class
