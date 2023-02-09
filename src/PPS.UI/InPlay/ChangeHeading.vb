Friend Module ChangeHeading
    Friend Sub Run(faction As IFaction)
        AnsiConsole.Clear()
        Dim ship = PickShip(faction.Ships)
        If ship Is Nothing Then
            Return
        End If
        ship.Heading = AnsiConsole.Ask("[olive]New Heading?[/]", ship.Heading)
    End Sub
End Module
