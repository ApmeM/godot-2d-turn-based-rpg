# HighlitePointer

Полноэкранная подсказка для обучения: затемняет экран, оставляет прозрачное круглое отверстие и ждет нажатия внутри него.

Добавьте `HighlitePointer.tscn` в UI и дождитесь завершения `Show(position, radius)`:

```csharp
await GetNode<HighlitePointer>("HighlitePointer").Show(targetPosition, 48f);
```

Новый вызов отменяет предыдущий показ. Сцена использует ShaderMaterial и `finger.png`; передавайте координаты в системе viewport.