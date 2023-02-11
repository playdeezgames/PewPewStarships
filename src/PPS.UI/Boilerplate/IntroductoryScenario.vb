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
        aiFaction.Name = "Second Player"
        aiFaction.IsHuman = True
        Dim ship = scenario.AddShip(aiFaction, 5.0, 0.0)
        ship.Name = "Ship#B1"
        ship.Torpedos = 10
        ship.AddTorpedoTube()
    End Sub

    Private Sub CreatePlayerFaction(scenario As IScenario)
        Dim playerFaction = scenario.CreateFaction()
        playerFaction.Name = "First Player"
        playerFaction.IsHuman = True
        scenario.CurrentFaction = playerFaction
        Dim ship = scenario.AddShip(playerFaction, -5.0, 0.0)
        ship.Name = "Ship#A1"
        ship.Torpedos = 10
        ship.AddTorpedoTube()
    End Sub
End Module
