﻿# Getting Started
Add the latest version of the NuGet package to your project.
>PM> Install-Package **SereneApi**
## Index
*	**[Implementation](#api-implementation)**
*	**[Registration](#api-registration)**
*	**[Instantiation](#api-instantiation)**
*	**[BaseApiHandler](#baseapihandler)**
*	**[CrudApiHandler](#crudapihandler)**
## API Implementation
The first step in implementing an API, is its definition. The definition is an interface representing all available actions that can be performed against an API.
>**BEST PRACTICE:** API definitions should use the following naming convention 'I*Resource*Api'.

Below is an example of an API intended for the resource 'Foo'. The API contains two actions, A GET that requires an ID and a CREATE that requires a *FooDto* object.
>**BEST PRACTICE:** API methods should return an *IApiResponse*.
```csharp
public interface IFooApi: IDisposable
{
	Task<IApiResposne<FooDto>> GetAsync(long id);

	Task<IApiResponse> CreateAsync(FooDto foo);
}
```
After an API's definition has been created, its associated handler needs to be implemented. The handler is the backbone of an API, performing all the magic required for sending and receiving requests. This is where your request logic is located.
>**SEE:** More details on requests can be seen [here](#baseapihandler).
>
>**BEST PRACTICE:** Handler implementations should use the following naming convention '*Resource*ApiHandler' and be located in a *Handlers* folder contained in your project.

```csharp
public class FooApiHandler: BaseApiHandler, IFooApi
{
	public FooApiHandler(IApiOptions<IFooApi> options) : base(options)
	{
	}
	
	public Task<IApiResposne<FooDto>> GetAsync(long id)
	{
		return PerformRequestAsync<FooDto>(Method.GET, r => r
			.WithEndPoint(id));
	}
	
	public Task<IApiResonse> CreateAsync(FooDto foo)
	{
		return PerformRequestAsync(Method.POST, r => r
			.AddInBodyContent(foo));
	}
}
```
There are a couple of things to take note of in the above example.
*	*FooApiHandler* inherits the abstract class *BaseApiHandler*.
*	*FooApiHandler* inherits the interface *IFooApi*.
*	*FooApiHandler's* constructor contains a single parameter *IApiOptions* with the generic type set to *IFooApi*.

Once an API's definition and handler have been implemented it is now possible to register them.
## API Registration
API registering is important as it not only binds the API to the handler but it also allows configuration to be provided. API Registering can currently be done using one of two methods.

### ApiFactory Method
```csharp
ApiFactory factory = new ApiFactory();

factory.RegisterApi<IFooApi, FooApiHandler>(o => 
{
	o.UseSource("http://www.somehost.com", "Foo");
	o.UseLogger(myLogger);
});
```
### Dependency Injection Method
By default all APIs registered using dependency injection will receive an *ILogger* using *ILoggerFacgtory* if it is available.
>**NOTE:** To use dependency injection  install *SereneApi.Extensions.DependencyInjection*

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.RegisterApi<IFooApi, FooApiHandler>(b =>
	{
		o.UseSource("http://www.somehost.com", "Foo");
	});
}
```
Both of the above registrations will deliver the same configuration for Foo API.
## API Instantiation
After an API has been registered its handler needs to be instantiated, this is where the *IApiOptions* parameter comes in. *IApiOptions* contains all the API's configuration and dependencies as declared during registration. This process occurs behind the scenes but it still needs to be invoked. It is important to set your API definition as the generic type parameter for *IApiOptions*.
>**NOTE:** If an API's handler does not have *IApiOptions* configured correctly, it can either get the settings for a different handler.

### Invoking with ApiFactory
Invocation with *ApiFactory* can be done with either the class or the interface, in the example below the interface will be used because it does not expose the registration methods.
When an API is required, call the *Build\<TApi>()* method. This provides an instantiated instance of TApi.
>**NOTE:** The instance of TApi needs to implement IDisposable.
```csharp
public class FooService
{
	private readonly IApiFactory _factory;

	public void DoStuff(long id)
	{
		IApiResponse<FooDto> response;

		using (IFooApi fooApi = _factory.Build<IFooApi>())
		{
			response = fooApi.GetAsync(id);
		}

		// Do stuff on response here.
	}
}
```
### Invoking with Dependency Injection
Invocation with Dependency Injection is easy and straightforward. Add your APIs implementation interface to the constructor of your class and DI will handle the rest.
>**NOTE:** The API should not be disposed of as this is handled by dependency injection.
```csharp
public class FooService
{
	private readonly IFooApi _fooApi;

	public FooService(IFooService fooApi)
	{
		_fooApi = fooApi;
	}

	public void DoStuff(long id)
	{
		IApiResponse<FooDto> response = fooApi.GetAsync(id);
		
		// Do stuff on response here.
	}
}
```

## BaseApiHandler
Inheriting the base class *BaseApiHandler* gives access to several protected methods for performing requests.
```csharp
PerformRequest();
PerformRequestAsync();
PerformRequest<TResponse>();
PerformRequestAsync<TResponse>();
```
Each of the methods listed above share the same parameters. The first parameter is the *Method* in which the request will be performed. The methods are the standard array of REST methods.
* **POST** — *Submits an entity to the specified resource.*
* **GET** — *Requests a representation of the specified resource.*
* **PUT** — *Replaces all current representations of the target resource.*
* **PATCH** — *Applies partial modifications to a resource.*
* **DELETE** — *Deletes the specified resource.*

The second parameter is the request factory, this parameter is entirely optional. It contains multiple methods that are required to be called in a specific order.
* **AgainstResource**
	Specifies or overrides the resource that the request is intended for. If the resource was provided during configuration this method is not necessary.
* **WithEndpoint**
	Specifies the endpoint for the request, it is applied after the resource.
* **WithEndpointTemplate**
	Specifies the endpoint for the request, is applied after the resource. Two parameters must be provided, a format-table string and an array of objects that will be formatted to the string.
* **WithInBodyContent\<TContent>**
	Specifies the content to be sent in the body of the request.
	>**NOTE**: This method can only be used in conjunction with *POST*, *PUT* and *PATCH*.

* **WithQuery\<TQuery>**
	Specifies the query to be added to the end of the requests URI. Has a secondary optional parameter allowing specific properties to be selected.

A variant of *PerformRequest* is available. This method takes an *IApiRequest* as its sole parameter, enabling pre-configured or custom requests to be provided.
## CrudApiHandler
When *CrudApiHandler* is inherited, it provides pre-implemented CRUD API methods. To implement *CrudApiHandler* you are required to provided two generic parameters.
*	**TResource**
		Specifies the type that defines the APIs resource, this resource will be retrieved and provided by the API.
*	**TIdentifier**
		Specifies the identifier type used by the API to identify the resource.
	>**NOTE:** Must be  value type.
```csharp
public interface IBarApi: ICrudApi<BarDto, long>
{
}
```
```csharp
public class BarApiHandler: CrudApiHandler<BarDto, long>, IBarApi
{
	public BarApiHandler(IApiOptions<IBarApi> options) : base(options)
	{
	}
}
```
After *CrudApiHandler* has been implemented the following methods will become available *GetAsync*, *CreateAsync*, *DeleteAsync*, *ReplaceAsync*, *UpdateAsync*.