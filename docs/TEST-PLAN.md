# Test Plan - SauceDemo UI Automation

## 1. Objective

Validate the core shopping journey of SauceDemo using repeatable browser-based automated tests.

## 2. Scope

Included:
- Login with valid, invalid, locked, and empty credentials
- Product inventory rendering
- Add and remove a product from the cart
- Cart badge and cart contents
- Checkout with valid information
- Checkout validation when the first name is missing

Not included:
- Payment gateway integration (the demo site does not process real payments)
- Load, performance, security, accessibility, and mobile-device testing
- Tests against private or authenticated production systems

## 3. Environment

- Application: https://www.saucedemo.com/
- Browser: Google Chrome
- Automation: Selenium WebDriver 4
- Language: C# / .NET 8
- Test runner: NUnit 4
- Driver management: Selenium Manager

## 4. Test cases

| ID | Scenario | Expected result |
|---|---|---|
| LOGIN-01 | Login with standard_user | Products page is displayed |
| LOGIN-02 | Login with incorrect password | Credential error is displayed |
| LOGIN-03 | Login with locked_out_user | Locked-out error is displayed |
| LOGIN-04 | Submit empty credentials | Required username error is displayed |
| CART-01 | Add backpack to cart | Badge shows 1 and cart contains backpack |
| CART-02 | Remove backpack | Cart becomes empty |
| INV-01 | Open inventory | Six products are displayed |
| CHECKOUT-01 | Complete checkout with valid details | Order confirmation is displayed |
| CHECKOUT-02 | Continue without first name | First-name validation error is displayed |

## 5. Entry and exit criteria

Entry:
- .NET 8 SDK and Chrome are installed
- Internet access is available
- SauceDemo is reachable

Exit:
- All planned tests have executed
- Failures are reviewed with their logs and screenshots
- Any environment-related failure is distinguished from a product defect

## 6. Risks

- The public demo site can be unavailable or changed without notice.
- Browser and driver versions can change; Selenium Manager handles driver resolution but still requires network access on first use.
- Dynamic page behavior can introduce timing issues; the framework uses explicit waits and disables implicit waits.
