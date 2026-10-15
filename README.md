# maui-treeview-performance-metrics

Performance benchmark samples, benchmark results, and test environment documentation for the .NET MAUI TreeView control across Android, iOS, Windows, and macOS. These benchmarks enable reproducible performance validation for TreeView item loading operations across supported platforms.

## TreeView Item Loading Performance

| Use Case | Windows | Android | macOS | iOS |
|----------|---------:|---------:|---------:|---------:|
| 100 Items Loading | 0.4377947 | 4.16983352 | 0.86103 | 0.6266359 |
| 1,000 Items Loading | 0.4376196 | 3.1697072 | 0.95892 | 0.7273857 |
| 10K Items Loading | 0.6203427 | 6.8474828 | 1.972114 | 1.7441194 |
| 1L Items Loading | 3.3440006 | 21.8852443 | 12.682 | 12.6036825 |

## Test Setup

| Item | Details |
|--------|---------|
| Version | Syncfusion .NET MAUI v35.1.39 |
| Android Device | Vivo V2355, Android 16 |
| Windows Device | ASUS Vivobook |
| iOS Device | iPhone 18 Pro, iOS 27.0 |
| macOS Device | Mac mini (Apple M4 Pro) |
| Build Configuration | Release, .NET 10 |
| Tested Date | October 9, 2026 |

## Notes

- All benchmarks were executed using the **Release** configuration on **.NET 10**.
- Performance measurements were collected on physical devices across Android, iOS, Windows, and macOS.
- The results represent TreeView item loading times for different dataset sizes.
- Actual performance may vary depending on device hardware, operating system version, and runtime conditions.

## Additional Resources

For detailed benchmark results and analysis, see the Loop document:

📄  **[Loop Report](https://loop.cloud.microsoft/p/eyJ3Ijp7InUiOiJodHRwczovL3N5bmNmdXNpb24uc2hhcmVwb2ludC5jb20vP25hdj1jejBsTWtZbVpEMWlJWGhOVWpkdGJFMUtRekJsYkRaVmJYWkJhbGxVVkRocWJYWlBWR1JqUTBwTWNuRTBSMmRhTFdWdFFUYzRkSEppWjJSMVFWTlJOMDV2YnpZNU5FVlJXbUltWmowd01WQXlVbGxYVDFWUU5VdFBSMHBETjBSYVNrY3pUVUZWU1ZWQlVqUXlORXhaSm1NOUptWnNkV2xrUFRFJTNEIiwiciI6ZmFsc2V9LCJwIjp7InUiOiJodHRwczovL3N5bmNmdXNpb24uc2hhcmVwb2ludC5jb20vOmZsOi9yL2NvbnRlbnRzdG9yYWdlL0NTUF85YTdiYzRjNC0wOTUzLTQ3MGItYTVlOS00OWFmMDIzNjEzNGYvRG9jdW1lbnQlMjBMaWJyYXJ5L0xvb3BBcHBEYXRhL1VudGl0bGVkLmxvb3A_ZD13MDY3Njk2NThhOGNhNDZlY2JmYjk5NzlkNThkZjQ3NTAmY3NmPTEmd2ViPTEmbmF2PWN6MGxNa1pqYjI1MFpXNTBjM1J2Y21GblpTVXlSa05UVUY4NVlUZGlZelJqTkMwd09UVXpMVFEzTUdJdFlUVmxPUzAwT1dGbU1ESXpOakV6TkdZbVpEMWlJWGhOVWpkdGJFMUtRekJsYkRaVmJYWkJhbGxVVkRocWJYWlBWR1JqUTBwTWNuRTBSMmRhTFdWdFFUYzRkSEppWjJSMVFWTlJOMDV2YnpZNU5FVlJXbUltWmowd01WQXlVbGxYVDFOWlUxb3pRVTVUVmtrMVVrUk1OMDlOV0ZSV1RVNDJVakpSSm1NOUpUSkdKbVpzZFdsa1BURW1ZVDFNYjI5d1FYQndKbkE5SlRRd1pteDFhV1I0SlRKR2JHOXZjQzF3WVdkbExXTnZiblJoYVc1bGNpWjRQU1UzUWlVeU1uY2xNaklsTTBFbE1qSlVNRkpVVlVoNGVtVlhOV3BhYmxaNllWYzVkVXh1VG05WldFcHNZMGM1Y0dKdVVYVlpNamwwWmtkSmFHVkZNVk5PTWpGelZGVndSRTFIVm5OT2JGWjBaR3RHY1ZkV1VsVlBSM0IwWkdzNVZWcEhUa1JUYTNoNVkxUlNTRm94YjNSYVZ6RkNUbnBvTUdOdFNtNWFTRlpDVlRGRk0xUnRPWFpPYW1zd1VsWkdZVmx1ZDNkTlZrRjVWV3hzV0ZReFZsRk9WWFJRVWpCd1JFNHdVbUZUYTJONlZGVkdWbE5XVmtKVmFsRjVUa1Y0V2lVeU1pVXlReVV5TW1rbE1qSWxNMEVsTWpJMVpHTmhPVFJqWWkwNFltVXhMVFE0TnpNdFlqUmtZUzFpWkROaFpEaGhaV1V6TXpBbE1qSWxOMFElM0QiLCJyIjpmYWxzZX0sImkiOnsiaSI6IjVkY2E5NGNiLThiZTEtNDg3My1iNGRhLWJkM2FkOGFlZTMzMCJ9fQ)**

