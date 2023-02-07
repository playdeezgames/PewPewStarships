Imports System.Security

Friend Module InPlay
    Friend Sub Run(scenario As IScenario)
        Do While Not scenario.IsCompleted
            Dim faction = scenario.CurrentFaction
            If faction.IsHuman Then
                RunHumanTurn(faction)
            Else
                'computer turn
            End If
            scenario.NextFaction()
        Loop
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("Scenario Complete!")
        OkPrompt()
    End Sub

    Private Sub RunHumanTurn(faction As IFaction)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{faction.Name}'s turn:")
        For Each ship In faction.Ships
            AnsiConsole.MarkupLine($"({ship.X},{ship.Y})")
        Next
        OkPrompt()
    End Sub
End Module
