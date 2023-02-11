Friend Module LoadTorpedo
    Friend Sub Run(faction As IFaction)
        Dim tube = PickTorpedoTube(faction)
        If tube Is Nothing Then
            Return
        End If
        If tube.IsLoaded Then
            AnsiConsole.MarkupLine("Tube is already loaded!")
            OkPrompt()
            Return
        End If
        If tube.CanLoad Then
            tube.Load()
            AnsiConsole.MarkupLine("You so loaded the tube!")
            OkPrompt()
            Return
        End If
        AnsiConsole.MarkupLine("You cannot load the tube!")
        OkPrompt()
    End Sub
End Module
