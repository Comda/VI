﻿Imports COMDA_COM_Product_QA.Magento_API

Module CommonProperties
#Region "Magento Entities"
    Public Property MageHandler As MagentoService
#End Region


#Region "SQL Varialbles"

    Friend WithEvents Magento_ProductCatalogImport_da As MagentoStoreTableAdapters.Magento_ProductCatalogImportTableAdapter
    Friend WithEvents Magento_ProductCatalogImport_SKU_Details_da As MagentoStoreTableAdapters.Magento_ProductCatalogImport_SKU_DetailsTableAdapter
    Friend WithEvents Magento_SOAP_Requests_da As MagentoStoreTableAdapters.Magento_SOAP_RequestsTableAdapter
    Friend WithEvents Magento_Store_ds As MagentoStore

#End Region


End Module