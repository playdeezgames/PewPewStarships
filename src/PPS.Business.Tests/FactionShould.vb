Public Class FactionShould
    <Fact>
    Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        faction.ShouldNotBeNull
        faction.Name.ShouldBeNull
        faction.IsHuman.ShouldBeFalse
        faction.FactionIndex.ShouldBe(0)
        faction.Ships.ShouldBeEmpty
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
    <Fact>
    Sub allow_setting_a_human_player()
        Const expected = True
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        faction.IsHuman = expected
        Dim actual = faction.IsHuman
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub have_ships()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        scenario.AddShip(faction)
        faction.Ships.ShouldHaveSingleItem
    End Sub
End Class
