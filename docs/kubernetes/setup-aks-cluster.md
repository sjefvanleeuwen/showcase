- [Deployment on Kubernetes](#deployment-on-kubernetes)
  - [Prerequisites](#prerequisites)
  - [Setup](#setup)
    - [Azure Resource Group Creation](#azure-resource-group-creation)
      - [Alternative location](#alternative-location)
    - [Azure Cluster Creation](#azure-cluster-creation)
    - [Connect to your Azure cluster](#connect-to-your-azure-cluster)

# Deployment on Kubernetes

The following describes deploying dapr on kubernetes on an azure AKS cluster.

## Prerequisites

* Create an (free) Azure Account if you don't already have one [here](https://azure.microsoft.com/en-us/)
* Installing Azure [Cli](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)

## Setup

This setup procedure will take you through 3 main steps:

1. Azure Resource Group Creation
2. Azure Cluster Creation
3. Connect to your Azure cluster

### Azure Resource Group Creation

```
az login
```

A web browser will open asking you to login with your account, if you are not already authenticated.

```
The default web browser has been opened at https://login.microsoftonline.com/common/oauth2/authorize. Please continue the login in the web browser. If no web browser is available or if the web browser fails to open, use device code flow with `az login --use-device-code`.
You have logged in. Now let us find all the subscriptions to which you have access...
The following tenants don't contain accessible subscriptions. Use 'az login --allow-no-subscriptions' to have tenant level access.
```

Your subscription details will appear as json.

```json
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
'experimentum'
[
  {
    "cloudName": "AzureCloud",
    "homeTenantId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx",
    "id": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx",
    "isDefault": true,
    "managedByTenants": [],
    "name": "Visual Studio Enterprise",
    "state": "Enabled",
    "tenantId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx",
    "user": {
      "name": "********",
      "type": "user"
    }
  }
]
```

Connect to your subscription that you want to provision the cluster in. My subscription is called "Visual Studio Enterprise"

```
az account set --subscription "Visual Studio Enterprise"
```

Now that we have switched to the subscription we want to use, we are ready to start provisioning an AKS cluster.

We will be provisioning a one node cluster.
Create a resource group in the desired location.

```
az group create --name showcase --location northeurope
```

Within seconds the command will respond with a succeeded provisionin state. Your resource group is now available.

```json
{
  "id": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/showcase",
  "location": "northeurope",
  "managedBy": null,
  "name": "showcase",
  "properties": {
    "provisioningState": "Succeeded"
  },
  "tags": null,
  "type": "Microsoft.Resources/resourceGroups"
}
```

#### Alternative location

If you wish to use another location, then you can list all available locations.

```
az account list-locations > locations.json
```

Here is a snippet of the list:

```json
...
{
    "displayName": "North Europe",
    "id": "/subscriptions/cef69e49-5a85-484b-a920-4a40fe9b4d35/locations/northeurope",
    "metadata": {
      "geographyGroup": "Europe",
      "latitude": "53.3478",
      "longitude": "-6.2597",
      "pairedRegion": [
        {
          "id": "/subscriptions/cef69e49-5a85-484b-a920-4a40fe9b4d35/locations/westeurope",
          "name": "westeurope",
          "subscriptionId": null
        }
      ],
      "physicalLocation": "Ireland",
      "regionCategory": "Recommended",
      "regionType": "Physical"
    },
    "name": "northeurope",
    "regionalDisplayName": "(Europe) North Europe",
    "subscriptionId": null
  }
...
```

Another great way of selecting your prefered region is to visit: https://azureprice.net/Region.
The ID column contains the name of the region you can use in the az cli, as well as the average VM costs indexed against other regions.

For a graphical overview (worldmap) of regions and more details per region visit: https://azure.microsoft.com/en-us/global-infrastructure/geographies/


### Azure Cluster Creation

We are now ready to set up the cluster in the created resource group. We will be creating a simple one node cluster for now.

```
az aks create --resource-group showcase --name showcase --node-count 1 --node-vm-size Standard_D2s_v3 --enable-addons monitoring --vm-set-type VirtualMachineScaleSets --generate-ssh-keys
```

Please wait for around 4 minutes for the cluster to be created. When the cluster is provisioned we can check its status by issuing the following command.

```
az aks show --name showcase --resource-group showcase
```

Notice the following entry:

```
provisioningState": "Succeeded",
```

Our cluster is now ready.

### Connect to your Azure cluster

You will need to install the kubernetes tools on your development environment. You can install the kubctl cli from within the `az` cli.

```
az aks install-cli
```

For authenticating to the cluster, you can merge your original credentials from the previous step with the AKS cli.

```
az aks get-credentials --name showcase --resource-group showcase
```

This will create your credentials in the kube config for the kubectl.

Now you can easily execute native kubctl commands.

```
kubectl get nodes

NAME                                STATUS   ROLES   AGE     VERSION
aks-nodepool1-32983209-vmss000000   Ready    agent   6m59s   v1.18.14
```

You should see the single node kubernetes cluster in ready state.

**note** Please stop the cluster when you don't need it to save costs (you will still have to pay for storage)...

```
az aks stop --resource-group showcase --name showcase
```

or start it again using

```
az aks start --resource-group showcase --name showcase
```


In the [next section](./setup-dapr.md) we will setup dapr on the cluster.



