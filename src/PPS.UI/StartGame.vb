Friend Module StartGame

    Private ReadOnly scenarioTable As IReadOnlyDictionary(Of String, Func(Of IScenario)) =
        New Dictionary(Of String, Func(Of IScenario)) From
        {
            {"Introductory Scenario(Easy)", AddressOf CreateIntroductoryScenario}
        }

    Private Function CreateIntroductoryScenario() As IScenario
        Dim scenario As IScenario = New Scenario With {
            .Introduction = "This is the introductory scenario."
        }
        Dim playerFaction = scenario.CreateFaction()
        Dim aiFaction = scenario.CreateFaction()
        Return scenario
    End Function

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
