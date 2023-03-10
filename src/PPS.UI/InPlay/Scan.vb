Friend Module Scan
    Friend Sub Run(faction As IFaction)
        Dim ship = PickShip(faction.Ships)
        If ship Is Nothing Then
            Return
        End If
        Dim otherShips = ship.Scan()
        AnsiConsole.MarkupLine($"{ship.Name} sees {otherShips.Count} other ships:")
        For Each otherShip In otherShips
            AnsiConsole.MarkupLine($"Faction: {otherShip.Faction.Name}, Name: {otherShip.Name}, Distance: {otherShip.DistanceFrom(ship):f}, Heading: {ship.HeadingTo(otherShip):f}")
        Next
        OkPrompt()
    End Sub
End Module
