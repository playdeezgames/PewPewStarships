﻿Friend Class Faction
    Implements IFaction
    Private ReadOnly _scenarioData As ScenarioData
    Private ReadOnly _factionIndex As Integer
    Private ReadOnly Property Data As FactionData
        Get
            Return _scenarioData.Factions(_factionIndex)
        End Get
    End Property

    Sub New(scenarioData As ScenarioData, factionIndex As Integer)
        _scenarioData = scenarioData
        _factionIndex = factionIndex
    End Sub

    Public Property Name As String Implements IFaction.Name
        Get
            Return Data.Name
        End Get
        Set(value As String)
            Data.Name = value
        End Set
    End Property

    Public Property IsHuman As Boolean Implements IFaction.IsHuman
        Get
            Return Data.IsHuman
        End Get
        Set(value As Boolean)
            Data.IsHuman = value
        End Set
    End Property

    Public ReadOnly Property FactionIndex As Integer Implements IFaction.FactionIndex
        Get
            Return _factionIndex
        End Get
    End Property

    Public ReadOnly Property Ships As IEnumerable(Of IShip) Implements IFaction.Ships
        Get
            Return _scenarioData.Ships.Where(Function(x) x.Value.FactionIndex = _factionIndex).Select(Function(x) New Ship(_scenarioData, x.Key))
        End Get
    End Property
End Class
