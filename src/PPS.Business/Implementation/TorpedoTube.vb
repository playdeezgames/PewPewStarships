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

    Private ReadOnly Property Data As TorpedoTubeData
        Get
            Return _scenarioData.Ships(_shipIdentifier).TorpedoTubes(_tubeIdentifier)
        End Get
    End Property
End Class
