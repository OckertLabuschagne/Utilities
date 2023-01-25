using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDServiceWizard.Project
{
    public class CRUDServiceProject
    {
        public string ProjectName { get; set; }
        public string ConnectionString { get; set; }
        public string CoreModelProjectName { get; set; }
        public string CoreModelProjectFolder { get; set; }
        public string ServicesProjectName { get; set; }
        public string ServicesProjectFolder { get; set; }
        public string MappingProjectName { get; set; }
        public string MappingProjectFolder { get; set; }
        public string UnitTestProjectName { get; set; }
        public string UnitTestProjectFolder { get; set; }
        public string IntegrationTestProjectName { get; set; }
        public string IntegrationTestProjectFolder { get; set; }
    }
}
