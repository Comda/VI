﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server



Partial Public Class StoredProcedures
    <Microsoft.SqlServer.Server.SqlProcedure()>
    Public Shared Sub Magento_Synchronize_ERP(ByVal UserID As String, ByVal API_ID As String, ByVal ConnectionString As String, ByVal Action As String, ByVal dbContext As String, ByVal TransactionID As String)

        'Dim UserID As String = Me.tb_UserID.Text ' "jeromeb"
        'Dim API_ID As String = Me.tb_API_ID.Text ' "sophie"
        Dim ControlRoot As String = Action.ToUpper   'Me.tb_ControlRoot.Text ' "GetProductCatalog"
        'Dim TransactionID As String = Guid.NewGuid().ToString
        Dim dbcon As New SqlClient.SqlConnection
        dbcon.ConnectionString = ConnectionString

        Action = Action.ToUpper

        Select Case Action
            Case "UPDATE CATALOG"
                Dim MagentoType As String = Nothing

                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then

                    init.InitializeSQLVariables(dbcon, "PARENT")
                    init.GetCurrentCatalog(init.CurrentSessionID, "PARENT", MagentoType)

                    init.InitializeSQLVariables(dbcon, "FAMILY")
                    init.GetCurrentCatalog(init.CurrentSessionID, "FAMILY", MagentoType)

                    init.InitializeSQLVariables(dbcon, "CHILD")
                    init.GetCurrentCatalog(init.CurrentSessionID, "CHILD", MagentoType)
                End If

            Case "SYNCH NAMES"

                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim pu As New Magento_API_UpdateNameDescription.UpdateDescription(dbcon, init.CurrentSessionID, TransactionID, ControlRoot)
                End If
            Case "UPDATE SWATCH"

                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim po As New Magento_API_CustomOptions.CustomOptions(dbcon, init.CurrentSessionID, TransactionID, ControlRoot)
                End If

            Case "SETUP FEES"

                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim ps As New Magento_API_SetupFees.SetUpFees(dbcon, init.CurrentSessionID, TransactionID, ControlRoot)
                End If

            Case "MAGE_PRICE_DATA_COMPARE"
                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim CreateTierPrice As Boolean = False
                    Dim tp As New Magento_API_TierPrice.ChangeTierPrices(dbcon, init.CurrentSessionID, Guid.Parse(TransactionID), CreateTierPrice, Action)
                End If
            Case "MAGE_PRICE_DATA_UPDATE"
                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim CreateTierPrice As Boolean = True
                    Dim tp As New Magento_API_TierPrice.ChangeTierPrices(dbcon, init.CurrentSessionID, Guid.Parse(TransactionID), CreateTierPrice, Action)
                End If

            Case "ERP_PRICING COMPARE"

                Dim CreateTierPrice As Boolean = False
                Dim CreateTierPriceGRID As Boolean = False


                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim tp As New Magento_API_TierPrice.ChangeTierPrices(dbcon, init.CurrentSessionID, Guid.Parse(TransactionID), CreateTierPrice, CreateTierPriceGRID, Action)
                End If
            Case "ERP_PRICING UPLOAD"

                Dim CreateTierPrice As Boolean = False
                Dim CreateTierPriceGRID As Boolean = True


                Dim init As New Magento_API_Parameters.Initialize
                init.GetMagentoAPI_Credentials(UserID, API_ID, ControlRoot, TransactionID, dbContext)
                If init.CurrentSessionID.Length > 0 Then
                    Dim tp As New Magento_API_TierPrice.ChangeTierPrices(dbcon, init.CurrentSessionID, Guid.Parse(TransactionID), CreateTierPrice, CreateTierPriceGRID, Action)
                End If


        End Select

    End Sub
End Class
