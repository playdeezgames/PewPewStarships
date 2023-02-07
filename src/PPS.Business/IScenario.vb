Public Interface IScenario
    Property Introduction As String
    Property CurrentFaction As IFaction
    Function CreateFaction() As IFaction
    Function AddShip() As IShip
    Sub NextFaction()
    ReadOnly Property IsCompleted As Boolean
End Interface
