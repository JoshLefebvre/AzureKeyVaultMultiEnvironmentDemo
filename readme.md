# Azure KeyVault Multi Environment Deployment Demo
The following repository demonstrates how an organization that deploys to multiple environments (development, staging, production, etc.) can use Azure Key Vault in a secure and limited way.

In order for this code example to work you must create the appropriate azurekeyvault.ENV.json file and place it in your root directory. This file is part of the .gitignore and should never be checked in as it contains your client secret for accessing your secure Azure Key Vault. The file should be of the following format:

<script src="https://gist.github.com/JoshLefebvre/ea8e1d006a6eacaf1f547a8ab974644a.js"></script>

For further information please read the associated blog post: