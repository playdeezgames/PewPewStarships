Friend Module HumanTurn

    Friend Sub Run(faction As IFaction)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{faction.Name}'s turn:")
        For Each ship In faction.Ships
            AnsiConsole.MarkupLine($"ID: {ship.Identifier}, Name: {ship.Name}, X: {ship.X:f}, Y: {ship.Y:f}, Heading: {ship.Heading:f}, Speed: {ship.Speed:f}")
        Next
        OkPrompt()
    End Sub

End Module
