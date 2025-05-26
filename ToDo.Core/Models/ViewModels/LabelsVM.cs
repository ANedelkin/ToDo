using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models
{
    public class LabelsVM
    {
        public string ProjectName { get; }
        public List<ListedLabel> Labels { get; }
        public LabelsVM(string projectName, List<ListedLabel> labels)
        {
            ProjectName = projectName;
            Labels = labels;
        }
    }
}
