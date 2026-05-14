# Getting started / 快速入门

## 中文说明

### 1. 安装 NuGet 包

独立项目中使用：

```bash
dotnet add package Yzl.Extensions.Actuator
```

当前 demo 使用：

```xml
<PackageReference Include="Yzl.Extensions.Actuator" Version="0.1.7" />
```

### 2. 注册 Actuator 服务

在 `Program.cs` 中注册：

```csharp
using Yzl.Extensions.Actuator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpringNetActuator(builder.Configuration);
```

### 3. 映射 Actuator 端点

如果没有配置独立管理端口，需要在 ASP.NET Core 应用中映射端点：

```csharp
var app = builder.Build();

app.UseSpringNetActuatorMapEndpoints(builder.Configuration);

app.Run();
```

启动后访问：

```text
http://localhost:17001/actuator
http://localhost:17001/actuator/health
http://localhost:17001/actuator/metrics
```

### 4. 添加自定义健康检查

实现 `IHealthContributor` 后会被自动发现并注册：

```csharp
using Yzl.Extensions.Actuator.Abstractions;
using Yzl.Extensions.Actuator.Endpoints.Health;

public sealed class DatabaseHealthContributor : IHealthContributor
{
    public string Name => "db";

    public Task<HealthComponent> CheckAsync(CancellationToken ct)
    {
        return Task.FromResult(new HealthComponent
        {
            Status = HealthStatus.Up,
            Details = new Dictionary<string, object>
            {
                ["database"] = "sample-db"
            }
        });
    }
}
```

访问 `/actuator/health` 时会看到 `db` 节点。

### 5. 使用缓存和日志示例

本 demo 提供两个辅助接口：

```text
GET /cache/add?name=demo
GET /cache/get?name=demo
GET /logger?str=hello
```

调用缓存接口后，可通过 `/actuator/caches` 查看缓存信息；调用日志接口后，可通过 `/actuator/loggers` 查看日志配置。

## English

### 1. Install the NuGet package

For a standalone application:

```bash
dotnet add package Yzl.Extensions.Actuator
```

This demo uses:

```xml
<PackageReference Include="Yzl.Extensions.Actuator" Version="0.1.7" />
```

### 2. Register Actuator services

Register Actuator in `Program.cs`:

```csharp
using Yzl.Extensions.Actuator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpringNetActuator(builder.Configuration);
```

### 3. Map Actuator endpoints

If no dedicated management port is configured, map the endpoints on the ASP.NET Core application:

```csharp
var app = builder.Build();

app.UseSpringNetActuatorMapEndpoints(builder.Configuration);

app.Run();
```

After startup, open:

```text
http://localhost:17001/actuator
http://localhost:17001/actuator/health
http://localhost:17001/actuator/metrics
```

### 4. Add a custom health contributor

Implement `IHealthContributor`; it is discovered and registered automatically:

```csharp
using Yzl.Extensions.Actuator.Abstractions;
using Yzl.Extensions.Actuator.Endpoints.Health;

public sealed class DatabaseHealthContributor : IHealthContributor
{
    public string Name => "db";

    public Task<HealthComponent> CheckAsync(CancellationToken ct)
    {
        return Task.FromResult(new HealthComponent
        {
            Status = HealthStatus.Up,
            Details = new Dictionary<string, object>
            {
                ["database"] = "sample-db"
            }
        });
    }
}
```

The `db` component appears in `/actuator/health`.

### 5. Try cache and logger helpers

The demo includes these helper endpoints:

```text
GET /cache/add?name=demo
GET /cache/get?name=demo
GET /logger?str=hello
```

After using the cache helper, inspect `/actuator/caches`; after writing logs, inspect `/actuator/loggers`.
