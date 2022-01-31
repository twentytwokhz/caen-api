# CAEN API

![GitHub release (latest by date)](https://img.shields.io/github/v/release/twentytwokhz/caen-api)
![GitHub Release Date](https://img.shields.io/github/release-date/twentytwokhz/caen-api)
![GitHub issues](https://img.shields.io/github/issues/twentytwokhz/caen-api)
![GitHub](https://img.shields.io/github/license/twentytwokhz/caen-api)

![Lines of code](https://img.shields.io/tokei/lines/github/twentytwokhz/caen-api)
[![Azure Static Web Apps CI/CD](https://github.com/twentytwokhz/caen-api/actions/workflows/azure-static-web-apps-lively-island-0c5aca203.yml/badge.svg)](https://github.com/twentytwokhz/caen-api/actions/workflows/azure-static-web-apps-lively-island-0c5aca203.yml)

This is an open-source effort to democratize access to the Romanian CAEN codes.
Any person who wishes to use CAEN codes in their project can use this API.

---
## Usage
Currently the API is hosted on a temporary subdomain
https://caen-api.florinbobis.me

The API can be hosted using Azure Static Web Apps or Azure Functions. Visit the `src` folder to learn more.

### Available endpoints

> Note: Parameters with `?` are optional

#### 1. Get CAEN Codes by section/division/group

`https://caen-api.florinbobis.me/api/caen/{sectionId?}/{divisionId?}/{groupId?}`

- https://caen-api.florinbobis.me/api/caen
- https://caen-api.florinbobis.me/api/caen/A
- https://caen-api.florinbobis.me/api/caen/A/1
- https://caen-api.florinbobis.me/api/caen/A/1/11

#### 2. Search CAEN Codes

`https://caen-api.florinbobis.me/api/search/{searchTerm}`

- https://caen-api.florinbobis.me/api/search/plant

---
## Official reference

The data was parsed and curated from [here](http://legislatie.just.ro/Public/DetaliiDocument/81727)

---
MIT licensed | Copyright © 2022 Florin Bobiș
