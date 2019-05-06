namespace CustomFramework.WebApiCodeGenerator
{
    public class Field
    {
        public Field(string fieldName, string fieldDataType, string fieldDataLength, bool notNull, bool addToRequest, bool addToResponse
            , bool hasGetMethod, bool isUnique)
        {
            FieldName = fieldName;
            FieldDataType = fieldDataType;
            FieldDataLength = fieldDataLength;
            NotNull = notNull;
            AddToRequest = addToRequest;
            AddToResponse = addToResponse;
            HasGetMethod = hasGetMethod;
            IsUnique = isUnique;
        }

        public string FieldName { get; }
        public string FieldDataType { get; }
        public string FieldDataLength { get; }
        public bool NotNull { get; }
        public bool AddToRequest { get; }
        public bool AddToResponse { get; }
        public bool HasGetMethod { get; }
        public bool IsUnique { get; }
    }
}