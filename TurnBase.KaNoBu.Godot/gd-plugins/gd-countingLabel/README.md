# CountingLabel

`CountingLabel.tscn` содержит Label, который плавно меняет отображаемое число.

Добавьте сцену в UI и задайте свойство `Value`. Текущее отображаемое значение доступно через `CurrentValue`, длительность перехода задается `AnimationTime`.

```csharp
var score = GetNode<CountingLabel>("Score");
score.AnimationTime = 0.4f;
score.Value = 125;
```

Компонент использует Tween/SceneTreeTween и может обновляться в редакторе благодаря `[Tool]`.