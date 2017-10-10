using System;
using System.Collections.Generic;
using System.Reflection;
using MovHubDb.Model;

namespace HtmlReflect
{
    public class Htmlect
    {
        private string singleObjPredicate = "\t<li class='list-group-item'><strong>";

        private Dictionary<object,string> cache = new Dictionary<object, string>();

        public string ToHtml(object obj)
        {

            if (cache.ContainsKey(obj))
            {
                return cache[obj];
            }
            string r = "<ul class='list-group'>\n";
            PropertyInfo[] val = obj.GetType().GetProperties();
            foreach (var property in val)
            {
                if(property.GetCustomAttribute<HtmlIgnoreAttribute>()!=null)
                    continue;
                var c = property.GetCustomAttribute<HtmlAsAttribute>();
                if (c != null)
                {
                    r += c.Val.Replace("{name}",property.Name.Replace("_",String.Empty)).Replace("{value}",property.GetValue(obj)?.ToString())+"\n";
                    continue;
                }

               
                r += singleObjPredicate + property.Name.Replace("_",String.Empty)+"</strong>:&nbsp" + property.GetValue(obj) + "</li>\n";
                
                
            }
            cache.Add(obj,r+"</ul>");
            return r+"</ul>";
        }

        public string ToHtml(object[] arr)
        {
            if (cache.ContainsKey(arr)) return cache[arr];
            string r = "<table class='table table-hover'>\n\t<thead>\n\t\t<tr>";
            PropertyInfo[] A = arr[0].GetType().GetProperties();
            foreach (var info in A)
            {
                if (info.GetCustomAttribute<HtmlIgnoreAttribute>() == null)
                r += "<th>" + info.Name.Replace("_", String.Empty) + "</th>";
                
            }
            r += "</tr>\n\t</thead>\n\t<tbody>\n";
            foreach (var o in arr)
            {
                r += "\t\t<tr>";
                foreach (var info in A)
                {
                    if (info.GetCustomAttribute<HtmlIgnoreAttribute>() != null)
                    {
                        continue;
                    }
                    var c = info.GetCustomAttribute<HtmlAsAttribute>();
                    if (c != null)
                    {
                        r += c.Val
                            .Replace("{name}", info.Name.Replace("_", String.Empty))
                            .Replace("{value}", info.GetValue(o).ToString());
                        continue;
                    }
                    r += "<td>"+ info.GetValue(o)+"</td>";
                }
                r += "</tr>\n";
            }
            cache.Add(arr, r + "\t</tbody>\n</table>");
            return r+"\t</tbody>\n</table>";
        }
    }
}
