using System.Collections.Generic;

namespace TurnBase.KaNoBu
{
    public class KaNoBuInitModel
    {
        public KaNoBuInitModel(int width, int height, List<KaNoBuFigure.FigureTypes> availableFigures, int maxMovesPerTurn)
        {
            Width = width;
            Height = height;
            AvailableFigures = availableFigures;
            MaxMovesPerTurn = maxMovesPerTurn;
        }

        public readonly List<KaNoBuFigure.FigureTypes> AvailableFigures;
        public readonly int Width;
        public readonly int Height;
        public readonly int MaxMovesPerTurn;
    }
}