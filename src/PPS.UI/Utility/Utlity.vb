Friend Module Utlity
    Friend Sub OkPrompt()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("OK")
        AnsiConsole.Prompt(prompt)
    End Sub
    Friend Function PickShip(ships As IEnumerable(Of IShip)) As IShip
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Ship?[/]"}
        Dim table = ships.ToDictionary(Function(x) $"#{x.Identifier}: {x.Name}", Function(x) x)
        prompt.AddChoices(table.Keys)
        prompt.AddChoice(NeverMindText)
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            Return Nothing
        End If
        Return table(answer)
    End Function
End Module
