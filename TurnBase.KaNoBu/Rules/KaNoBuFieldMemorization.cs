using System;
using System.Collections.Generic;

namespace TurnBase.KaNoBu
{
    public class KaNoBuFieldMemorization
    {
        public static readonly Dictionary<KaNoBuFigure.FigureTypes, KaNoBuFigure.FigureTypes> Winner = new Dictionary<KaNoBuFigure.FigureTypes, KaNoBuFigure.FigureTypes>
        {
            {KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipScissors},
            {KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipStone},
            {KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipPaper},
        };

        public static readonly Dictionary<KaNoBuFigure.FigureTypes, KaNoBuFigure.FigureTypes> Looser = new Dictionary<KaNoBuFigure.FigureTypes, KaNoBuFigure.FigureTypes>
        {
            {KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipStone},
            {KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipPaper},
            {KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipScissors},
        };
        
        public Field2D Field;

        public void Clear()
        {
            Field = null;
        }

        public void SynchronizeField(Field2D model)
        {
            if (Field == null)
            {
                Field = (Field2D)model.copyForPlayer(-1);
            }
            else
            {
                for (var x = 0; x < model.Width; x++)
                {
                    for (var y = 0; y < model.Height; y++)
                    {
                        var requestShip = model[x, y] as KaNoBuFigure;
                        var memorizedShip = Field[x, y] as KaNoBuFigure;

                        if (requestShip != null && memorizedShip == null || memorizedShip != null && requestShip == null)
                        {
                            throw new Exception("Inconsistent field state");
                        }

                        if (requestShip == null && memorizedShip == null)
                        {
                            continue;
                        }

                        memorizedShip.PlayerId = requestShip.PlayerId;
                        if (requestShip.FigureType != KaNoBuFigure.FigureTypes.Unknown)
                        {
                            memorizedShip = memorizedShip.WithFigureType(requestShip.FigureType);
                        }

                        Field[x, y] = memorizedShip;
                    }
                }
            }
        }

        public void UpdateKnownShips(KaNoBuMoveNotificationModel moveNotification)
        {
            if (this.Field == null || moveNotification.MoveNotifications.Count == 0)
            {
                return;
            }

            foreach (var notification in moveNotification.MoveNotifications)
            {
                var fromMapPos = notification.From;
                var toMapPos = notification.To;

                var movedUnit = this.Field[fromMapPos] as KaNoBuFigure;
                var defenderUnit = this.Field[toMapPos] as KaNoBuFigure;

                this.Field[fromMapPos] = null;
                this.Field[toMapPos] = null;

                if (notification.Battle.HasValue)
                {
                    switch (notification.Battle.Value.battleResult)
                    {
                        case KaNoBuMoveNotificationModel.BattleResult.Draw:
                        {
                            var movedType = movedUnit.FigureType;
                            var defenderType = defenderUnit.FigureType;
                            if (movedType != KaNoBuFigure.FigureTypes.Unknown)
                            {
                                defenderUnit = defenderUnit.WithFigureType(movedType);
                            }
                            if (defenderType != KaNoBuFigure.FigureTypes.Unknown)
                            {
                                movedUnit = movedUnit.WithFigureType(defenderType);
                            }
                            this.Field[fromMapPos] = movedUnit;
                            this.Field[toMapPos] = defenderUnit;
                            break;
                        }
                        case KaNoBuMoveNotificationModel.BattleResult.BothDestroyed:
                            break;
                        case KaNoBuMoveNotificationModel.BattleResult.AttackerWon:
                        {
                            if (movedUnit.FigureType == KaNoBuFigure.FigureTypes.ShipUniversal)
                            {
                                movedUnit = movedUnit.WithFigureType(KaNoBuFigure.FigureTypes.Unknown);
                            }
                            if (notification.Battle.Value.isDefenderFlag)
                            {
                                defenderUnit = defenderUnit.WithFigureType(KaNoBuFigure.FigureTypes.ShipFlag);
                            }
                            else
                            {
                                if (movedUnit.FigureType != KaNoBuFigure.FigureTypes.Unknown)
                                {
                                    defenderUnit = defenderUnit.WithFigureType(Looser[movedUnit.FigureType]);
                                }
                                if (defenderUnit.FigureType != KaNoBuFigure.FigureTypes.Unknown)
                                {
                                    movedUnit = movedUnit.WithFigureType(Winner[defenderUnit.FigureType]);
                                }
                            }
                            this.Field[toMapPos] = movedUnit;
                            break;
                        }
                        case KaNoBuMoveNotificationModel.BattleResult.DefenderWon:
                        {
                            if (defenderUnit.FigureType == KaNoBuFigure.FigureTypes.ShipUniversal)
                            {
                                defenderUnit = defenderUnit.WithFigureType(KaNoBuFigure.FigureTypes.Unknown);
                            }

                            if (movedUnit.FigureType != KaNoBuFigure.FigureTypes.Unknown)
                            {
                                defenderUnit = defenderUnit.WithFigureType(Winner[movedUnit.FigureType]);
                            }
                            if (defenderUnit.FigureType != KaNoBuFigure.FigureTypes.Unknown)
                            {
                                movedUnit = movedUnit.WithFigureType(Looser[defenderUnit.FigureType]);
                            }

                            this.Field[toMapPos] = defenderUnit;
                            break;
                        }
                    }
                }
                else
                {
                    this.Field[toMapPos] = movedUnit;
                }
            }
        }
    }
}