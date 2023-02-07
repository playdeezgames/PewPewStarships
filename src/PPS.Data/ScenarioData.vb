Public Class ScenarioData
    Public Property Introduction As String
    Public Property Factions As New List(Of FactionData)
    Public Property CurrentFaction As Integer?
    Public Property Ships As New Dictionary(Of Guid, ShipData)
End Class
