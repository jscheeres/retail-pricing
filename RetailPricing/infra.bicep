@description('The location of the resourcegroup')
param location string = resourceGroup().location
@description('The name of the project')
param projectName string
@description('The environment to deploy to (tst/prd)')
param env string

var storageAccountName =  replace('${projectName}${env}st', '-', '')

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-09-01' = {
  name: storageAccountName
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Standard_ZRS'
  }
  tags: {
    Environment: env
    Project: 'hip'
    Application: containerAppName
  }
}