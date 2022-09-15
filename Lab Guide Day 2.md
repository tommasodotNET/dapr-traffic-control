# Lab Day 2

## Introduction

First of all, get familiar with the README.md file in the root of this repository. It contains a lot of useful information about the lab.

## Prerequisites

There is no additional prerequisites for this lab. Should you have missed the previous lab, here are the prerequisites:

- [ ] Install [Docker Desktop](https://www.docker.com/products/docker-desktop) on your laptop.
- [ ] Install [Visual Studio Code](https://code.visualstudio.com/) on your laptop.
- [ ] Install [Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/) on your laptop.
- [ ] Install [Postman](https://www.postman.com/) on your laptop.

Optional:
- [ ] Install [Dapr Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-dapr) on your laptop.
- [ ] Install [C# extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) on your laptop.

## Fill in the blanks

The repository you have been provided with contains the new services on which you will focus on today, and other services such as the `Simulation`, which is the application frontend.

In order to complete the lab, you can either work both on day1 and day2 repositories or merge them.
If you want to merge them, you will need to add the new projects into the `dapr-traffic-control.sln` solution file.

In this lab you will be focusing on the `TrafficControlService`, implemented in two different ways - with or without the Actor pattern.

### TrafficControlService - Without Actors

The `TrafficControlService` keeps track of new vehicles entering and exiting. In the end, it calculates the avarage vehicle speed using and signals the `FineCollectionService` to issue a fine if the vehicle speed is too high.
This is done using the Pub/Sub building block sending a `SpeedingViolation` message. The avarage vehicle speed is calculated using the entering and exiting timestamps, which are saved using the Dapr State building block.

### TrafficControlService - With Actors

Now that you have implemented the base logic for the `TrafficControlService`, you will implement the same logic using the Actor pattern. You will find the partial implementation for the actor's logic in the [Actor](./src/TrafficControlService/Actors/) folder.

## Test the services

To test only the `TrafficControlService`, you can use Postman as in the previous lab.

Once you have successfully started the TrafficControlService and the Simulator, you can observe from the console output that the simulator is generating random car entry and car exit and the TrafficControlService is receiving those entry and exit.

## Put everything together

You can follow the steps in both README files - day 1 and day 2 - to start all the services and enjoy the complete Dapr traffic control application.