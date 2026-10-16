# MAUI TreeView Performance Metrics

This example repo maintains the demo used to measure the performance of the Syncfusion MAUI TreeView control for all the 4 platforms with latest metrics details for reference.

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
