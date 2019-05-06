namespace CustomFramework.WebApiCodeGenerator
{
    public class Reference
    {
        public Reference(string fieldName, string fieldDataType, Relations relation, bool notNull, bool addToRequest, bool addToResponse
            , bool hasGetMethod, bool isUnique, string referenceClassName)
        {
            FieldName = fieldName;
            FieldDataType = fieldDataType;
            Relation = relation;
            NotNull = notNull;
            AddToRequest = addToRequest;
            AddToResponse = addToResponse;
            HasGetMethod = hasGetMethod;
            IsUnique = isUnique;
            ReferenceClassName = referenceClassName;
        }

        public string FieldName { get; }
        public string FieldDataType { get; }
        public Relations Relation { get; set; }
        public bool NotNull { get; }
        public bool AddToRequest { get; }
        public bool AddToResponse { get; }
        public bool HasGetMethod { get; }
        public bool IsUnique { get; }
        public string ReferenceClassName { get; set; }
    }
}