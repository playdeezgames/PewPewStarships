Friend Module IntroductoryScenario
    Friend Function Create() As IScenario
        Dim scenario As IScenario = New Scenario With {
            .Introduction = "This is the introductory scenario."
        }
        CreatePlayerFaction(scenario)
        CreateComputerFaction(scenario)
        Return scenario
    End Function

    Private Sub CreateComputerFaction(scenario As IScenario)
        Dim aiFaction = scenario.CreateFaction()
        aiFaction.Name = "Computer"
        aiFaction.IsHuman = False
        Dim ship = scenario.AddShip(aiFaction)
        ship.X = 100.0
        ship.Y = 0.0
    End Sub

    Private Sub CreatePlayerFaction(scenario As IScenario)
        Dim playerFaction = scenario.CreateFaction()
        playerFaction.Name = "Player"
        playerFaction.IsHuman = True
        scenario.CurrentFaction = playerFaction
        Dim ship = scenario.AddShip(playerFaction)
        ship.X = -100.0
        ship.Y = 0.0
    End Sub
End Module
