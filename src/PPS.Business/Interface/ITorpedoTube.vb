Public Interface ITorpedoTube
    ReadOnly Property TubeIndex As Integer
    Sub Load()
    ReadOnly Property IsLoaded As Boolean
    ReadOnly Property CanLoad As Boolean
End Interface
