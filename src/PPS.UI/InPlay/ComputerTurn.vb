Friend Module ComputerTurn
    Friend Sub Run(faction As IFaction)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{faction.Name}'s turn:")
        OkPrompt()
    End Sub
End Module
