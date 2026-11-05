# SOF3091 - Selenium WebDriver Automation Framework

A maintainable browser automation project built with **C#**, **Selenium WebDriver**, and **NUnit**. The sample application under test is [SauceDemo](https://www.saucedemo.com/), a public demo shop designed for UI automation practice.

## Learning outcomes

| Goal | Implementation |
|---|---|
| G1 - Selenium + C# | Browser automation with Chrome and Selenium WebDriver |
| G2 - Automation framework | Reusable driver factory, configuration, waits, page objects, test base, failure screenshots |
| G3 - OOP | Encapsulation and separation of page, test, and infrastructure responsibilities |
| G4 - AI in testing | AI-assisted test ideas and review workflow documented in `docs/AI-USAGE.md`; all generated code must be validated |
| G5 - Git + GitHub | Git-ready structure and GitHub Actions CI workflow |

## Project structure

```text
SOF3091_TB02324/
├── .github/workflows/tests.yml
├── docs/
│   ├── AI-USAGE.md
│   └── TEST-PLAN.md
├── src/SOF3091.Automation/
│   ├── Core/
│   │   ├── AutomationConfig.cs
│   │   └── DriverFactory.cs
│   ├── Pages/
│   │   ├── BasePage.cs
│   │   ├── LoginPage.cs
│   │   ├── InventoryPage.cs
│   │   ├── CartPage.cs
│   │   └── CheckoutPage.cs
│   ├── Tests/
│   │   ├── BaseTest.cs
│   │   ├── LoginTests.cs
│   │   ├── CartTests.cs
│   │   └── CheckoutTests.cs
│   ├── appsettings.json
│   └── SOF3091.Automation.csproj
└── .gitignore
```

## Requirements

- .NET 8 SDK
- Google Chrome
- Internet connection on the first run (Selenium Manager resolves the matching browser driver)

No manually downloaded ChromeDriver is required.

## Run the tests

From the repository root:

```bash
dotnet restore src/SOF3091.Automation/SOF3091.Automation.csproj
dotnet test src/SOF3091.Automation/SOF3091.Automation.csproj
```

Run a specific group:

```bash
dotnet test src/SOF3091.Automation/SOF3091.Automation.csproj --filter FullyQualifiedName~LoginTests
dotnet test src/SOF3091.Automation/SOF3091.Automation.csproj --filter FullyQualifiedName~CartTests
dotnet test src/SOF3091.Automation/SOF3091.Automation.csproj --filter FullyQualifiedName~CheckoutTests
```

## Browser configuration

Edit `src/SOF3091.Automation/appsettings.json`:

- `BaseUrl`: application URL
- `Browser`: currently Chrome
- `Headless`: set to `true` for headless execution
- `ExplicitWaitSeconds`: maximum explicit wait

Environment variables override JSON settings. For example:

```bash
# PowerShell
$env:Automation__Headless = "true"
$env:Automation__BaseUrl = "https://www.saucedemo.com/"
dotnet test src/SOF3091.Automation/SOF3091.Automation.csproj

# Bash
Automation__Headless=true dotnet test src/SOF3091.Automation/SOF3091.Automation.csproj
```

## Test accounts

SauceDemo publishes demo accounts on its login page. The default happy-path account is:

- Username: `standard_user`
- Password: `secret_sauce`

The locked account test uses `locked_out_user`. These are public demo credentials, not personal credentials.

## Framework design

- **DriverFactory** creates and configures the browser in one place.
- **AutomationConfig** reads settings from JSON and environment variables.
- **BasePage** centralizes explicit waits and common browser interactions.
- **Page Objects** expose business actions instead of leaking selectors into tests.
- **BaseTest** manages browser lifecycle and captures a screenshot after a failed test.
- **NUnit** provides test discovery, assertions, test cases, and CI-compatible results.

Tests are intentionally independent: each test starts with a clean browser session.

## CI

GitHub Actions runs the test suite on pushes and pull requests to `main`. Test results are uploaded as workflow artifacts. A public demo site or browser/network outage can cause an environmental failure; inspect the test output and screenshot artifact before treating it as an application defect.

## Scope and limitations

This is a learning framework for the SauceDemo demo site, not a production test suite for a private application. Selectors and expected behavior may change if the demo website changes. The tests have been authored but must be executed in an environment with .NET 8, Chrome, and network access before claiming a passing result.

## License

Educational use for the SOF3091 coursework.
