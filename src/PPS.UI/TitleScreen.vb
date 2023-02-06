Module TitleScreen

    Friend Sub Run()
        AnsiConsole.Clear()
        ShowTitle()
        OkPrompt()
    End Sub

    Private Sub ShowTitle()
        Dim figlet = New FigletText(PewPewStarshipsTitle) With {.Color = Color.Yellow, .Justification = Justify.Center}
        AnsiConsole.Write(figlet)
    End Sub

End Module
