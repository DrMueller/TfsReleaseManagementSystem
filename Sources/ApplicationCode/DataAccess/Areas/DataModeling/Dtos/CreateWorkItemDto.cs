using System.Collections.Generic;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Dtos
{
    public class CreateWorkItemDto
    {
        public List<WorkItemFieldDto> Fields { get; set; }
        public List<WorkItemRelationDto> Relations { get; set; }
        public string WorkItemTypeName { get; set; }
    }
}