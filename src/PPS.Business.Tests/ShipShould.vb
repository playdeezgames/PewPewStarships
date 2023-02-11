Public Class ShipShould
    <Fact>
    Sub have_expected_initial_values()
        Const x = 1.0
        Const y = 2.0
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, x, y)
        subject.ShouldNotBeNull
        subject.Name.ShouldBeNull
        subject.X.ShouldBe(x)
        subject.Y.ShouldBe(y)
        subject.Heading.ShouldBe(0.0)
        subject.Speed.ShouldBe(0.0)
        subject.Faction.ShouldNotBeNull
        subject.Identifier.ShouldBe(0)
        subject.ScanRange.ShouldBe(10.0)
        Dim scanResults = subject.Scan()
        scanResults.ShouldBeEmpty()
        subject.Torpedos.ShouldBe(0)
        subject.TorpedoTubes.ShouldBeEmpty
    End Sub
    <Fact>
    Sub set_heading()
        Const expected = 1.0
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        subject.Heading = expected
        Dim actual = subject.Heading
        actual.ShouldBe(expected)
    End Sub
    <Theory>
    <InlineData(0.5, 0.5)>
    <InlineData(0.0, 0.0)>
    <InlineData(1.0, 1.0)>
    <InlineData(-0.5, 0.0)>
    <InlineData(1.5, 1.0)>
    Sub set_speed(candidate As Double, expected As Double)
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        subject.Speed = candidate
        Dim actual = subject.Speed
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub set_name()
        Const expected = "name"
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        subject.Name = expected
        Dim actual = subject.Name
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub set_torpedo_count()
        Const expected = 5
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        subject.Torpedos = expected
        Dim actual = subject.Torpedos
        actual.ShouldBe(expected)
    End Sub
    <Theory>
    <InlineData(5.0, 1)>
    Sub scan_for_other_ships(otherShipX As Double, expectedCount As Integer)
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        scenario.AddShip(faction, otherShipX, 0.0)
        Dim scanResults = subject.Scan()
        scanResults.Count.ShouldBe(expectedCount)
    End Sub
    <Theory>
    <InlineData(5.0, 5.0)>
    Sub determine_distance_to_other_ship(otherShipX As Double, expectedDistance As Double)
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        Dim other = scenario.AddShip(faction, otherShipX, 0.0)
        Dim actual = subject.DistanceFrom(other)
        actual.ShouldBe(expectedDistance)
    End Sub
    <Theory>
    <InlineData(5.0, 5.0, 45.0)>
    Sub determine_heading_to_other_ship(otherShipX As Double, otherShipY As Double, expectedHeading As Double)
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        Dim other = scenario.AddShip(faction, otherShipX, otherShipY)
        Dim actual = subject.HeadingTo(other)
        actual.ShouldBe(expectedHeading)
    End Sub
    <Fact>
    Sub update()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        subject.Torpedos = 1
        Dim tube = subject.AddTorpedoTube
        tube.Load()
        subject.Heading = 90
        subject.Speed = 1.0
        subject.Update()
        tube.CanFire.ShouldBeTrue
        subject.X.ShouldBe(0.00000000000000006123233995736766)
        subject.Y.ShouldBe(1.0)
    End Sub
    <Fact>
    Sub add_a_torpedo_tube()
        Dim scenario As IScenario = New Scenario
        Dim faction = scenario.CreateFaction()
        Dim subject = scenario.AddShip(faction, 0.0, 0.0)
        Dim tube As ITorpedoTube = subject.AddTorpedoTube()
        tube.ShouldNotBeNull
        subject.TorpedoTubes.ShouldHaveSingleItem
    End Sub
End Class
