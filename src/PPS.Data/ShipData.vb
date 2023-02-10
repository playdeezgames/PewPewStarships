Public Class ShipData
    Public Property X As Double
    Public Property Y As Double
    Public Property FactionIndex As Integer
    Public Property Heading As Double
    Public Property Speed As Double
    Public Property Name As String
    Public Property Torpedos As Integer
    Public Property TorpedoTubes As New List(Of TorpedoTubeData)
End Class
