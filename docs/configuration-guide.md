# Configuration guide / 配置指南

## 中文说明

### 完整配置示例

```json
{
  "management": {
    "server": {
      "port": 17001
    },
    "endpoints": {
      "web": {
        "basePath": "/actuator",
        "exposure": {
          "include": [ "health", "info", "metrics", "loggers", "caches", "env", "mappings", "conditions", "metadata" ],
          "exclude": []
        }
      }
    }
  }
}
```

### 配置项说明

| 配置项 | 说明 | 示例 |
| --- | --- | --- |
| `management:endpoints:web:basePath` | Actuator 根路径 | `/actuator` |
| `management:endpoints:web:exposure:include` | 允许暴露的端点列表 | `[ "health", "info", "metrics" ]` |
| `management:endpoints:web:exposure:exclude` | 需要排除的端点列表 | `[ "env" ]` |
| `management:server:port` | 独立管理端口；未配置时复用业务端口 | `17001` |

### 复用业务端口模式

不配置 `management:server:port` 时，Actuator 端点复用业务应用端口。此时需要调用：

```csharp
app.UseSpringNetActuatorMapEndpoints(builder.Configuration);
```

访问地址类似：

```text
http://localhost:17001/actuator/health
```

### 独立管理端口模式

配置 `management:server:port` 后，Actuator 会使用独立管理端口运行，适合生产环境隔离运维接口：

```json
{
  "management": {
    "server": {
      "port": 17011
    }
  }
}
```

访问地址类似：

```text
http://localhost:17011/actuator/health
```

### 内置端点

| Endpoint | Path | 说明 |
| --- | --- | --- |
| `root` | `/actuator` | 返回所有已暴露端点链接 |
| `health` | `/actuator/health` | 应用健康状态 |
| `info` | `/actuator/info` | 应用信息 |
| `metrics` | `/actuator/metrics` | 指标列表与详情 |
| `loggers` | `/actuator/loggers` | 日志级别查看与管理 |
| `caches` | `/actuator/caches` | 缓存查看与清理 |
| `env` | `/actuator/env` | 环境与配置项 |
| `mappings` | `/actuator/mappings` | ASP.NET Core 路由映射 |
| `conditions` | `/actuator/conditions` | 条件信息 |
| `metadata` | `/actuator/metadata` | Actuator 元数据 |

## English

### Full configuration example

```json
{
  "management": {
    "server": {
      "port": 17001
    },
    "endpoints": {
      "web": {
        "basePath": "/actuator",
        "exposure": {
          "include": [ "health", "info", "metrics", "loggers", "caches", "env", "mappings", "conditions", "metadata" ],
          "exclude": []
        }
      }
    }
  }
}
```

### Configuration keys

| Key | Description | Example |
| --- | --- | --- |
| `management:endpoints:web:basePath` | Root path for Actuator endpoints | `/actuator` |
| `management:endpoints:web:exposure:include` | Endpoint IDs to expose | `[ "health", "info", "metrics" ]` |
| `management:endpoints:web:exposure:exclude` | Endpoint IDs to exclude | `[ "env" ]` |
| `management:server:port` | Dedicated management port; when omitted, the business port is reused | `17001` |

### Shared business port mode

When `management:server:port` is not configured, Actuator endpoints are mapped on the business application port. In this mode, call:

```csharp
app.UseSpringNetActuatorMapEndpoints(builder.Configuration);
```

Example URL:

```text
http://localhost:17001/actuator/health
```

### Dedicated management port mode

When `management:server:port` is configured, Actuator runs on a dedicated management port. This is useful when operational endpoints should be isolated in production:

```json
{
  "management": {
    "server": {
      "port": 17011
    }
  }
}
```

Example URL:

```text
http://localhost:17011/actuator/health
```

### Built-in endpoints

| Endpoint | Path | Description |
| --- | --- | --- |
| `root` | `/actuator` | Links for exposed endpoints |
| `health` | `/actuator/health` | Application health status |
| `info` | `/actuator/info` | Application information |
| `metrics` | `/actuator/metrics` | Metric names and details |
| `loggers` | `/actuator/loggers` | Logger-level inspection and management |
| `caches` | `/actuator/caches` | Cache inspection and eviction |
| `env` | `/actuator/env` | Environment and configuration values |
| `mappings` | `/actuator/mappings` | ASP.NET Core route mappings |
| `conditions` | `/actuator/conditions` | Condition information |
| `metadata` | `/actuator/metadata` | Actuator metadata |
