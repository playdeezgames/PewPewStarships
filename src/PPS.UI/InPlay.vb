Imports System.Security

Friend Module InPlay
    Friend Sub Run(scenario As IScenario)
        Do While Not scenario.IsCompleted
            Dim faction = scenario.CurrentFaction
            If faction.IsHuman Then
                HumanTurn.Run(faction)
            Else
                RunComputerTurn(faction)
            End If
            scenario.NextFaction()
        Loop
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("Scenario Complete!")
        OkPrompt()
    End Sub

    Private Sub RunComputerTurn(faction As IFaction)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{faction.Name}'s turn:")
        OkPrompt()
    End Sub
End Module
