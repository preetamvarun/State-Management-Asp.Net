using System.Web.Optimization;

namespace StateManagement
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* Create a style bundle */
            StyleBundle styleBundle = new StyleBundle("~/Content/StyleBundle");
            styleBundle.Include("~/Minify/style1.min.css", "~/Minify/style2.min.css");
            bundles.Add(styleBundle);
            BundleTable.EnableOptimizations = true;

            //Create a ScriptBundle and include all the Scripts files into it (Example Code)
            //ScriptBundle scriptBundle = new ScriptBundle("~/Scripts/NITScriptBundle");
            //scriptBundle.Include("~/Scripts/Test1.min.js", "~/Scripts/Test2.min.js");
            //bundles.Add(scriptBundle); //Example Code
        }
    }
}