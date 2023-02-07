Friend Module IntroductoryScenario
    Friend Function CreateIntroductoryScenario() As IScenario
        Dim scenario As IScenario = New Scenario With {
            .Introduction = "This is the introductory scenario."
        }
        Dim playerFaction = scenario.CreateFaction()
        playerFaction.Name = "Player"
        playerFaction.IsHuman = True
        scenario.CurrentFaction = playerFaction
        Dim aiFaction = scenario.CreateFaction()
        aiFaction.Name = "Computer"
        aiFaction.IsHuman = False

        Return scenario
    End Function
End Module
