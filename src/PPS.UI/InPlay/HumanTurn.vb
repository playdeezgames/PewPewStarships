Friend Module HumanTurn

    Friend Sub Run(faction As IFaction)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"{faction.Name}'s turn:")
            For Each ship In faction.Ships
                AnsiConsole.MarkupLine($"ID: {ship.Identifier}, Name: {ship.Name}, X: {ship.X:f}, Y: {ship.Y:f}, Heading: {ship.Heading:f}, Speed: {ship.Speed:f}")
            Next
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Yer Orders?[/]"}
            prompt.AddChoice(ChangeHeadingText)
            prompt.AddChoice(ChangeSpeedText)
            prompt.AddChoice(NextTurnText)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case ChangeHeadingText
                    ChangeHeading.Run(faction)
                Case ChangeSpeedText
                    ChangeSpeed.Run(faction)
                Case NextTurnText
                    Exit Do
            End Select
        Loop
    End Sub

End Module
