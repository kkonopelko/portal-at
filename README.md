# Introduction

TAF based on .NET 8.

Contain examples of:
1. E2E tests with Selenium framework;
2. E2E tests with Playwright;
3. Basic API tests;

Main purpose - provide examples of using both popular E2E framewoks for browser testing: Selenium and Playwright.

# Getting Started

## Prerequisites

Install [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## How to run tests with Playwright?

1. In the project of tests there should be installed package - 'Microsoft.Playwright.NUnit'
2. Build solution
3. In the 'bin/Debug/net8.0' folder of the tests project (where are your playwrite tests) - run playwright.ps1: 

`
pwsh bin/Debug/net8.0/playwright.ps1 install
`

- this command will install all 4 browsers to the machune with latest version for your package of Playwright. You can customize it to install
only needed browsers;
- full guide how to start with [Playwright](https://playwright.dev/dotnet/docs/intro);

4. Note, when you update the version of Playwright in your solution - you need pass steps 1-3 again. So it generates new pwsh script and
install ned versions of browsers correlated with new version of Playwright package.
