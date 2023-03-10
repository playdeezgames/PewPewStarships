Friend Class TorpedoTube
    Implements ITorpedoTube

    Private ReadOnly _scenarioData As ScenarioData
    Private ReadOnly _shipIdentifier As Integer
    Private ReadOnly _tubeIdentifier As Integer

    Public Sub New(scenarioData As ScenarioData, shipIdentifier As Integer, tubeIdentifier As Integer)
        _scenarioData = scenarioData
        _shipIdentifier = shipIdentifier
        _tubeIdentifier = tubeIdentifier
    End Sub

    Public ReadOnly Property TubeIndex As Integer Implements ITorpedoTube.TubeIndex
        Get
            Return _tubeIdentifier
        End Get
    End Property

    Public ReadOnly Property IsLoaded As Boolean Implements ITorpedoTube.IsLoaded
        Get
            Return Data.IsLoaded
        End Get
    End Property

    Public ReadOnly Property CanLoad As Boolean Implements ITorpedoTube.CanLoad
        Get
            Return Not IsLoaded AndAlso Ship.Torpedos > 0
        End Get
    End Property

    Private ReadOnly Property Data As TorpedoTubeData
        Get
            Return _scenarioData.Ships(_shipIdentifier).TorpedoTubes(_tubeIdentifier)
        End Get
    End Property

    Public Sub Load() Implements ITorpedoTube.Load
        If CanLoad Then
            Ship.Torpedos -= 1
            Data.IsLoaded = True
            Data.CanFire = False
        End If
    End Sub

    Public Sub Update() Implements ITorpedoTube.Update
        Data.CanFire = Data.IsLoaded
    End Sub

    Public Sub Fire(target As IShip) Implements ITorpedoTube.Fire
        If Not CanFire Then
            Return
        End If
        Data.CanFire = False
        Data.IsLoaded = False
        'TODO: determine if target is destroyed
        'based on distance?
    End Sub

    Private ReadOnly Property Ship As IShip
        Get
            Return New Ship(_scenarioData, _shipIdentifier)
        End Get
    End Property

    Public ReadOnly Property CanFire As Boolean Implements ITorpedoTube.CanFire
        Get
            Return Data.CanFire
        End Get
    End Property
End Class
