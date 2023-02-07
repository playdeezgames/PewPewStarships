Imports System.Security

Friend Module InPlay
    Friend Sub Run(scenario As IScenario)
        Do While Not scenario.IsCompleted
            Dim faction = scenario.CurrentFaction
            If faction.IsHuman Then
                'human turn
            Else
                'computer turn
            End If
            scenario.NextFaction()
        Loop
        AnsiConsole.MarkupLine("Scenario Complete!")
        OkPrompt()
    End Sub
End Module
