Public Class WorldShould
    <Fact>
    Sub have_expected_initial_values()
        Dim subject As IWorld = New World
        subject.ShouldNotBeNull
    End Sub
End Class

