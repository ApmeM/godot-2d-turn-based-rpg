using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBase.KaNoBu
{
    public class KaNoBuInitModel
    {
        public KaNoBuInitModel(int width, int height, List<KaNoBuFigure.FigureTypes> availableFigures)
        {
            Width = width;
            Height = height;
            AvailableFigures = availableFigures;
        }

        public readonly List<KaNoBuFigure.FigureTypes> AvailableFigures;
        public readonly int Width;
        public readonly int Height;
    }

    public class KaNoBuInitResponseModel
    {
        public KaNoBuInitResponseModel(IField field)
        {
            Field = field;
        }

        public readonly IField Field;
    }

    public class KaNoBuMoveModel
    {
        public KaNoBuMoveModel(IField field)
        {
            Field = field;
        }

        public readonly IField Field;
    }

    public class KaNoBuMoveResponseModel
    {
        public struct MoveStep
        {
            public MoveStep(Point from, Point to)
            {
                From = from;
                To = to;
            }

            public readonly Point From;
            public readonly Point To;
        }

        public KaNoBuMoveResponseModel(List<MoveStep> moves)
        {
            Moves = moves ?? new List<MoveStep>();
        }

        public readonly List<MoveStep> Moves;
    }

    public class KaNoBuMoveNotificationModel
    {
        public class MoveNotification
        {
            public MoveNotification(Point from, Point to, Battle? battle = null)
            {
                From = from;
                To = to;
                Battle = battle;
            }

            public readonly Point From;
            public readonly Point To;
            public readonly Battle? Battle;
        }

        public struct Battle
        {
            public BattleResult battleResult;
            public bool isDefenderFlag;
            public bool isMine;
        }

        public enum BattleResult
        {
            Draw,
            AttackerWon,
            DefenderWon
        }

        public KaNoBuMoveNotificationModel(List<MoveNotification> moveNotifications)
        {
            this.MoveNotifications = moveNotifications ?? new List<MoveNotification>();
        }

        public readonly List<MoveNotification> MoveNotifications;

        public override string ToString()
        {
            if (this.MoveNotifications.Count == 0)
            {
                return "Player skip turn.";
            }
            StringBuilder result = new StringBuilder();

            foreach (var move in this.MoveNotifications)
            {
                result.AppendLine($"Player move from {move.From} to {move.To}.");
                if (move.Battle.HasValue)
                {
                    result.AppendLine($"Battle result: {move.Battle.Value.battleResult} (IsFlag = {move.Battle.Value.isDefenderFlag})");
                }
            }

            return result.ToString();
        }
    }
}