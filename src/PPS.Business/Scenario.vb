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

    Public ReadOnly Property IsCompleted As Boolean Implements IScenario.IsCompleted
        Get
            Return Not Data.CurrentFaction.HasValue
        End Get
    End Property

    Public ReadOnly Property Ships As IEnumerable(Of IShip) Implements IScenario.Ships
        Get
            Return Data.Ships.Select(Function(x) New Ship(Data, x.Key))
        End Get
    End Property

    Public Sub NextFaction() Implements IScenario.NextFaction
        If Not Data.CurrentFaction.HasValue Then
            Return
        End If
        'how many factions have ships?
        Dim factionsWithShips As New HashSet(Of Integer)
        For Each ship In Ships

        Next
        'if <2, then the scenario is over
        Throw New NotImplementedException()
    End Sub

    Public Function CreateFaction() As IFaction Implements IScenario.CreateFaction
        Dim factionIndex = Data.Factions.Count
        Data.Factions.Add(New FactionData)
        Return New Faction(Data, factionIndex)
    End Function

    Public Function AddShip() As IShip Implements IScenario.AddShip
        Dim shipIdentifier As Guid = Guid.NewGuid
        Data.Ships.Add(shipIdentifier, New ShipData)
        Return New Ship(Data, shipIdentifier)
    End Function
End Class
