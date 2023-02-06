﻿Module TitleScreen

    Friend Sub Run()
        AnsiConsole.Clear()
        ShowTitle()
        OkPrompt()
    End Sub

    Private Sub OkPrompt()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("OK")
        AnsiConsole.Prompt(prompt)
    End Sub

    Private Sub ShowTitle()
        Dim figlet = New FigletText("Pew Pew Starships!") With {.Color = Color.Yellow, .Justification = Justify.Center}
        AnsiConsole.Write(figlet)
    End Sub

End Module