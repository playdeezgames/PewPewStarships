Public Interface IScenario
    Property Introduction As String
    Property CurrentFaction As IFaction
    Function AddFaction() As IFaction
    Function AddShip(faction As IFaction, x As Double, y As Double) As IShip
    Sub NextFaction()
    ReadOnly Property IsCompleted As Boolean
    ReadOnly Property Ships As IEnumerable(Of IShip)
End Interface
