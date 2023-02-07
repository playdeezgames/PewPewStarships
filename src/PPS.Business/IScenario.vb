Public Interface IScenario
    Property Introduction As String
    Property CurrentFaction As IFaction
    Function CreateFaction() As IFaction
End Interface
