# Azure KeyVault Multi Environment Deployment Demo
The following repository demonstrates how an organization that deploys to multiple environments (development, staging, production, etc.) can access secrets from their respective Azure Key Vault in a secure and limited way.

In order for this code example to work you must create the appropriate azurekeyvault.ENV.json file and place it in your root directory. This file is part of the .gitignore and should never be checked in as it contains your client secret for accessing your secure Azure Key Vault. The file should be of the following format:

```JSON
{
  "AzureKeyVault": {
     "Endpoint": "YOUR_KEYVAULT_ENDPOINT_GOES_HERE",
     "ClientId": "CLIENT_ID_GOES_HERE",
     "ClientSecret": "CLIENT_SECRET_GOES_HERE"
   }
}
```

For further information please read the associated blog post:
