Friend Module HumanTurn

    Friend Sub Run(faction As IFaction)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{faction.Name}'s turn:")
        For Each ship In faction.Ships
            AnsiConsole.MarkupLine($"{ship.Name}: ({ship.X},{ship.Y})")
        Next
        OkPrompt()
    End Sub

End Module
