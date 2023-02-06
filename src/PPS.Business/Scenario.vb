Public Class Scenario
    Implements IScenario
    Private Data As New ScenarioData

    Public Property Introduction As String Implements IScenario.Introduction
        Get
            Return Data.Introduction
        End Get
        Set(value As String)
            Data.Introduction = value
        End Set
    End Property

    Public Function CreateFaction() As IFaction Implements IScenario.CreateFaction
        Dim factionIndex = Data.Factions.Count
        Data.Factions.Add(New FactionData)
        Return New Faction(Data, factionIndex)
    End Function
End Class
