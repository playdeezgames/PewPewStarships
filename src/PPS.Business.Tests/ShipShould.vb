Public Class ShipShould
    <Fact>
    Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario
        Dim subject = scenario.AddShip()
        subject.ShouldNotBeNull
        subject.X.ShouldBe(0.0)
        subject.Y.ShouldBe(0.0)
    End Sub
End Class
