# AI Usage in the Testing Workflow

This document describes a responsible, reviewable way to apply AI during test automation (G4).

## Where AI can help

1. **Test design:** ask AI to derive positive, negative, boundary, and validation scenarios from a user story.
2. **Code scaffolding:** ask AI to draft a Page Object, test fixture, or reusable wait helper.
3. **Debugging:** provide the exception, relevant locator, and sanitized log to get possible root causes.
4. **Refactoring:** ask AI to identify duplicated selectors or responsibilities that should move into a page object.
5. **Documentation:** use AI to improve test case descriptions and explain framework decisions.

## Example prompts

- "From this login requirement, list positive, negative, and boundary UI test scenarios. Include expected results."
- "Review this Selenium C# Page Object for fragile selectors, duplicated waits, and missing encapsulation."
- "Explain why this WebDriverWait times out and suggest a diagnostic checklist without hiding the original exception."
- "Review these NUnit tests for independence and test-data coupling."

## Human verification checklist

- Confirm selectors against the live application.
- Review every generated assertion against the actual requirement.
- Run tests locally and inspect failures.
- Do not paste passwords, access tokens, private customer data, or confidential source code into public AI services.
- Treat AI suggestions as hypotheses, not evidence that a test passed.

AI assistance does not replace execution, code review, or human responsibility. Test results must come from an actual test run.
