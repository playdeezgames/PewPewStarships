Friend Module StartGame

    Private ReadOnly scenarioTable As IReadOnlyDictionary(Of String, Func(Of IScenario)) =
        New Dictionary(Of String, Func(Of IScenario)) From
        {
            {"Introductory Scenario(Easy)", AddressOf Create}
        }

    Friend Sub Run()
        AnsiConsole.Clear()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Choose Scenario:[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(scenarioTable.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            Return
        End If
        Introduction.Run(scenarioTable(answer)())
    End Sub
End Module
