Public Interface IFaction
    Property Name As String
    Property IsHuman As Boolean
    ReadOnly Property FactionIndex As Integer
    ReadOnly Property Ships As IEnumerable(Of IShip)
End Interface
