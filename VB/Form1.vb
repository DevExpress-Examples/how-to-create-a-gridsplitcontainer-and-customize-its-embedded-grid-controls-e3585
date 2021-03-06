﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Collections

Namespace CreateGridSplitContainer
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

			Dim dataSource As IList = CreateDataSource()

			Dim gridSplitContainer As New GridSplitContainer()
			gridSplitContainer.Parent = Me
			gridSplitContainer.Location = New Point(0, 0)
			gridSplitContainer.Size = New Size(350, 300)
			gridSplitContainer.Initialize()
			AddHandler gridSplitContainer.SplitViewCreated, AddressOf gridSplitContainer_SplitViewCreated

			' Customize the first grid control.
			Dim grid As GridControl = gridSplitContainer.Grid
			Dim view As GridView = TryCast(grid.MainView, GridView)
			' Specify a data source.
			grid.DataSource = dataSource
			' Resize columns according to their values.
			view.BestFitColumns()
			' Locate a row containing a specific value.
			view.FocusedRowHandle = view.LocateByValue("Country", "UK")

			' Display a splitter and second grid control.
			gridSplitContainer.ShowSplitView()

			' Customize the second grid control.
			Dim secondGrid As GridControl = gridSplitContainer.SplitChildGrid
			Dim secondView As GridView = TryCast(secondGrid.MainView, GridView)
			' Locate a row containing a specific value.
			secondView.FocusedRowHandle = secondView.LocateByValue("Country", "Sweden")
		End Sub

		Private Sub gridSplitContainer_SplitViewCreated(ByVal sender As Object, ByVal e As EventArgs)
			' Display the Embedded Navigator for the second grid control 
			' in the horizontally oriented Split View.
			Dim gsc As GridSplitContainer = TryCast(sender, GridSplitContainer)
			If (Not gsc.Horizontal) Then
				gsc.SplitChildGrid.UseEmbeddedNavigator = True
			End If
		End Sub


		Private Function CreateDataSource() As IList
			Dim list As New List(Of MyRecord)()
			list.Add(New MyRecord(1, "Rene Phillips", "USA"))
			list.Add(New MyRecord(2, "Robert McKinsey", "UK"))
			list.Add(New MyRecord(3, "Christina Berglund", "Sweden"))
			list.Add(New MyRecord(4, "Martín Sommer", "Spain"))
			list.Add(New MyRecord(5, "Laurence Lebihan", "France"))
			list.Add(New MyRecord(6, "Elizabeth Lincoln", "Canada"))
			list.Add(New MyRecord(7, "Steven Baum", "USA"))
			Return list
		End Function


	End Class

	Public Class MyRecord
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateCountry As String
		Public Property Country() As String
			Get
				Return privateCountry
			End Get
			Set(ByVal value As String)
				privateCountry = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Public Sub New(ByVal id As Integer, ByVal name As String, ByVal country As String)
			ID = id
			Name = name
			Country = country
		End Sub
	End Class
End Namespace