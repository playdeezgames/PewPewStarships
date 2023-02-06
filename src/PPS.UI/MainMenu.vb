Friend Module MainMenu
    Const QuitText = "Quit"
    Const NoText = "No"
    Const YesText = "Yes"
    Const MainMenuTitle = "[olive]Main Menu:[/]"
    Const ConfirmQuitTitle = "[red]Are you sure you want to quit?[/]"
    Friend Sub Run()
        Do While RunLoop()
        Loop
    End Sub

    Private Function RunLoop() As Boolean
        AnsiConsole.Clear()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = MainMenuTitle}
        prompt.AddChoices(QuitText)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case QuitText
                Return Not ConfirmQuit()
            Case Else
                Throw New NotImplementedException
        End Select
        Return True
    End Function
    Private Function ConfirmQuit() As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ConfirmQuitTitle}
        prompt.AddChoices(NoText, YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
End Module
