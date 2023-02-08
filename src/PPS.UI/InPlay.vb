Imports System.Security

Friend Module InPlay
    Friend Sub Run(scenario As IScenario)
        Do While Not scenario.IsCompleted
            Dim faction = scenario.CurrentFaction
            If faction.IsHuman Then
                HumanTurn.Run(faction)
            Else
                ComputerTurn.Run(faction)
            End If
            scenario.NextFaction()
        Loop
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("Scenario Complete!")
        OkPrompt()
    End Sub
End Module
