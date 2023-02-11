Friend Module FireTorpedo
    Friend Sub Run(faction As IFaction)
        Dim tube = PickTorpedoTube(faction)
        If tube Is Nothing Then
            Return
        End If
        If Not tube.CanFire Then
            AnsiConsole.MarkupLine("You cannot fire that torpedo tube.")
            Return
        End If
        Dim target = PickShip(faction.EnemyShips)
        If target Is Nothing Then
            Return
        End If
        tube.Fire(target)
        If target.IsDestroyed Then
            AnsiConsole.MarkupLine($"{target.Name} is destroyed.")
        End If
    End Sub
End Module
