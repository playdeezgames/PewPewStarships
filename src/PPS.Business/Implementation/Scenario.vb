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
            Data.CurrentFaction = value.FactionIndex
        End Set
    End Property

    Public ReadOnly Property IsCompleted As Boolean Implements IScenario.IsCompleted
        Get
            Return Not Data.CurrentFaction.HasValue
        End Get
    End Property

    Public ReadOnly Property Ships As IEnumerable(Of IShip) Implements IScenario.Ships
        Get
            Dim shipIndex = 0
            Dim result As New List(Of IShip)
            For Each ship In Data.Ships
                result.Add(New Ship(Data, shipIndex))
                shipIndex += 1
            Next
            Return result
        End Get
    End Property

    Public Sub NextFaction() Implements IScenario.NextFaction
        If Not Data.CurrentFaction.HasValue Then
            Return
        End If
        Dim factionCount = Ships.Select(Function(x) x.Faction.FactionIndex).Distinct().Count
        If factionCount < 2 Then
            Data.CurrentFaction = Nothing
            Return
        End If
        Do
            Dim candidate = (Data.CurrentFaction.Value + 1)
            If candidate >= Data.Factions.Count Then
                UpdateShips()
            End If
            Data.CurrentFaction = candidate Mod Data.Factions.Count
        Loop Until CurrentFaction.Ships.Any
    End Sub

    Private Sub UpdateShips()
        For Each ship In Ships
            ship.Update()
        Next
    End Sub

    Public Function CreateFaction() As IFaction Implements IScenario.CreateFaction
        Dim factionIndex = Data.Factions.Count
        Data.Factions.Add(New FactionData)
        Return New Faction(Data, factionIndex)
    End Function

    Public Function AddShip(faction As IFaction, x As Double, y As Double) As IShip Implements IScenario.AddShip
        Dim shipIdentifier = Data.Ships.Count
        Data.Ships.Add(
            New ShipData With
            {
                .FactionIndex = faction.FactionIndex,
                .X = x,
                .Y = y
            })
        Return New Ship(Data, shipIdentifier)
    End Function
End Class
