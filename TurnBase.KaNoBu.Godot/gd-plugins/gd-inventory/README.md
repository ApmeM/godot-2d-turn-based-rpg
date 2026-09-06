# Inventory

Набор компонентов для предметов, drag-and-drop слотов, обычного инвентаря, экипировки и окна сумки.

## Основные сцены

- `InventorySlot.tscn` — один слот с переносом предметов.
- `Inventory.tscn` — динамическая сетка слотов.
- `EquipmentInventory.tscn` — фиксированные слоты экипировки.
- `BagInventoryPopup.tscn` — готовое окно сумки, денег и экипировки.
- `BaseLoot.tscn` — базовая сцена предмета.

`Inventory` предоставляет `UpdateSlotsCount`, `TryChangeCount`, `GetItemCount`, `ClearItems` и `GetItems`. `InventorySlot` хранит `LootName`, `ItemsCount`, `LootDefinition` и `AcceptedTypes`. Для экипировки используйте `EquipmentInventory.ForceSetItems`, `GetItems` и `ClearItems`.

Сцены лута должны находиться в `res://Presentation/loots/{name}/{name}.tscn`; `LootDefinition.EnsureLoaded()` и `Instantiator` используют это соглашение. Для popup также нужны ресурсы из `gd-popups`, тема из `gd-theme` и корректно настроенные типы предметов.