##### launchsettings.json

  ```json  
  "Development": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "Production": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production" 
      }
    }
```

![launchSetting2](https://user-images.githubusercontent.com/25562982/163707421-22d91893-1930-4ce4-bb0f-eb0b34ddd7c8.png)

##### appsettings.Production.json

  ```json 
  "CustomConfig": {
    "ConnectionString": "Server=localhost;Integrated Security=True;Database=Prod_DB;",
    "EmailSettings": {
      "SMTPEmail": "prod-email@gmail.com",
      "SMTPPassWord": "my-password",
      "SMTPPort": "587",
      "SMTPHostname": "smtp.gmail.com"
    }
  }
  ```
##### appsettings.Development.json

  ```json 
 "CustomConfig": {
    "ConnectionString": "Server=localhost;Integrated Security=True;Database=Dev_DB;",
    "EmailSettings": {
      "SMTPEmail": "dev-email@gmail.com",
      "SMTPPassWord": "my-password",
      "SMTPPort": "587",
      "SMTPHostname": "smtp.gmail.com"
    }
  }
  ```
#### Configure settings with IOptions pattern 
[https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)

`CustomConfig.cs` 
 ```cs 
public class CustomConfig
    {
        public string ConnectionString { get; set; }

        public EmailSetting EmailSettings { get; set; }

        public class EmailSetting
        {
            public string SMTPEmail { get; set; }
            public string SMTPPassWord { get; set; }
            public string SMTPPort { get; set; }
            public string SMTPHostname { get; set; }
        }
    }
  ```
`Program.cs` 
 ```cs 
	builder.Services.Configure<CustomConfig>(builder.Configuration.GetSection(nameof(CustomConfig)));
	builder.Services.AddOptions();
	
	//......
	if (app.Environment.IsProduction())
	{
 	  //prod app.use 
   
	}
	if (app.Environment.IsDevelopment())
	{
	   //dev app.use 
	}
  ```
  
 `ProductController.cs` 
 
  ```cs
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IOptions<CustomConfig> _options;
        public ProductController(IOptions<CustomConfig> options)
        {
            _options = options;
        }
        [HttpPost]
        public IActionResult GetProduct(Product product)
        {
            product.Name = "Product";
            return Ok(product);
        }
    }
  ```
## Result
#### When working with Production environment
![prodconfig](https://user-images.githubusercontent.com/25562982/163707729-6d36be64-6a46-4b4c-b0b9-4ff38ee17fc7.png)


#### When working with Development environment
![devconfig](https://user-images.githubusercontent.com/25562982/163707732-df9f91a1-5976-41d8-9f59-b4bb915e34d5.png)


