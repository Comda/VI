﻿
Module PrivateMethods

    Private Function GetProductId(ByVal SKU As String) As Integer
        Dim prodid As Integer = 0
        Try
            If Not IsNothing(catalogProduct.Find(Function(x) x.sku.Equals(SKU.Trim))) Then
                prodid = catalogProduct.Find(Function(x) x.sku.Equals(SKU.Trim)).product_id
            End If
        Catch ex As Exception
            Api_Para.WriteEventToLog("Error", "GetProductId", ex.Message, StopwatchLocal, Guid.Parse(TransactionID_Current), ControlRoot_Current)
        End Try

        Return prodid
    End Function

    Public Sub InitializeSQLVariables(ByVal dbConnection As SqlClient.SqlConnection)


        Magento_ProductCatalog_TierPrice_QA_da = New Magento_StoreTableAdapters.Magento_ProductCatalog_TierPrice_QATableAdapter
        Magento_ProductCatalog_TierPrice_QA_da.Connection = dbConnection

        Magento_ProductCatalog_TierPrice_QA_Compare_da = New Magento_StoreTableAdapters.Magento_ProductCatalog_TierPrice_QA_CompareTableAdapter
        Magento_ProductCatalog_TierPrice_QA_Compare_da.Connection = dbConnection
        Magento_ProductCatalog_TierPrice_Universe_GET_da = New Magento_StoreTableAdapters.Magento_ProductCatalog_TierPrice_Universe_GETTableAdapter
        Magento_ProductCatalog_TierPrice_Universe_GET_da.Connection = dbConnection


        Magento_Store_ds = New Magento_Store


    End Sub

    Public Sub InitializeSQLVariables_ERP(ByVal dbConnection As SqlClient.SqlConnection)
        GetTierPricesFromERP_da = New Magento_StoreTableAdapters.GetTierPricesFromERPTableAdapter
        GetTierPricesFromERP_da.Connection = dbConnection
        ProductFeedData_Buffer_DELETE = New Magento_StoreTableAdapters.ProductFeedData_Buffer_DELETETableAdapter
        ProductFeedData_Buffer_DELETE.Connection = dbConnection
    End Sub
End Module
