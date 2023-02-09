Friend Module ChangeSpeed
    Friend Sub Run(faction As IFaction)
        Dim ship = PickShip(faction.Ships)
        If ship Is Nothing Then
            Return
        End If
        ship.Speed = AnsiConsole.Ask("[olive]New Speed?[/]", ship.Speed)
    End Sub
End Module
