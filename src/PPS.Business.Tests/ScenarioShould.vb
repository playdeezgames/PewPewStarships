Public Class ScenarioShould
    <Fact>
    Sub have_expected_initial_values()
        Dim subject As IScenario = New Scenario
        subject.ShouldNotBeNull
    End Sub
End Class

