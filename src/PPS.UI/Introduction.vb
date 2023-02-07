Friend Module Introduction
    Friend Sub Run(scenario As IScenario)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine(scenario.Introduction)
        OkPrompt()
        InPlay.Run(scenario)
    End Sub
End Module
