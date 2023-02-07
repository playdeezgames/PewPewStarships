Friend Class Ship
    Implements IShip

    Public ReadOnly Property X As Double Implements IShip.X
        Get
            Return 0.0
        End Get
    End Property

    Public ReadOnly Property Y As Double Implements IShip.Y
        Get
            Return 0.0
        End Get
    End Property
End Class
