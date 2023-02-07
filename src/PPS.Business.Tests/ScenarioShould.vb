Public Class ScenarioShould
    <Fact>
    Sub have_expected_initial_values()
        Dim subject As IScenario = New Scenario
        subject.ShouldNotBeNull
        subject.Introduction.ShouldBeNull
        subject.CurrentFaction.ShouldBeNull
    End Sub
    <Fact>
    Sub contain_an_introduction()
        Const expected = "i am an introduction"
        Dim subject As IScenario = New Scenario
        subject.ShouldNotBeNull
        subject.Introduction = expected
        Dim actual = subject.Introduction
        actual.ShouldBe(expected)
    End Sub
    <Fact>
    Sub create_a_faction()
        Dim subject As IScenario = New Scenario
        Dim faction = subject.CreateFaction()
        faction.ShouldNotBeNull
    End Sub
    <Fact>
    Sub set_current_faction()
        Dim subject As IScenario = New Scenario
        Dim faction = subject.CreateFaction()
        subject.CurrentFaction = faction
        subject.CurrentFaction.ShouldNotBeNull
    End Sub
End Class

