namespace TurnBase.KaNoBu
{
    public class KaNoBuMoveModel
    {
        public KaNoBuMoveModel(IField field)
        {
            Field = field;
        }

        public readonly IField Field;
    }
}