Simple State Machine on C#

Features:
- Simple and easy to use.
- Multiple states.
- Custom StateMachine implementation.
- Custom IState implementation.
- Works with Unity.
- Can be adaptive to Unity`s Job System.

## Использование:

### Инициализация State Machine:

Обычная инициализация:

```csharp
private StateMachine<Your_Context> _states;

void Init()
{
    var stateRegistry = new StateRegistry<Your_Context>();
    
    stateRegistry.AddState(new State_1());  
    stateRegistry.AddState(new State_2());  
    stateRegistry.AddState(new State_3());
    
    var stateActivator = new StateActivator<Your_Context>(stateRegistry.GetStatesBaseArray());
    _states = new StateMachine<Your_Context>(stateRegistry, stateActivator);
}
```

При помощи билдера:
```csharp
private StateMachine<Your_Context> _states;
void Init()
{
    _states = new StateMachineBuilder<Your_Context>()
        .AddState(new State_1())  
        .AddState(new State_2())  
        .AddState(new State_3())  
        .Build();
    
    //или добавление списком
    _states = new StateMachineBuilder<Your_Context>()
        .AddStates(new State_1(), new State_2(), new State_3())  
        .Build();
}
```
