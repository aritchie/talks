namespace Sample
{
    public static class Constants
    {
        // THIS IS A TRADITIONAL APPROACH

#if CI
        public const string ApiKey = "$(ParseToken)";
        public const string BaseUri = "$(BaseUri)";
#else
        public const string ApiKey = "MyTestKey";
        public const string BaseUri = "http://localhost";
#endif
    }
}
