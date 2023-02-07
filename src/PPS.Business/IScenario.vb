Public Interface IScenario
    Property Introduction As String
    Property CurrentFaction As IFaction
    Function CreateFaction() As IFaction
    Function AddShip() As IShip
End Interface
