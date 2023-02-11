Public Class TorpedoTubeShould
    <Fact>
    Public Sub have_expected_initial_values()
        Dim scenario As IScenario = New Scenario()
        Dim faction = scenario.CreateFaction()
        Dim ship = scenario.AddShip(faction, 0.0, 0.0)
        Dim subject = ship.AddTorpedoTube()
        subject.ShouldNotBeNull
        subject.TubeIndex.ShouldBe(0)
        subject.CanLoad.ShouldBeFalse
        subject.IsLoaded.ShouldBeFalse
        subject.CanFire.ShouldBeFalse
    End Sub
    <Fact>
    Public Sub load()
        Dim scenario As IScenario = New Scenario()
        Dim faction = scenario.CreateFaction()
        Dim ship = scenario.AddShip(faction, 0.0, 0.0)
        ship.Torpedos = 1
        Dim subject = ship.AddTorpedoTube()
        subject.CanLoad.ShouldBeTrue
        subject.Load()
        subject.IsLoaded.ShouldBeTrue
        subject.CanLoad.ShouldBeFalse
        ship.Torpedos.ShouldBe(0)
        subject.CanFire.ShouldBeFalse
    End Sub
    <Fact>
    Public Sub update()
        Dim scenario As IScenario = New Scenario()
        Dim faction = scenario.CreateFaction()
        Dim ship = scenario.AddShip(faction, 0.0, 0.0)
        ship.Torpedos = 1
        Dim subject = ship.AddTorpedoTube()
        subject.Load()
        subject.Update()
        subject.CanFire.ShouldBeTrue
    End Sub
End Class
