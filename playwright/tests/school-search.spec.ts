import { test, expect } from '@playwright/test';

test('can search for a school', async ({ page }) => {
    await page.goto('/');

    await expect(page).toHaveTitle(/Home page - SchoolPerformanceTablesMock/);
    await page.getByText('Start now').click();
    await expect(page).toHaveURL(/.*Schools/)
    await page.locator('#SchoolNameOrUrn').type("mulb");

    await page.getByText('Mulberry').first().click();
    await page.getByRole('button', { name: 'Search'}).click();
    await expect(page).toHaveTitle(/Details - SchoolPerformanceTablesMock/);
});

