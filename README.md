

# Overview

SereneApi is intended to provide a straightforward way of consuming **RESTful** APIs requiring as little code & setup as possible whilst providing a powerful set of extensible tools.

**Why?**
I found that creating Web Requests, then needing to Deserialize/Serialize usually became tedious and in some cases even break DRY.

After using the repository patter for many years. I decided to try fiddling with the idea of an API consumer using a similar pattern. After implementing a basic handler I decided the idea was found and began work on SereneApi.

### Documentation
* **[SereneApi](https://github.com/SereneApi/SereneApi/tree/master/src/SereneApi#getting-started)**<br/>Covers the basics usage of SereneApi

* **[SereneApi.Abstractions](https://github.com/SereneApi/SereneApi/tree/master/src/SereneApi.Abstractions#getting-started)**<br/>Covers the basics components and more advanced usage.

* **[SereneApi.Extensions.DependencyInjection](https://github.com/SereneApi/SereneApi/tree/master/src/SereneApi.Extensions.DependencyInjection#getting-started)**<br/>Covers how to use SereneApi with DependencyInjection.

* **[SereneApi.Extensions.Mocking](https://github.com/SereneApi/SereneApi/tree/master/src/SereneApi.Extensions.Mocking#overview)**<br/>Covers how to use the Mocking API.

* **[SereneApi.Extensions.Newtonsoft](https://github.com/SereneApi/SereneApi/tree/master/src/SereneApi.Extensions.Newtonsoft#getting-started)**<br/>Covers usage of Newtonsoft.




## Stable Release
|Package|Downloads|Build|NuGet|
|-|-|-|-|
|**SereneApi**|![](https://img.shields.io/nuget/dt/SereneApi?style=for-the-badge)|![Azure DevOps builds](https://img.shields.io/azure-devops/build/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/14?style=for-the-badge)|[![Nuget](https://img.shields.io/nuget/v/SereneApi.svg?style=for-the-badge)](https://www.nuget.org/packages/SereneApi/) |
|**SereneApi.AspNet**|![](https://img.shields.io/nuget/dt/SereneApi.AspNet?style=for-the-badge)|![Azure DevOps builds](https://img.shields.io/azure-devops/build/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/14?style=for-the-badge)|[![Nuget](https://img.shields.io/nuget/v/SereneApi.AspNet.svg?style=for-the-badge)](https://www.nuget.org/packages/SereneApi.AspNet/) |
|**SereneApi.Abstractions**|![](https://img.shields.io/nuget/dt/SereneApi.Abstractions?style=for-the-badge)|![Azure DevOps builds](https://img.shields.io/azure-devops/build/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/13?style=for-the-badge)| [![Nuget](https://img.shields.io/nuget/v/SereneApi.Abstractions.svg?style=for-the-badge)](https://www.nuget.org/packages/SereneApi.Abstractions/) |
|**SereneApi.Extensions.DependencyInjection**|![](https://img.shields.io/nuget/dt/SereneApi.Extensions.DependencyInjection?style=for-the-badge)|![Azure DevOps builds](https://img.shields.io/azure-devops/build/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/15?style=for-the-badge)|[![Nuget](https://img.shields.io/nuget/v/SereneApi.Extensions.DependencyInjection.svg?style=for-the-badge)](https://www.nuget.org/packages/SereneApi.Extensions.DependencyInjection/)|
|**SereneApi.Extensions.Mocking**|![](https://img.shields.io/nuget/dt/SereneApi.Extensions.Mocking?style=for-the-badge)|![Azure DevOps builds](https://img.shields.io/azure-devops/build/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/16?style=for-the-badge)|[![Nuget](https://img.shields.io/nuget/v/SereneApi.Extensions.Mocking.svg?style=for-the-badge)](https://www.nuget.org/packages/SereneApi.Extensions.Mocking/)|
|**SereneApi.Extensions.Newtonsoft**|![](https://img.shields.io/nuget/dt/SereneApi.Extensions.Newtonsoft?style=for-the-badge)|![Azure DevOps builds](https://img.shields.io/azure-devops/build/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/17?style=for-the-badge)|[![Nuget](https://img.shields.io/nuget/v/SereneApi.Extensions.Newtonsoft.svg?style=for-the-badge)](https://www.nuget.org/packages/SereneApi.Extensions.Newtonsoft/)|

## Tests
|Package||Coverage|
|-|-|-|
|**SereneApi**|![Azure DevOps tests](https://img.shields.io/azure-devops/tests/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/14?style=for-the-badge)|![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/14?style=for-the-badge)|
|**SereneApi.Abstractions**|![Azure DevOps tests](https://img.shields.io/azure-devops/tests/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/13?style=for-the-badge)|![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/13?style=for-the-badge)|
|**SereneApi.Extensions.DependencyInjection**|![Azure DevOps tests](https://img.shields.io/azure-devops/tests/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/15?style=for-the-badge)|![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/15?style=for-the-badge)|
|**SereneApi.Extensions.Mocking**|![Azure DevOps tests](https://img.shields.io/azure-devops/tests/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/16?style=for-the-badge)|![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/16?style=for-the-badge)|
|**SereneApi.Extensions.Newtonsoft**|![Azure DevOps tests](https://img.shields.io/azure-devops/tests/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/17?style=for-the-badge)|![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/DeltaWareAU/e18b43d4-35b6-4aa6-b09d-a50814de3303/17?style=for-the-badge)|
