Public Class ShipShould
    <Fact>
    Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario
        Dim subject = scenario.AddShip()
        subject.ShouldNotBeNull
        subject.X.ShouldBe(0.0)
        subject.Y.ShouldBe(0.0)
    End Sub
    <Fact>
    Sub set_x()
        Const expected = 1.0
        Dim scenario As IScenario = New Scenario
        Dim subject = scenario.AddShip()
        subject.X = expected
        Dim actual = subject.X
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub set_y()
        Const expected = 1.0
        Dim scenario As IScenario = New Scenario
        Dim subject = scenario.AddShip()
        subject.Y = expected
        Dim actual = subject.Y
        actual.ShouldBe(expected)
    End Sub
End Class
