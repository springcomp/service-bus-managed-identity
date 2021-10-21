# Overview

This repository contains a sample application to publish a message to a service bus namespace topic.

## Setup

Register you application and set the appropriate credentials in the `appSettings.json` file:

```json
{
	"service-principals:sample-app-tenant-id": "<your-tenant-id",
	"service-principals:sample-app:client-id": "<your-client-id",

	"service-bus-namespaces:sample:namespace-name": "<fully-qualified-name-to-service-bus>",
}
```

For security reasons, it is recommanded to add your client secret as an ASP.Net secret
using the following command:

```pwsh
dotnet user-secrets set "service-principals:sample-app:client-secret" "<your-client-secret>"
```

Then you can run the application by specifying a topic name:

```pwsh
dotnet run -- <your-topic-name>
```
