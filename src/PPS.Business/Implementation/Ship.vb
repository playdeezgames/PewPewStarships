Friend Class Ship
    Implements IShip
    Private ReadOnly _scenarioData As ScenarioData
    Private ReadOnly _shipIdentifier As Integer
    Sub New(scenarioData As ScenarioData, shipIdentifier As Integer)
        _scenarioData = scenarioData
        _shipIdentifier = shipIdentifier
    End Sub

    Public Function Scan() As IEnumerable(Of IShip) Implements IShip.Scan
        Dim result As New List(Of IShip)
        For index = 0 To _scenarioData.Ships.Count - 1
            If index = _shipIdentifier Then
                Continue For
            End If
            Dim otherShip = New Ship(_scenarioData, index)
            If otherShip.DistanceFrom(Me) <= ScanRange Then
                result.Add(otherShip)
            End If
        Next
        Return result
    End Function

    Public Function DistanceFrom(other As IShip) As Double Implements IShip.DistanceFrom
        Dim deltaX = other.X - X
        Dim deltaY = other.Y - Y
        Return Math.Sqrt(deltaX * deltaX + deltaY * deltaY)
    End Function

    Public Function HeadingTo(other As IShip) As Double Implements IShip.HeadingTo
        Return Math.Atan2(other.Y - Y, other.X - X) * 180.0 / Math.PI
    End Function

    Public Sub Move() Implements IShip.Move
        X += Math.Cos(Heading * Math.PI / 180.0) * Speed
        Y += Math.Sin(Heading * Math.PI / 180.0) * Speed
    End Sub

    Public Function AddTorpedoTube() As ITorpedoTube Implements IShip.AddTorpedoTube
        Dim tubeIdentifier = Data.TorpedoTubes.Count
        Data.TorpedoTubes.Add(New TorpedoTubeData)
        Return New TorpedoTube(_scenarioData, _shipIdentifier, tubeIdentifier)
    End Function

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

    Public ReadOnly Property Identifier As Integer Implements IShip.Identifier
        Get
            Return _shipIdentifier
        End Get
    End Property

    Public ReadOnly Property ScanRange As Double Implements IShip.ScanRange
        Get
            Return 10.0
        End Get
    End Property

    Public Property Torpedos As Integer Implements IShip.Torpedos
        Get
            Return Data.Torpedos
        End Get
        Set(value As Integer)
            Data.Torpedos = value
        End Set
    End Property

    Public ReadOnly Property TorpedoTubes As IEnumerable(Of ITorpedoTube) Implements IShip.TorpedoTubes
        Get
            Dim result As New List(Of ITorpedoTube)
            Dim index = 0
            For Each torpedoTube In Data.TorpedoTubes
                result.Add(New TorpedoTube(_scenarioData, _shipIdentifier, index))
                index += 1
            Next
            Return result
        End Get
    End Property
End Class
