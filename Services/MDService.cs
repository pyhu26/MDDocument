using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MDDocument
{
    public class MDService : ComponentBase
    {
        [Parameter]
        public string DirectoryName { get; set; }
        [Parameter]
        public string FileName { get; set; }
        public string ConvertedHtml => Markdown.ToHtml(MarkDownText ?? "please input");
        public string MarkDownText { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            string path = Path.Combine(Environment.CurrentDirectory, "MdFiles", DirectoryName ?? string.Empty,  FileName + ".md");
            this.MarkDownText = File.ReadAllText(path);
            

            StateHasChanged();
        }
    }
}
