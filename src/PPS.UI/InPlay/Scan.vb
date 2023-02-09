Friend Module Scan
    Friend Sub Run(faction As IFaction)
        Dim ship = PickShip(faction.Ships)
        If ship Is Nothing Then
            Return
        End If
        Dim otherShips = ship.Scan()
        AnsiConsole.MarkupLine($"{ship.Name} sees {otherShips.Count} other ships.")
        OkPrompt()
    End Sub
End Module
