using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MDDocument
{
    public class MDService : ComponentBase
    {
        [Inject]
        NavigationManager navMgr { get; set; }

        [Parameter]
        public string DirectoryName { get; set; }
        [Parameter]
        public string FileName { get; set; }
        public string ConvertedHtml => Markdown.ToHtml(MarkDownText ?? "please input");
        public string MarkDownText { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            string path = Path.Combine(Environment.CurrentDirectory, "MdFiles", DirectoryName ?? string.Empty, FileName + ".md");
            this.MarkDownText = File.ReadAllText(path);

            //string decodeUri = HttpUtility.UrlDecode(navMgr.Uri).Replace(FileName, "");

            //url에서는 스페이스를 인식 못함 인식할 수 있는 인코딩 %20 으로 변환
            // string encodeUri = navMgr.BaseUri + "img/" +
            //                     DirectoryName.Replace(" ", "%20") + "/" +
            //                     FileName.Replace(" ", "%20");

            // this.MarkDownText = this.MarkDownText.Replace("![](img", "![](" + encodeUri);

            this.MarkDownText = this.MarkDownText.Replace("/wwwroot/", "/");

            StateHasChanged();
        }
    }
}
