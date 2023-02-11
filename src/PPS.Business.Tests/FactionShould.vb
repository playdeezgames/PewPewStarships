Public Class FactionShould
    <Fact>
    Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.AddFaction()
        faction.ShouldNotBeNull
        faction.Name.ShouldBeNull
        faction.IsHuman.ShouldBeFalse
        faction.FactionIndex.ShouldBe(0)
        faction.Ships.ShouldBeEmpty
        faction.EnemyShips.ShouldBeEmpty
    End Sub
    <Fact>
    Sub allow_setting_a_name()
        Const expected = "name"
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.AddFaction()
        faction.Name = expected
        Dim actual = faction.Name
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub allow_setting_a_human_player()
        Const expected = True
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.AddFaction()
        faction.IsHuman = expected
        Dim actual = faction.IsHuman
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub have_ships()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.AddFaction()
        scenario.AddShip(faction, 0.0, 0.0)
        faction.Ships.ShouldHaveSingleItem
    End Sub
    <Fact>
    Sub have_enemy_ships()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.AddFaction()
        Dim otherFaction = scenario.AddFaction()
        scenario.AddShip(otherFaction, 0.0, 0.0)
        faction.EnemyShips.ShouldHaveSingleItem
    End Sub
End Class
