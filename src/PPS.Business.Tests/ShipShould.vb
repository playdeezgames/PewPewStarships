Public Class ShipShould
    <Fact>
    Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction)
        subject.ShouldNotBeNull
        subject.X.ShouldBe(0.0)
        subject.Y.ShouldBe(0.0)
        subject.Faction.ShouldNotBeNull
    End Sub
    <Fact>
    Sub set_x()
        Const expected = 1.0
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction)
        subject.X = expected
        Dim actual = subject.X
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub set_y()
        Const expected = 1.0
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction)
        subject.Y = expected
        Dim actual = subject.Y
        actual.ShouldBe(expected)
    End Sub
End Class
