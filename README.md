# Introduction

A repository of Portal test automation framework based on .Net 6.
API and UI tests were written for CI-CD training purpose.
TODO: using this project - run tests in the Docker container.

# Getting Started

## Prerequisites

Install [.Net 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Project configuration

1. General project configuration stored in `appsettings.json` file.
2. AzureSettings secrets for local run stored with manage secrets (need to create local file)

## Build

1. Install [.Net 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
   - Make sure you added `dotnet` folder to the PATH (usually path is `C:\Program Files\dotnet`)
2. Install **NuGet Command Line Tool** from [NuGet CLI](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
   - Make sure you added nuget.exe folder to the PATH

## Test

1. Console
   - Install [NUnit-Console](https://nunit.org/docs/2.4/nunit-console.html)
   - Run `nunit3-console Tests.dll`
     - with [filters](https://github.com/nunit/docs/wiki/Console-Command-Line) `dotnet test --filter "TestCategory=API"` for run only API tests
     - with [filters](https://github.com/nunit/docs/wiki/Console-Command-Line) `dotnet test --filter "TestCategory=UI"` for run only UI tests
     - [Other tags](https://github.com/nunit/docs/wiki/Test-Selection-Language)
2. Visual Studio 2019/2022
   - Setup [NUnit 3 Test Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter) extension
   - Run tests using `Test > Windows > Test Explorer` window.
