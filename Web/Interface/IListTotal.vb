Public Interface IListTotal(Of X)
    Property DataList As IEnumerable(Of X)
    Property Total As Integer
End Interface