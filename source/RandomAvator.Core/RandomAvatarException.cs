using System;

namespace RandomAvator
{
    //http://stackoverflow.com/questions/27917258/system-drawing-namespace-missing-in-aspnetvnext-core-clr/27964081#27964081
    //http://stackoverflow.com/questions/28427607/which-package-do-i-need-for-images-in-asp-net-5/28427930#28427930
    public class RandomAvatarException : Exception
    {
        public RandomAvatarException(Exception ex) : base("", ex)
        {

        }

        public RandomAvatarException(string message) : base(message)
        {

        }
    }
}
