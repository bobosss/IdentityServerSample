using System;
using System.Collections.Generic;

namespace Auditor.Bussness.Models
{
    public class AuditorInformationViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public IList<string> Information { get; set; } = new List<string>();
        public IDictionary<string, string> Links { get; set; } = new Dictionary<string, string>();
    }
}