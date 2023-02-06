Public Class FactionShould
    <Fact>
    Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        faction.ShouldNotBeNull
        faction.Name.ShouldBeNull
    End Sub
    <Fact>
    Sub allow_setting_a_name()
        Const expected = "name"
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        faction.Name = expected
        Dim actual = faction.Name
        actual.ShouldBe(expected)
    End Sub
End Class
