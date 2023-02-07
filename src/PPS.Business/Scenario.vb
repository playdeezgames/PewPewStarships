Public Class Scenario
    Implements IScenario
    Private ReadOnly Data As New ScenarioData

    Public Property Introduction As String Implements IScenario.Introduction
        Get
            Return Data.Introduction
        End Get
        Set(value As String)
            Data.Introduction = value
        End Set
    End Property

    Public Property CurrentFaction As IFaction Implements IScenario.CurrentFaction
        Get
            If Not Data.CurrentFaction.HasValue Then
                Return Nothing
            End If
            Return New Faction(Data, Data.CurrentFaction.Value)
        End Get
        Set(value As IFaction)
            If value Is Nothing Then
                Data.CurrentFaction = Nothing
            End If
            Data.CurrentFaction = DirectCast(value, Faction)._factionIndex
        End Set
    End Property

    Public Function CreateFaction() As IFaction Implements IScenario.CreateFaction
        Dim factionIndex = Data.Factions.Count
        Data.Factions.Add(New FactionData)
        Return New Faction(Data, factionIndex)
    End Function
End Class
