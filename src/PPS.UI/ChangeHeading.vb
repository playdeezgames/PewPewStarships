Friend Module ChangeHeading
    Friend Sub Run(faction As IFaction)
        AnsiConsole.Clear()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Ship?[/]"}
        Dim table = faction.Ships.ToDictionary(Function(x) $"#{x.Identifier}: {x.Name}", Function(x) x)
        prompt.AddChoices(table.Keys)
        prompt.AddChoice(NeverMindText)
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            Return
        End If
        Dim ship = table(answer)
        ship.Heading = AnsiConsole.Ask("[olive]New Heading?[/]", ship.Heading)
    End Sub
End Module
