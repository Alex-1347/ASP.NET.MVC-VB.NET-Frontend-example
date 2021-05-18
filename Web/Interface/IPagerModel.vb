Public Interface IPagerModel(Of T As IListTotal(Of X), X)
    Property DataListT As T
    Property Skip As Integer
    Property PagerText As String
    Property Err1 As String
End Interface
