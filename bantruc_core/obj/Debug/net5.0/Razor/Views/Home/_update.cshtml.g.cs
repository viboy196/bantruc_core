#pragma checksum "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "547d0eb358725c10affe31e9e08b8f28ad1a1f24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__update), @"mvc.1.0.view", @"/Views/Home/_update.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"547d0eb358725c10affe31e9e08b8f28ad1a1f24", @"/Views/Home/_update.cshtml")]
    public class Views_Home__update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<bantruc_core.Demos.TinHieuTruc>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
  

    var stt = ViewBag.stt != null ? (string)ViewBag.stt:"";
    var tinhieutruc = stt!= ""?bantruc_core.Services.BantrucService._BantrucService.GetTinHieuTruc(stt):Model;
    var idten = "ten_" + tinhieutruc.Id;
    string giuon_phong = tinhieutruc.TenPhongBenh + " " + tinhieutruc.tengiuongbenh;
    var localtion = tinhieutruc.mathietbi == "800" ? "global" : "local";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-sm-3\">\r\n        <a>");
#nullable restore
#line 12 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
      Write(tinhieutruc.tenNhomtruc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> <br />\r\n        <a");
            BeginWriteAttribute("id", " id=\"", 528, "\"", 539, 1);
#nullable restore
#line 13 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 533, idten, 533, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
                  Write(tinhieutruc.tenBenhnhan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> <br />\r\n        <a>");
#nullable restore
#line 14 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
      Write(giuon_phong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        ");
#nullable restore
#line 15 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
   Write(DateTime.Now);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n    <div class=\"col-sm-6\"");
            BeginWriteAttribute("id", " id=\"", 669, "\"", 698, 2);
            WriteAttributeValue("", 674, "col_info_", 674, 9, true);
#nullable restore
#line 18 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 683, tinhieutruc.Id, 683, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 19 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
         foreach (var tt in tinhieutruc.infoadd)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a>");
#nullable restore
#line 21 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
          Write(tt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a><br />\r\n");
#nullable restore
#line 22 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"col-sm-3 text-right\">\r\n        <button class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 899, "\"", 971, 8);
            WriteAttributeValue("", 909, "Call(\'", 909, 6, true);
#nullable restore
#line 25 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 915, tinhieutruc.mathietbi, 915, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 937, "\',", 937, 2, true);
            WriteAttributeValue(" ", 939, "\'", 940, 2, true);
#nullable restore
#line 25 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 941, tinhieutruc.Id, 941, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 956, "\',\'", 956, 3, true);
#nullable restore
#line 25 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 959, localtion, 959, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 969, "\')", 969, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Gọi lại</button>\r\n        <button class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1035, "\"", 1070, 3);
            WriteAttributeValue("", 1045, "Chuyen(\'", 1045, 8, true);
#nullable restore
#line 26 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 1053, tinhieutruc.Id, 1053, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1068, "\')", 1068, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Chuyển</button>\r\n        <button class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1133, "\"", 1170, 3);
            WriteAttributeValue("", 1143, "sendmess(\'", 1143, 10, true);
#nullable restore
#line 27 "C:\Users\viboy\OneDrive\Máy tính\bantruc_core\bantruc_core\Views\Home\_update.cshtml"
WriteAttributeValue("", 1153, tinhieutruc.Id, 1153, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1168, "\')", 1168, 2, true);
            EndWriteAttribute();
            WriteLiteral(">chú thích</button>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<bantruc_core.Demos.TinHieuTruc> Html { get; private set; }
    }
}
#pragma warning restore 1591