using System;

namespace MovHubDb.Model
{
    public class HtmlIgnoreAttribute:Attribute
    {
        
    }

    public class HtmlAsAttribute : Attribute
    {
        public HtmlAsAttribute(string val)
        {
            this.Val = val;
        }
        public string Val { get; private set; }
    }
}