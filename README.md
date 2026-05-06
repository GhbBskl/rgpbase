# RPG Base

这是一个基于 Unity 的 2D RPG 课程练习项目，用来记录角色移动、跳跃、攻击、动画事件和基础敌人继承等功能的实现过程。

## 开发环境

- Unity：`6000.3.14f1`
- 项目类型：2D RPG 练习项目
- 主场景：`Assets/Scenes/SampleScene.unity`

## 运行方式

1. 使用 Unity Hub 打开本项目根目录。
2. 在 Unity 编辑器中打开 `Assets/Scenes/SampleScene.unity`。
3. 点击 Play 运行场景。

## 操作说明

| 按键 | 功能 |
| --- | --- |
| `A / D` 或方向键 | 控制角色左右移动 |
| `Space` | 跳跃 |
| `J` | 攻击 |
| `F` | 触发敌人攻击调试逻辑 |

## 当前功能

- 玩家左右移动、跳跃和朝向翻转。
- 基于 `Rigidbody2D` 的角色移动控制。
- 使用射线检测角色是否站在地面上。
- 通过 Animator 参数控制移动、跳跃、下落和攻击动画。
- 使用攻击点和攻击范围检测敌人。
- 通过动画事件触发攻击判定，以及在攻击过程中禁用或恢复移动和跳跃。
- 实现基础敌人类 `Enemy`，并通过 `Enemy_Goblin` 和 `Enemy_Archer` 展示继承与方法重写。
- 提供简单的受击变色冷却示例。

## 项目结构

```text
Assets/
  Animations/       角色动画资源
  Materials/        物理材质等资源
  Scenes/           Unity 场景文件
  Scripts/          玩家、敌人和示例脚本
  Player.controller 玩家动画控制器
  Player_Graphics.png

Packages/           Unity 包依赖配置
ProjectSettings/    Unity 项目配置
```

## 主要脚本

- `Assets/Scripts/Player.cs`：处理玩家输入、移动、跳跃、翻转、攻击检测和动画参数更新。
- `Assets/Scripts/PlayerAnimationEvents.cs`：接收动画事件，并调用玩家攻击和移动锁定逻辑。
- `Assets/Scripts/Enemy.cs`：敌人的基础类，包含移动、攻击和受伤方法示例。
- `Assets/Scripts/Enemy_Goblin.cs`：继承 `Enemy`，演示 Goblin 的特殊攻击行为。
- `Assets/Scripts/Enemy_Archer.cs`：继承 `Enemy`，演示 Archer 的攻击重写。
- `Assets/Scripts/Cooldown_Example.cs`：演示受击后短时间变红并恢复颜色的冷却逻辑。

## Git 说明

仓库只跟踪 Unity 项目源码和配置文件。以下 Unity 生成目录和本机 IDE 文件不会提交：

- `Library/`
- `Temp/`
- `Logs/`
- `UserSettings/`
- `.vscode/`
- `*.csproj`
- `*.sln`

## 后续计划

- 完善玩家和敌人的血量、伤害结算系统。
- 增加更完整的敌人 AI 和巡逻、追击、攻击行为。
- 增加关卡地图和可交互场景内容。
- 增加 UI、音效和战斗反馈。
- 继续整理脚本结构，让角色、敌人和战斗逻辑更容易扩展。
