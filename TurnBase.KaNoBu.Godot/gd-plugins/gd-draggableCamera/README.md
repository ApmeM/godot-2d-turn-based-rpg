# DraggableCamera

Камера для перемещения перетаскиванием, масштабирования колесом мыши или touch-жестом и ограничения области просмотра.

Добавьте `DraggableCamera.tscn` в игровую сцену и сделайте Camera2D текущей. Основные настройки: `enabled`, `MinimumZoom`, `MaximumZoom`, `NormalizedZoom` и `IsDebugMode`.

Для ограничения камеры по TileMap вызовите `SetCameraLimits(tileMap, extraSize)`. Камера рассчитывает границы на основе размера карты и viewport.