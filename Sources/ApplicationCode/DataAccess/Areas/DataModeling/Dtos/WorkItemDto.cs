using System.Collections.Generic;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Dtos
{
    public class WorkItemDto
    {
        public List<WorkItemFieldDto> Fields { get; set; }
        public int Id { get; set; }
        public List<WorkItemRelationDto> Relations { get; set; }
        public long Revision { get; set; }
        public string Url { get; set; }
    }
}