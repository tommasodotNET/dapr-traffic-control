# Lab Day 1

## Introduction

First of all, get familiar with the README.md file in the root of this repository. It contains a lot of useful information about the lab.

## Prerequisites

- [ ] Install [Docker Desktop](https://www.docker.com/products/docker-desktop) on your laptop.
- [ ] Install [Visual Studio Code](https://code.visualstudio.com/) on your laptop.
- [ ] Install [Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/) on your laptop.
- [ ] Install [Postman](https://www.postman.com/) on your laptop.

Optional:
- [ ] Install [Dapr Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-dapr) on your laptop.
- [ ] Install [C# extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) on your laptop.

## Fill in the blanks

You have provided with a partial solution of the traffic control system application. In this lab you will add the Dapr building blocks you have seen so far. The `VehicleRegistrationService` is already completed. You will focus on the `FineCollectionService`.

### FineCollectionService

The `FineCollectionService` is responsible for collecting fines from drivers. It is a simple service that has a single endpoint: `POST /collectfine`. The service will be invoked by `TrafficControlService`using Pub/Sub building block. The `TrafficControlService`is not within the scope of the first lab, so you will not implement it. You will have to add necessary code to make it ready to be invoked by `TrafficControlService` via Pub/Sub.

Moreover, you will have to add the code to retrieve the vehicle's information from the `VehicleRegistrationService` using the Service Invocation building block. The `VehicleRegistrationService` is already implemented and you will not have to change it.

Lastly, you will have to use Dapr's Output Binding to send the email. As described in the README, the email service is simulated using Maildev.

### Dapr Components

You will find the email.yaml component ready to use, you will need to work on the pubsub.yaml that will be used also for day 2. Please refer to the [dapr docs](https://docs.dapr.io/reference/components-reference/supported-pubsub/setup-rabbitmq/).

## Test the services

Once you have implemented the `FineCollectionService`, you can test it following these steps:

1. Open Postman.

1. Test the `VehicleRegistrationService` with a GET request to `http://localhost:6002/vehicleinfo/13-XK-46`.

    > Alternatively you can also make the http call with the tool of your choice.

1. You should get this result:

    ![VehicleRegistrationService test](img/test-vehicleregistrationservice.png)

1. Test the `FineCollectionService` with a POST request to `http://localhost:6001/collectfine`.

1. Fill the request body with raw JSON as follow:

    ```console
    {
       "VehicleId": "13-XK-46",
       "RoadId": "A14",
       "ViolationInKmh": 20,
       "Timestamp": "2022-07-14T16:53:00"
    }
    ```
    > Alternatively you can also make the http call with the tool of your choice.

1. You should get a 200 OK result and check if there is a new email with the fine details.

1. To see the emails that are sent by the FineCollectionService, open a browser and browse to [http://localhost:4000](http://localhost:4000). You should see the emails coming in:

   ![Mailbox](img/mailbox.png)

That's all for your first lab.

See you for the last part!
