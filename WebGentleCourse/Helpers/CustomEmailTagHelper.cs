using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebGentleCourse.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:nitish.webgentle@gmail.com");
            output.Content.SetContent("my-email");
        }
    }
}
                                                                                                                              