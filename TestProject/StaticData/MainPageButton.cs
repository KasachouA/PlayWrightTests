using System.Reflection;

namespace CoreTestProject.StaticData
{
    public class MainPageButton
    {
        public string Name { get; init; }

        private MainPageButton(string name) => Name = name;

        public static MainPageButton JavaScriptDelay = new MainPageButton("JavaScript Delays");
        public static MainPageButton FormFields = new MainPageButton("Form Fields");
        public static MainPageButton Popups = new MainPageButton("Popups");
        public static MainPageButton Sliders = new MainPageButton("Sliders");
        public static MainPageButton Calendars = new MainPageButton("Calendars");
        public static MainPageButton Modals = new MainPageButton("Modals");
        public static MainPageButton Tables = new MainPageButton("Tables");
        public static MainPageButton WindowOperations = new MainPageButton("Window Operations");
        public static MainPageButton Hover = new MainPageButton("Hover");
        public static MainPageButton Ads = new MainPageButton("Ads");
        public static MainPageButton Gestures = new MainPageButton("Gestures");
        public static MainPageButton FileDownload = new MainPageButton("File Download");
        public static MainPageButton ClickEvents = new MainPageButton("Click Events");
        public static MainPageButton Spinners = new MainPageButton("Spinners");
        public static MainPageButton FileUpload = new MainPageButton("File Upload");
        public static MainPageButton Iframes = new MainPageButton("Iframes");
        public static MainPageButton BrokenImages = new MainPageButton("Broken Images");
        public static MainPageButton BrokenLinks = new MainPageButton("Broken Links");
        public static MainPageButton Accordions = new MainPageButton("Accordions");
    }
}
