namespace CoreTestProject.Exceptions
{
    public class PageFactoryException : Exception
    {
        public PageFactoryException(Type pageType) : this(pageType, null) { }
        public PageFactoryException(Type pageType, Exception inner) : base($"Failed to initialise {pageType} page", inner) { }
    }
}
