Friend Module LoadTorpedo
    Friend Sub Run(faction As IFaction)
        Dim ship = PickShip(faction.Ships)
        If ship Is Nothing Then
            Return
        End If
        Dim table = ship.TorpedoTubes.ToDictionary(Function(x) $"#{x.TubeIndex}", Function(x) x)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Tube?[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            Return
        End If
        Dim tube = table(answer)
        If tube.IsLoaded Then
            AnsiConsole.MarkupLine("Tube is already loaded!")
            Return
        End If
        If tube.CanLoad Then
            tube.Load()
            AnsiConsole.MarkupLine("You so loaded the tube!")
            Return
        End If
        AnsiConsole.MarkupLine("You cannot load the tube!")
    End Sub
End Module
