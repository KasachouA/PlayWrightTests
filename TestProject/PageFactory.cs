using CoreTestProject.Exceptions;
using CoreTestProject.Pages;
using Microsoft.Playwright;

namespace CoreTestProject
{
    public class PageFactory
    {
        private IPage _page;

        public PageFactory(IPage page)
        {
            _page = page;
        }

        public T CreatePage<T>() where T : BasePage
        {
            var pageInstance = Activator.CreateInstance(typeof(T), _page);

            if (pageInstance is null)
            {
                throw new PageFactoryException(typeof(T));
            }

            return pageInstance as T;
        }
    }
}
