---
sessionId: session-261010-164824-pmlz
---

# Explanation

### BenchmarkClient 和 BenchmarkServer 的用途

它们是ET框架的**网络性能测试工具**，用于压测服务端网络通信的性能。

#### BenchmarkServer（性能测试服务端）

- **位置**：`Unity/Assets/Scripts/Hotfix/Server/Benchmark/`
- **作用**：作为一个轻量级的服务端，接收来自BenchmarkClient的请求并快速响应
- **核心代码**：
  - `BenchmarkServerComponent.cs` - 服务端组件，只包含一个计数器`Count`
  - `C2G_BenchmarkHandler.cs` - 处理客户端请求的消息处理器，每处理100万次请求打印一次日志

#### BenchmarkClient（性能测试客户端）

- **位置**：`Unity/Assets/Scripts/Hotfix/Server/Benchmark/`
- **作用**：模拟大量并发网络请求，向BenchmarkServer发送请求并测量吞吐量
- **核心逻辑**：
  - 创建2个连接到BenchmarkServer的Session
  - 每个Session并发发送1000个请求
  - 循环发送请求，统计处理次数

#### 使用场景

在`Options.cs`中可以看到它们是独立的启动选项。启动方式：
1. 先启动一个`BenchmarkServer`进程
2. 再启动`BenchmarkClient`进程
3. 客户端会自动连接服务端并进行压测
4. 通过日志查看每秒处理次数，评估网络性能

#### 为什么在NetComponentSystem中被特殊处理

在`NetComponentSystem.cs`中，Benchmark场景被排除了`SessionIdleCheckerComponent`，因为性能测试不需要空闲检查，减少不必要的逻辑干扰测试结果。

#### 总结

| 组件 | 用途 |
|------|------|
| BenchmarkServer | 接收请求的服务端，统计处理次数 |
| BenchmarkClient | 发送请求的客户端，模拟高并发 |

它们不是游戏功能的一部分，而是**开发阶段的性能基准测试工具**，用于验证网络层的吞吐量和延迟。