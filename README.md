# Yzl.Extensions.Actuator Samples

## 中文说明

这是 `Yzl.Extensions.Actuator` 的完整示例项目，演示如何在 .NET 8 ASP.NET Core 应用中启用类似 Spring Boot Actuator 的运维端点。示例项目位于 `Yzl.Extensions.Actuator.Samples` 目录，可作为独立 GitHub 仓库维护。

本 demo 覆盖：

- `AddSpringNetActuator` 服务注册
- `UseSpringNetActuatorMapEndpoints` 端点映射
- `/actuator` 端点链接
- `/actuator/health` 健康检查与自定义 `IHealthContributor`
- `/actuator/info` 应用信息
- `/actuator/metrics` 指标列表与指标详情
- `/actuator/loggers` 日志级别查看
- `/actuator/caches` 内存缓存查看与清理
- `/actuator/env`、`/actuator/mappings`、`/actuator/conditions`、`/actuator/metadata`

## English

This is a complete demo for `Yzl.Extensions.Actuator`, showing how to expose Spring Boot Actuator-style operational endpoints from a .NET 8 ASP.NET Core application. The samples live under `Yzl.Extensions.Actuator.Samples` and can be maintained as a standalone GitHub repository.

The demo covers:

- Service registration with `AddSpringNetActuator`
- Endpoint mapping with `UseSpringNetActuatorMapEndpoints`
- `/actuator` endpoint links
- `/actuator/health` with custom `IHealthContributor` implementations
- `/actuator/info` application information
- `/actuator/metrics` metric names and metric details
- `/actuator/loggers` logger-level inspection
- `/actuator/caches` memory cache inspection and eviction
- `/actuator/env`, `/actuator/mappings`, `/actuator/conditions`, `/actuator/metadata`

## 快速开始 / Quick start

```bash
dotnet build Yzl.Extensions.Actuator.Samples/Yzl.Extensions.Actuator.Samples.sln

dotnet run --project Yzl.Extensions.Actuator.Samples/src/Yzl.Extensions.Actuator.Samples.Web/Yzl.Extensions.Actuator.Samples.Web.csproj
```

默认端口 / Default port:

- Web + Actuator: `http://localhost:17001`

访问 demo 入口 / Try the demo endpoints:

- `http://localhost:17001/`
- `http://localhost:17001/actuator`
- `http://localhost:17001/actuator/health`
- `http://localhost:17001/actuator/info`
- `http://localhost:17001/actuator/metrics`
- `http://localhost:17001/actuator/metrics/jvm.memory.used`
- `http://localhost:17001/actuator/loggers`
- `http://localhost:17001/actuator/caches`
- `http://localhost:17001/cache/add?name=demo`
- `http://localhost:17001/cache/get?name=demo`
- `http://localhost:17001/logger?str=hello`

## 文档 / Docs

- [Getting started / 快速入门](docs/getting-started.md)
- [Configuration guide / 配置指南](docs/configuration-guide.md)

## 项目结构 / Project structure

```text
src/Yzl.Extensions.Actuator.Samples.Web   ASP.NET Core Actuator demo application
docs                                      中英双语文档 / bilingual docs
```

## 作为独立仓库发布 / Publishing as a standalone repo

当前示例通过 NuGet 包引用 `Yzl.Extensions.Actuator`，符合独立 samples 仓库的使用方式：

The demo references `Yzl.Extensions.Actuator` as a NuGet package, which matches the standalone samples repository scenario:

```xml
<ItemGroup>
  <PackageReference Include="Yzl.Extensions.Actuator" Version="0.1.7" />
</ItemGroup>
```

如果需要在本地调试库源码，可把包引用临时替换为指向 `dotnet-extensions/src/Yzl.Extensions.Actuator/Yzl.Extensions.Actuator.csproj` 的 `ProjectReference`。
