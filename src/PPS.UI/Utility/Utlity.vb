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

    Friend Function PickTorpedoTube(faction As IFaction) As ITorpedoTube
        Dim ship = PickShip(faction.Ships)
        If ship Is Nothing Then
            Return Nothing
        End If
        Dim table = ship.TorpedoTubes.ToDictionary(Function(x) $"#{x.TubeIndex}, {If(x.IsLoaded, "LOADED", "UNLOADED")}, {If(x.CanFire, "CAN FIRE", "CANNOT FIRE")}", Function(x) x)
        AnsiConsole.MarkupLine($"{Ship.Name} has {Ship.Torpedos} torpedos available.")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Tube?[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            Return Nothing
        End If
        Return table(answer)
    End Function
End Module
