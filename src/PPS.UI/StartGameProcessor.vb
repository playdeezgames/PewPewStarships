﻿Friend Module StartGameProcessor
    Const NeverMindText = "Never Mind"

    Private ReadOnly scenarioTable As IReadOnlyDictionary(Of String, Func(Of IScenario)) =
        New Dictionary(Of String, Func(Of IScenario)) From
        {
            {"Introductory Scenario(Easy)", AddressOf CreateIntroductoryScenario}
        }

    Private Function CreateIntroductoryScenario() As IScenario
        Throw New NotImplementedException()
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
        IntroductionProcessor.Run(scenarioTable(answer)())
    End Sub
End Module
