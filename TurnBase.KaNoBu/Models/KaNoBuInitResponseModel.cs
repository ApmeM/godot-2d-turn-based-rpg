namespace TurnBase.KaNoBu
{
    public class KaNoBuInitResponseModel
    {
        public KaNoBuInitResponseModel(IField field)
        {
            Field = field;
        }

        public readonly IField Field;
    }
}