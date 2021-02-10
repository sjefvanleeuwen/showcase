![banner](./docs/images/banner.svg)


# Showcase

A personal full stack journey. Consisting out of:

* Micro Services
* Micro (modular) Front End
* Simulation Driven Development

## Status

Very much under construction. Started with the back end. The schema for the back end can be found here.
https://sjefvanleeuwen.github.io/showcase/schemas/graphql/

## High Level Overview

High level overview of what I am building.

![High Level Overview](./docs/images/high-level.svg)

## Integration Tests

Integration tests are done in postman and exported as dashboard using newman with `newman-reporter-html-extra` npm package.

The dashboard can be found here:
https://sjefvanleeuwen.github.io/showcase/tests/newman/dashboard.html

## Hosting Modes

### Micro services

At this time the micro services run in self hosted mode. The eventual "production" mode is targeted towards kubernetes.

![Hosting Modes](./docs/images/hosting-modes.svg)

## Setup dapr on Azure AKS kubernetes

Please follow the guide [here](./docs/kubernetes/setup-aks-cluster.md)