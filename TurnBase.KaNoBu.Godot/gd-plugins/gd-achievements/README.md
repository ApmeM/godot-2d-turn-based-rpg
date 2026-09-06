# Achievements

Система достижений с локальным хранением прогресса и необязательной синхронизацией с Google Play Games Services.

## Состав

- `AchievementList.tscn` отображает список достижений. После добавления в UI вызовите `ReloadList()`.
- `AchievementNotifications.tscn` показывает всплывающие уведомления. Используйте `ProgressAchievement(id, value)` и `UnlockAchievement(id)`.
- `AchievementNotification.tscn` является шаблоном одной карточки и обычно создается менеджером автоматически.
- `IAchievementRepository`, `LocalAchievementRepository` и `Achievement` задают хранилище и модель данных.

По умолчанию локальный репозиторий хранит данные в `user://achievements.json`. Для Android передайте путь к узлу `GodotPlayGameService` в `AchievementList.GodotPlayGameServicePath`. Иконки и звук находятся в `resources`.

```csharp
var notifications = GetNode<AchievementNotifications>("AchievementNotifications");
notifications.ProgressAchievement("first_battle", 1);
notifications.UnlockAchievement("first_battle");
```

Требуются Newtonsoft.Json и `gd-utils`. Android-режим требует отдельной настройки Google Play plugin.