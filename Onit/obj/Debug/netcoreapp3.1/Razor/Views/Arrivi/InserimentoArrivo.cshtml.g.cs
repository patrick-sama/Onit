#pragma checksum "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c44c53ea8f84a4d70788e68c3be2cd9a5375fb1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Arrivi_InserimentoArrivo), @"mvc.1.0.view", @"/Views/Arrivi/InserimentoArrivo.cshtml")]
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
#nullable restore
#line 1 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\_ViewImports.cshtml"
using Onit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\_ViewImports.cshtml"
using Onit.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c44c53ea8f84a4d70788e68c3be2cd9a5375fb1", @"/Views/Arrivi/InserimentoArrivo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17f3ba162f2add85a33b3cd71e4be8737a7000ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Arrivi_InserimentoArrivo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Onit.Models.Arrivi>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Area"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Area", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ComponenteCodice"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ComponenteCodice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("NuovoArrivoForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("ArriviForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n<div class=\"panel panel-default\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c44c53ea8f84a4d70788e68c3be2cd9a5375fb16610", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 8 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <div class=""panel-heading"">
        <div class=""row"">
            <h2 class=""panel-title pull-left"" style=""margin-left:10px;"">
                <strong>Detaglio Arrivi</strong>
            </h2>
            <button style=""margin-right:10px"" class=""btn btn-primary pull-right"" onclick=""AperturaModal()"">Nuovo arrivo</button>
        </div>
    </div>

");
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
     if (Model.Count() != 0)
    {
        foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"panel-body\">\r\n                <table class=\"table table-striped table-responsive\">\r\n                    <tbody>\r\n                        <tr>\r\n                            <td><b>Data arrivo :</b> ");
#nullable restore
#line 28 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                                Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td><b>Codice identificativo :</b> ");
#nullable restore
#line 29 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                                          Write(item.Identificativo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td> <b> Descrizione :</b> ");
#nullable restore
#line 32 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                                  Write(item.Descrizione);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td> <b> Matricola carello :</b> ");
#nullable restore
#line 33 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                                        Write(item.Carello.Matricola);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        </tr>

                        <tr>
                            <td colspan=""3"">
                                <table class=""table table-bordered"">
                                    <tbody>
                                        <tr>
                                            <th>Componente</th>
                                            <th>Quantity</th>
                                        </tr>
");
#nullable restore
#line 44 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                         foreach (var order in item.Carello.ComponentiDelCarello)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 47 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                               Write(order.Componente.Codice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 48 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
                                               Write(order.Qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 50 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <br />
                    </tbody>
                </table>
            </div>
");
#nullable restore
#line 60 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
        }
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"panel-body\">\r\n            <h3 style=\"color:red;\">vuoto!</h3>\r\n        </div>\r\n");
#nullable restore
#line 67 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""nuovoArrivoModal"">
    <div class=""modal-dialog modal-lg"" style="" width: 900px !important;"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4>Aggiungere arrivo</h4>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c44c53ea8f84a4d70788e68c3be2cd9a5375fb113728", async() => {
                WriteLiteral("\r\n                <div class=\"modal-body\">\r\n");
                WriteLiteral(@"                    <h5 style=""color:#ff6347"">Detagli Arrivo</h5>
                    <hr />
                    <div class=""form-horizontal"">
                        <input type=""hidden"" id=""CarelloId"" />
                        <div class=""form-group"">
                            <label class=""control-label col-md-4"">
                                Identificativo arrivo
                            </label>
                            <div class=""col-md-4"">
                                <input type=""text"" id=""Identificativo"" name=""Identificativo"" placeholder=""Identificativo arrivo"" class=""form-control"" required />
                            </div><br />
                            <label class=""control-label col-md-4"">
                                Matricola Carello
                            </label>
                            <div class=""col-md-4"">
                                <input type=""text"" id=""Matricola"" name=""Matricola"" placeholder=""Matricola Carello"" class=""form-control"" r");
                WriteLiteral(@"equired />
                            </div><br />
                            <label class=""control-label col-md-4"">
                                Descrizione arrivo
                            </label>
                            <div class=""col-md-8"">
                                <input type=""text"" id=""Descrizione"" name=""Descrizione"" placeholder=""Descrizione arrivo"" class=""form-control"" required />
                            </div> <br />
                            <div class=""col-md-4"">
                                <label class=""control-label col-md-2""> Area </label>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c44c53ea8f84a4d70788e68c3be2cd9a5375fb115816", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 108 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.AreaId;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div> <br />
                            <label class=""control-label col-md-4"">
                                Codice Locazione
                            </label>
                            <div class=""col-md-4"">
                                <input type=""text"" id=""Locazione"" name=""Locazione"" placeholder=""Codice Locazione"" class=""form-control"" required />
                            </div>
                        </div>
                    </div>

");
                WriteLiteral(@"                    <h5 style=""margin-top:10px;color:#ff6347"">Detagli Carello</h5>
                    <hr />
                    <div class=""form-horizontal"">
                        <input type=""hidden"" id=""ComponenteId"" />
                        <div class=""form-group"">
                            <label class=""control-label col-md-4"">
                                Codice Componente
                            </label>
                            <div class=""col-md-4"">
                                <div class=""form-group"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c44c53ea8f84a4d70788e68c3be2cd9a5375fb119122", async() => {
                    WriteLiteral("\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 130 "C:\Users\user\Documents\Visual Studio 2019\Project\Onit\Onit\Views\Arrivi\InserimentoArrivo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.ComponenteId;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class=""form-group"">
                            <label class=""control-label col-md-2"">
                                Quantity
                            </label>
                            <div class=""col-md-4"">
                                <input type=""number"" id=""quantity"" name=""quantity"" value=""1"" class=""form-control"" />
                            </div>
                            <div class=""col-md-2 col-lg-offset-4"">
                                <a id=""addToList"" class=""btn btn-primary"">Add To List</a>
                            </div>
                        </div>

                        <table id=""detailsTable"" class=""table"">
                            <thead>
                                <tr>
                                    <th style=""width:45%"">Componente</th>
                                  ");
                WriteLiteral(@"  <th style=""width:30%"">Quantity</th>
                                    <th style=""width:10%""></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""reset"" class=""btn btn-default"" data-dismiss=""modal"">Chiudi</button>
                    <button id=""SubmitArrivo"" type=""submit"" class=""btn btn-danger"" >Submit</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Onit.Models.Arrivi>> Html { get; private set; }
    }
}
#pragma warning restore 1591
