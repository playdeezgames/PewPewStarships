Friend Module Utlity
    Friend Sub OkPrompt()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("OK")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
